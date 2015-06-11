namespace WIAUtility
{
	/// <summary>
	/// Film Scan Mode
	/// </summary>
	[WIAProperty(3104)]
	public enum FilmScanMode /*WIA_IPS_FILM_SCAN_MODE*/
	{
		/// <summary>The scan will be a color scan.</summary>
		ColorSlide=0,
		/// <summary>The scan will be a color scan of a negative.</summary>
		ColorNegative=1,
		/// <summary>The scan will be black and white (grayscale) scan.</summary>
		BwNegative=2,
	}
}