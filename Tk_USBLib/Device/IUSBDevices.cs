using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib.Device
{
    public interface IUSBDevices
    {
        /// <summary>
        /// Rerurns a list of DeviceInfo for all USB Pnp devices.
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfo> GetAll();

        /// <summary>
        /// Returns a DeviceInfo based on it's Device Id
        /// </summary>
        /// <param name="deviceId">Devcie Id to search</param>
        /// <returns></returns>
        public DeviceInfo GetById(string deviceId);

    }
}
