using Microsoft.AspNetCore.Mvc;
using Parking.Main.Models;

namespace Parking.Main.Controllers
{
    public class TarifaController : Controller
    {
        public static List<TarifaViewModel> _tarifas = new();

        public ActionResult Index() => View(_tarifas);

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarifaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Id = _tarifas.Count + 1;
            _tarifas.Add(model);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var tarifa = _tarifas.Find(t => t.Id == id);
            if (tarifa == null) return NotFound();
            return View(tarifa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TarifaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var tarifa = _tarifas.Find(t => t.Id == model.Id);
            if (tarifa != null)
            {
                tarifa.Nombre = model.Nombre;
                tarifa.PrecioPorHora = model.PrecioPorHora;
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var tarifa = _tarifas.Find(t => t.Id == id);
            if (tarifa == null) return NotFound();
            return View(tarifa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tarifas.RemoveAll(t => t.Id == id);
            return RedirectToAction(nameof(Index));
        }
    }
}

