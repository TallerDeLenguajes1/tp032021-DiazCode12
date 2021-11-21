using System.Collections.Generic;

namespace WebApplication.Models.DataBase
{
    public interface IRepoCadete
    {
        void DeleteCadete(int id);
        ClaseCadete GetCadeteByID(int id);
        List<ClaseCadete> GetCadetes();
        void SaveCadete(ClaseCadete cadete);
        void UpdateCadetes(ClaseCadete cadete);
        ClaseCadete ObtenerCadete(string nombre, string apellido);
    }
}