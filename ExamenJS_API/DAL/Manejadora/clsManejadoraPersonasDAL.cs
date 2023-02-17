using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadora
{
    public class clsManejadoraPersonasDAL
    {

        /// <summary>
        /// Metodo que accede a mi base de datos para actualizar una persona que le mando como parametro
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int ActualizarPersonaDAL(clsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "UPDATE Personas " +
                    "SET " +
                    "Nombre = @nombre, " +
                    "Apellidos = @apellidos," +
                    "Telefono = @telefono," +
                    "Direccion = @direccion," +
                    "Foto = @foto," +
                    "FechaNacimiento = @fechaNacimiento," +
                    "IDDepartamento = @idDepartamento" +
                    " WHERE ID = @idPersona";
                miComando.Connection = conexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }
    }
}
