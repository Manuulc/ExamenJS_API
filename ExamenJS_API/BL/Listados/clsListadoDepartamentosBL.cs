using DAL;
using DAL.Listado;
using Entidades;
using System.Collections.ObjectModel;

namespace BL.Listados
{
    public class clsListadoDepartamentosBL
    {

        /// <summary>
        /// Funcion que llama a la funcion ObtenerListadoDepartamentoDAL de la capa DAL y le aplica una logica de negocio
        /// </summary>
        /// <returns> new List<clsDepartamento>(clsListadoDepartamentosDAL.ObtenerListadoDepartamentosDAL() </returns>
        public static List<clsDepartamento> ObtenerListadoDepartamentosBL()
        {
            // aqui va la logica del negocio

            return clsListadoDepartamentosDAL.ObtenerListadoDepartamentosDAL();
        }
    }
}