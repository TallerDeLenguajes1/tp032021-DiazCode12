using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.DataBase;
using WebApplication.Models.Entity;

namespace WebApplication.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IRepoPedido _repoPedido;
        private readonly IRepoCadete _repoCadete;
        private readonly IRepoCliente _repoCliente;
        public PedidoController(ILogger<PedidoController> logger, IRepoPedido repoPedido,IRepoCadete repoCadete, IRepoCliente repoCliente)
        {
            _logger = logger;
            _repoPedido = repoPedido;
            _repoCadete = repoCadete;
            _repoCliente = repoCliente;
        }
        public IActionResult PedidoIndex()
        {

            return View(_repoCadete.GetCadetes());
        }
        public IActionResult SavePedido(string apellido, string nombre, string direccion, string telefono, string obs, string cadeteID)
        {
            ClaseCliente cliente = new ClaseCliente(nombre,apellido,direccion,telefono);
            _repoCliente.SaveCliente(cliente);
            ClasePedido pedido = new ClasePedido(obs, cliente);
            pedido.Cadete = _repoCadete.GetCadeteByID(Convert.ToInt32(cadeteID));
            _repoPedido.SavePedido(pedido);
            return View("PedidoIndex");
        }
    }
}
