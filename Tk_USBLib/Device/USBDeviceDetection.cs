using System;
using System.Management;

namespace Tk_USBLib.Device
{
    /// <summary>
    /// Encapsulates any method that takes an object and a USBDetectionEventArgs.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// In most cases, the we don't need to use the delegate.
    /// </remarks>
    public delegate void DeviceChangedEvenHandler(Object sender, USBDetectionEventArgs e);


    /// <summary>
    /// The class uses Windows Management Instrumentation (WMI) to get information about 
    /// USB devices inserted or removed from the system.
    /// </summary>
    /// <remarks>
    /// The System.Management.dll NuGet package must be installed to use this class. 
    /// Not all kind of devises will be detected by the class.
    /// </remarks>
    public class USBDeviceDetection
    {
        /// <summary>
        /// Fired when USB Device is inserted or removed.
        /// </summary>
        public event EventHandler<USBDetectionEventArgs> DeviceChangedEvenHandler;


        /// <summary>
        /// Fires an EventArrivedEventArgs when a device is inserted. 
        /// </summary>
        /// <param name="sender">Reference to the current USBDeviceDetection instance.</param>
        /// <param name="e">Device Status and description</param>        
        public void DeviceInsertedEvent(object sender, EventArrivedEventArgs e) =>
            DeviceChangedEvenHandler?.Invoke(this, CreateEventArg(USBDetectionEventType.Inserted, e));


        /// <summary>
        /// Fires an EventArrivedEventArgs when a device is removed. 
        /// </summary>
        /// <param name="sender">Reference to the current USBDeviceDetection instance.</param>
        /// <param name="e">Device Status and description</param>        
        public void DeviceRemovedEvent(object sender, EventArrivedEventArgs e) =>
            DeviceChangedEvenHandler?.Invoke(this, CreateEventArg(USBDetectionEventType.Removed, e));

       
        /// <summary>
        /// Start watchers
        /// </summary>
        public void Start()
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();
        }

        /// <summary>
        /// creates an USBDetectionEventArgs object with available information
        /// about the detected USB device.
        /// </summary>
        /// <param name="eventType">Kund of action detected (inserted, removed).</param>
        /// <param name="e">nformation about the arrived event.</param>
        /// <returns></returns>
        USBDetectionEventArgs CreateEventArg(USBDetectionEventType eventType, EventArrivedEventArgs e)
        {
            //Todo: Can more information be added from the EventArrivedEventArgs?
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            var deviceInfo = DeviceInfoTools.CreateDeviceInfo(instance, e.NewEvent);
            return new USBDetectionEventArgs { Action = eventType, DeviceInfo = deviceInfo };
        }

    }
}
