using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace USBLib.Device
{
    public class USBDevices
    {

        public string GetAllProperties()
        {
            StringBuilder sb = new();
            ManagementObjectCollection devices;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                devices = searcher.Get();

            foreach (var device in devices)
                foreach (var property in device.Properties)
                    sb.AppendLine($"{property.Name}={property.Value}");

            return sb.ToString();
        }


        public DeviceInfo GetById(string deviceId)
        {
            var devices = GetAll();
            foreach (var device in devices)
                if (device.DeviceId.Equals(deviceId.Trim()))
                    return device;
           return null;
        }

        public List<DeviceInfo> GetAll()
        {
            try
            {
                List<DeviceInfo> allDevices = new ();
                ManagementObjectCollection devices;

                using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                    devices = searcher.Get();

                foreach (var device in devices)
                    allDevices.Add(CreateDeviceInfo(device));

                devices.Dispose();
                return allDevices;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    
        internal static DeviceInfo CreateDeviceInfo(ManagementBaseObject device, ManagementBaseObject newEvent=null)
        {
            return new DeviceInfo
            {
                ClassPath = (string) newEvent?.ClassPath.ToString(),
                ConfigManagerUserConfig = (bool) device.GetPropertyValue("ConfigManagerUserConfig"),
                CreationClassName = (string) device.GetPropertyValue("CreationClassName"),
                Caption = (string) device.GetPropertyValue("Caption"),
                ConfigManagerErrorCode = Convert.ToInt32(device.GetPropertyValue("ConfigManagerErrorCode")),
                Description = (string) device.GetPropertyValue("Description"),
                DeviceId = (string) device.GetPropertyValue("DeviceID"),
                Name = (string) device.GetPropertyValue("Name"),
                PnpDeviceId = (string) device.GetPropertyValue("PNPDeviceID"),
                Status = (string) device.GetPropertyValue("Status"),
                SystemCreationClassName = (string) device.GetPropertyValue("SystemCreationClassName"),
                SystemName = (string) device.GetPropertyValue("SystemName"),
            };
        }

    }
}
