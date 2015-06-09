using Sezac.Control.Comun;
using System.Data;

namespace Sezac.Control.Entidades
{
	public class Historial
	{
		#region Propiedades

		public DataTable Datos
		{
			get;
			set;
		}
		public Definiciones.TipoHistorial Tipo
		{
			get;
			set;
		}

		#endregion
	}
}
