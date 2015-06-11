namespace WIAUtility
{
	/// <summary> 
	/// Preview
	/// </summary>
	[WIAProperty(3100)]
	public enum Preview /*WIA_DPS_PREVIEW*/
	{
		/// <summary>The application will perform a final scan.</summary>
		FinalScan=0,
		/// <summary>The application will perform a preview scan.</summary>
		PreviewScan=1,
	}
}