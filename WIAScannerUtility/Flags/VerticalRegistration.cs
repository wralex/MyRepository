namespace WIAUtility
{
	/// <summary> 
	/// Vertical Bed Registration
	/// </summary>
    [WIAProperty(3080)]
	public enum VerticalRegistration /*WIA_DPS_VERTICAL_BED_REGISTRATION*/
	{
		/// <summary>The paper is top-aligned.</summary>
		TopJustified=0,
		/// <summary>The paper is centered.</summary>
		Centered=1,
		/// <summary>The paper is bottom-aligned.</summary>
		BottomJustified=2,
	}
}