using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebControlShoes.Data;
using WebControlShoes.Models;

namespace WebControlShoes.Controllers
{
    public class ModelosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelosController(ApplicationDbContext context)
        {
            _context = context;
        }
        //HTTP Get Index
        public IActionResult Modelos()
        {
            IEnumerable<Modelos> listModelos = _context.Modelos;
            return View(listModelos);
        }
        //HTTP Get Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Modelos modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Modelos.Add(modelo);
                _context.SaveChanges();

                TempData["mensaje"] = "El modelo se ha creado correctamente";

                return RedirectToAction("Modelos");
            }

            return View();
        }

        //HTTP Get Edit
        public IActionResult Edit(int? SKU)
        {
            if (SKU == null || SKU == 0)
            {
                return NotFound();
            }

            //Obtener el color
            var modelo = _context.Modelos.Find(SKU);

            if(modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        //HTTP Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Modelos modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Models.Update(modelo);
                _context.SaveChanges();

                TempData["mensaje"] = "El modelo se ha actualizado correctamente";
                return RedirectToAction("Modelos");
            }

            return View();
        }


        //HTTP Get Delete
        public IActionResult Delete(int? SKU)
        {
            if (SKU == null || SKU == 0)
            {
                return NotFound();
            }

            //Obtener el modelo
            var modelo = _context.Modelos.Find(SKU);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }


        //HTTP Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteModelos(int? SKU)
        {
            //Obtener color por id
            var modelo = _context.Colours.Find(SKU);

            if (modelo == null)
            {
                return NotFound();
            }
            _context.Modelos.Remove(modelo);
            _context.SaveChanges();

            TempData["mensaje"] = "El modelo se ha eliminado correctamente";
            return RedirectToAction("Modelos");
        }

    }

}
