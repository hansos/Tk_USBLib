using System;
using Tk_USBLib.Device;

namespace USBDemo
{
    class Program
    {

        private static void UsbChangeDetected(object sender, USBDetectionEventArgs e) =>
            Console.WriteLine(value: $"{Tools.DeviceEventDescriptionText(e.DeviceInfo, e.Action)}");


        public static void Main(string[] args)
        {
            Console.WriteLine("Tk_UsbLib demo program");
            Console.WriteLine("======================");
            Console.WriteLine();

            Console.WriteLine("Devices found:");
            Console.WriteLine("--------------");

            //Show currently installed devices:
            IUSBDevices usbDevices;
            usbDevices = new USBDevices();
            //usbDevices = new USBHubDevices();
            //usbDevices = new USBPnpDevices();

            var deviceInfos = usbDevices.GetAll();
            foreach (var deviceInfo in deviceInfos)
                Console.WriteLine(Tools.DeviceDescriptionText(deviceInfo));



            //Start the listener
            USBDeviceDetection d = new();
            d.DeviceChangedEvenHandler += UsbChangeDetected;
            d.Start();

            //Write some instructions and wait...
            Console.WriteLine();
            Console.WriteLine("Insert or remove devices to print device information.");
            Console.WriteLine("Press a key to exit.");
            Console.WriteLine();


            //Close application when done.
            Console.ReadKey();
        }



    }
}
