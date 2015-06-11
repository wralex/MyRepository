namespace WIAUtility
{
	/// <summary>
	/// Orientation and Rotation
	/// </summary>
	[WIAProperty(6156)]
	[WIAProperty(6157)]
	public enum OrientationAndRotation /*WIA_IPS_ORIENTATION & WIA_IPS_ROTATION*/
	{
		/// <summary>The driver will not rotate the image.</summary>
		Portrait=0,
		/// <summary>The orientation is a 90-degree counterclockwise rotation, relative to the PORTRAIT orientation.</summary>
		Lanscape=1,
		/// <summary>The orientation is a 90-degree counterclockwise rotation, relative to the PORTRAIT orientation.</summary>
		Landscape=Lanscape,
		/// <summary>The orientation is a 180-degree counterclockwise rotation, relative to the PORTRAIT orientation.</summary>
		Rot180=2,
		/// <summary>The orientation is a 270-degree counterclockwise rotation, relative to the PORTRAIT orientation.</summary>
		Rot270=3,
	}
}