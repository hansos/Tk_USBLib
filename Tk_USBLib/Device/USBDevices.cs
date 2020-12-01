using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib.Device
{
    /// <summary>
    /// Merge devices from Hub and Pnp
    /// </summary>
    public class USBDevices : IUSBDevices
    {

        /// <summary>
        /// Rerurns a list of DeviceInfo for all USB Pnp devices.
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfo> GetAll()
        {
            var mergeList = new USBHubDevices().GetAll();
            var pnpDevices = new USBPnpDevices().GetAll();
            foreach(var pnpDevice in pnpDevices)
                if (!mergeList.Exists(o => o.DeviceId.Equals(pnpDevice.DeviceId)))
                    mergeList.Add(pnpDevice);
            return mergeList;
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
