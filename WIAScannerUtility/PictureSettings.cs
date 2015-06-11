using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public class PictureSettings : WIASettings
    {
		public PictureSettings(IProperties properties)
			: base(properties)
		{ }


		[WIAProperty(4098)]
		public string ItemName
		{
			get { return this.GetPropertyValue<string>(4098); }
		} /*WIA_IPA_ITEM_NAME*/ // 0x1002

		[WIAProperty(4099)]
		public string FullItemName
		{
			get { return this.GetPropertyValue<string>(4099); }
		} /*WIA_IPA_FULL_ITEM_NAME*/ // 0x1003

		[WIAProperty(4100)]
		public UInt16 ItemTime
		{
			get { return this.GetPropertyValue<UInt16>(4100); }
			set { this.SetPropertyValue(4100,value); }
		} /*WIA_IPA_ITEM_TIME*/ // 0x1004

		[WIAProperty(4101)]
		public WiaItemFlag ItemFlags
		{
			get { return this.GetPropertyValue<WiaItemFlag>(4101); }
		} /*WIA_IPA_ITEM_FLAGS*/ // 0x1005

		[WIAProperty(4102)]
		public AccessRights AccessRights
		{
			get { return this.GetPropertyValue<AccessRights>(4102); }
			set { this.SetPropertyValue(4102,value); }
		} /*WIA_IPA_ACCESS_RIGHTS*/ // 0x1006

		[WIAProperty(4103)]
		public DataType DataType
		{
			get { return this.GetPropertyValue<DataType>(4103); }
			set { this.SetPropertyValue(4103,value); }
		} /*WIA_IPA_DATATYPE*/ // 0x1007

		[WIAProperty(4104)]
		public int Depth
		{
			get { return this.GetPropertyValue<int>(4104); }
			set { this.SetPropertyValue(4104,value); }
		} /*WIA_IPA_DEPTH*/ // 0x1008

		[WIAProperty(4105)]
		public string PreferredFormat
		{
			get { return this.GetPropertyValue<string>(4105); }
		} /*WIA_IPA_PREFERRED_FORMAT*/ // 0x1009

		[WIAProperty(4106)]
		public string Format
		{
			get { return this.GetPropertyValue<string>(4106); }
			set { this.SetPropertyValue(4106,value); }
		} /*WIA_IPA_FORMAT*/ // 0x100a

		[WIAProperty(4107)]
		public Compression Compression
		{
			get { return this.GetPropertyValue<Compression>(4107); }
			set { this.SetPropertyValue(4107,value); }
		} /*WIA_IPA_COMPRESSION*/ // 0x100b

		[WIAProperty(4108)]
		public MediaType MediaType
		{
			get { return this.GetPropertyValue<MediaType>(4108); }
			set { this.SetPropertyValue(4108,value); }
		} /*WIA_IPA_TYMED*/ // 0x100c

		[WIAProperty(4109)]
		public int ChannelsPerPixel
		{
			get { return this.GetPropertyValue<int>(4109); }
		} /*WIA_IPA_CHANNELS_PER_PIXEL*/ // 0x100d

		[WIAProperty(4110)]
		public int BitsPerChannel
		{
			get { return this.GetPropertyValue<int>(4110); }
		} /*WIA_IPA_BITS_PER_CHANNEL*/ // 0x100e

		[WIAProperty(4111)]
		public Planar Planar
		{
			get { return this.GetPropertyValue<Planar>(4111); }
			set { this.SetPropertyValue(4111,value); }
		} /*WIA_IPA_PLANAR*/ // 0x100f

		[WIAProperty(4112)]
		public int PixelsPerLine
		{
			get { return this.GetPropertyValue<int>(4112); }
		} /*WIA_IPA_PIXELS_PER_LINE*/ // 0x1010

		[WIAProperty(4113)]
		public int BytesPerLine
		{
			get { return this.GetPropertyValue<int>(4113); }
		} /*WIA_IPA_BYTES_PER_LINE*/ // 0x1011

		[WIAProperty(4114)]
		public int NumberOfLines
		{
			get { return this.GetPropertyValue<int>(4114); }
		} /*WIA_IPA_NUMBER_OF_LINES*/ // 0x1012

		[WIAProperty(4115)]
		public int GammaCurves
		{
			get { return this.GetPropertyValue<int>(4115); }
		} /*WIA_IPA_GAMMA_CURVES*/ // 0x1013

		[WIAProperty(4116)]
		public int ItemSize
		{
			get { return this.GetPropertyValue<int>(4116); }
		} /*WIA_IPA_ITEM_SIZE*/ // 0x1014

		[WIAProperty(4117)]
		public int ColorProfile
		{
			get { return this.GetPropertyValue<int>(4117); }
		} /*WIA_IPA_COLOR_PROFILE*/ // 0x1015

		[WIAProperty(4118)]
		public int MinBufferSize
		{
			get { return this.GetPropertyValue<int>(4118); }
		} /*WIA_IPA_MIN_BUFFER_SIZE*/ // 0x1016

		[WIAProperty(4118)]
		public int BufferSize
		{
			get { return this.GetPropertyValue<int>(4118); }
		} /*WIA_IPA_BUFFER_SIZE*/ // 0x1016


		[WIAProperty(4119)]
		public int RegionType
		{
			get { return this.GetPropertyValue<int>(4119); }
		} /*WIA_IPA_REGION_TYPE*/ // 0x1017

		[WIAProperty(4120)]
		public string IcmProfileName
		{
			get { return this.GetPropertyValue<string>(4120); }
			set { this.SetPropertyValue(4120,value); }
		} /*WIA_IPA_ICM_PROFILE_NAME*/ // 0x1018

		[WIAProperty(4121)]
		public int AppColorMapping
		{
			get { return this.GetPropertyValue<int>(4121); }
		} /*WIA_IPA_APP_COLOR_MAPPING*/ // 0x1019

		[WIAProperty(4122)]
		public string StreamCompatibilityID
		{
			get { return this.GetPropertyValue<string>(4122); }
		} /*WIA_IPA_PROP_STREAM_COMPAT_ID*/ // 0x101a

		[WIAProperty(4123)]
		public string FilenameExtension
		{
			get { return this.GetPropertyValue<string>(4123); }
		} /*WIA_IPA_FILENAME_EXTENSION*/ // 0x101b

		[WIAProperty(4124)]
		public SuppressPropertyPage SuppressPropertyPage
		{
			get { return this.GetPropertyValue<SuppressPropertyPage>(4124); }
		} /*WIA_IPA_SUPPRESS_PROPERTY_PAGE*/ // 0x101c

		[WIAProperty(4125)]
		public string ItemCategory
		{
			get { return this.GetPropertyValue<string>(4125); }
		} /*WIA_IPA_ITEM_CATEGORY*/  // 0x101d


		/// <summary>
		/// Upload Item Size
		/// The UploadItemSize property is used by applications to specify the number of bytes to upload for an item. The application creates and maintains this property.
		/// Versions: Available on Windows Vista and later operating systems.
		/// </summary>
		[WIAProperty(4126)]
		public int UploadItemSize
		{
			get { return this.GetPropertyValue<int>(4126); }
			set { this.SetPropertyValue(4126,value); }
		} /*WIA_IPA_UPLOAD_ITEM_SIZE*/  // 0x101e


		/// <summary>
		/// Items Stored
		/// The ItemsStored property specifies how many items are stored in the storage (WIA_CATEGORY_FOLDER) item. The WIA minidriver creates and maintains this WIA property. 
		/// Versions: Available in Windows Vista and later versions of the operating system. 
		/// </summary>
		[WIAProperty(4127)]
		public int ItemsStored
		{
			get { return this.GetPropertyValue<int>(4127); }
		} /*WIA_IPA_ITEMS_STORED*/  // 0x101f


		/// <summary>
		/// Raw Bits Per Channel
		/// The RawBitsPerChannel property contains the number of bits in each color channel. 
		/// The RawBitsPerChannel property should be reported as a vector that contains as many byte values as there are channels, where the first byte corresponds to the number of bits in the first channel, the second byte to the number of bits in the second channel, and so on. The vector must contain as many entries as the WIA_IPA_CHANNELS_PER_PIXEL property reports there are channels. The driver sets WIA_IPA_CHANNELS PER_PIXEL when the application sets WIA_IPA_FORMAT to WiaImgFmt_RAW.
		/// RawBitsPerChannel is similar to the WIA_IPA_BITS_PER_CHANNEL property (which is used for formats other than RAW).
		/// </summary>
		[WIAProperty(4128)]
		public UInt16 RawBitsPerChannel
		{
			get { return this.GetPropertyValue<UInt16>(4128); }
		} /*WIA_IPA_RAW_BITS_PER_CHANNEL*/  // 0x1020
    }
}
