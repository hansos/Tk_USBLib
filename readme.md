# Tk USB Library (Tk_USBLib.dll)

## Goal
The goal with this project is to create one or several "easy to use" DotNet DLL's for communication with USB Devices. 


## Current status
### 2020-11-29 (Initial version)
- Reading information about devices inserted. 
- Trigging an event when devces are inserted or removed.

## Reference
#### Requirements
- The solution uses MS Windows libraries and will not build on other platforms.
- The current version requires C# version 9 and DotNet 5.
- The project uses System.Management.dll which can be installed using the NuGet command `Install-Package System.Management -Version 5.0.0`.

#### Functions
##### Tk_USBLib.Device.USBDevices.GetAll();
Returns a list of DeviceInfo for all devices found.

##### Tk_USBLib.Device.USBDevices.GetAllProperties()
Returns a string with Device Property names and values for for all devices found.

##### Tk_USBLib.Device.USBDevices.GetById(string deviceId)
Returns a single DeviceInfo object identified by deviceInfo received as parameter.


#### Triggers
##### Tk_USBLib.DeviceDeviceChangedEvenHandler
Fires when a device is inserted or removed.

#### Properties
##### Tk_USBLib.DeviceInfo
Information about the requested device.

## Roadmap
- Support Win32_PnPEntity. 
- Add a class for reading/writing data.
- ~~Create a User Manual / Reference guide in this Readme (Done).~~

