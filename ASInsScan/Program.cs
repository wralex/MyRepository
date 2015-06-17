/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/7/2013
 * Time: 10:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace ASInsScan
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
            String procName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(procName).Length > 1)
            {
                MessageBox.Show("The Allscripts Insurance Card Scanning Application is currently running on this machine.", "Application Is Currently Running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ScanCard());
		}
		
	}
}
