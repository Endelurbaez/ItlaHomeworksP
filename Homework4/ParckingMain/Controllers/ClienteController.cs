using Microsoft.AspNetCore.Mvc;
using Parking.Main.Models;

namespace Parking.Main.Controllers
{
    public class ClienteController : Controller
    {
        public static List<ClienteViewModel> _clientes = new();

        public IActionResult Index()
        {
            return View(_clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = _clientes.Count + 1;
                _clientes.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var existing = _clientes.Find(c => c.Id == cliente.Id);
                if (existing != null)
                {
                    existing.Nombre = cliente.Nombre;
                    existing.Cedula = cliente.Cedula;
                    existing.Telefono = cliente.Telefono;
                    existing.Correo = cliente.Correo;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            return cliente == null ? NotFound() : View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clientes.RemoveAll(c => c.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}

