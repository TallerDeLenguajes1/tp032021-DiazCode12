using Microsoft.AspNetCore.Mvc;
using ServicioCadeteria.Data;
using ServicioCadeteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioCadeteria.Controllers
{
    public class CadeteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCadete()
        {

            CadeteDB dB = new CadeteDB();
            List<ClaseCadete> cad = dB.GetCadetes();
            TempData["ClaseCadetes"] = cad;
         
            return View();
        } 

        [HttpPost]
        public IActionResult AddCadete(ClaseCadete cadete)
        {
            CadeteDB db = new CadeteDB();
            if (ModelState.IsValid)
            {
                db.SaveCadetes(cadete);
            }

            return View();
        }
        public IActionResult buscarCadete(string apellido)
        {
            CadeteDB cadeteDB = new CadeteDB();
            List<ClaseCadete> cad = cadeteDB.buscarCadete(apellido);
            TempData["cadetes"] = cad;
            return View("AddCadete");
        }

    }
}
