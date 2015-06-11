namespace WIAUtility
{
	/// <summary>
	/// Data Type
	/// </summary>
	[WIAProperty(4103)]
	public enum DataType /*WIA_IPA_DATATYPE*/
	{
		/// <summary>The threshold is one bit per pixel of black-and-white data. Data over the current value of WIA_IPS_THRESHOLD is converted to white; data under this value is converted to black.</summary>
		Threshold=0,
		/// <summary>Scan data is dithered by using the currently selected dither pattern.</summary>
		Dither=1,
		/// <summary>Scan data represents intensity. The palette is a fixed, equally spaced grayscale with a depth that the WIA_IPA_DEPTH property specifies.</summary>
		Grayscale=2,
		/// <summary>Scan data is red-green-blue (RGB).	/// </summary>
		Color=3,
		/// <summary>Color threshold data.</summary>
		ColorThreshold=4,
		/// <summary>The same as WIA_DATA_COLOR, except that the data is dithered by using the currently selected dither pattern.</summary>
		ColorDither=5,
		/// <summary>Scan data is in the red-green-blue (RGB) colorspace. The full color format is described using the same WIA properties as in WIA_DATA_RAW_BGR. 
		/// WIA_IPA_RAW_BITS_PER_CHANNEL must be set to 3.</summary>
		RawRgb=6,
		/// <summary>Scan data is in the BGR (blue-green-red) colorspace. 
		/// WIA_IPA_RAW_BITS_PER_CHANNEL must be set to 3.</summary>
		RawBgr=7,
		/// <summary>Scan data is in the luminance-blue difference-red difference (YUV)  colorspace. The full color format is described by using the same WIA properties that are listed for WIA_DATA_RAW_BGR. 
		/// WIA_IPA_RAW_BITS_PER_CHANNEL must be set to 3.</summary>
		RawYuv=8,
		/// <summary>Scan data is in the luminance-blue difference-red difference-black (YUVK) colorspace. The full color format is described by using the same WIA properties that are listed for WIA_DATA_RAW_BGR.
		/// WIA_IPA_RAW_BITS_PER_CHANNEL must be set to 4.</summary>
		RawYuvk=9,
		/// <summary>Scan data is in the cyan-magenta-yellow (CMY) colorspace. The full color format is described by using the same WIA properties that are listed for WIA_DATA_RAW_BGR.
		/// WIA_IPA_RAW_BITS_PER_CHANNEL must be set to 3.</summary>
		RawCmy=10,
		/// <summary>Scan data is in the cyan-magenta-yellow-black (CMYK) colorspace. The full color format is described by using the same WIA properties that are listed for WIA_DATA_RAW_BGR.
		/// WIA_IPA_RAW_BITS_PER_CHANNEL must be set to 4.</summary>
		RawCmyk=11,
	}

}