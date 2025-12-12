using Microsoft.AspNetCore.Mvc;
using Parking.Main.Models;
using System.Net.Http.Json;

namespace Parking.Main.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "https://localhost:7274";

        public VehiculoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiBaseUrl);

                var response = await client.GetAsync("/api/vehiculo");

                if (response.IsSuccessStatusCode)
                {
                    var vehiculos = await response.Content.ReadFromJsonAsync<List<VehiculoViewModel>>();
                    return View(vehiculos ?? new List<VehiculoViewModel>());
                }

                return View(new List<VehiculoViewModel>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return View(new List<VehiculoViewModel>());
            }
        }

        // GET: Vehiculo/Create
        public async Task<IActionResult> Create()
        {
            // ¡IMPORTANTE: Usar VehiculoViewModel, NO TicketViewModel!
            var model = new VehiculoViewModel();

            // Cargar clientes
            await CargarClientesEnViewBag();

            return View(model);
        }

        // POST: Vehiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiculoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    client.BaseAddress = new Uri(_apiBaseUrl);

                    var response = await client.PostAsJsonAsync("/api/vehiculo", model);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            await CargarClientesEnViewBag();
            return View(model);
        }

        private async Task CargarClientesEnViewBag()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiBaseUrl);

                var response = await client.GetAsync("/api/cliente");

                if (response.IsSuccessStatusCode)
                {
                    var clientes = await response.Content.ReadFromJsonAsync<List<ClienteViewModel>>();
                    ViewBag.Clientes = clientes ?? new List<ClienteViewModel>();
                }
                else
                {
                    ViewBag.Clientes = new List<ClienteViewModel>();
                }
            }
            catch
            {
                ViewBag.Clientes = new List<ClienteViewModel>();
            }
        }

        // Otros métodos (Edit, Details, Delete) aquí...
    }
}