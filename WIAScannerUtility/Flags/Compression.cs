namespace WIAUtility
{
	/// <summary>
	/// Compression
	/// </summary>
	[WIAProperty(4107)]
	public enum Compression /*WIA_IPA_COMPRESSION*/
	{
		/// <summary>No compression</summary>
		None=0,
		/// <summary>RLE 4 compression</summary>
		BiRle4=1,
		/// <summary>RLE 8 compression</summary>
		BiRle8=2,
		/// <summary>Group 3 compression</summary>
		G3=3,
		/// <summary>Group 4 compression</summary>
		G4=4,
		/// <summary>JPEG compression</summary>
		Jpeg=5,
		/// <summary>IS 11544 (ITU-T T.82) compression*</summary>
		Jbig=6,
		/// <summary>JPEG 2000 compression*</summary>
		Jpeg2k=7,
		/// <summary>W3C PNG compression*</summary>
		Png=8,
	}
}