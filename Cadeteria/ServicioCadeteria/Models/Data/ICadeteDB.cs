using ServicioCadeteria.Models;
using System.Collections.Generic;

namespace ServicioCadeteria.Data
{
    public interface ICadeteDB
    {
        void DeleteCadete(int id);
        ClaseCadete GetCadeteByApellido(string apellido);
        List<ClaseCadete> GetCadetes();
        void SaveCadetes(ClaseCadete cadete);
        void UpdateCadete(ClaseCadete cadete);
    }
}