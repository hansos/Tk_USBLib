using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace Tk_USBLib.Device
{
    /// <summary>
    /// Read information from HUB devices.
    /// </summary>
    public class USBHubDevices : IUSBDevices
    {
        /// <summary>
        /// Rerurns a list of DeviceInfo for all USB HUB devices.
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfo> GetAll()
        {
            try
            {
                List<DeviceInfo> allDevices = new();
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

        /// <summary>
        /// Returns a DeviceInfo based on it's Device Id
        /// </summary>
        /// <param name="deviceId">Devcie Id to search</param>
        /// <returns></returns>
        public DeviceInfo GetById(string deviceId)
        {
            var devices = GetAll();
            foreach (var device in devices)
                if (device.DeviceId.Equals(deviceId.Trim()))
                    return device;
           return null;
        }



    }
}
