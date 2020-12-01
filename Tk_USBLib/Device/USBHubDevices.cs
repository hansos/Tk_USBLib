using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace Tk_USBLib.Device
{
    public class USBHubDevices : IUSBDevices
    {

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
                    allDevices.Add(DeviceInfoTools.CreateDeviceInfo(device));

                devices.Dispose();
                return allDevices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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



    }
}
