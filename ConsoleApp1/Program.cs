﻿using System;
using System.Management;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Title = "Fetch hardware information of your computer.";
            Console.WriteLine("Fetch hardware information of your computer.");
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            Console.WriteLine();
            Console.WriteLine("Computer Name          :=> " +  GetComputerName());
            Console.WriteLine("Processor Information  :=> " + GetProcessorInformation());
            Console.WriteLine("Motherboard Maker      :=> " + GetBoardMaker());
            Console.WriteLine("Mothor Board Product ID:=> " + GetBoardProductId());
            Console.WriteLine("CD Rom                 :=> " + GetCdRomDrive());
            Console.WriteLine("BIOS Maker             :=> " + GetBIOSmaker());
            Console.WriteLine("Processor Id           :=> " + GetProcessorId());
            Console.WriteLine("HDD Serial No          :=> " + GetHDDSerialNo());
            Console.WriteLine("MAC Address            :=> " + GetMACAddress());
            Console.WriteLine("BIOS Serial No         :=> " + GetBIOSserNo());
            Console.WriteLine("BIOS Caption           :=> " + GetBIOScaption());
            Console.WriteLine("Account Name           :=> " + GetAccountName());
            Console.WriteLine("Physical Memory        :=> " + GetPhysicalMemory());
            Console.WriteLine("No of RAM Slots        :=> " + GetNoRamSlots());
            Console.WriteLine("CPU Speed In GHz       :=> " + GetCpuSpeedInGHz());
            Console.WriteLine("Current Language       :=> " + GetCurrentLanguage());
            Console.WriteLine("OS Information         :=> " + GetOSInformation());
            Console.WriteLine("CPU Manufacturer       :=> " + GetCPUManufacturer());
            Console.WriteLine("CPU Current Clock Speed:=> " + GetCPUCurrentClockSpeed());
            Console.WriteLine("Default IP Gateway     :=> " + GetDefaultIPGateway());

            Console.ReadKey();
        }


        public static String GetProcessorInformation()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                string name = (string)mo["Name"];
                name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");

                info = name + ", " + (string)mo["Caption"] + ", " + (string)mo["SocketDesignation"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }

        public static String GetComputerName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                info = (string)mo["Name"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }
        public static string GetBoardMaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }

            }

            return "Board Maker: Unknown";

        }

        public static string GetBoardProductId()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();

                }

                catch { }

            }

            return "Product: Unknown";

        }

        public static string GetCdRomDrive()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Drive").ToString();

                }

                catch { }

            }

            return "CD ROM Drive Letter: Unknown";

        }

        public static string GetBIOSmaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }


        public static string GetProcessorId()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;

        }

        public static string GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }

        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        public static string GetBIOSserNo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch { }
            }
            return "BIOS Serial Number: Unknown";
        }

        public static string GetBIOScaption()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();
                }
                catch { }
            }
            return "BIOS Caption: Unknown";
        }

        public static string GetAccountName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch { }
            }
            return "User Account Name: Unknown";
        }

        public static string GetPhysicalMemory()
        {
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oCollection = oSearcher.Get();

            long MemSize = 0;
            long mCap = 0;

            // In case more than one Memory sticks are installed
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemSize += mCap;
            }
            MemSize = (MemSize / 1024) / 1024;
            return MemSize.ToString() + "MB";
        }

        public static string GetNoRamSlots()
        {
            int MemSlots = 0;
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            ManagementObjectCollection oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);
            }
            return MemSlots.ToString();
        }

        public static double? GetCpuSpeedInGHz()
        {
            double? GHz = null;
            using (ManagementClass mc = new ManagementClass("Win32_Processor"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    GHz = 0.001 * (UInt32)mo.Properties["CurrentClockSpeed"].Value;
                    break;
                }
            }
            return GHz;
        }

        public static string GetCurrentLanguage()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("CurrentLanguage").ToString();
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }

        public static string GetOSInformation()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return ((string)wmi["Caption"]).Trim() + ", " + (string)wmi["Version"] + ", " + (string)wmi["OSArchitecture"];
                }
                catch { }
            }
            return "BIOS Maker: Unknown";
        }

        public static string GetCPUManufacturer()
        {
            string cpuMan = String.Empty;
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuMan == String.Empty)
                {
                    // only return manufacturer from first CPU
                    cpuMan = obj.Properties["Manufacturer"].Value.ToString();
                }
            }
            return cpuMan;
        }

        public static int GetCPUCurrentClockSpeed()
        {
            int cpuClockSpeed = 0;
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuClockSpeed == 0)
                {
                    // only return cpuStatus from first CPU
                    cpuClockSpeed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
                }
            }
            //return the status
            return cpuClockSpeed;
        }

        public static string GetDefaultIPGateway()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string gateway = String.Empty;
            //loop through all the objects we find
            foreach (ManagementObject obj in objCol)
            {
                if (gateway == String.Empty)  // only return MAC Address from first card
                {
                    //grab the value from the first network adapter we find
                    //you can change the string to an array and get all
                    //network adapters found as well
                    //check to see if the adapter's IPEnabled
                    //equals true
                    if ((bool)obj["IPEnabled"] == true)
                    {
                        gateway = obj["DefaultIPGateway"].ToString();
                    }
                }
                //dispose of our object
                obj.Dispose();
            }
            //replace the ":" with an empty space, this could also
            //be removed if you wish
            gateway = gateway.Replace(":", "");
            //return the mac address
            return gateway;
        }
    }
}
//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Fetch hardware information of your computer.");

