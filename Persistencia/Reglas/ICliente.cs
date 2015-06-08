using Sezac.Persistencia.Entidades;
using System.Collections.Generic;

namespace Sezac.Persistencia.Reglas
{
	interface ICliente
	{
		#region Metodos

		object Ejecutar(List<Sentencia> sentencia);

		#endregion
	}
}
