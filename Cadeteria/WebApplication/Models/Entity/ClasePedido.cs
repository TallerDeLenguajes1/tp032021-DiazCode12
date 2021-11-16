using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Entity
{
    public class ClasePedido
    {
        private int id;
        private string obs;
        private string estado;
        private ClaseCliente cliente;

        public ClasePedido()
        {

        }
        public ClasePedido(string obs, string estado, ClaseCliente cliente)
        {
            this.Obs = obs;
            this.Estado = estado;
            this.Cliente = cliente;
        }

        public int Id { get => id; set => id = value; }
        public string Obs { get => obs; set => obs = value; }
        public string Estado { get => estado; set => estado = value; }
        public ClaseCliente Cliente { get => cliente; set => cliente = value; }
    }
}
