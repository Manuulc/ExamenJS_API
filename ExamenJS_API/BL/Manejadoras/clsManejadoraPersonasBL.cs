using DAL.Manejadora;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Manejadoras
{
    public class clsManejadoraPersonasBL
    {

        /// <summary>
        /// Funcion que llama a la funcion ActualizarPersonaDAL de la capa DAL y le aplica una logica de negocio
        /// </summary>
        /// <param name="persona"></param>
        /// <returns> int numeroFilasAfectadas </returns>
        public static int ActualizarPersonaBL(clsPersona persona)
        {
            //aqui va la logica del negocio
            return clsManejadoraPersonasDAL.ActualizarPersonaDAL(persona);
        }
    }
}
