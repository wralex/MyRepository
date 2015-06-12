using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIAUtility;

namespace AmcAllscriptsScanning
{
    public partial class Form1 : Form
    {
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
            WebCam cam = new WebCam();
            String[] s = cam.GetConnectedCameras();
        }
    }
}
