using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaisesApp.Models;
using System.Diagnostics;

namespace PaisesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<JsonResult> GetPais(string Pais)
        {
            PaisModels pais = null;

            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v2/name/" + Pais);

                if (response.IsSuccessStatusCode)
                {

                    HttpContent content = response.Content;
                    string data = await content.ReadAsStringAsync();
                    dynamic d = JsonConvert.DeserializeObject(data);
                    pais = new PaisModels

                    {
                        name = d[0].name,
                        region = d[0].region,
                        capital = d[0].capital,
                        flag = d[0].flags.svg
                    };

                    return Json(pais);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return Json(null);
        }
    }
}