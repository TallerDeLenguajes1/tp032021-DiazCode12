using Cadeteria2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria2.Controllers
{
    public class CadeteController : Controller
    {
        public IActionResult Cadete()
        {
            return View();
        }
        public IActionResult AddCadete()
        {
            Cadete cadete = new Cadete();
            return View();
        }
    }
}
