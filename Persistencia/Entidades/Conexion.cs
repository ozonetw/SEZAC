using Sezac.Persistencia.Comun;

namespace Sezac.Persistencia.Entidades
{
	public class Conexion
	{
		#region Propiedades

		public string Nombre
        {
            get;
            set;
        }
		public Definiciones.TipoConexion Tipo
        {
            get;
            set;
        }
		public Definiciones.TipoCliente TipoCliente
        {
            get;
            set;
        }

		#endregion
	}
}
