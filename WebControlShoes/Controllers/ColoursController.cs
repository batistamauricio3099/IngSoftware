using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebControlShoes.Data;
using WebControlShoes.Models;

namespace WebControlShoes.Controllers
{
    public class ColoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColoursController(ApplicationDbContext context)
        {
            _context = context;
        }
        //HTTP Get Index
        public IActionResult Colours()
        {
            IEnumerable<Colours> listColours = _context.Colours;
            return View(listColours);
        }
        //HTTP Get Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Colours colour)
        {
            if (ModelState.IsValid)
            {
                _context.Colours.Add(colour);
                _context.SaveChanges();

                TempData["mensaje"] = "El color se ha creado correctamente";

                return RedirectToAction("Colours");
            }

            return View();
        }
        
        //HTTP Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el color
            var color = _context.Colours.Find(id);

            if(color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        //HTTP Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Colours colour)
        {
            if (ModelState.IsValid)
            {
                _context.Colours.Update(colour);
                _context.SaveChanges();

                TempData["mensaje"] = "El color se ha actualizado correctamente";
                return RedirectToAction("Colours");
            }

            return View();
        }


        //HTTP Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el color
            var color = _context.Colours.Find(id);

            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }


        //HTTP Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteColour(int? id)
        {
            //Obtener color por id
            var color = _context.Colours.Find(id);

            if (color == null)
            {
                return NotFound();
            }
            _context.Colours.Remove(color);
            _context.SaveChanges();

            TempData["mensaje"] = "El color se ha eliminado correctamente";
            return RedirectToAction("Colours");
        }

    }

}
