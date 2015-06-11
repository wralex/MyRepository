using System;

namespace WIAUtility
{
	/// <summary>
	/// Document Handling Select
	/// </summary>
	[Flags]
	[WIAProperty(3088)]
	public enum DocumentHandlingSelect /*WIA_DPS_DOCUMENT_HANDLING_SELECT*/
	{
		/// <summary>Scan by using the document feeder.</summary>
		Feeder=0x001,
		/// <summary>Scan by using the flatbed.</summary>
		Flatbed=0x002,
		/// <summary>Scan by using duplexer operations.</summary>
		Duplex=0x004,
		/// <summary>Scan the front of the document first. This value is valid only when DUPLEX is set.</summary>
		FrontFirst=0x008,
		/// <summary>Scan the back of the document first. This value is valid only when DUPLEX is set.</summary>
		BackFirst=0x010,
		/// <summary>Scan the front only.</summary>
		FrontOnly=0x020,
		/// <summary>Scan the back only. This value is valid only when DUPLEX is set.</summary>
		BackOnly=0x040,
		/// <summary>Scan the next page of the document.</summary>
		NextPage=0x080,
		/// <summary>Enable pre-feed mode. Preposition the next document while scanning.</summary>
		Prefeed=0x100,
		/// <summary>Enable automatic feeding of the next document after a scan.</summary>
		AutoAdvance=0x200,
		/// <summary>Scan by using individual configuration settings for each child feeder item (WIA_CATEGORY_FEEDER_FRONT and WIA_CATEGORY_FEEDER_BACK). This flag cannot be set together with DUPLEX. A device that supports different scan settings for the front and back items should implement the optional ADF front and back items and it should support both DUPLEX and ADVANCED_DUPLEX.</summary>
		AdvancedDuplex=0x400
	}
}