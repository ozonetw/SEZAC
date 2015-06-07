using Sezac.Persistencia.Comun;

namespace Sezac.Persistencia.Entidades
{
	public class Conexion
	{
		#region Propiedades

		public string BaseDatos
        {
            get;
            set;
        }
		public Credenciales Credenciales
        {
            get;
            set;
        }
		public string IdServicio
        {
            get;
            set;
        }
		public string Nombre
        {
            get;
            set;
        }
		public string Puerto
        {
            get;
            set;
        }
		public string Servidor
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
