namespace WIAUtility
{
	/// <summary>
	/// Document Handling Status
	/// </summary>
	[WIAProperty(3087)]
	public enum DocumentHandlingStatus /*WIA_DPS_DOCUMENT_HANDLING_STATUS*/
	{
		/// <summary>The document feeder has a page loaded and is ready for use.</summary>
		FeedReady=0x01,
		/// <summary>The flatbed is ready for use.</summary>
		FlatReady=0x02,
		/// <summary>The duplexer is enabled and ready to use.</summary>
		DupReady=0x04,
		/// <summary>The flatbed cover is up.</summary>
		FlatCoverUp=0x08,
		/// <summary>The paper path is covered and is preventing proper operation.</summary>
		PathCoverUp=0x10,
		/// <summary>A document is stuck in the document feeder.</summary>
		PaperJam=0x20,
		/// <summary>A transparency adapter is installed and ready for use.</summary>
		FilmTpaReady=0x40,
		/// <summary>A storage device is installed and ready for use.</summary>
		StorageReady=0x80,
		/// <summary>The storage is full; no upload operations are possible.</summary>
		StorageFull=0x100,
		/// <summary>A multiple feed occurred; this type of feed usually occurs with a PAPER_JAM value.</summary>
		MultipleFeed=0x200,
		/// <summary>There is an error that requires user intervention on the scanner.</summary>
		DeviceAttention=0x400,
		/// <summary>The scanner has a problem with the lamp and is not ready.</summary>
		LampErr=0x800,
	}
}