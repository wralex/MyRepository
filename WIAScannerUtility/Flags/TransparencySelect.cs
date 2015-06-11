using System;

namespace WIAUtility
{
	/// <summary> 
	/// Transparency Adapter Select
	/// </summary>
	[Flags]
	[WIAProperty(3102)]
	public enum TransparencySelect /*WIA_DPS_TRANSPARENCY_SELECT*/
	{
		Select=0x001, // currently not used
		Positive=0x002,
		Negative=0x004,
	}
}