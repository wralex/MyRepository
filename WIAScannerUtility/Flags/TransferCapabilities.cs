namespace WIAUtility
{
	/// <summary>
	/// Transfer Capabilities 
	/// </summary>
	[WIAProperty(6169)]
	public enum TransferCapabilities /*WIA_IPS_TRANSFER_CAPABILITIES*/
	{
		/// <summary>The device can transfer the parent and child items together or the device must make a separate scan for each item and each child item.</summary>
		ChildrenSingleScan=0x00000001
	}
}