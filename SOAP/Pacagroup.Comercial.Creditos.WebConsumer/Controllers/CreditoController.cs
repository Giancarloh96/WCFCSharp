using Pacagroup.Comercial.Creditos.WebConsumer.Models.Credito;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pacagroup.Comercial.Creditos.WebConsumer.Controllers
{
    public class CreditoController : Controller
    {
        public string Enconding { get; private set; }

        // GET: Credito
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("WcfServiceCliente/CreditoService.svc/rest/ListarCreditos");

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<CreditoViewModel>));
                    List<CreditoViewModel> response = obj.ReadObject(result) as List<CreditoViewModel>;
                    return View(response);
                }
                return View();
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreditoViewModel credito)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ser = new DataContractJsonSerializer(typeof(CreditoViewModel));
                var men = new MemoryStream();
                ser.WriteObject(men, credito);
                string data = Encoding.UTF8.GetString(men.ToArray(), 0, (int)men.Length);

                HttpResponseMessage res = await client.PostAsync("WcfServiceCliente/CreditoService.svc/rest/RegistrarCredito", new StringContent(data, Encoding.UTF8, "application/json"));

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<ActionResult> Edit(int idCredito)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("WcfServiceCliente/CreditoService.svc/rest/ObtenerCredito/" + idCredito);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStreamAsync().Result;
                    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(CreditoViewModel));
                    CreditoViewModel response = obj.ReadObject(result) as CreditoViewModel;
                    return View(response);
                }
                return View();
            }

        }
    }
}