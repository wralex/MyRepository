namespace WIAUtility
{
	/// <summary>
	/// Segmentation Filter
	/// </summary>
	[WIAProperty(6164)]
	public enum SegmentationFilter /*WIA_IPS_SEGMENTATION*/
	{
		/// <summary>
		/// The application should use the segmentation filter for multi-region scanning.
		/// </summary>
		UseSegmentationFilter=0,
		/// <summary>
		/// The driver creates the child items itself for multi-region scanning. This situation typically occurs if a scanner uses fixed frames for multi-region scanning.
		/// </summary>
		DontUseSegmentationFilter=1,
	}
}