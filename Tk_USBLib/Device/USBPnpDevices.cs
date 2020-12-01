using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib.Device
{
    public class USBPnpDevices : IUSBDevices
    {
        public List<DeviceInfo> GetAll()
        {

            try
            {
                List<DeviceInfo> allDevices = new();
                ManagementObjectCollection devices;
                ManagementScope scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\CIMV2");

                using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                    devices = searcher.Get();

                foreach (var device in devices)
                    if (device.Properties["Name"].Value != null && device.Properties["Name"].Value.ToString().StartsWith("USB"))
                        allDevices.Add(DeviceInfoTools.CreateDeviceInfo(device));

                devices.Dispose();
                return allDevices;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DeviceInfo GetById(string deviceId)
        {
            throw new NotImplementedException();
        }


        public string GetAllProperties()
        {
            StringBuilder sb = new();
            List<DeviceInfo> allDevices = new();
            ManagementObjectCollection devices;
            ManagementScope scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\CIMV2");

            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                devices = searcher.Get();
            foreach (var device in devices)
                foreach (var property in device.Properties)
                    sb.AppendLine($"{property.Name}={property.Value}");

            return sb.ToString();
        }



    }
}
