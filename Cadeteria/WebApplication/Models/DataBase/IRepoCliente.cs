using WebApplication.Models.Entity;

namespace WebApplication.Models.DataBase
{
    public interface IRepoCliente
    {
        void SaveCliente(ClaseCliente cliente);
    }
}