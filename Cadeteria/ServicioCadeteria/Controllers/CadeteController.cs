using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
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
        private readonly ILogger<CadeteController> _logger;
        private readonly ICadeteDB _repoCadetes;
        private readonly string pathCadete = @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\ServicioCadeteria\DB\cadetesDB.db";
        private Logger logger;

        public CadeteController(ILogger<CadeteController> logger, ICadeteDB repoCadetes)
        {
            _logger = logger;
            _repoCadetes = repoCadetes;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCadete()
        {
            CadeteDB dB = new CadeteDB(logger);
            List<ClaseCadete> cad = _repoCadetes.GetCadetes();
            
            return View();
        } 

        [HttpPost]
        public IActionResult AddCadete(ClaseCadete cadete)
        {
            
            if (ModelState.IsValid)
            {
                _repoCadetes.SaveCadetes(cadete);
            }

            return View();
        }
        public IActionResult buscarCadete(string apellido)
        {
            
            return View("AddCadete");
        }

    }
}
