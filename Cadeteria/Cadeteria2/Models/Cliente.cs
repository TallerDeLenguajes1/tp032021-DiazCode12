using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria2.Models
{
    public class Cliente : persona
    {
        public Cliente( string nombre,string direccion, string telefono):base( nombre, direccion, telefono)
        {

        }
    }
}
