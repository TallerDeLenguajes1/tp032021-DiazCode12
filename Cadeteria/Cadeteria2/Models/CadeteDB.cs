using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria2.Models
{
    public class CadeteDB
    {
        

        public  List<Cadete> GetCadetes()
        {
            try
            {
                List<Cadete> listadoCadete = new List<Cadete>();
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                SQLiteConnection conexion = new SQLiteConnection(cadena);
                string instruccion = @"SELECT id,nombre,direccion,telefono
                                    FROM     Cadetes
                                    WHERE Activo = -1";

                SQLiteCommand command = new SQLiteCommand(instruccion,conexion);
                conexion.Open();
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cadete cadete = new Cadete(Convert.ToInt32(reader["cadeteID"]), reader["nombre"].ToString(), reader["direccion"].ToString(),reader["telefono"].ToString());
                    listadoCadete.Add(cadete);

                }
                conexion.Close();

                return listadoCadete;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
        
        
    
}
