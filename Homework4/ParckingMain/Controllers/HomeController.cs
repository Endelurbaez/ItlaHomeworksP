using Microsoft.AspNetCore.Mvc;
using Parking.Main.Models;
using System.Diagnostics;

namespace Parking.Main.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Mensaje = "Ha ocurrido un error inesperado"
            };
            return View(model);
        }
    }
}
