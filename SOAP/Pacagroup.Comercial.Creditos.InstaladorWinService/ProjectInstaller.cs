using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
namespace Pacagroup.Comercial.Creditos.InstaladorWinService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            var process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            var service = new ServiceInstaller();
            service.ServiceName = "WCFServicioCliente";

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
