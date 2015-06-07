namespace Sezac.Persistencia.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

        public enum TipoCifrado 
        { 
			AES,
			MD5,
			SHA1
		};
        public enum TipoCliente
        {
            MySql
        };
        public enum TipoConexion
        {
            CredencialesExplicitas,
            NombreConexion
        };
		public enum TipoManejadorTransaccion 
        { 
			ContinuarTransaccion, 
			FinalizarTransaccion, 
			IniciarTransaccion, 
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
