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
        private static void DeleteCadete(Cadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"UPDATE cadetes SET Activo = 0 WHERE cadeteID = @Id";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        conexion.Open();
                        
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        private static void UpdateCadetes(Cadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"UPDATE cadetes SET cadeteNombre = @Nombre, cadeteDireccion = @Direccion, cadeteTelefono = @Telefono WHERE cadeteID = @Id";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@Nombre", cadete.Nombre);
                        command.Parameters.AddWithValue("@Direccion", cadete.Direccion);
                        command.Parameters.AddWithValue("@Telefonp", cadete.Telefono);
                       // command.Parameters.AddWithValue("@Id", cadete.Id);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        private static void SaveCadetes(Cadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"INSERT INTO Cadetes(nombre,direccion,telefono) values (@nombre,@direccion,@telefono)";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                        command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                        command.Parameters.AddWithValue("@telefonp", cadete.Telefono);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        /*
        private static  List<Cadete> GetCadetes()
        {
            List<Cadete> listadoCadete = new List<Cadete>();
            try
            {
               
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"SELECT id,nombre,direccion,telefono
                                    FROM     Cadetes
                                    WHERE Activo = -1";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        conexion.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cadete cadete = new Cadete(Convert.ToInt32(reader["cadeteID"]), reader["nombre"].ToString(), reader["direccion"].ToString(), reader["telefono"].ToString());
                                listadoCadete.Add(cadete);
                            }
                        }
                        conexion.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return listadoCadete;
        }
   */ }
        
        
    
}
