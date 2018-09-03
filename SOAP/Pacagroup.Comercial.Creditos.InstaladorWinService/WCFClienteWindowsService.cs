using Pacagroup.Comercial.Creditos.Implementacion;
using System.ServiceModel;
using System.ServiceProcess;


namespace Pacagroup.Comercial.Creditos.InstaladorWinService
{
    public class WCFClienteWindowsService : ServiceBase
    {
        private WCFClienteWindowsService()
        {
            ServiceName = "WCFServicioCliente";
        }

        public static void Main()
        {
            ServiceBase.Run(new WCFClienteWindowsService());
        }

        private ServiceHost _serviceHost = null;

        protected override void OnStart(string[] args)
        {
            _serviceHost?.Close();
            _serviceHost = new ServiceHost(typeof(ClienteService));
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (_serviceHost == null) return;
            _serviceHost.Close();
            _serviceHost = null;
        }
    }
}
