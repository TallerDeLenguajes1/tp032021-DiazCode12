using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Entity;


namespace WebApplication.Models.DataBase
{
    public class RepoPedido : IRepoPedido
    {
        // private readonly ILogger _logger;
        //deberia cambiar el nombre de esta variable y hacer una inyeccion de esta direccion para usarla en todas las clases?
        private string pathCadetes = @"C:\Users\Usuario\OneDrive\Escritorio\practicaC#\tp032021-DiazCode12\Cadeteria\WebApplication\SQLite\DBWebAplication.db";
        private NLog.Logger logger;

        /*public RepoPedido(ILogger logger)
        {
            _logger = logger;
        }*/

        public RepoPedido(NLog.Logger logger)
        {
            this.logger = logger;
        }

        public void SavePedido(ClasePedido pedido)
        {
            try
            {
                string cadena = "Data Source = " + Path.Combine(Directory.GetCurrentDirectory(), pathCadetes);
                string instruccion = @"INSERT INTO pedidos(pedidoObs,pedidoEstado,clienteID,cadeteID)
                                                        VALUES (@obs,@estado,@cliente,@cadete)";
                using (SQLiteConnection conexion = new(cadena))
                {

                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        //command.Parameters.AddWithValue("@cadeteID", cadete.id);

                        command.Parameters.AddWithValue("@obs", pedido.Obs);
                        command.Parameters.AddWithValue("@estado", pedido.Estado);
                        command.Parameters.AddWithValue("@cliente", pedido.Cliente.Id);
                        command.Parameters.AddWithValue("@cadete", pedido.Cadete.Id);

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

        public ClaseCadete AsignarCadete()
        {
            ClaseCadete cadete = new ClaseCadete();

            return cadete;

        }
    }
}
