using Lw.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using PruebaZonaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PruebaZonaVirtual.Data;

namespace PruebaZonaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<ActionResult> Index()
        {
            var answer = new List<HttpClientModel>();
            Uri url = new Uri("http://pbiz.zonavirtual.com/api/Prueba/Consulta");
            var response = await Consume_service(url, new StringContent("", Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(response))
            {
                answer =  JsonConvert.DeserializeObject<List<HttpClientModel>>(response);
            }

            List<HttpClientModel> lstSinRepetidos = answer.Distinct().ToList();
            
            List<Comercio> lstComercio = new List<Comercio>();

            foreach (var item in lstSinRepetidos)
            {
                lstComercio.Add(new Comercio() { Comercio_codigo = item.comercio_codigo, Comercio_nombre = item.comercio_nombre, Comercio_nit = item.comercio_nit, Comercio_direccion = item.comercio_direccion });
            }

            context.Comercio.AddRange(lstComercio);
            context.SaveChanges();

            return View(answer);
        }
        
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public async Task<string> Consume_service(Uri url, HttpContent content)
        {
            using var httpClient = new HttpClient();
                        
            using var response = await Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, TimeSpan, retryCount, context) => { })
                .ExecuteAsync(() => httpClient.PostAsync(url, content)).ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            
        }
    }
}
