using Pacagroup.Comercial.Creditos.Contrato;
using Pacagroup.Comercial.Creditos.Dominio;
using Pacagroup.Comercial.Creditos.Fachada;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pacagroup.Comercial.Creditos.Implementacion
{
    public class CreditoService : ICreditoService
    {
        public Credito ActualizarCredito(Credito credito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.ActualizarCredito(credito);
            }
        }

        public bool EliminarCredito(string idCredito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.EliminarCredito(idCredito);
            }
        }

        public IEnumerable<Credito> ListarCredito()
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.ListarCredito();
            }
        }

        public Credito RegistrarCredito(Credito credito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.RegistrarCredito(credito);
            }
        }

        public Credito ObtenerCredito(string idCredito)
        {
            try
            {
                using (var instancia = new CreditoFachada())
                {
                    return instancia.ObtenerCredito(idCredito);
                }
            }
            catch (System.Exception ex)
            {
                throw new FaultException<Error>(new Error() { CodigoError = "1001", Descripcion = "Excepcion administrada por el servicio", Mensaje = ex.Message });
            }

        }
    }
}
