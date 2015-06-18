using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WIAUtility;
using WinControl;
using WinControl.Enums;

namespace AmcAllscriptsScanning
{
    public partial class Form1 : Form
    {
        private const string ieMainTitle = "Eclipse PPM";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scanner scanner = new Scanner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEAccessible ieEclipse = new IEAccessible(@"https://eod1.eclipseppm.com/");
            ieEclipse.SetIEWindowState(WINDOW_STATE.SW_SHOWMAXIMIZED);
            ieEclipse.BringTabForward();
        }


    }
}
