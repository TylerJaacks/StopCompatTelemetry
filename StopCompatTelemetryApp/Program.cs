// Author: Tyler Jaacks

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
                    }

                    System.Threading.Thread.Sleep(5);
                }

                catch (Exception e) { }
            }
        }
    }
}
