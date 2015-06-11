namespace WIAUtility
{
	/// <summary> Media Type </summary>
	[WIAProperty(4108)]
	public enum MediaType /*WIA_IPA_TYMED*/
	{
		/// <summary>Transfer an image to memory, in bands. This constant is obsolete for Windows�Vista and later operating systems.</summary>
		Callback=128,
		/// <summary>
		/// Transfer multiple images to a file.
		/// </summary>
		MultipageFile=256,
		/// <summary>
		/// Transfer multiple images to memory, in bands. This constant is obsolete for Windows�Vista and later operating systems.
		/// </summary>
		MultipageCallback=512,
	}
}