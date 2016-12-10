using System;
using System.ComponentModel;
using System.Diagnostics;

namespace StopComaptTelemetry
{
    public class KillCode
    {
        public void KillProcess()
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
                catch (Win32Exception e)
                {
                    Console.WriteLine("The process is terminating or could not be terminated.");
                }

                catch (InvalidOperationException e)
                {
                    Console.WriteLine("The process has already exited.");
                }

                catch (Exception e)  // some other exception
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
    }
}
