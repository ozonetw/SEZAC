using System.Data;

namespace Sezac.Persistencia.Entidades
{
	public class Parametro
	{
		#region Propiedades

		public ParameterDirection Direccion 
        { 
            get; 
            set; 
        }
		public string Nombre
        {
            get;
            set;
        }
		public DbType Tipo
        {
            get;
            set;
        }
		public object Valor
        {
            get;
            set;
        }

		#endregion
	}
}
