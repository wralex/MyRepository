namespace WIAUtility
{
	/// <summary>
	/// Horizontal Bed Registration & Sheet Feeder Registration
	/// </summary>
	[WIAProperty(3078)]
	[WIAProperty(3079)]
	public enum HorizontalRegistration /*WIA_DPS_HORIZONTAL_BED_REGISTRATION & WIA_DPS_SHEET_FEEDER_REGISTRATION*/
	{
		/// <summary>The document is positioned to the left with respect to the scanning head.</summary>
		LeftJustified=0,
		/// <summary>The document is centered on the scanning head.</summary>
		Centered=1,
		/// <summary>The document is positioned to the right with respect to the scanning head.</summary>
		RightJustified=2,
	}
}