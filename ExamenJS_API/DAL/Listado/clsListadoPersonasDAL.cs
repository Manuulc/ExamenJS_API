using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL.Listado
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Funcion que nos devuelve un listado completo de personas de una base de datos
        /// </summary>
        /// <returns> List<clsPersona> listadoPersonas </returns>
        public static List<clsPersona> ObtenerListadoPersonasDAL()
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona persona;

            try

            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        persona = new clsPersona();

                        persona.IdPersona = (int)miLector["ID"];
                        persona.Nombre = (string)miLector["Nombre"];
                        persona.Apellidos = (string)miLector["Apellidos"];
                        persona.Telefono = (string)miLector["Telefono"];
                        persona.Direccion = (string)miLector["Direccion"];
                        persona.Foto = (string)miLector["Foto"];
                        persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        persona.IdDepartamento = (int)miLector["IDDepartamento"];

                        listadoPersonas.Add(persona);
                    }
                }
                miLector.Close();
                conexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas;
        }
    }
}