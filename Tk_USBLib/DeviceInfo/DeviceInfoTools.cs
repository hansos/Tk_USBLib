using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib
{
    public static class DeviceInfoTools
    {
        internal static DeviceInfo CreateDeviceInfo(ManagementBaseObject device, ManagementBaseObject newEvent = null)
        {
            return new DeviceInfo
            {
                ClassPath = (string)newEvent?.ClassPath.ToString(),
                ConfigManagerUserConfig = (bool)device.GetPropertyValue("ConfigManagerUserConfig"),
                CreationClassName = (string)device.GetPropertyValue("CreationClassName"),
                Caption = (string)device.GetPropertyValue("Caption"),
                ConfigManagerErrorCode = Convert.ToInt32(device.GetPropertyValue("ConfigManagerErrorCode")),
                Description = (string)device.GetPropertyValue("Description"),
                DeviceId = (string)device.GetPropertyValue("DeviceID"),
                Name = (string)device.GetPropertyValue("Name"),
                PnpDeviceId = (string)device.GetPropertyValue("PNPDeviceID"),
                Status = (string)device.GetPropertyValue("Status"),
                SystemCreationClassName = (string)device.GetPropertyValue("SystemCreationClassName"),
                SystemName = (string)device.GetPropertyValue("SystemName"),
            };
        }
    }
}
