using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib.Device
{
    public class USBDevices : IUSBDevices
    {

        public List<DeviceInfo> GetAll()
        {
            var mergeList = new USBHubDevices().GetAll();
            var pnpDevices = new USBPnpDevices().GetAll();
            foreach(var pnpDevice in pnpDevices)
                if (!mergeList.Exists(o => o.DeviceId.Equals(pnpDevice.DeviceId)))
                    mergeList.Add(pnpDevice);
            return mergeList;
        }

        public string GetAllProperties()
        {
            throw new NotImplementedException();
        }

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
