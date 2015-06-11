namespace WIAUtility
{
	/// <summary>
	/// Show preview control
	/// </summary>
	[WIAProperty(3103)]
	public enum ShowPreviewControl /*WIA_DPS_SHOW_PREVIEW_CONTROL & WIA_IPS_SHOW_PREVIEW_CONTROL*/
	{
		/// <summary>Do not show a preview control to the user, because this device cannot perform a preview.</summary>
		ShowPreviewControl=0,
		/// <summary>Show a preview control to the user, because this device can perform a preview.</summary>
		DontShowPreviewControl=1,
	}
}