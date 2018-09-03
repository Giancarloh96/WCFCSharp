using System.Configuration;

namespace Pacagroup.Comercial.Creditos.SqlRepositorio
{
    public class ConexionRepositorio
    {
        public static string ObtenerCadenaConexion() => ConfigurationManager.ConnectionStrings["CreditosDB"].ToString();
    }
}
