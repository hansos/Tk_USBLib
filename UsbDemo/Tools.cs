using System.Text;
using Tk_USBLib;

namespace USBDemo
{
    internal static class Tools
    {

        internal static string DeviceDescriptionText(DeviceInfo deviceInfo)
        {
            //With of the label column
            const int c1 = -30;

            StringBuilder sb = new();
            sb.AppendLine();
            sb.AppendLine($"***** {deviceInfo.DeviceId} - {deviceInfo.Caption} *****");
            sb.AppendLine($"{"Class path:",c1} {deviceInfo.ClassPath}");
            sb.AppendLine($"{"User Config:",c1} {deviceInfo.ConfigManagerUserConfig}");
            sb.AppendLine($"{"Creation Class Name:",c1} {deviceInfo.CreationClassName}");
            sb.AppendLine($"{"Description:",c1} {deviceInfo.Description}");
            sb.AppendLine($"{"Name:",c1} {deviceInfo.Name}");
            sb.AppendLine($"{"PnpDeviceId:",c1} {deviceInfo.PnpDeviceId}");
            sb.AppendLine($"{"Status:",c1} {deviceInfo.Status}");
            sb.AppendLine($"{"SystemCreationClassName:",c1} {deviceInfo.SystemCreationClassName}");
            sb.AppendLine($"{"System Name:",c1} {deviceInfo.SystemName}");
            sb.AppendLine($"{"Error code:",c1} {deviceInfo.ConfigManagerErrorCode} - {deviceInfo.ConfigManagerErrorCodeText} ");


            return sb.ToString();

        }

        internal static string DeviceEventDescriptionText(DeviceInfo deviceInfo, Tk_USBLib.Device.USBDetectionEventType action)
        {
            StringBuilder sb = new();
            sb.AppendLine();
            sb.AppendLine($"Device {action}:");
            sb.AppendLine(DeviceDescriptionText(deviceInfo));
            return sb.ToString();
        }
    }
}
