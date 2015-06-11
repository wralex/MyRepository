using System;

namespace WIAUtility
{
	/// <summary>
	/// Document Handling Capabilities
	/// </summary>
	[Flags]
	[WIAProperty(3086)]
	public enum DocumentHandlingCapabilities /*WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES*/
	{
		/// <summary>The scanner has a document feeder installed.</summary>
		Feed=0x01,
		/// <summary>The scanner has a flatbed platen.</summary>
		Flat=0x02,
		/// <summary>The scanner has a duplexer.</summary>
		Dup=0x04,
		/// <summary>The scanner can detect a document on the flatbed platen.</summary>
		DetectFlat=0x08,
		/// <summary>The scanner can detect a document in the feeder only by scanning.</summary>
		DetectScan=0x10,
		/// <summary>The scanner can detect a document in the feeder.</summary>
		DetectFeed=0x20,
		/// <summary>The scanner can detect a duplex scan request from a user.</summary>
		DetectDup=0x40,
		/// <summary>The scanner can detect when a document feeder is installed.</summary>
		DetectFeedAvail=0x80,
		/// <summary>The scanner can detect when a duplexer is installed.</summary>
		DetectDupAvail=0x100,
		/// <summary>The scanner has a transparency or film scanning adapter.</summary>
		FilmTpa=0x200,
		/// <summary>The scanner can detect when the transparency or film scanning adapter is ready to scan.</summary>
		DetectFilmTpa=0x400,
		/// <summary>The scanner is equipped with an internal storage device.</summary>
		Stor=0x800,
		/// <summary>The scanner can detect when there is a document in the internal storage.</summary>
		DetectStor=0x1000,
		/// <summary>The device supports advanced duplex scan configuration, independently on each document size.</summary>
		AdvancedDup=0x2000,
		/// <summary>AUTOSOURCE | The device supports auto-configured scanning.</summary>
	}
}