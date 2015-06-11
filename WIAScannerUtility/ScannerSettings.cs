using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public class ScannerSettings : DeviceSettings
    {
		public ScannerSettings(IProperties properties)
			: base(properties)
		{ }

        [WIAProperty(3074)]
		public int HorizontalBedSize
		{
			get { return this.GetPropertyValue<int>(3074); }
		} /*WIA_DPS_HORIZONTAL_BED_SIZE*/ // 0xc02

        [WIAProperty(3075)]
		public int VerticalBedSize
		{
			get { return this.GetPropertyValue<int>(3075); }
		} /*WIA_DPS_VERTICAL_BED_SIZE*/ // 0xc03

		[WIAProperty(3076)]
		public int HorizontalSheetFeedSize
		{
			get { return this.GetPropertyValue<int>(3076); }
		} /*WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE*/ // 0xc04

		[WIAProperty(3077)]
		public int VerticalSheetFeedSize
		{
			get { return this.GetPropertyValue<int>(3077); }
		} /*WIA_DPS_VERTICAL_SHEET_FEED_SIZE*/ // 0xc05

		[WIAProperty(3078)]
		public HorizontalRegistration SheetFeederRegistration
		{
			get { return this.GetPropertyValue<HorizontalRegistration>(3078); }
		} /*WIA_DPS_SHEET_FEEDER_REGISTRATION*/ // 0xc06

		[WIAProperty(3079)]
		public HorizontalRegistration HorizontalBedRegistration
		{
			get { return this.GetPropertyValue<HorizontalRegistration>(3079); }
		} /*WIA_DPS_HORIZONTAL_BED_REGISTRATION*/ // 0xc07

		[WIAProperty(3080)]
		public VerticalRegistration VerticalBedRegistration
		{
			get { return this.GetPropertyValue<VerticalRegistration>(3080); }
		} /*WIA_DPS_VERTICAL_BED_REGISTRATION*/ // 0xc08

		[WIAProperty(3081)]
		public int PlatenColor
		{
			get { return this.GetPropertyValue<int>(3081); }
		} /*WIA_DPS_PLATEN_COLOR*/ // 0xc09

		[WIAProperty(3082)]
		public UInt16 PadColor
		{
			get { return this.GetPropertyValue<UInt16>(3082); }
			set { this.SetPropertyValue(3082,value); }
		} /*WIA_DPS_PAD_COLOR*/ // 0xc0a

		[WIAProperty(3083)]
		public int FilterSelect
		{
			get { return this.GetPropertyValue<int>(3083); }
		} /*WIA_DPS_FILTER_SELECT*/  // 0xc0b

		[WIAProperty(3084)]
		public int DitherSelect
		{
			get { return this.GetPropertyValue<int>(3084); }
		} /*WIA_DPS_DITHER_SELECT*/  // 0xc0c

		[WIAProperty(3085)]
		public int DitherPatternData
		{
			get { return this.GetPropertyValue<int>(3085); }
		} /*WIA_DPS_DITHER_PATTERN_DATA*/  // 0xc0d

		[WIAProperty(3086)]
		public DocumentHandlingCapabilities DocumentHandlingCapabilities
		{
			get { return this.GetPropertyValue<DocumentHandlingCapabilities>(3086); }
		} /*WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES*/ // 0xc0e

		[WIAProperty(3087)]
		public DocumentHandlingStatus DocumentHandlingStatus
		{
			get { return this.GetPropertyValue<DocumentHandlingStatus>(3087); }
		} /*WIA_DPS_DOCUMENT_HANDLING_STATUS*/ // 0xc0f

		[WIAProperty(3088)]
		public DocumentHandlingSelect DocumentHandlingSelect
		{
			get { return this.GetPropertyValue<DocumentHandlingSelect>(3088); }
			set { this.SetPropertyValue(3088,value); }
		} /*WIA_DPS_DOCUMENT_HANDLING_SELECT*/ // 0xc10

		[Obsolete]
		public int DocumentHandlingCapacity
		{
			get { return this.GetPropertyValue<int>(3089); }
		} /*WIA_DPS_DOCUMENT_HANDLING_CAPACITY*/ // 0xc11

		[WIAProperty(3090)]
		public int HorizontalOpticalResolution
		{
			get { return this.GetPropertyValue<int>(3090); }
		} /*WIA_DPS_OPTICAL_XRES*/ // 0xc12

		[WIAProperty(3091)]
		public int VerticalOpticalResolution
		{
			get { return this.GetPropertyValue<int>(3091); }
		} /*WIA_DPS_OPTICAL_YRES*/ // 0xc13

		[WIAProperty(3092)]
		public int EndorserCharacters
		{
			get { return this.GetPropertyValue<int>(3092); }
		} /*WIA_DPS_ENDORSER_CHARACTERS*/ // 0xc14

		[WIAProperty(3093)]
		public string EndorserString
		{
			get { return this.GetPropertyValue<string>(3093); }
			set { this.SetPropertyValue(3093,value); }
		} /*WIA_DPS_ENDORSER_STRING*/ // 0xc15

		[WIAProperty(3094)]
		public int ScanAheadPages
		{
			get { return this.GetPropertyValue<int>(3094); }
			set { this.SetPropertyValue(3094,value); }
		} /*WIA_DPS_SCAN_AHEAD_PAGES*/ // 0xc16

		[WIAProperty(3095)]
		public int MaxScanTime
		{
			get { return this.GetPropertyValue<int>(3095); }
		} /*WIA_DPS_MAX_SCAN_TIME*/ // 0xc17

		[WIAProperty(3096)]
		public int Pages
		{
			get { return this.GetPropertyValue<int>(3096); }
			set { this.SetPropertyValue(3096,value); }
		} /*WIA_DPS_PAGES*/ // 0xc18


		[WIAProperty(3097)]
		public PageSize PageSize
		{
			get { return this.GetPropertyValue<PageSize>(3097); }
			set { this.SetPropertyValue(3097,value); }
		} /*WIA_DPS_PAGE_SIZE*/ // 0xc19

		[WIAProperty(3098)]
		public int PageWidth
		{
			get { return this.GetPropertyValue<int>(3098); }
		} /*WIA_DPS_PAGE_WIDTH*/ // 0xc1a

		[WIAProperty(3099)]
		public int PageHeight
		{
			get { return this.GetPropertyValue<int>(3099); }
		} /*WIA_DPS_PAGE_HEIGHT*/ // 0xc1b

		[WIAProperty(3100)]
		public Preview Preview
		{
			get { return this.GetPropertyValue<Preview>(3100); }
			set { this.SetPropertyValue(3100,value); }
		} /*WIA_DPS_PREVIEW*/ // 0xc1c

		[Obsolete]
		[WIAProperty(3101)]
		public Transparency Transparency
		{
			get { return this.GetPropertyValue<Transparency>(3101); }
		} /*WIA_DPS_TRANSPARENCY*/ // 0xc1d

		[Obsolete]
		[WIAProperty(3102)]
		public TransparencySelect TransparencySelect
		{
			get { return this.GetPropertyValue<TransparencySelect>(3102); }
		} /*WIA_DPS_TRANSPARENCY_SELECT*/ // 0xc1e

		[WIAProperty(3103)]
		public ShowPreviewControl ShowPreviewControl
		{
			get { return this.GetPropertyValue<ShowPreviewControl>(3103); }
		} /*WIA_DPS_SHOW_PREVIEW_CONTROL*/ // 0xc1f

		[WIAProperty(3104)]
		public int MinHorizontalSheetFeedSize
		{
			get { return this.GetPropertyValue<int>(3104); }
		} /*WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE*/ // 0xc20

		[WIAProperty(3105)]
		public int MinVerticalSheetFeedSize
		{
			get { return this.GetPropertyValue<int>(3105); }
		} /*WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE*/ // 0xc21

		[WIAProperty(3106)]
		public TransparencyCapabilities TransparencyCapabilities
		{
			get { return this.GetPropertyValue<TransparencyCapabilities>(3106); }
		} /*WIA_DPS_TRANSPARENCY_CAPABILITIES*/  // 0xc22

		[Obsolete]
		[WIAProperty(3107)]
		public Transparency TransparencyStatus
		{
			get { return this.GetPropertyValue<Transparency>(3107); }
		} /*WIA_DPS_TRANSPARENCY_STATUS*/  // 0xc23

		[WIAProperty(3112)]
		public string UserName
		{
			get { return this.GetPropertyValue<string>(3112); }
		} /*WIA_DPS_USER_NAME*/  // 0xc28

		[WIAProperty(3113)]
		public string ServiceID
		{
			get { return this.GetPropertyValue<string>(3113); }
		} /*WIA_DPS_SERVICE_ID*/  // 0xc29

		[WIAProperty(3114)]
		public string ScannerDeviceID
		{
			get { return this.GetPropertyValue<string>(3114); }
		} /*WIA_DPS_DEVICE_ID*/  // 0xc2a

		[WIAProperty(3115)]
		public string GlobalIdentity
		{
			get { return this.GetPropertyValue<string>(3115); }
		} /*WIA_DPS_GLOBAL_IDENTITY*/  // 0xc2b
    }
}
