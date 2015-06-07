using Sezac.Persistencia.Entidades;
using System.Data;

namespace Sezac.Persistencia.Reglas
{
	internal abstract class Cliente
	{
		#region Atributos

		protected readonly string _cadenaConexion;

		#endregion

		#region Constructor

		protected Cliente(string cadenaConexion)
		{
			_cadenaConexion = cadenaConexion;
		}

		#endregion

		#region Metodos

		protected abstract bool Conectar();
		protected abstract void CrearComando(Sentencia sentencia);
		protected abstract bool Desconectar();
		protected abstract object EjecutarEscalar();
		protected abstract int EjecutarNoQuery();
		protected abstract DataTable EjecutarQuery();
		protected abstract object ObtenerParametro(string nombreParametro);

		#endregion
	}
}
