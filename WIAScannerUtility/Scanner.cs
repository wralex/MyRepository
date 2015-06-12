using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public class Scanner
    {
		public Device Device { get; private set; }
		public ScannerSettings Settings { get; private set; }
        public ScannerPicSettings PictureSettings { get; private set; }

        public Scanner()
		{
            initiate((new WIA.CommonDialog()).ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false));
		}
        public Scanner(Device device)
        {
            initiate(device);
        }

        private void initiate(Device device)
        {
            this.Device = device;
            this.Settings = new ScannerSettings(device.Properties);
            this.PictureSettings = new ScannerPicSettings(device.Items[1].Properties);
        }

        public IEnumerable<Image> PerformScan(PictureFormatID formatID = PictureFormatID.wiaFormatBMP)
		{
            ImageFile imageFile = (ImageFile)this.Device.Items[1].Transfer(_Utility.GetDescriptionAttributeValue(formatID));
			return Scanner.ExtractImages(imageFile);
		}

        private static IEnumerable<Image> ExtractImages(ImageFile imageFile)
		{
			for (int frame = 1;frame<=imageFile.FrameCount;frame++)
			{
				imageFile.ActiveFrame = frame;
				ImageFile argbImage = imageFile.ARGBData.get_ImageFile(imageFile.Width,imageFile.Height);

				Image result = Image.FromStream(new MemoryStream((byte[])argbImage.FileData.get_BinaryData()));
				yield return result;
			}
		}
    }
}
