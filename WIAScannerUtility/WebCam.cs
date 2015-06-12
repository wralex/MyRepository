using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WIA;
using WIAVIDEOLib;

namespace WIAUtility
{
    public class WebCam
    {
        private static WebCam WebCamObj { get; set; }
        public static WebCam NewWebCam()
        {
            if (WebCam.WebCamObj == null)
                WebCam.WebCamObj = new WebCam();

            return WebCam.WebCamObj;
        }

        public List<DeviceInfo> Devices { get; set; }
        private WiaVideo WiaVideoObj { get; set; }
        private Device WiaObj { get; set; }
        private DeviceInfo DefaultDevice { get; set; }
        private bool DeviceIsOpen { get; set; }
        
        public WebCam()
        {
            DeviceIsOpen = false;
            Initialize();
            SetDefaultDevice();
            OpenDefaultDevice();
        }

        private void Initialize()
        {
            if (WiaObj == null)
                WiaObj = new Device();

            if (WiaVideoObj == null)
            {
                WiaVideoObj = new WiaVideo();
                WiaVideoObj.ImagesDirectory = Path.GetTempPath();
            }
        }

        public void CloseResources()
        {
            try
            {
                if (WiaObj != null)
                    Marshal.FinalReleaseComObject(WiaObj);
                if (WiaVideoObj != null)
                    Marshal.FinalReleaseComObject(WiaVideoObj);
                if (DefaultDevice != null)
                    Marshal.FinalReleaseComObject(DefaultDevice);
                if (Devices != null)
                    Marshal.FinalReleaseComObject(Devices);

                DeviceIsOpen = false;
                GC.Collect();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void SetDefaultDevice()
        {
            CloseDefaultDevice();

            Devices = new List<DeviceInfo>();

            foreach (Item obj in WiaObj.Items)
            {
                DeviceInfo dev = (DeviceInfo) Marshal.CreateWrapperOfType(obj, typeof(DeviceInfo));

                if (dev.Type.ToString().Contains("Video"))
                    Devices.Add(dev);
                else
                {
                    Marshal.FinalReleaseComObject(obj);
                    Marshal.FinalReleaseComObject(dev);
                }
            }

            if (Devices.Count > 0)
                DefaultDevice = Devices[0];
            else
                throw new Exception("No Cameras Detected");
        }

        public string[] GetConnectedCameras()
        {
            string[] devs = new string[Devices.Count];

            for (int i = 0; i < devs.Length; i++)
                devs[i] = Devices[i].DeviceID;

            return devs;
        }

        private void CloseDefaultDevice()
        {
            if (this.DeviceIsOpen == false)
                return;
            try
            {
                if (this.WiaVideoObj != null)
                {
                    this.WiaVideoObj.DestroyVideo();
                    Marshal.FinalReleaseComObject(this.DefaultDevice);
                    DeviceIsOpen = false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                DeviceIsOpen = false;
            }
        }

        public bool SetDefaultDevice(string name)
        {
            CloseDefaultDevice();

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].DeviceID.Equals(name))
                {
                    DefaultDevice = Devices[i];
                    return true;
                }
            }
            return false;
        }

        private bool OpenDefaultDevice()
        {
            CloseDefaultDevice();

            try
            {
                this.WiaVideoObj.PreviewVisible = 0;
                _RemotableHandle handle = new _RemotableHandle();
                this.WiaVideoObj.CreateVideoByWiaDevID(DefaultDevice.DeviceID, ref handle, 0, 0);

                Thread.CurrentThread.Join(3000);
                DeviceIsOpen = true;
                WiaVideoObj.Play();
                Thread.CurrentThread.Join(3000);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                CloseDefaultDevice();
                return false;
            }

            return true;
        }

        public byte[] GrabFrame()
        {
            string imagefile;
            WiaVideoObj.TakePicture(out imagefile);
            return ReadImageFile(imagefile);
        }
        
        private byte[] ReadImageFile(string img)
        {
            FileInfo fileInfo = new FileInfo(img);

            byte[] buf = new byte[fileInfo.Length];

            using (FileStream fs =
                new FileStream(img, FileMode.Open, FileAccess.Read))
            {
                fs.Read(buf, 0, buf.Length);
                fs.Close();
            }

            fileInfo.Delete();
            
            GC.ReRegisterForFinalize(fileInfo);

            return buf;
        }
    }
}
