using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Entity
{
    public enum EstadoPedido
    {
        Preparando_pedido,
        En_camino,
        Entregado,
        Cancelado
    }
    public class ClasePedido
    {
        private int id;
        private string obs;
        private string estado;
        private ClaseCliente cliente;
        private ClaseCadete cadete;
        public ClasePedido()
        {

        }
        public ClasePedido(string obs, ClaseCliente cliente)
        {
            this.Obs = obs;
            this.Estado = EstadoPedido.Preparando_pedido.ToString();
            this.Cliente = cliente;
        }

        public int Id { get => id; set => id = value; }
        public string Obs { get => obs; set => obs = value; }
        public string Estado { get => estado; set => estado = value; }
        public ClaseCliente Cliente { get => cliente; set => cliente = value; }
        public ClaseCadete Cadete { get => cadete; set => cadete = value; }
    }
}
