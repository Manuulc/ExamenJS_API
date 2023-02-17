using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL.Listado
{
    public class clsListadoDepartamentosDAL
    {

        /// <summary>
        /// Funcion que nos devuelve un listado completo de departamentos de una base de datos
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> ObtenerListadoDepartamentosDAL()
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsDepartamento departamento;

            try

            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();

                        departamento.IdDepartamento = (int)miLector["ID"];
                        departamento.NombreDepartamento = (string)miLector["Nombre"];


                        listadoDepartamentos.Add(departamento);
                    }
                }
                miLector.Close();
                conexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoDepartamentos;
        }
    }
}
