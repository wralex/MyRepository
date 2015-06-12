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
		public ScannerSettings DeviceSettings { get; private set; }
        public ScannerPictureSettings PictureSettings { get; private set; }

        public Scanner(Device device)
		{
			this.Device = device;
			this.DeviceSettings = new ScannerSettings(device.Properties);
            this.PictureSettings = new ScannerPictureSettings(device.Items[1].Properties);
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
