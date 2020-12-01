using System.Management;

namespace Tk_USBLib
{
    public class DeviceInfo
    {
        #region string constants

        private const string V00 = "This device is working properly";
        private const string V01 = "This device is not configured correctly";
        private const string V02 = "Windows cannot load the driver for this device";
        private const string V03 = "The driver for this device might be corrupted, or your system may be running low on memory or other resources";
        private const string V04 = "This device is not working properly. One of its drivers or your registry might be corrupted";
        private const string V05 = "The driver for this device needs a resource that Windows cannot manage";
        private const string V06 = "The boot configuration for this device conflicts with other devices";
        private const string V07 = "Cannot filter";
        private const string V08 = "The driver loader for the device is missing";
        private const string V09 = "This device is not working properly because the controlling firmware is reporting the resources for the device incorrectly";
        private const string V10 = "This device cannot start";
        private const string V11 = "This device failed";
        private const string V12 = "This device cannot find enough free resources that it can use";
        private const string V13 = "Windows cannot verify this device's resources";
        private const string V14 = "This device cannot work properly until you restart your computer";
        private const string V15 = "This device is not working properly because there is probably a re-enumeration problem";
        private const string V16 = "Windows cannot identify all the resources this device uses";
        private const string V17 = "This device is asking for an unknown resource type";
        private const string V18 = "Reinstall the drivers for this device";
        private const string V19 = "Failure using the VxD loader";
        private const string V20 = "Your registry might be corrupted";
        private const string V21 = "System failure: Try changing the driver for this device. If that does not work, see your hardware documentation. Windows is removing this device";
        private const string V22 = "This device is disabled";
        private const string V23 = "System failure: Try changing the driver for this device. If that doesn't work, see your hardware documentation";
        private const string V24 = "This device is not present, is not working properly, or does not have all its drivers installed";
        private const string V25 = "Windows is still setting up this device";
        private const string V26 = "Windows is still setting up this device";
        private const string V27 = "This device does not have valid log configuration";
        private const string V28 = "The drivers for this device are not installed";
        private const string V29 = "This device is disabled because the firmware of the device did not give it the required resources";
        private const string V30 = "This device is using an Interrupt Request (IRQ) resource that another device is using";
        private const string V31 = "This device is not working properly because Windows cannot load the drivers required for this device";
        
        #endregion

        #region Construction

        public DeviceInfo()
        {
        }

        public DeviceInfo(string deviceId, string pnpDeviceId, string description)
        {
            DeviceId = deviceId;
            PnpDeviceId = pnpDeviceId;
            Description = description;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Short textual description of the object. This property is inherited from the CIM_ManagedSystemElement.
        /// </summary>
        public string Caption { get; init; }

        /// <summary>
        /// Win32 Configuration Manager error code.
        /// </summary>
        public int ConfigManagerErrorCode { get; init; }

        /// <summary>
        /// Descriptive text for the current ConfigManagerErrorCode property
        /// </summary>
        public string ConfigManagerErrorCodeText { 
            get 
            {
                return ConfigManagerErrorCode switch
                {
                    0 => V00, 1 => V01, 2 => V02, 3 => V03, 4 => V04, 5 => V05,
                    6 => V06, 7 => V07, 8 => V08, 9 => V09, 10 => V10,
                    11 => V11, 12 => V12, 13 => V13, 14 => V14, 15 => V15,
                    16 => V16, 17 => V17, 18 => V18, 19 => V19,  20 => V20,
                    21 => V21, 22 => V22, 23 => V23, 24 => V24, 25 => V25,
                    26 => V26,  27 => V27, 28 => V28, 29 => V29, 30 => V30,
                    31 => V31, _ => "",
                };
            } 
        }


        /// <summary>
        /// Gets the path to the management object's class.
        /// </summary>
        public string ClassPath { get; init; }

        /// <summary>
        /// User configurations is registered for the device.
        /// </summary>
        public bool ConfigManagerUserConfig { get; init; }

        /// <summary>
        /// Name of the class or subclass used in the creation of an instance. 
        /// When used with other key properties of the class, this property allows all instances of 
        /// the class and its subclasses to be uniquely identified. 
        /// This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string CreationClassName { get; init; }

        /// <summary>
        /// Textual description of the object. This property is inherited from CIM_ManagedSystemElement.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// An address or other identifying information which uniquely identifies the USBHub.
         /// </summary>
        public string DeviceId { get; init; }

        /// <summary>
        /// Label by which the object is known. When subclassed, this property can be overridden to be a key property.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Win32 Plug and Play device identifier of the logical device.
        /// </summary>
        public string PnpDeviceId { get; init; }

        /// <summary>
        /// Current status of the object. This property is inherited from CIM_ManagedSystemElement.
        /// </summary>
        public string Status { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public string SystemCreationClassName { get; init; }

        /// <summary>
        /// Scoping system's name. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string SystemName { get; init; }

        #endregion
    }
}
