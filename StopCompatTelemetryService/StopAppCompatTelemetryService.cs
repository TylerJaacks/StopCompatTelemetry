// https://docs.microsoft.com/en-us/dotnet/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer
using System.ServiceProcess;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;

namespace StopComaptTelemetry
{
    public partial class StopAppCompatTelemetryService : ServiceBase
    {
        private IContainer components;
        private EventLog eventlog;
    
        public StopAppCompatTelemetryService()
        {
            InitializeComponent();
            
            eventlog = new EventLog();
            
            if (!System.Diagnostics.EventLog.SourceExists("StopAppCompatTelemetryServiceSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("StopAppCompatTelemetryServiceSource", "StopAppCompatTelemetryServiceLog");
            }
            
            eventlog.Source = "StopAppCompatTelemetryServiceSource";
            eventlog.Log = "StopAppCompatTelemetryServiceLog";
        }

        protected override void OnStart(string[] args)
        {
            eventlog.WriteEntry("StopAppCompatTelemetryService Started.");
        
            Timer timer = new System.Timers.Timer();
            
            timer.Interval = 60000;
            timer.Elapsed += new System.Timer.ElapsedTime(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            eventlog.WriteEntry("StopAppCompatTelemetryService Stoped.");
        }
        
        protected override void OnContinue()
        {
	        eventlog.WriteEntry("StopAppCompatTelemetryService Resuming.");
        }  
        
        public void OnTimer(object sender, ElapsedEventArg args)
        {
            eventlog.WriteEntry("Scanning for the resource hog AppCompatTelemetry.", EventLogEntryType.Information, eventId);
            
            KillCode killCode = new KillCode() ;
            killCode.KillProcess();
        }
    }
}
