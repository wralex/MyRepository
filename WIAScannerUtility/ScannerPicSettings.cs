using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public class ScannerPicSettings : PictureSettings
    {
        public ScannerPicSettings(IProperties properties)
			: base(properties)
		{ }

		[WIAProperty(6146)]
		public CurrentIntent CurrentIntent
		{
			get { return this.GetPropertyValue<CurrentIntent>(6146); }
			set { this.SetPropertyValue(6146,value); }
		} /*WIA_IPS_CUR_INTENT*/ // 0x1802

		[WIAProperty(6147)]
		public int HorizontalResolution
		{
			get { return this.GetPropertyValue<int>(6147); }
			set { this.SetPropertyValue(6147,value); }
		} /*WIA_IPS_XRES*/ // 0x1803

		[WIAProperty(6148)]
		public int VerticalResolution
		{
			get { return this.GetPropertyValue<int>(6148); }
			set { this.SetPropertyValue(6148,value); }
		} /*WIA_IPS_YRES*/ // 0x1804

		[WIAProperty(6149)]
		public int HorizontalStartPosition
		{
			get { return this.GetPropertyValue<int>(6149); }
			set { this.SetPropertyValue(6149,value); }
		} /*WIA_IPS_XPOS*/ // 0x1805

		[WIAProperty(6150)]
		public int VerticalStartPosition
		{
			get { return this.GetPropertyValue<int>(6150); }
			set { this.SetPropertyValue(6150,value); }
		} /*WIA_IPS_YPOS*/ // 0x1806

		[WIAProperty(6151)]
		public int HorizontalExtent
		{
			get { return this.GetPropertyValue<int>(6151); }
			set { this.SetPropertyValue(6151,value); }
		} /*WIA_IPS_XEXTENT*/ // 0x1807

		[WIAProperty(6152)]
		public int VerticalExtent
		{
			get { return this.GetPropertyValue<int>(6152); }
			set { this.SetPropertyValue(6152,value); }
		} /*WIA_IPS_YEXTENT*/ // 0x1808

		[WIAProperty(6153)]
		public PhotometricInterpretation PhotometricInterpretation
		{
			get { return this.GetPropertyValue<PhotometricInterpretation>(6153); }
			set { this.SetPropertyValue(6153,value); }
		} /*WIA_IPS_PHOTOMETRIC_INTERP*/ // 0x1809

		[WIAProperty(6154)]
		public int Brightness
		{
			get { return this.GetPropertyValue<int>(6154); }
			set { this.SetPropertyValue(6154,value); }
		} /*WIA_IPS_BRIGHTNESS*/ // 0x180a

		[WIAProperty(6155)]
		public int Contrast
		{
			get { return this.GetPropertyValue<int>(6155); }
			set { this.SetPropertyValue(6155,value); }
		} /*WIA_IPS_CONTRAST*/ // 0x180b

		[WIAProperty(6156)]
		public OrientationAndRotation Orientation
		{
			get { return this.GetPropertyValue<OrientationAndRotation>(6156); }
			set { this.SetPropertyValue(6156,value); }
		} /*WIA_IPS_ORIENTATION*/ // 0x180c

		[WIAProperty(6157)]
		public OrientationAndRotation Rotation
		{
			get { return this.GetPropertyValue<OrientationAndRotation>(6157); }
			set { this.SetPropertyValue(6157,value); }
		} /*WIA_IPS_ROTATION*/ // 0x180d

		[WIAProperty(6158)]
		public Mirror Mirror
		{
			get { return this.GetPropertyValue<Mirror>(6158); }
		} /*WIA_IPS_MIRROR*/ // 0x180e

		[WIAProperty(6159)]
		public int Threshold
		{
			get { return this.GetPropertyValue<int>(6159); }
			set { this.SetPropertyValue(6159,value); }
		} /*WIA_IPS_THRESHOLD*/ // 0x180f

		[WIAProperty(6160)]
		public int Invert
		{
			get { return this.GetPropertyValue<int>(6160); }
		} /*WIA_IPS_INVERT*/ // 0x1810

		[WIAProperty(6161)]
		public int WarmUpTime
		{
			get { return this.GetPropertyValue<int>(6161); }
		} /*WIA_IPS_WARM_UP_TIME*/ // 0x1811

		[WIAProperty(6162)]
		public int DeskewX
		{
			get { return this.GetPropertyValue<int>(6162); }
			set { this.SetPropertyValue(6162,value); }
		} /*WIA_IPS_DESKEW_X*/  // 0x1812

		[WIAProperty(6163)]
		public int DeskewY
		{
			get { return this.GetPropertyValue<int>(6163); }
			set { this.SetPropertyValue(6163,value); }
		} /*WIA_IPS_DESKEW_Y*/  // 0x1813

		[WIAProperty(6164)]
		public SegmentationFilter Segmentation
		{
			get { return this.GetPropertyValue<SegmentationFilter>(6164); }
			set { this.SetPropertyValue(6164,value); }
		} /*WIA_IPS_SEGMENTATION*/  // 0x1814

		[WIAProperty(6165)]
		public int MaxHorizontalSize
		{
			get { return this.GetPropertyValue<int>(6165); }
		} /*WIA_IPS_MAX_HORIZONTAL_SIZE*/  // 0x1815

		[WIAProperty(6166)]
		public int MaxVerticalSize
		{
			get { return this.GetPropertyValue<int>(6166); }
		} /*WIA_IPS_MAX_VERTICAL_SIZE*/  // 0x1816

		[WIAProperty(6167)]
		public int MinHorizontalSize
		{
			get { return this.GetPropertyValue<int>(6167); }
		} /*WIA_IPS_MIN_HORIZONTAL_SIZE*/  // 0x1817

		[WIAProperty(6168)]
		public int MinVerticalSize
		{
			get { return this.GetPropertyValue<int>(6168); }
		} /*WIA_IPS_MIN_VERTICAL_SIZE*/  // 0x1818

		[WIAProperty(6169)]
		public TransferCapabilities TransferCapabilities
		{
			get { return this.GetPropertyValue<TransferCapabilities>(6169); }
		} /*WIA_IPS_TRANSFER_CAPABILITIES*/  // 0x1819

		[WIAProperty(3078)]
		public HorizontalRegistration SheetFeederRegistration
		{
			get { return this.GetPropertyValue<HorizontalRegistration>(3078); }
		} /*WIA_IPS_SHEET_FEEDER_REGISTRATION*/  // 0xc06

		[WIAProperty(3088)]
		public DocumentHandlingSelect DocumentHandlingSelect
		{
			get { return this.GetPropertyValue<DocumentHandlingSelect>(3088); }
			set { this.SetPropertyValue(3088,value); }
		} /*WIA_IPS_DOCUMENT_HANDLING_SELECT*/  // 0xc10

		[WIAProperty(3090)]
		public int HorizontalOpticalResolution
		{
			get { return this.GetPropertyValue<int>(3090); }
		} /*WIA_IPS_OPTICAL_XRES*/  // 0xc12

		[WIAProperty(3091)]
		public int VerticalOpticalResolution
		{
			get { return this.GetPropertyValue<int>(3091); }
		} /*WIA_IPS_OPTICAL_YRES*/  // 0xc13

		[WIAProperty(3096)]
		public int Pages
		{
			get { return this.GetPropertyValue<int>(3096); }
			set { this.SetPropertyValue(3096,value); }
		} /*WIA_IPS_PAGES*/  // 0xc18

		[WIAProperty(3097)]
		public PageSize PageSize
		{
			get { return this.GetPropertyValue<PageSize>(3097); }
			set { this.SetPropertyValue(3097,value); }
		} /*WIA_IPS_PAGE_SIZE*/  // 0xc19

		[WIAProperty(3098)]
		public int PageWidth
		{
			get { return this.GetPropertyValue<int>(3098); }
		} /*WIA_IPS_PAGE_WIDTH*/  // 0xc1a

		[WIAProperty(3099)]
		public int PageHeight
		{
			get { return this.GetPropertyValue<int>(3099); }
		} /*WIA_IPS_PAGE_HEIGHT*/  // 0xc1b

		[WIAProperty(3100)]
		public Preview Preview
		{
			get { return this.GetPropertyValue<Preview>(3100); }
			set { this.SetPropertyValue(3100,value); }
		} /*WIA_IPS_PREVIEW*/  // 0xc1c

		[WIAProperty(3103)]
		public ShowPreviewControl ShowPreviewControl
		{
			get { return this.GetPropertyValue<ShowPreviewControl>(3103); }
		} /*WIA_IPS_SHOW_PREVIEW_CONTROL*/  // 0xc1f

		[WIAProperty(3104)]
		public FilmScanMode FilmScanMode
		{
			get { return this.GetPropertyValue<FilmScanMode>(3104); }
			set { this.SetPropertyValue(3104,value); }
		} /*WIA_IPS_FILM_SCAN_MODE*/  // 0xc20

		[WIAProperty(3105)]
		public Lamp Lamp
		{
			get { return this.GetPropertyValue<Lamp>(3105); }
			set { this.SetPropertyValue(3105,value); }
		} /*WIA_IPS_LAMP*/  // 0xc21

		[WIAProperty(3106)]
		public int AutoOff
		{
			get { return this.GetPropertyValue<int>(3106); }
			set { this.SetPropertyValue(3106,value); }
		} /*WIA_IPS_LAMP_AUTO_OFF*/  // 0xc22

		[WIAProperty(3107)]
		public AutoDeskew AutoDeskew
		{
			get { return this.GetPropertyValue<AutoDeskew>(3107); }
			set { this.SetPropertyValue(3107,value); }
		} /*WIA_IPS_AUTO_DESKEW*/  // 0xc23

		[WIAProperty(3108)]
		public int SupportsChildItemCreation
		{
			get { return this.GetPropertyValue<int>(3108); }
		} /*WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION*/  // 0xc24

		[WIAProperty(3109)]
		public int HorizontalScaling
		{
			get { return this.GetPropertyValue<int>(3109); }
			set { this.SetPropertyValue(3109,value); }
		} /*WIA_IPS_XSCALING*/  // 0xc25

		[WIAProperty(3110)]
		public int VerticalScaling
		{
			get { return this.GetPropertyValue<int>(3110); }
			set { this.SetPropertyValue(3110,value); }
		} /*WIA_IPS_YSCALING*/  // 0xc26

		[WIAProperty(3111)]
		public PreviewType PreviewType
		{
			get { return this.GetPropertyValue<PreviewType>(3111); }
		} /*WIA_IPS_PREVIEW_TYPE*/  // 0xc27

		[WIAProperty(4129)]
		public string FilmNodeName
		{
			get { return this.GetPropertyValue<string>(4129); }
			set { this.SetPropertyValue(4129,value); }
		} /*WIA_IPS_FILM_NODE_NAME*/  // 0x1021
    }
}
