/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/13/2013
 * Time: 2:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace ASInsScan
{
	public class ImagePrintDocument : PrintDocument
	{
		public Image PrintImage { get; set; }

		public ImagePrintDocument() { }
		
		public ImagePrintDocument(Image image)
		{
			this.PrintImage = image;
		}
		
		protected override void OnPrintPage(PrintPageEventArgs e) 
		{
			base.OnPrintPage(e);

			Graphics gdiPage = e.Graphics;
			int top = Math.Max(0, (e.PageBounds.Height - PrintImage.Height) / 2);
			int left = Math.Max(0, (e.PageBounds.Width - PrintImage.Width) / 2);
			gdiPage.DrawImage(PrintImage, left, top, PrintImage.Width, PrintImage.Height);
		}
	}
}
