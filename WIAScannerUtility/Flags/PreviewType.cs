namespace WIAUtility
{
	/// <summary>
	/// Preview Type
	/// </summary>
	[WIAProperty(3111)]
	public enum PreviewType /*WIA_IPS_PREVIEW_TYPE*/
	{
		/// <summary>Live preview updates are supported.</summary>
		AdvancedPreview=0,
		/// <summary>Preview images can be updated only with a new preview scan.</summary>
		BasicPreview=1,
	}
}