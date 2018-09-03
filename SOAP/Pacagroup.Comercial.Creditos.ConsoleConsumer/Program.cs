using Pacagroup.Comercial.Creditos.ConsoleConsumer.ProxyCredito;
using Pacagroup.Comercial.Creditos.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Pacagroup.Comercial.Creditos.ConsoleConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rest();
            Soap();
        }

        private static void Rest()
        {
            WebClient proxy = new WebClient();
            string serviceURL = "http://localhost/WcfServiceCliente/CreditoService.svc/rest/ListarCreditos";
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);

            var obj = new DataContractJsonSerializer(typeof(IEnumerable<Credito>));

            IEnumerable<Credito> credito = obj.ReadObject(stream) as IEnumerable<Credito>;

            if (credito != null)
            {
                foreach (var item in credito)
                {
                    Console.WriteLine("IdCredito: " + item.idCredito + "Fecha: " + item.Fecha + "Monto: " + item.Monto);
                }
            }

            Console.ReadLine();
        }

        private static void Soap()
        {
            ProxyCredito.CreditoServiceClient proxy = new CreditoServiceClient();
            IEnumerable<Credito> coleccion = proxy.ListarCredito();

            if (coleccion != null)
            {
                foreach (var item in coleccion)
                {
                    Console.WriteLine("IdCredito: " + item.idCredito + "Fecha: " + item.Fecha + "Monto: " + item.Monto);
                }
            }

            if (proxy.State == System.ServiceModel.CommunicationState.Opened)
            {
                proxy.Close();
            }

            Console.ReadLine();
        }
    }
}
