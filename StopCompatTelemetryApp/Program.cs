using System;
using System.ComponentModel;
using System.Diagnostics;

namespace StopCompatTelemetry
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    foreach (Process process in Process.GetProcessesByName("CompatTelRunner"))
                    {
                        process.Kill();
                        Console.WriteLine("Successfully killed the process.");
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
    }
}
