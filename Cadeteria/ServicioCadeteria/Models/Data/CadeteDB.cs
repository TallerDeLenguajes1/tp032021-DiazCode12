using ServicioCadeteria.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioCadeteria.Data
{
    public class CadeteDB
    {
        public string pathCadete = @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\ServicioCadeteria\DB\cadetesDB.db";
        public void SaveCadetes(ClaseCadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadete);
                string instruccion = @"INSERT INTO cadetes(cadeteApellido,cadeteNombre,cadeteDireccion,cadeteTelefono)
                                                        VALUES (@apellido,@nombre,@direccion,@telefono)";
                using (SQLiteConnection conexion = new(cadena))
                {
                    

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        //command.Parameters.AddWithValue("@cadeteID", cadete.id);
                        
                        command.Parameters.AddWithValue("@apellido", cadete.apellido);
                        command.Parameters.AddWithValue("@nombre", cadete.nombre);
                        command.Parameters.AddWithValue("@direccion", cadete.direccion);
                        command.Parameters.AddWithValue("@telefono", cadete.telefono);
                        
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

        public List<ClaseCadete> GetCadetes()
        {
            List<ClaseCadete> listadoCadete = new List<ClaseCadete>();
            try
            {

                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadete);
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"SELECT cadeteID,cadeteApellido,cadeteNombre,cadeteDireccion,cadeteTelefono
                                    FROM     cadetes";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        conexion.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClaseCadete cadete = new ClaseCadete();
                                cadete.id = Convert.ToInt32(reader["cadeteID"]);
                                cadete.apellido = reader["cadeteApellido"].ToString();
                                cadete.nombre = reader["cadeteNombre"].ToString();
                                cadete.direccion = reader["cadeteDireccion"].ToString();
                                cadete.telefono = reader["cadeteTelefono"].ToString();
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
    
        public List<ClaseCadete> buscarCadete(string ap)
        {
            List<ClaseCadete> lista = new List<ClaseCadete>();
            List<ClaseCadete> lc = new List<ClaseCadete>();
            lc = GetCadetes();
            lista =lc.Where(a => a.apellido.ToLower().Contains(ap.ToString().ToLower())).ToList();
            
            return lista;
        }
    
    }
}
