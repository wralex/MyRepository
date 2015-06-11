namespace WIAUtility
{
	/// <summary>
	/// Page Size
	/// </summary>
	[WIAProperty(3097)]
	public enum PageSize /*WIA_DPS_PAGE_SIZE & WIA_IPS_PAGE_SIZE*/
	{
		/// <summary>8267 x 11692 (PORTRAIT orientation).</summary>
		A4=0,
		/// <summary>8500 x 11000 (PORTRAIT orientation).</summary>
		Letter=1,
		/// <summary>Defined by the values of the WIA_IPS_PAGE_HEIGHT and WIA_IPS_PAGE_WIDTH properties.</summary>
		Custom=2,
		/// <summary> 8500 x 14000(PORTRAIT orientation).</summary>
		Uslegal=3,
		/// <summary></summary>
		Usletter=Letter,
		/// <summary>11000 x 17000 (PORTRAIT orientation).</summary>
		Usledger=4,
		/// <summary>5500 x  8500 (PORTRAIT orientation).</summary>
		Usstatement=5,
		/// <summary>3543 x  2165 (PORTRAIT orientation).</summary>
		Businesscard=6,
		/// <summary>33110 x 46811 (PORTRAIT orientation).</summary>
		IsoA0=7,
		/// <summary>23385 x 33110 (PORTRAIT orientation).</summary>
		IsoA1=8,
		/// <summary>16535 x 23385 (PORTRAIT orientation).</summary>
		IsoA2=9,
		/// <summary>11692 x 16535 (PORTRAIT orientation).</summary>
		IsoA3=10,
		/// <summary>8267 x 11692 (PORTRAIT orientation).</summary>
		IsoA4=A4,
		/// <summary>5826 x  8267 (PORTRAIT orientation).</summary>
		IsoA5=11,
		/// <summary>4133 x  5826 (PORTRAIT orientation).</summary>
		IsoA6=12,
		/// <summary>2913 x  4133 (PORTRAIT orientation).</summary>
		IsoA7=13,
		/// <summary>2047 x  2913 (PORTRAIT orientation).</summary>
		IsoA8=14,
		/// <summary>1456 x  2047 (PORTRAIT orientation).</summary>
		IsoA9=15,
		/// <summary>1023 x  1456 (PORTRAIT orientation).</summary>
		IsoA10=16,
		/// <summary>39370 x 55669 (PORTRAIT orientation).</summary>
		IsoB0=17,
		/// <summary>27834 x 39370 (PORTRAIT orientation).</summary>
		IsoB1=18,
		/// <summary>19685 x 27834 (PORTRAIT orientation).</summary>
		IsoB2=19,
		/// <summary>13897 x 19685 (PORTRAIT orientation).</summary>
		IsoB3=20,
		/// <summary>9842 x 13897 (PORTRAIT orientation).</summary>
		IsoB4=21,
		/// <summary>6929 x  9842 (PORTRAIT orientation).</summary>
		IsoB5=22,
		/// <summary>4921 x  6929 (PORTRAIT orientation).</summary>
		IsoB6=23,
		/// <summary>3464 x  4921 (PORTRAIT orientation).</summary>
		IsoB7=24,
		/// <summary>2440 x  3464 (PORTRAIT orientation).</summary>
		IsoB8=25,
		/// <summary>1732 x  2440 (PORTRAIT orientation).</summary>
		IsoB9=26,
		/// <summary>1220 x  1732 (PORTRAIT orientation).</summary>
		IsoB10=27,
		/// <summary>36102 x 51062 (PORTRAIT orientation).</summary>
		IsoC0=28,
		/// <summary>25511 x 36102 (PORTRAIT orientation).</summary>
		IsoC1=29,
		/// <summary>18031 x 25511 (PORTRAIT orientation).</summary>
		IsoC2=30,
		/// <summary>12755 x 18031 (PORTRAIT orientation).</summary>
		IsoC3=31,
		/// <summary>9015 x 12755 (unfolded) (PORTRAIT orientation).</summary>
		IsoC4=32,
		/// <summary>6377 x  9015 (folded once) (PORTRAIT orientation).</summary>
		IsoC5=33,
		/// <summary>4488 x  6377 (folded twice) (PORTRAIT orientation).</summary>
		IsoC6=34,
		/// <summary>3188 x  4488 (PORTRAIT orientation).</summary>
		IsoC7=35,
		/// <summary>2244 x  3188 (PORTRAIT orientation).</summary>
		IsoC8=36,
		/// <summary>1574 x  2244 (PORTRAIT orientation).</summary>
		IsoC9=37,
		/// <summary>1102 x  1574 (PORTRAIT orientation).</summary>
		IsoC10=38,
		/// <summary>40551 x 57322 (PORTRAIT orientation).</summary>
		JisB0=39,
		/// <summary>28661 x 40551 (PORTRAIT orientation).</summary>
		JisB1=40,
		/// <summary>20275 x 28661 (PORTRAIT orientation).</summary>
		JisB2=41,
		/// <summary>14330 x 20275 (PORTRAIT orientation).</summary>
		JisB3=42,
		/// <summary>10118 x 14330 (PORTRAIT orientation).</summary>
		JisB4=43,
		/// <summary>7165 x 10118 (PORTRAIT orientation).</summary>
		JisB5=44,
		/// <summary>5039 x  7165 (PORTRAIT orientation).</summary>
		JisB6=45,
		/// <summary>3582 x  5039 (PORTRAIT orientation).</summary>
		JisB7=46,
		/// <summary>2519 x  3582 (PORTRAIT orientation).</summary>
		JisB8=47,
		/// <summary>1771 x  2519 (PORTRAIT orientation).</summary>
		JisB9=48,
		/// <summary>1259 x  1771 (PORTRAIT orientation).</summary>
		JisB10=49,
		/// <summary>46811 x 66220 (PORTRAIT orientation).</summary>
		Jis2a=50,
		/// <summary>66220 x  93622 (PORTRAIT orientation).</summary>
		Jis4a=51,
		/// <summary>55669 x 78740 (PORTRAIT orientation).</summary>
		Din2b=52,
		/// <summary>78740 x 111338 (PORTRAIT orientation).</summary>
		Din4b=53,
		/// <summary>Used to configure automatic page size detection.</summary>
		Auto=100,
		/// <summary>Defined by the values of the WIA_IPS_PAGE_HEIGHT and WIA_IPS_PAGE_WIDTH properties. This value is used to define custom page sizes, instead of the single page that the WIA_PAGE_CUSTOM value enables.</summary>
		CustomBase=0x8000,
	}
}