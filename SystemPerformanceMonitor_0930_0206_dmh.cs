// 代码生成时间: 2025-09-30 02:06:24
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SystemPerformanceMonitorTool
{
    /// <summary>
    /// Class responsible for monitoring system performance metrics.
    /// </summary>
    public class SystemPerformanceMonitor
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter memoryCounter;

        /// <summary>
        /// Initializes a new instance of the SystemPerformanceMonitor class.
        /// </summary>
        public SystemPerformanceMonitor()
        {
            // Initialize performance counters for CPU and memory usage.
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        /// <summary>
        /// Retrieves the current CPU usage as a percentage.
        /// </summary>
        /// <returns>The current CPU usage percentage.</returns>
        public double GetCurrentCpuUsage()
        {
            try
            {
                return cpuCounter.NextValue();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while retrieving CPU usage.
                Console.WriteLine($"Error retrieving CPU usage: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Retrieves the current available memory in megabytes.
        /// </summary>
        /// <returns>The current available memory in megabytes.</returns>
        public float GetCurrentAvailableMemory()
        {
            try
            {
                return memoryCounter.NextValue();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while retrieving memory usage.
                Console.WriteLine($"Error retrieving memory usage: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Starts monitoring system performance and prints the metrics to the console.
        /// </summary>
        public void StartMonitoring()
        {
            Console.WriteLine("Starting system performance monitoring...");
            while (true)
            {
                double cpuUsage = GetCurrentCpuUsage();
                float memoryAvailable = GetCurrentAvailableMemory();

                // Print the current system performance metrics to the console.
                Console.WriteLine($"CPU Usage: {cpuUsage}%
Memory Available: {memoryAvailable} MB");

                // Wait for a second before printing the next set of metrics.
                Task.Delay(1000).Wait();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SystemPerformanceMonitor monitor = new SystemPerformanceMonitor();
            monitor.StartMonitoring();
        }
    }
}