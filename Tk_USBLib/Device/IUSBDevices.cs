using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tk_USBLib.Device
{
    public interface IUSBDevices
    {

        public List<DeviceInfo> GetAll();

        public DeviceInfo GetById(string deviceId);

        public string GetAllProperties();

    }
}
