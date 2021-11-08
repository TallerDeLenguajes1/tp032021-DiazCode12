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
            return View("AddCadete");
        }
        public IActionResult AddCadete()
        {
            List<Cadete> cad = new List<Cadete>();
            using (var db = new DemoContext())
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
        [HttpPost]
        public IActionResult EditarCadete(Cadete cadete)
        {
            using(var db = new DemoContext())
            {
                var CadeteTemporal = db.cadetes.Where(u => u.Id == cadete.Id).FirstOrDefault();
                TempData["CadeteTemporal"] = CadeteTemporal;
            }
            return View();
        }
        
        public IActionResult GuardarCadeteEditado(Cadete cadete)
        {
            using (var db = new DemoContext())
            {
                var subirCadete = db.cadetes.Where(u => u.Id == cadete.Id).FirstOrDefault();

                subirCadete.Apellido = cadete.Apellido;
                subirCadete.Nombre = cadete.Nombre;
                subirCadete.Domicilio = cadete.Domicilio;
                subirCadete.Telefono = cadete.Telefono;

                db.SaveChanges();

            }
            return View("AddCadete");
        }
    }
}
