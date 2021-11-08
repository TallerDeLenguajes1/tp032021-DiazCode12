using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria2.Models
{
    public class Cliente : persona
    {
        public Cliente(int id, string nombre,string direccion, string telefono):base(id, nombre, direccion, telefono)
        {

        }
    }
}
