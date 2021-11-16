using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Entity;

namespace WebApplication.Models
{
    public class ClaseCadete : ClaseCliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;

        public ClaseCadete()
        {

        }
        public ClaseCadete(string nombre, string apellido, string direccion, string telefono)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
