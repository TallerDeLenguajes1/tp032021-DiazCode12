using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria2.Models
{
    public class persona
    {
        
        private string nombre;
        private string direccion;
        private string telefono;

        public persona(string nombre, string direccion, string telefono)
        {
            
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
