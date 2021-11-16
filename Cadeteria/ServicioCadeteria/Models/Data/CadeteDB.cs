using Microsoft.Extensions.Logging;
using ServicioCadeteria.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;


namespace ServicioCadeteria.Data
{
    public class CadeteDB : ICadeteDB
    {
        //private readonly string pathcadete1;
        // private readonly ILogger logger1;
        public string v = @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\ServicioCadeteria\DB\cadetesDB.db";

        private NLog.Logger logger;

        /*public CadeteDB(string pathCadete, ILogger logger)
        {
            this.pathcadete1 = pathCadete;
            logger1 = logger;
        }*/

        public CadeteDB( NLog.Logger logger)
        {
            this.logger = logger;
        }

        public void SaveCadetes(ClaseCadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), v);
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

                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), v);
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

        public ClaseCadete GetCadeteByApellido(string apellido)
        {
            ClaseCadete cadete = new ClaseCadete();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(v))
                {
                    string sqlQuery = "SELECT * FROM cadetes " +
                                        "WHERE cadeteApellido = @apellido";

                    using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@apellido", apellido);
                        connection.Open();

                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            cadete.id = Convert.ToInt32(dataReader["cadeteID"]);
                            cadete.nombre = dataReader["cadeteNombre"].ToString();
                            cadete.apellido = dataReader["cadeteApellido"].ToString();
                            cadete.direccion = dataReader["cadeteDireccion"].ToString();
                            cadete.telefono = dataReader["cadeteTelefono"].ToString();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cadete;
        }

        public void UpdateCadete(ClaseCadete cadete)
        {

            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"UPDATE cadetes SET cadeteApellido = @Apellido, cadeteNombre = @Nombre, cadeteDireccion = @Direccion, cadeteTelefono = @Telefono WHERE cadeteID = @Id";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@Apellido", cadete.apellido);
                        command.Parameters.AddWithValue("@Nombre", cadete.nombre);
                        command.Parameters.AddWithValue("@Direccion", cadete.direccion);
                        command.Parameters.AddWithValue("@Telefonp", cadete.telefono);
                        command.Parameters.AddWithValue("@Id", cadete.id);
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

        public void DeleteCadete(int id)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\Cadeteria2\DB\Cadeteria2.db");
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"DELETE FROM cadetes WHERE cadeteID = @Id";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@Id", id);
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
    }
}
