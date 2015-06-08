namespace Sezac.Persistencia.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

        public enum TipoCliente
        {
            MySql
        };
        public enum TipoConexion
        {
            NombreConexion
        };
		public enum TipoTransaccion 
        { 
			Continuar, 
			Finalizar, 
			Iniciar, 
			NoTransaccion 
		};
		public enum TipoResultado 
        { 
			Cadena, 
			Conjunto, 
			Decimal, 
			Entero, 
			Vacio = -1
		};
		public enum TipoSentencia 
        { 
			Escalar,
			NoQuery,
			Query
		};

		#endregion
	}
}
