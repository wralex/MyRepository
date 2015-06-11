using System;

namespace WIAUtility
{
	/// <summary>
	/// Current Intent
	/// </summary>
	[Flags]
	[WIAProperty(6146)]
	public enum CurrentIntent /*WIA_IPS_CUR_INTENT*/
	{
		/// <summary>Default value. No intent is specified.</summary>
		None=0x00000000,
		/// <summary>The application intends to prepare the device for a color scan.</summary>
		ImageTypeColor=0x00000001,
		/// <summary>The application intends to prepare the device for a grayscale scan.</summary>
		ImageTypeGrayscale=0x00000002,
		/// <summary>The application intends to prepare the device for scanning text.</summary>
		ImageTypeText=0x00000004,
		/// <summary>This flag is a mask for all of the image-type flags.</summary>
		ImageTypeMask=0x0000000F,
		/// <summary>The application intends to prepare the device for scanning an image that results in a small scan.</summary>
		MinimizeSize=0x00010000,
		/// <summary>The application intends to prepare the device for scanning a high-quality image.</summary>
		MaximizeQuality=0x00020000,
		/// <summary>The application intends to prepare the device for scanning a preview.</summary>
		BestPreview=0x00040000,
		/// <summary>This flag is a mask for all of the size and quality flags.</summary>
		SizeMask=0x000F0000,
	}
}