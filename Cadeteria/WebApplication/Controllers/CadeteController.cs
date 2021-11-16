using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.DataBase;

namespace WebApplication.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly RepoCadete _repoCadete;
        public CadeteController(ILogger<CadeteController> logger, RepoCadete repoCadete)
        {
            _logger = logger;
            _repoCadete = repoCadete;
        }
        public IActionResult CadeteIndex()
        {
            
            return View(_repoCadete.GetCadetes());
        }
        [HttpPost]
        public IActionResult SaveCadete(string apellido,string nombre,string direccion, string telefono)
        {
            ClaseCadete cadete = new ClaseCadete(nombre, apellido, direccion, telefono);
            _repoCadete.SaveCadete(cadete);
            return View("CadeteIndex");
        }

        
        public IActionResult UpdateCadeteForm(int id)
        {
            ClaseCadete cadete = new ClaseCadete();
            cadete = _repoCadete.GetCadeteByID(id);
            return View(cadete);
        }
        [HttpPost]
        public IActionResult UpdateCadete(int id,string apellido, string nombre, string direccion, string telefono)
        {
            ClaseCadete cadete = new ClaseCadete(nombre, apellido, direccion, telefono);
            cadete.Id = id;
            _repoCadete.UpdateCadetes(cadete);
            return View("IndexCadete",_repoCadete.GetCadetes());
        }

        public IActionResult DeleteCadete(int id)
        {
            _repoCadete.DeleteCadete(id);
            return View("IndexCadete", _repoCadete.GetCadetes());
        }
    }
}
