using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
    public class CadeteController : Controller
    {
        public IActionResult buscarCadete(string apellido)
        {
            List<Cadete> cad = new List<Cadete>();
            using (var db = new DemoContext())
            {
                cad = db.cadetes.Where(a => a.Apellido.ToLower().Contains(apellido.ToLower())).ToList();
            }
            TempData["cadetes"] = cad;
            return View ("AddCadete");
        }
        public IActionResult AddCadete()
        {
            List<Cadete> cad = new List<Cadete>();
            using(var db = new DemoContext())
            {
                cad = db.cadetes.ToList();
            }
            TempData["cadetes"] = cad;
            return View();
        }
        [HttpPost]
        public IActionResult AddCadete(Cadete cadete)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    db.Add(cadete);
                    db.SaveChanges();
                }
            }
            
            return View();
        }

        
    }
}
