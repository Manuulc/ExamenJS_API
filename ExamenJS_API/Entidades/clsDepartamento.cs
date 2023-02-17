namespace Entidades
{
    public class clsDepartamento
    {

        #region Propiedades

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        #endregion

        #region Constructores

        public clsDepartamento(int idDepartamento, string nombreDepartamento)
        {
            IdDepartamento = idDepartamento;
            NombreDepartamento = nombreDepartamento;
        }

        public clsDepartamento()
        {

        }

        #endregion
    }
}