using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Devices;

namespace WindowsService_liulu
{

    public class SystemStatus
    {

        public static string getCpuUsageByProcessName(string processname)
        {
            string result = "";
            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Process";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = processname;
                result = cpuCounter.NextValue() + "%";
                System.Threading.Thread.Sleep(1000);
                result = cpuCounter.NextValue().ToString("F3") + "%";
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return result;
        }

        public static string getMemoryUsageByProcessName(string processname)
        {

            ComputerInfo ci = new ComputerInfo();
            double total_memory = ci.TotalPhysicalMemory;

            string result = "";
            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Process";
                cpuCounter.CounterName = "Working Set";
                cpuCounter.InstanceName = processname;

                return (cpuCounter.NextValue() / total_memory * 100).ToString("F3") + "%";
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return result;
        }


        public static string getTotalCpuUsage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            string result = cpuCounter.NextValue() + "%";
            System.Threading.Thread.Sleep(1000);
            result = cpuCounter.NextValue().ToString("F3") + "%";
            return result;
        }

        public static string getTotalRAMUsage()
        {
            ComputerInfo ci = new ComputerInfo();
            double total_memory = ci.TotalPhysicalMemory / 1024 / 1024;

            PerformanceCounter ramCounter;
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return ((1 - ramCounter.NextValue() / total_memory) * 100).ToString("F3") + "%";
        }


        public static void getDiskUsage()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine(drive.Name + " " + drive.TotalFreeSpace / 1073741824 + "GB/" + drive.TotalSize / 1073741824 + "GB");
                }

            }
        }
    }
}
