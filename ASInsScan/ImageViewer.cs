/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/12/2013
 * Time: 1:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ASInsScan
{
	/// <summary>
	/// Description of ImageViewer.
	/// </summary>
	public partial class ImageViewer : UserControl
	{
		public ImageViewer() : this("[Title]") { }
		
		public ImageViewer(String Title) {
			InitializeComponent();
			this.Title = Title;
		}
		
		public String Title {
			get { return grpImageId.Text; }
			set { grpImageId.Text = value; }
		}

		private int brightness = 50;
		public int Brightness {
			get { return brightness; }
			set {
				brightness = value;
				pictImage.Image = GetViewingImage();
			}
		}

		private ColorMatrix ImageColorMatrix {
			get {
				float bright = ((float) Brightness) / 255.0f;
				return new ColorMatrix(
					new float[][] {
						new float[] {1.0f, 0f, 0f, 0f, 0f},
						new float[] {0f, 1.0f, 0f, 0f, 0f},
						new float[] {0f, 0f, 1.0f, 0f, 0f},
						new float[] {0f, 0f, 0f, 1.0f, 0f},
						new float[] {bright, bright, bright, 0f, 1f} });
			}
		}

		private Bitmap originalImage;

		public Bitmap EditableImage {
			get {
				if (originalImage == null)
					return null;
				
				int imgWidth = originalImage.Width;
				int imgHeight = originalImage.Height;
	
				Bitmap result = new Bitmap(imgWidth, imgHeight);
				
				using (ImageAttributes attributes = new ImageAttributes()) {
					attributes.SetColorMatrix(ImageColorMatrix);
					
					using (Graphics graphics = Graphics.FromImage(result)) {
						graphics.DrawImage(
							originalImage, new Rectangle(0, 0, imgWidth, imgHeight),
							0, 0, imgWidth, imgHeight,
							GraphicsUnit.Pixel, attributes);
					}
				}
	
				return result;
			}
			set {
				this.originalImage = value;
				pictImage.Image = GetViewingImage();
			}
		}
		
		private void SetControls(object sender, int value){
			Brightness = value;

			if (!(sender is NumericUpDown))
				nmbBright.Value = value;
			if (!(sender is TrackBar))
				tbBright.Value = value;
		}
		
		void btnResetClick(object sender, System.EventArgs e) { SetControls(sender, 50); }
		void NmbBrightValueChanged(object sender, EventArgs e) { SetControls(sender, (int) nmbBright.Value); }
		void TbBrightValueChanged(object sender, EventArgs e) { SetControls(sender, tbBright.Value); }

		private Bitmap GetViewingImage()
		{
			if (EditableImage == null)
				return null;
			return ImageUtility.ResizeImage(EditableImage, pictImage.Size);
		}
	}
}
