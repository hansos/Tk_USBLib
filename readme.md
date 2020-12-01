# Tk USB Library (Tk_USBLib.dll)

## Goal
The goal with this project is to create one or several "easy to use" DotNet DLL's for communication with USB Devices. 


## Current status

### 2020-12-01
- The Event Listener is now using Win32_PnPEntity to sence device insertion/removal.
- The existing Device Info class (USBDevices) replaced with two other classes. One using Win32_PnPEntity, another using Win32_USBHub.
- A new Deveice Device info class (USBDevices)  class created, merging data from Win32_PnPEntity and Win32_USBHub.
- An interface for the two Device Info classes is added. 
- The Device Info function GetAllProperties() deleted.
- Project version numbering implemented.

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

##### Tk_USBLib.Device.USBHubDevices.GetAll();
Returns a list of DeviceInfo for all devices found, using Win32_USBHub.

##### Tk_USBLib.Device.USBPnpDevices.GetAll();
Returns a list of DeviceInfo for all devices found, using Win32_PnPEntity.

##### Tk_USBLib.Device.USBDevices.GetAllProperties()
Returns a string with Device Property names and values for for all devices found.

##### Tk_USBLib.Device.USBDevices.GetById(string deviceId)
Returns a single DeviceInfo object identified by deviceInfo received as parameter.

#### Interfaces
#### IUsbDevices
Used by USBHubDevices and USBPnpDevices.

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

## Useful links
[List of USB Ids on Linux-usb.org](http://www.linux-usb.org/usb.ids)
