using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib.Device
{
    /// <summary>
    /// Read information from Pnp devices.
    /// </summary>
    public class USBPnpDevices : IUSBDevices
    {
        /// <summary>
        /// Rerurns a list of DeviceInfo for all USB Pnp devices.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a DeviceInfo based on it's Device Id
        /// </summary>
        /// <param name="deviceId">Devcie Id to search</param>
        /// <returns></returns>
        public DeviceInfo GetById(string deviceId)
        {
            throw new NotImplementedException();
        }

    }
}
