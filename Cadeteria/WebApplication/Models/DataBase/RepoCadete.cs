using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.DataBase
{
    public class RepoCadete : IRepoCadete
    {
        private readonly ILogger _logger;
        private string pathCadetes = @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\WebApplication\SQLite\DBWebAplication.db";
        public RepoCadete(ILogger logger)
        {
            _logger = logger;
        }
        public ClaseCadete GetCadeteByID(int id)
        {
            ClaseCadete cadeteBuscado = new ClaseCadete();

            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
                using (SQLiteConnection connection = new SQLiteConnection(cadena))
                {
                    string sqlQuery = "SELECT * FROM cadetes WHERE cadeteID = @cadeteID ";

                    using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@cadeteID", id);
                        connection.Open();

                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            cadeteBuscado.Id = Convert.ToInt32(dataReader["cadeteID"]);
                            cadeteBuscado.Nombre = dataReader["cadeteNombre"].ToString();
                            cadeteBuscado.Apellido = dataReader["cadeteApellido"].ToString();
                            cadeteBuscado.Direccion = dataReader["cadeteDireccion"].ToString();
                            cadeteBuscado.Telefono = dataReader["cadeteTelefono"].ToString();

                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return cadeteBuscado;
        }
        public void UpdateCadetes(ClaseCadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
                using (SQLiteConnection conexion = new SQLiteConnection(cadena))
                {
                    string instruccion = @"UPDATE cadetes SET cadeteApellido = @Apellido, cadeteNombre = @Nombre, cadeteDireccion = @Direccion, cadeteTelefono = @Telefono WHERE cadeteID = @Id";

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@Apellido", cadete.Apellido);
                        command.Parameters.AddWithValue("@Nombre", cadete.Nombre);
                        command.Parameters.AddWithValue("@Direccion", cadete.Direccion);
                        command.Parameters.AddWithValue("@Telefono", cadete.Telefono);
                        command.Parameters.AddWithValue("@Id", cadete.Id);
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

                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
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
                                cadete.Id = Convert.ToInt32(reader["cadeteID"]);
                                cadete.Apellido = reader["cadeteApellido"].ToString();
                                cadete.Nombre = reader["cadeteNombre"].ToString();
                                cadete.Direccion = reader["cadeteDireccion"].ToString();
                                cadete.Telefono = reader["cadeteTelefono"].ToString();
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
        public void SaveCadete(ClaseCadete cadete)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
                string instruccion = @"INSERT INTO cadetes(cadeteApellido,cadeteNombre,cadeteDireccion,cadeteTelefono)
                                                        VALUES (@apellido,@nombre,@direccion,@telefono)";
                using (SQLiteConnection conexion = new(cadena))
                {

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        //command.Parameters.AddWithValue("@cadeteID", cadete.id);

                        command.Parameters.AddWithValue("@apellido", cadete.Apellido);
                        command.Parameters.AddWithValue("@nombre", cadete.Nombre);
                        command.Parameters.AddWithValue("@direccion", cadete.Direccion);
                        command.Parameters.AddWithValue("@telefono", cadete.Telefono);

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
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
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
