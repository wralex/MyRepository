using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public static class WIADevice
    {
        public static Device FromDeviceId(string deviceID)
        {
            DeviceManager deviceManager = new DeviceManager();
            foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos)
                if (deviceInfo.DeviceID == deviceID)
                    return deviceInfo.Connect();
            throw new ArgumentException("The Device with '" + deviceID + "' is unfound.");
        }

        public static Device FromUserDialog(
            WiaDeviceType deviceType = WiaDeviceType.UnspecifiedDeviceType, bool alwaysSelectDevice = false)
        {
            CommonDialog wiaDialog = new CommonDialog();
            return wiaDialog.ShowSelectDevice(deviceType, alwaysSelectDevice, false);
        }

        public static Device GetFirstScannerDevice()
        {
            DeviceManager deviceManager = new DeviceManager();
            foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos)
                if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                    return deviceInfo.Connect();
            throw new ArgumentException("The Scanner is unavailable.");
        }

        public static ScannerDevice AsScannerDevice(this Device device)
        {
            return new ScannerDevice(device);
        }
    }
}
