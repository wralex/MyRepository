/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/13/2013
 * Time: 11:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ASInsScan
{
	public class ImageUtility
	{
		public static Bitmap MergeImages(Image a, Image b) {
			return MergeImages(a, b, ImageMergeDirection.Vertical);
		}
		
		public static Bitmap MergeImages(Image a, Image b, ImageMergeDirection direction) {
			int width = a.Width;
			int height = a.Height;
			
			switch (direction){
				case ImageMergeDirection.Horizontal:
					width += b.Width;
					if (b.Height > a.Height)
						height = b.Height;
					break;
				case ImageMergeDirection.Vertical:
					height += b.Height;
					if (b.Width > a.Width)
						width = b.Width;
					break;
			}
			
			Bitmap result = new Bitmap(width, height);
			
	    	using (Graphics canvas = Graphics.FromImage(result))
	    	{
	    		canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
	    		canvas.DrawImage(a, 0, 0, a.Width, a.Height);
	    		if (direction == ImageMergeDirection.Vertical)
	    			canvas.DrawImage(b, 0, a.Height+1, b.Width, b.Height);
	    		else
	    			canvas.DrawImage(b, a.Width+1, 0, b.Width, b.Height);
	    	}
	    	return result;
		}
		
		public static Bitmap ResizeImage(Image image, Size size) { return ResizeImage(image, size, true); }
		public static Bitmap ResizeImage(Image image, Size size, bool preserveAspectRatio)
		{
			int newWidth;
			int newHeight;
			if (preserveAspectRatio) {
				int originalWidth = image.Width;
				int originalHeight = image.Height;
				float percentWidth = (float)size.Width / (float)originalWidth;
				float percentHeight = (float)size.Height / (float)originalHeight;
				float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
				newWidth = (int)(originalWidth * percent);
				newHeight = (int)(originalHeight * percent);
			}
			else
			{
				newWidth = size.Width;
				newHeight = size.Height;
			}
			
			Bitmap result = new Bitmap(newWidth, newHeight);

			using (Graphics graphicsHandle = Graphics.FromImage(result)) {
				graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
			}

			return result;
		}
		
		public static void SaveImageFile(Image image, String directory, String fileName, ImageFormat format) {
			fileName += "." + format.ToString();
			String path = Path.Combine(directory, fileName);
			image.Save(path, format);
		}
	}
	
	public enum ImageMergeDirection {
		Horizontal, Vertical
	}

}
