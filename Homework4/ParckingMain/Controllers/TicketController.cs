using Microsoft.AspNetCore.Mvc;
using Parking.Main.Models;
using System.Net.Http.Json;

namespace Parking.Main.Controllers
{
    public class TicketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "https://localhost:7274";

        public TicketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Ticket/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiBaseUrl);

                // Obtener tickets
                var response = await client.GetAsync("/api/ticket");

                if (response.IsSuccessStatusCode)
                {
                    var tickets = await response.Content.ReadFromJsonAsync<List<TicketViewModel>>();
                    return View(tickets ?? new List<TicketViewModel>());
                }

                Console.WriteLine($"API Tickets respondió: {response.StatusCode}");
                return View(new List<TicketViewModel>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Index de Tickets: {ex.Message}");
                return View(new List<TicketViewModel>());
            }
        }

        // GET: Ticket/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiBaseUrl);

                // Obtener vehículos para el dropdown
                var responseVehiculos = await client.GetAsync("/api/vehiculo");

                if (responseVehiculos.IsSuccessStatusCode)
                {
                    var vehiculos = await responseVehiculos.Content.ReadFromJsonAsync<List<VehiculoViewModel>>();
                    ViewBag.Vehiculos = vehiculos ?? new List<VehiculoViewModel>();
                }
                else
                {
                    ViewBag.Vehiculos = new List<VehiculoViewModel>();
                }

                return View(new TicketViewModel());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Create (GET): {ex.Message}");
                ViewBag.Vehiculos = new List<VehiculoViewModel>();
                return View(new TicketViewModel());
            }
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.BaseAddress = new Uri(_apiBaseUrl);

                    // Establecer fecha de entrada si no viene
                    if (model.FechaEntrada == default)
                    {
                        model.FechaEntrada = DateTime.Now;
                    }

                    var response = await client.PostAsJsonAsync("/api/ticket", model);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine($"API respondió con error: {response.StatusCode}");
                        ModelState.AddModelError("", "Error al crear el ticket en la API");
                    }
                }

                // Si hay error, recargar vehículos
                await CargarVehiculosEnViewBag();
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Create (POST): {ex.Message}");
                ModelState.AddModelError("", $"Error: {ex.Message}");
                await CargarVehiculosEnViewBag();
                return View(model);
            }
        }

        // Método auxiliar para cargar vehículos
        private async Task CargarVehiculosEnViewBag()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiBaseUrl);

                var response = await client.GetAsync("/api/vehiculo");

                if (response.IsSuccessStatusCode)
                {
                    var vehiculos = await response.Content.ReadFromJsonAsync<List<VehiculoViewModel>>();
                    ViewBag.Vehiculos = vehiculos ?? new List<VehiculoViewModel>();
                }
                else
                {
                    ViewBag.Vehiculos = new List<VehiculoViewModel>();
                }
            }
            catch
            {
                ViewBag.Vehiculos = new List<VehiculoViewModel>();
            }
        }
    }
}