namespace WIAUtility
{
	/// <summary>
	/// Photometric Interpretation
	/// </summary>
	[WIAProperty(6153)]
	public enum PhotometricInterpretation /*WIA_IPS_PHOTOMETRIC_INTERP*/
	{
		/// <summary>White is 1, and black is 0.</summary>
		White1=0,
		/// <summary>White is 0, and black is 1.</summary>
		White0=1,
	}
}