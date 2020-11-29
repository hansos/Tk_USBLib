using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBLib.Device
{

    /// <summary>
    /// Event types supported by this application.
    /// </summary>
    public enum USBDetectionEventType
    {
        Inserted,
        Removed,
    }

    /// <summary>
    /// Event arguments containing kind of event and information about the device inserted / removed.
    /// </summary>
    public class USBDetectionEventArgs : EventArgs
    {
        public USBDetectionEventType Action { get; set; }

        public DeviceInfo DeviceInfo;
    }

}
