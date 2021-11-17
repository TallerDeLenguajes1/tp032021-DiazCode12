using WebApplication.Models.Entity;

namespace WebApplication.Models.DataBase
{
    public interface IRepoPedido
    {
        ClaseCadete AsignarCadete();
        void SavePedido(ClasePedido pedido);
    }
}