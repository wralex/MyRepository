/*
 * User: alexanw
 * Date: 11/12/2013
 * Time: 2:43 PM
 */
using CommonWin32.API;
using CommonWin32.Rectangles;
using CommonWin32.Windows;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.WinFroms;

namespace ASInsScan
{
	public partial class ScanCard : Form
	{
        /// <summary>
        /// ShowWindow is a COM Object call to control the Window indicated by the pointer wWnd and what command it's to complete
        /// </summary>
        /// <param name="wWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr wWnd, int nCmdShow);

        /// <summary>
        /// OasTabName is the Citrix or IE 8 window that is to be used to get the screen scraping of the MRN #
        /// </summary>
        private const String OasTabName = @"OAS/Gold Client";

        /// <summary>
        /// log is an internal object that is used to write to the application folder for any errors encountered
        /// </summary>
		private static readonly ILog log;

        /// <summary>
        /// ScannerSettings is a property to set the image and scanner attributes stored in the application Config file
        /// </summary>
        /// <returns>ScannerSettings</returns>
        private static ScannerSettings ScannerSettings
        {
            get { return scannerSettings; }
            set { scannerSettings = value; }
        }
        private static ScannerSettings scannerSettings;

        /// <summary>
        /// TwainScanSettings is a property to set the TWAIN API settings for the attached scanner
        /// </summary>
        /// <returns>ScanSettings</returns>
        private static ScanSettings TwainScanSettings
        {
            get { return twainScanSettings; }
            set { twainScanSettings = value; }
        }
        private static ScanSettings twainScanSettings;

        /// <summary>
        /// FileSettings is a property, from the application's Config file, to set the path and file naming attributes for use in the IEX Scanning service
        /// </summary>
        /// <returns>FileSaveSettings</returns>
        private static FileSaveSettings FileSettings {
            get { return fileSettings; }
            set { fileSettings = value; }
        }
        private static FileSaveSettings fileSettings;

        /// <summary>
        /// ExePath includes the actual EXE along with the full path, it's set to be a FileInfo Object then get that FileInfo's Directory Name
        /// </summary>
        /// <returns>String</returns>
        private static String ExePath { get { return new FileInfo(Application.ExecutablePath).DirectoryName; } }

        /// <summary>
        /// Mainscreen returns the first screen of the user's desktop environment if multiple monitors currently running
        /// </summary>
        /// <returns>Screen</returns>
        private static Screen MainScreen
        {
            get
            {
                foreach (var screen in Screen.AllScreens)
                {
                    if (screen.Bounds.X == 0)
                        return screen;
                }
                return null;
            }
		}

