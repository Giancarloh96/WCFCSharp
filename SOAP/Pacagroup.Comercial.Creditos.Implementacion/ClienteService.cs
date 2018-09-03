using Pacagroup.Comercial.Creditos.Contrato;
using Pacagroup.Comercial.Creditos.Dominio;
using Pacagroup.Comercial.Creditos.Fachada;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pacagroup.Comercial.Creditos.Implementacion
{
    public class ClienteService : IClienteService
    {

        public Cliente ObtenerCliente(string numeroDocumento)
        {
            try
            {
                using (var instancia = new ClienteFachada())
                {
                    return instancia.ObtenerCliente(numeroDocumento);
                }
            }
            catch (Exception ex)
            {

                throw new FaultException<Error>(new Error() { CodigoError = "1001", Descripcion = "Excepcion administrada por el servicio", Mensaje = ex.Message });
            }


        }

        public IEnumerable<Cliente> ListarCliente()
        {
            using (var instancia = new ClienteFachada())
            {
                return instancia.ListarCliente();
            }
        }
    }
}
