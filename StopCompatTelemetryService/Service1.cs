using System.ServiceProcess;


namespace StopComaptTelemetry
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            KillCode killCode = new KillCode() ;
            killCode.KillProcess();
        }

        protected override void OnStop()
        {
        }
    }
}