        /// <summary>
        /// The GetPathOfJavaExe is a method that will return the full path of the first instance that is found on the workstation where java.exe is located.
        /// <para>Normal installation paths are the "Program Files" or "Program Files (x86)" of the user's workstation.</para>
        /// </summary>
        /// <param name="diRootProgramFiles"></param>
        /// <returns>String</returns>
        private static String GetPathOfJavaExe(DirectoryInfo diRootProgramFiles)
        {
            // Get any Sub-Folder that have the name 'Java' in the root of a directory passed as parameter (ie. "C:\Program Files")
            foreach (DirectoryInfo diJava in diRootProgramFiles.GetDirectories().Where(d => d.Name.ToLower().Equals("java")))
            {
                // Get all Sub-Folders, also known as JREs, under the found Java folder
                foreach (DirectoryInfo diJre in diJava.GetDirectories())
                {
                    // Find a 'bin' directory under the JRE folder
                    foreach (DirectoryInfo diBin in diJre.GetDirectories().Where(d => d.Name.ToLower().Equals("bin")))
                    {
                        // Find a 'java.exe' file contained in the bin folder of the JRE
                        foreach (FileInfo fiJavaEx in diBin.GetFiles().Where(f => f.Name.ToLower().Equals("java.exe")))
                        {
                            // If 'java.exe' if found send the DirecotyrInfo of the JRE Path back to the requesting call
                            return diJre.FullName;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// JavaHomePath is a Property that will get the user's full path of a java.exe file for use in the Sikuli Script Screen Scraping.
        /// </summary>
        /// <returns>String</returns>
        private static String JavaHomePath
        {
            get
            {
                DirectoryInfo diProgramFiles =
                    new DirectoryInfo(
                        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));

                DirectoryInfo diAltProgramFiles =
                    new DirectoryInfo(
                        Path.Combine(diProgramFiles.Root.FullName, "Program Files (x86)"));

                String result = GetPathOfJavaExe(diProgramFiles);

                if (result == null)
                {
                    try { result = GetPathOfJavaExe(diAltProgramFiles); }
                    catch { }
                }

                return result;
            }
        }

        /// <summary>
        /// ScanCard Static Constructor that reads from the application config file and stores the information into the properties of the application
        /// </summary>
		static ScanCard()
        {
			log = LogManager.GetLogger(typeof(ScanCard));

            // Get information from Application Config File
            FileSettings = (FileSaveSettings)ConfigurationManager.GetSection("fileSaveSettings");
            ScannerSettings = (ScannerSettings)ConfigurationManager.GetSection("scannerSettings");

            // Setup Scanner TWAIN values for use of this application
            TwainScanSettings = new ScanSettings()
            {
                UseDocumentFeeder = ScannerSettings.UseDocumentFeeder,
                ShowTwainUI = ScannerSettings.ShowTwainUI,
                ShowProgressIndicatorUI = ScannerSettings.ShowProgressIndicatorUI,
                UseDuplex = ScannerSettings.UseDuplex,
                ShouldTransferAllPages = ScannerSettings.ShouldTransferAllPages,
                Area = null,
                Resolution = new ResolutionSettings() {
                    ColourSetting = ScannerSettings.ResolutionSettings.ColourSetting,
                    Dpi = ScannerSettings.ResolutionSettings.Dpi },
                Rotation = new RotationSettings() {
                    AutomaticRotate = ScannerSettings.RotationSettings.AutomaticRotate,
                    AutomaticBorderDetection = ScannerSettings.RotationSettings.AutomaticBorderDetection }
            };
        }

        /// <summary>
        /// trayIcon is a instance of the application set on the user's desktop near the Date-Time to allow the user to right click and start new scanning or exiting the application.
        /// </summary>
        private NotifyIcon trayIcon;
        /// <summary>
        /// The menu options of the Notification Icon to have 'Scan New' and 'Exit' options
        /// </summary>
        private ContextMenu trayMenu;

		/// <summary>
		/// frontTwain stores the image of the front side of the insurance card scanned
		/// </summary>
		private Twain frontTwain;
        /// <summary>
        /// backTwain stores the image of the back side of the insurance card scanned
        /// </summary>
		private Twain backTwain;

        /// <summary>
        /// isScanBoth is a flag to show if the scanner needs to scan both sides of the card. By default it's set to true, but if the user selects to scan either the fron or back side only this will be set to false so that it doesn't have the scanner do both
        /// </summary>
		private Boolean isScanBoth = true;

        /// <summary>
        /// isFirstTime is set for the user to do an Initial or New Scan
        /// </summary>
		private Boolean isFirstTime = true;

        /// <summary>
        /// SaveImage get's the image along with the attributes for the saved file and returns as a Bitmap image to the caller
        /// </summary>
        /// <returns>Bitmap</returns>
		private Bitmap SaveImage
        {
			get
            {
				Bitmap img = ImageUtility.MergeImages(imgVwrFront.EditableImage, imgVwrBack.EditableImage);
				return ImageUtility.ResizeImage(img, new Size(FileSettings.ImageWidth, FileSettings.ImageHeight));
			}
		}

        /// <summary>
        /// txtMrn_KeyPress controls what character's are being placed into the MRN Textbox. It should only allow for Digit's and Control characters (Cntl-V, Cntrl-C, etc.)
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">KeyPressEventArgs</param>
        protected void txtMrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// ScanCard instance is the start of a new scan of an insurance card and allow for the front and back side of the insurance card scanned to be added to the Allscripts EHR
        /// </summary>
		public ScanCard()
		{
			InitializeComponent();

			Nullable<int> i = ScannerSettings.ResolutionSettings.BrightLevel;
			if (i.HasValue)
            {
				imgVwrFront.Brightness = i.Value;
				imgVwrBack.Brightness = i.Value;
			}

			frontTwain = new Twain(new WinFormsWindowMessageHook(this));
			frontTwain.TransferImage += new EventHandler<TransferImageEventArgs>(FrontTwainTransferImage);
			frontTwain.ScanningComplete += new EventHandler<ScanningCompleteEventArgs>(FrontTwain_ScanningComplete);

			backTwain = new Twain(new WinFormsWindowMessageHook(this));
			backTwain.TransferImage += new EventHandler<TransferImageEventArgs>(BackTwain_TransferImage);
			backTwain.ScanningComplete += new EventHandler<ScanningCompleteEventArgs>(BackTwain_ScanningComplete);

            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("New Scan", ReScanBothToolStripMenuItemClick);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Allscripts Insurance Card Scan";
            trayIcon.Icon = this.Icon;
            
            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
		}


        /// <summary>
        /// FrontTwainTransferImage is the delegate to send the front-side scanned image to the form control 'imgVwrFront'
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">TransferImageEventArgs</param>
		void FrontTwainTransferImage(Object sender, TransferImageEventArgs e)
        {
			if (e.Image != null)
				this.imgVwrFront.EditableImage = e.Image;
		}

        /// <summary>
        /// FrontTwain_ScanningComplete is the delegate to handle what happens after the front of the image is completed.
        /// <para>If this is a 'New' or 'Initial' Scan then it will proceed with doing the back side of the card.</para>
        /// <para>This will also start the timer of the application, if not already running, to remove all items from the screen if not sent to chart within 2 minutes of the first scan.</para>
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">ScanningCompleteEventArgs</param>
		void FrontTwain_ScanningComplete(Object sender, ScanningCompleteEventArgs e)
        {
			if (isScanBoth)
				backTwain.StartScanning(TwainScanSettings);
            if (!tmrToClear.Enabled)
                tmrToClear.Start();
        }

        /// <summary>
        /// BackTwain_TransferImage is the delegate to send the back-side scanned image to the form control 'imgVwrBack'
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">TransferImageEventArgs</param>
        void BackTwain_TransferImage(Object sender, TransferImageEventArgs e)
        {
			if (e.Image != null)
				this.imgVwrBack.EditableImage = e.Image;
		}

        /// <summary>
        /// BackTwain_ScanningComplete is the delegate to handle what happens after the back card scanner is completed.
        /// <para>If this is a 'New' or 'Initial' Scan then it will proceed with getting the MRN #.</para>
        /// <para>This will also start the timer of the application, if not already running, to remove all items from the screen if not sent to chart within 2 minutes of the first scan.</para>
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">ScanningCompleteEventArgs</param>
        void BackTwain_ScanningComplete(Object sender, ScanningCompleteEventArgs e)
        {
			if (isFirstTime)
            {
				BtnGetMrnClick(null, null);
				isFirstTime = false;
			}
            if (!tmrToClear.Enabled)
                tmrToClear.Start();
		}
		
        /// <summary>
        /// ScanCardLoad is a handler that starts the process of starting a new scan and setting the button control 'btnSend' to be the default of the form
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void ScanCardLoad(object sender, EventArgs e)
		{
			ReScanBothToolStripMenuItemClick(null, null);
            AcceptButton = btnSend;
        }

		/// <summary>
        /// PrintPreviewToolStripMenuItemClick is a handler to display to the user a Prinmt Preview of the scanned card
		/// </summary>
		/// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void PrintPreviewToolStripMenuItemClick(object sender, EventArgs e)
		{
            dlgPrintPreview.Document = new ImagePrintDocument(SaveImage);
            dlgPrintPreview.ShowDialog(this);
		}

		/// <summary>
        /// PrintToolStripMenuItemClick is a handler to print the scanned images to a printer
		/// </summary>
		/// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void PrintToolStripMenuItemClick(object sender, EventArgs e)
		{
            dlgPrint.Document = new ImagePrintDocument(SaveImage);
            if (dlgPrint.ShowDialog() == DialogResult.OK)
            	dlgPrint.Document.Print();
		}

		/// <summary>
        /// ExitToolStripMenuItem1Click is a handler to close this application
		/// </summary>
		/// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void ExitToolStripMenuItem1Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
        /// ReScanFrontToolStripMenuItemClick is a handler to scan just the front side of the insurance card when selected by the file menu option
		/// </summary>
		/// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void ReScanFrontToolStripMenuItemClick(object sender, EventArgs e)
		{
			isScanBoth = false;
			frontTwain.StartScanning(TwainScanSettings);
			this.Activate();
		}

        /// <summary>
        /// ReScanBackToolStripMenuItemClick is a handler to scan just the back side of the insurance card when selected by the file menu option
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        void ReScanBackToolStripMenuItemClick(object sender, EventArgs e)
		{
			isScanBoth = false;
			backTwain.StartScanning(TwainScanSettings);
			this.Activate();
		}

        /// <summary>
        /// ReScanBothToolStripMenuItemClick is a handler to scan both sides of the insurance card when selected by the file menu option
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        void ReScanBothToolStripMenuItemClick(object sender, EventArgs e)
        {
            BtnNewClick(null, null);
        }

        /// <summary>
        /// OnExit is used to close the application
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        } 

		/// <summary>
        /// CopyScriptFiles will copy the Sikuli script and supporting batch files to the user's temporary directory to be executed for screen scraping the MRN # of the Signature web page.
		/// </summary>
		/// <returns>String</returns>
        private String CopyScriptFiles()
        {
            String userPath = Path.GetTempPath();
            try
            {
                String origFldr = Path.Combine(ExePath, "ScreenScrape");
                DirectoryInfo diOrig = new DirectoryInfo(origFldr);
                foreach (FileInfo file in diOrig.GetFiles())
                {
                    String fileName = Path.Combine(userPath, file.Name);
                    FileInfo existing = new FileInfo(fileName);

                    if (!existing.Exists || existing.CreationTime < file.CreationTime)
                        file.CopyTo(fileName, true);
                }
            }
            catch (Exception e)
            {
                log.Error("Unable to copy Script files to user's Temporary Folder.", e);
                throw e;
            }
            return userPath;
        }

        /// <summary>
        /// Method that executes the Sikuli script and returns the MRN# that the script stored into the clipboard
        /// </summary>
        /// <returns>String</returns>
		private String GetMrn()
        {
			Clipboard.Clear();

            String userTempPath = CopyScriptFiles();

            String procCmd = Path.Combine(userTempPath, "runScript.cmd");
            String skl = Path.Combine(userTempPath, "GetMRN.skl");

            ProcessStartInfo info = new ProcessStartInfo(procCmd)
            {
                Arguments = "-r \"" + skl + "\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true
			};

            if (!info.EnvironmentVariables.ContainsKey("JAVA_HOME"))
                info.EnvironmentVariables.Add("JAVA_HOME", JavaHomePath);

			Process jProc = new Process() { StartInfo = info };
			
			if (jProc.Start())
            {
				while (!jProc.HasExited)
					Thread.Sleep(100);
				
                log.Info(jProc.StandardOutput.ReadToEnd());
				log.Error(jProc.StandardError.ReadToEnd());
			}
			return Clipboard.GetText();
		}

        /// <summary>
        /// BtnGetMrnClick is used to get the Signature page setup on the user's desktop environment for the Sikuli Script to scrape the MRN # and store the value into the textbox that is used to send the data to the patients Allscripts EHR
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void BtnGetMrnClick(object sender, EventArgs e)
		{
            // Gets the Main Screen's Width and Height (minus 40 pixels) to setup the Internet Explorer window that is running OAS Gold Client
            int winWidth = MainScreen.Bounds.Width;
            int winHeight = MainScreen.Bounds.Height - 40;

            // Get this form's information to be used to set it on top of the OAS Screen after getting the MRN #
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            RECT formRect = new RECT();
            Process process = Process.GetCurrentProcess();
			IntPtr formHandle = process.MainWindowHandle;
			User32.GetWindowRect(formHandle, ref formRect);
			
            // Window Handle of OAS Gold running (either on local instance of IE or Citrix)
            IntPtr foundHnd = IntPtr.Zero;

            // Checks the User's Desktop to find a local copy of IE running that has the tabe name of the title passed to the method
            // Once found will set the foundHnd (Window Hanlde of IE that has title running somehwere in it).
            // Get all local instances (not Citrix) of Internet Explorere that the user is running
            Process[] procsInterExp = Process.GetProcessesByName("iexplore");
            if (procsInterExp != null)
            {
                IEAccessible access = null;
                foreach (Process proc in procsInterExp)
                {
                    try {
                        access = new IEAccessible(proc.MainWindowHandle, OasTabName);
                        if (access != null && access.TabFound)
                        {
                            foundHnd = access.WindowHandler;
                            break;
                        }
                    }
                    catch { }
                }
            }

            // Try to get all local instances of Citrix that conatins Internet Explorer running OAS Gold Client
            if (foundHnd == IntPtr.Zero)
            {
                Process[] procsCitrix = Process.GetProcessesByName("wfica32");
                foreach (Process proc in procsCitrix)
                {
                    if (proc.MainWindowTitle.StartsWith(OasTabName))
                    {
                        foundHnd = proc.MainWindowHandle;
                        break;
                    }
                }
            }

            // If a window of OAS Gold is running get the MRN number
            if (foundHnd != IntPtr.Zero)
            {
                ShowWindow(foundHnd, (int)ShowWindowOption.SW_MAXIMIZE);

                User32.SetWindowPos(foundHnd, HWndValues.HWND_TOPMOST, 0, 0, winWidth, winHeight, 0);

                String mrn = null;

                for (int i = 0; i < 5; i++)
                {
                    mrn = GetMrn();
                    if (!String.IsNullOrEmpty(mrn))
                    {
                        mrn = mrn.Trim();
                        if (mrn.Length > 7)
                            mrn = mrn.Substring(mrn.Length - 7, 7);
    
                        break;
                    }
                }

                User32.SetWindowPos(foundHnd, HWndValues.HWND_NOTOPMOST, 0, 0, winWidth, winHeight, 0);
                Thread.Sleep(1000);
                User32.SetWindowPos(formHandle, HWndValues.HWND_TOP, formRect.left, formRect.top, formRect.Width, formRect.Height, 0);

                this.txtMrn.Text = mrn;
            }
            else
            {
                MessageBox.Show(
                    @"Please open an AMC Signature ""Patient Verification"" Screen and click the [Get MRN#] button before continuing.",
                    "No Signature Screen Available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.btnSend.Enabled = true;
            this.AcceptButton = this.btnSend;
        }

        /// <summary>
        /// IsValidMrn checks the MRN textbox on the form to verify that all items are Digit and they have a length of 7 characters
        /// </summary>
        /// <returns>Boolean</returns>
        private bool IsValidMrn
        {
            get
            {
                Regex rx = new Regex("^[0-9]{7,7}$");
                return rx.IsMatch(txtMrn.Text);
            }
        }

        /// <summary>
        /// ClearAll clears all images, MRN Text entry, disables the 'Send to Chart' button and sets the 'New Scan' button as the default
        /// </summary>
        private void ClearAll()
        {
            imgVwrFront.EditableImage = null;
            imgVwrBack.EditableImage = null;
            txtMrn.Text = String.Empty;
            btnSend.Enabled = false;
            AcceptButton = btnNew;
        }

        /// <summary>
        /// FileFlags is a sub-class to store the configuration for the file format parameters to replace for IEX
        /// </summary>
        class FileFlags
        {
            public static String Mrn = "%mrn";
            public static String FldrNum = "%folderNumber";
            public static String Date = "%yyyyMMdd";
            public static String ID = "%id";
        }

        void BtnSendIdClick(object sender, EventArgs e)
        {
            if (IsValidMrn)
            {
                String filename = FileSettings.FileNameFormat;
                filename = filename.Replace(FileFlags.Mrn, this.txtMrn.Text);
                filename = filename.Replace(FileFlags.Date, DateTime.Now.ToString("yyyyMMdd"));
                filename = filename.Replace(FileFlags.FldrNum, FileSettings.FolderNumber.ToString("d"));
                filename = filename.Replace(FileFlags.ID, "IDSCAN");
                ImageUtility.SaveImageFile(SaveImage, FileSettings.IexPath, filename, ImageFormat.Jpeg);
                ClearAll();
            }
            else
            {
                MessageBox.Show(
                    @"Please enter a valid MRN # or open an AMC Signature Patient Verification Screen and click the ""Get MRN#"" button before continuing.",
                    "No Valid MRN #", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		/// <summary>
        /// BtnSendClick is the handler to save the scanned images to a file for IEX to pick up and add to the Allscripts chart
		/// </summary>
		/// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
		void BtnSendClick(object sender, EventArgs e)
		{
            if (IsValidMrn)
            {
                String filename = FileSettings.FileNameFormat;
                filename = filename.Replace(FileFlags.Mrn, this.txtMrn.Text);
                filename = filename.Replace(FileFlags.Date, DateTime.Now.ToString("yyyyMMdd"));
                filename = filename.Replace(FileFlags.FldrNum, FileSettings.FolderNumber.ToString("d"));
                filename = filename.Replace(FileFlags.ID, "INSSCAN");
                ImageUtility.SaveImageFile(SaveImage, FileSettings.IexPath, filename, ImageFormat.Jpeg);
                ClearAll();
            }
            else
            {
                MessageBox.Show(
                    @"Please enter a valid MRN # or open an AMC Signature Patient Verification Screen and click the ""Get MRN#"" button before continuing.",
                    "No Valid MRN #", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

        private void BtnNewClick(object sender, EventArgs e)
        {
            BtnClearClick(null, null);
            isScanBoth = true;
            frontTwain.StartScanning(TwainScanSettings);
            this.Activate();
        }

        /// <summary>
        /// TmrToClearTick is a handler to be used to clear the images and MRN number when the timer get's to 2 minutes.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void TmrToClearTick(object sender, EventArgs e)
        {
            BtnClearClick(null, null);
            tmrToClear.Stop();
        }

        /// <summary>
        /// BtnClearClick is the handler to clear all items from the form and readies the form for new scanning
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void BtnClearClick(object sender, EventArgs e)
        {
            ClearAll();
            isFirstTime = true;
        }
	}
}
