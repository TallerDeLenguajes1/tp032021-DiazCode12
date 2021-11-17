using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Entity;

namespace WebApplication.Models.DataBase
{
    public class RepoCliente : IRepoCliente
    {
        private Logger logger;
        private string pathCadetes = @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\WebApplication\SQLite\DBWebAplication.db";

        public RepoCliente(Logger logger)
        {
            this.logger = logger;
        }

        public void SaveCliente(ClaseCliente cliente)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
                string instruccion = @"INSERT INTO clientes(clienteApellido,clienteNombre,clienteDireccion,clienteTelefono)
                                                        VALUES (@ap,@nom,@dir,@tel)";
                using (SQLiteConnection conexion = new(cadena))
                {

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        //command.Parameters.AddWithValue("@cadeteID", cadete.id);

                        command.Parameters.AddWithValue("@ap", cliente.Apellido);
                        command.Parameters.AddWithValue("@nom", cliente.Nombre);
                        command.Parameters.AddWithValue("@dir", cliente.Direccion);
                        command.Parameters.AddWithValue("@tel", cliente.Telefono);

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