//            Console.WriteLine("Processor Information  :=> " + GetProcessorInformation());
//            Console.WriteLine("Motherboard Maker      :=> " + GetBoardMaker());
//            Console.WriteLine("Mothor Board Product ID:=> " + GetBoardProductId());
//            Console.WriteLine("CD Rom                 :=> " + GetCdRomDrive());
//            Console.WriteLine("BIOS Maker             :=> " + GetBIOSmaker());
//            Console.WriteLine("Processor Id           :=> " + GetProcessorId());
//            Console.WriteLine("HDD Serial No          :=> " + GetHDDSerialNo());
//            Console.WriteLine("MAC Address            :=> " + GetMACAddress());
//            Console.WriteLine("BIOS Serial No         :=> " + GetBIOSserNo());
//            Console.WriteLine("BIOS Caption           :=> " + GetBIOScaption());
//            Console.WriteLine("Account Name           :=> " + GetAccountName());
//            Console.WriteLine("Physical Memory        :=> " + GetPhysicalMemory());
//            Console.WriteLine("No of RAM Slots        :=> " + GetNoRamSlots());
//            Console.WriteLine("CPU Speed In GHz       :=> " + GetCpuSpeedInGHz());
//            Console.WriteLine("Current Language       :=> " + GetCurrentLanguage());
//            Console.WriteLine("OS Information         :=> " + GetOSInformation());
//            Console.WriteLine("CPU Manufacturer       :=> " + GetCPUManufacturer());
//            Console.WriteLine("CPU Current Clock Speed:=> " + GetCPUCurrentClockSpeed());
//            Console.WriteLine("Default IP Gateway     :=> " + GetDefaultIPGateway());
//        }

//        public static String GetProcessorInformation()
//        {
//            ManagementClass mc = new ManagementClass("win32_processor");
//            ManagementObjectCollection moc = mc.GetInstances();
//            String info = String.Empty;
//            foreach (ManagementObject mo in moc)
//            {
//                string name = (string)mo["Name"];
//                name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");

//                info = name + ", " + (string)mo["Caption"] + ", " + (string)mo["SocketDesignation"];
//                //mo.Properties["Name"].Value.ToString();
//                //break;
//            }
//            return info;
//        }

//        public static String GetComputerName()
//        {
//            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
//            ManagementObjectCollection moc = mc.GetInstances();
//            String info = String.Empty;
//            foreach (ManagementObject mo in moc)
//            {
//                info = (string)mo["Name"];
//                //mo.Properties["Name"].Value.ToString();
//                //break;
//            }
//            return info;
//        }
//        public static string GetBoardMaker()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("Manufacturer").ToString();
//                }
//                catch { }

//            }

//            return "Board Maker: Unknown";

//        }

//        public static string GetBoardProductId()
//        {

//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("Product").ToString();

//                }

//                catch { }

//            }

//            return "Product: Unknown";

//        }

//        public static string GetCdRomDrive()
//        {

//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");

//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("Drive").ToString();

//                }

//                catch { }

//            }

//            return "CD ROM Drive Letter: Unknown";

//        }

//        public static string GetBIOSmaker()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("Manufacturer").ToString();
//                }
//                catch { }
//            }
//            return "BIOS Maker: Unknown";
//        }


//        public static string GetProcessorId()
//        {
//            ManagementClass mc = new ManagementClass("win32_processor");
//            ManagementObjectCollection moc = mc.GetInstances();
//            String Id = String.Empty;
//            foreach (ManagementObject mo in moc)
//            {

//                Id = mo.Properties["processorID"].Value.ToString();
//                break;
//            }
//            return Id;

//        }

//        public static string GetHDDSerialNo()
//        {
//            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
//            ManagementObjectCollection mcol = mangnmt.GetInstances();
//            string result = "";
//            foreach (ManagementObject strt in mcol)
//            {
//                result += Convert.ToString(strt["VolumeSerialNumber"]);
//            }
//            return result;
//        }

//        public static string GetMACAddress()
//        {
//            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
//            ManagementObjectCollection moc = mc.GetInstances();
//            string MACAddress = String.Empty;
//            foreach (ManagementObject mo in moc)
//            {
//                if (MACAddress == String.Empty)
//                {
//                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
//                }
//                mo.Dispose();
//            }

