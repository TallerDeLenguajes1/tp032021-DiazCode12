using Microsoft.AspNetCore.Http;
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
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IRepoCadete _repoCadete;
        public UsuarioController(ILogger<UsuarioController> logger, IRepoCadete repoCadete)
        {
            _logger = logger;
            _repoCadete = repoCadete;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn(string nombre, string apellido)
        {
            ClaseCadete cadete = new ClaseCadete();
            cadete = _repoCadete.ObtenerCadete(nombre, apellido);

            if (cadete != null)
            {
                HttpContext.Session.SetInt32("id", cadete.Id);
                HttpContext.Session.SetString("nombre", cadete.Nombre);
                HttpContext.Session.SetString("apellido", cadete.Apellido);
                return RedirectToAction("Acces", "Usuario");
            }
            else
            {
                return RedirectToAction("Error", "Usuario");
            }
            
        }

        public IActionResult Acces()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
