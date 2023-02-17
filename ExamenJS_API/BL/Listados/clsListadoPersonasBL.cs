using DAL.Listado;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
    public class clsListadoPersonasBL
    {

        /// <summary>
        /// Funcion que llama a la funcion ObtenerListadoPersonasDAL de la capa DAL y le aplica una logica de negocio
        /// </summary>
        /// <returns> new List<clsPersona>(clsListadoPersonasDAL.ObtenerListadoPersonasDAL() </returns>
        public static List<clsPersona> ObtenerListadoPersonasBL()
        {
            // aqui va la logica de negocio

            return clsListadoPersonasDAL.ObtenerListadoPersonasDAL();
        }

    }
}
