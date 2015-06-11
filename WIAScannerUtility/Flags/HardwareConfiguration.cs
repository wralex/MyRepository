namespace WIAUtility
{
	/// <summary>
	/// Hardware Configuration 
	/// </summary>
	[WIAProperty(11)]
	public enum HardwareConfiguration /*WIA_DIP_HW_CONFIG*/
	{
		/// <summary>Generic WDM device</summary>
		GenericWdmDevice=1,
		/// <summary>SCSI device</summary>
		ScsiDevice=2,
		/// <summary>USB device</summary>
		UsbDevice=4,
		/// <summary>Serial device</summary>
		SerialDevice=8,
		/// <summary>Parallel device</summary>
		ParallelDevice=16,
	}
}