//            MACAddress = MACAddress.Replace(":", "");
//            return MACAddress;
//        }

//        public static string GetBIOSserNo()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("SerialNumber").ToString();
//                }
//                catch { }
//            }
//            return "BIOS Serial Number: Unknown";
//        }

//        public static string GetBIOScaption()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("Caption").ToString();
//                }
//                catch { }
//            }
//            return "BIOS Caption: Unknown";
//        }

//        public static string GetAccountName()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");
//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("Name").ToString();
//                }
//                catch { }
//            }
//            return "User Account Name: Unknown";
//        }

//        public static string GetPhysicalMemory()
//        {
//            ManagementScope oMs = new ManagementScope();
//            ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
//            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
//            ManagementObjectCollection oCollection = oSearcher.Get();

//            long MemSize = 0;
//            long mCap = 0;

//            // In case more than one Memory sticks are installed
//            foreach (ManagementObject obj in oCollection)
//            {
//                mCap = Convert.ToInt64(obj["Capacity"]);
//                MemSize += mCap;
//            }
//            MemSize = (MemSize / 1024) / 1024;
//            return MemSize.ToString() + "MB";
//        }

//        public static string GetNoRamSlots()
//        {
//            int MemSlots = 0;
//            ManagementScope oMs = new ManagementScope();
//            ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
//            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
//            ManagementObjectCollection oCollection2 = oSearcher2.Get();
//            foreach (ManagementObject obj in oCollection2)
//            {
//                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);
//            }
//            return MemSlots.ToString();
//        }

//        public static double? GetCpuSpeedInGHz()
//        {
//            double? GHz = null;
//            using (ManagementClass mc = new ManagementClass("Win32_Processor"))
//            {
//                foreach (ManagementObject mo in mc.GetInstances())
//                {
//                    GHz = 0.001 * (UInt32)mo.Properties["CurrentClockSpeed"].Value;
//                    break;
//                }
//            }
//            return GHz;
//        }

//        public static string GetCurrentLanguage()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return wmi.GetPropertyValue("CurrentLanguage").ToString();
//                }
//                catch { }
//            }
//            return "BIOS Maker: Unknown";
//        }

//        public static string GetOSInformation()
//        {
//            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
//            foreach (ManagementObject wmi in searcher.Get())
//            {
//                try
//                {
//                    return ((string)wmi["Caption"]).Trim() + ", " + (string)wmi["Version"] + ", " + (string)wmi["OSArchitecture"];
//                }
//                catch { }
//            }
//            return "BIOS Maker: Unknown";
//        }

//        public static string GetCPUManufacturer()
//        {
//            string cpuMan = String.Empty;
//            ManagementClass mgmt = new ManagementClass("Win32_Processor");
//            ManagementObjectCollection objCol = mgmt.GetInstances();
//            //start our loop for all processors found
//            foreach (ManagementObject obj in objCol)
//            {
//                if (cpuMan == String.Empty)
//                {
//                    // only return manufacturer from first CPU
//                    cpuMan = obj.Properties["Manufacturer"].Value.ToString();
//                }
//            }
//            return cpuMan;
//        }

//        public static int GetCPUCurrentClockSpeed()
//        {
//            int cpuClockSpeed = 0;
//            ManagementClass mgmt = new ManagementClass("Win32_Processor");
//            //create a ManagementObjectCollection to loop through
//            ManagementObjectCollection objCol = mgmt.GetInstances();
//            //start our loop for all processors found
//            foreach (ManagementObject obj in objCol)
//            {
//                if (cpuClockSpeed == 0)
//                {
//                    // only return cpuStatus from first CPU
//                    cpuClockSpeed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
//                }
//            }
//            //return the status
//            return cpuClockSpeed;
//        }

//        public static string GetDefaultIPGateway()
//        {
//            //create out management class object using the
//            //Win32_NetworkAdapterConfiguration class to get the attributes
//            //of the network adapter
//            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
//            //create our ManagementObjectCollection to get the attributes with
//            ManagementObjectCollection objCol = mgmt.GetInstances();
//            string gateway = String.Empty;
//            //loop through all the objects we find
//            foreach (ManagementObject obj in objCol)
//            {
//                if (gateway == String.Empty)  // only return MAC Address from first card
//                {
//                    //grab the value from the first network adapter we find
//                    //you can change the string to an array and get all
//                    //network adapters found as well
//                    //check to see if the adapter's IPEnabled
//                    //equals true
//                    if ((bool)obj["IPEnabled"] == true)
//                    {
//                        gateway = obj["DefaultIPGateway"].ToString();
//                    }
//                }
//                //dispose of our object
//                obj.Dispose();
//            }
//            //replace the ":" with an empty space, this could also
//            //be removed if you wish
//            gateway = gateway.Replace(":", "");
//            //return the mac address
//            return gateway;
//        }
//    }
//}
