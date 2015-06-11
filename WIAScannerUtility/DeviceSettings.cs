using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public class DeviceSettings : WIASettings
    {
        public DeviceSettings(IProperties properties)
            : base(properties)
        { }

        [WIAProperty(2)]
        public string DeviceID
        {
            get { return this.GetPropertyValue<string>(2); }
        } /*WIA_DIP_DEV_ID*/  // 0x2

        [WIAProperty(3)]
        public string VendorDescription
        {
            get { return this.GetPropertyValue<string>(3); }
        } /*WIA_DIP_VEND_DESC*/  // 0x3

        [WIAProperty(4)]
        public string DeviceDescription
        {
            get { return this.GetPropertyValue<string>(4); }
        } /*WIA_DIP_DEV_DESC*/  // 0x4

        [WIAProperty(5)]
        public WiaDeviceType DeviceType
        {
            get { return this.GetPropertyValue<WiaDeviceType>(5); }
        } /*WIA_DIP_DEV_TYPE*/  // 0x5

        [WIAProperty(6)]
        public string PortName
        {
            get { return this.GetPropertyValue<string>(6); }
        } /*WIA_DIP_PORT_NAME*/  // 0x6

        [WIAProperty(7)]
        public string DeviceName
        {
            get { return this.GetPropertyValue<string>(7); }
        } /*WIA_DIP_DEV_NAME*/  // 0x7

        [WIAProperty(8)]
        public string ServerName
        {
            get { return this.GetPropertyValue<string>(8); }
        } /*WIA_DIP_SERVER_NAME*/  // 0x8

        [WIAProperty(9)]
        public string RemoteDeviceID
        {
            get { return this.GetPropertyValue<string>(9); }
        } /*WIA_DIP_REMOTE_DEV_ID*/  // 0x9

        [WIAProperty(10)]
        public string UiClassID
        {
            get { return this.GetPropertyValue<string>(10); }
        } /*WIA_DIP_UI_CLSID*/  // 0xa

        [WIAProperty(11)]
        public HardwareConfiguration HardwareConfiguration
        {
            get { return this.GetPropertyValue<HardwareConfiguration>(11); }
        } /*WIA_DIP_HW_CONFIG*/  // 0xb

        [WIAProperty(12)]
        public string Baudrate
        {
            get { return this.GetPropertyValue<string>(12); }
        } /*WIA_DIP_BAUDRATE*/  // 0xc

        [WIAProperty(13)]
        public int StiGenericCapabilities
        {
            get { return this.GetPropertyValue<int>(13); }
        } /*WIA_DIP_STI_GEN_CAPABILITIES*/  // 0xd

        [WIAProperty(14)]
        public string WiaVersion
        {
            get { return this.GetPropertyValue<string>(14); }
        } /*WIA_DIP_WIA_VERSION*/  // 0xe

        [WIAProperty(15)]
        public string DriverVersion
        {
            get { return this.GetPropertyValue<string>(15); }
        } /*WIA_DIP_DRIVER_VERSION*/  // 0xf

        [WIAProperty(16)]
        public string PnpID
        {
            get { return this.GetPropertyValue<string>(16); }
        } /*WIA_DIP_PNP_ID*/  // 0x10

        [WIAProperty(17)]
        public string StiDriverVersion
        {
            get { return this.GetPropertyValue<string>(17); }
        } /*WIA_DIP_STI_DRIVER_VERSION*/  // 0x11

        [WIAProperty(1026)]
        public string FirmwareVersion
        {
            get { return this.GetPropertyValue<string>(1026); }
        } /*WIA_DPA_FIRMWARE_VERSION*/  // 0x402

        [WIAProperty(1027)]
        public ConnectionStatus ConnectionStatus
        {
            get { return this.GetPropertyValue<ConnectionStatus>(1027); }
        } /*WIA_DPA_CONNECT_STATUS*/  // 0x403

        [WIAProperty(1028)]
        public UInt16 DeviceTime
        {
            get { return this.GetPropertyValue<UInt16>(1028); }
            set { this.SetPropertyValue(1028, value); }
        } /*WIA_DPA_DEVICE_TIME*/  // 0x404
    }
}
