using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebControlShoes.Data;
using WebControlShoes.Models;

namespace WebControlShoes.Controllers
{
    public class ModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //HTTP Get Index
        public IActionResult Models()
        {
            IEnumerable<Models> listModels = _context.Models;
            return View(listModels);
        }
        //HTTP Get Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models model)
        {
            if (ModelState.IsValid)
            {
                _context.Models.Add(model);
                _context.SaveChanges();

                TempData["mensaje"] = "El modelo se ha creado correctamente";

                return RedirectToAction("Models");
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
            var model = _context.Models.Find(SKU);

            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        //HTTP Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models model)
        {
            if (ModelState.IsValid)
            {
                _context.Models.Update(model);
                _context.SaveChanges();

                TempData["mensaje"] = "El modelo se ha actualizado correctamente";
                return RedirectToAction("Models");
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
            var modelo = _context.Models.Find(SKU);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }


        //HTTP Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteModels(int? SKU)
        {
            //Obtener color por id
            var model = _context.Colours.Find(SKU);

            if (model == null)
            {
                return NotFound();
            }
            _context.Models.Remove(model);
            _context.SaveChanges();

            TempData["mensaje"] = "El modelo se ha eliminado correctamente";
            return RedirectToAction("Models");
        }

    }

}
