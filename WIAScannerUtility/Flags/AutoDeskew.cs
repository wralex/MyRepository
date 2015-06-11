namespace WIAUtility
{
	/// <summary>
	/// Automatic Deskew
	/// </summary>
	[WIAProperty(3107)]
	public enum AutoDeskew /*WIA_IPS_AUTO_DESKEW*/
	{
		/// <summary>Use automatic skew correction.</summary>
		On=0,
		/// <summary>Do not use automatic skew correction.</summary>
		Off=1,
	}
}