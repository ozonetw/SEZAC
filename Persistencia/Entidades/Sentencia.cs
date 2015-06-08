using Sezac.Persistencia.Comun;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Persistencia.Entidades
{
	public class Sentencia
	{
		#region Propiedades

        public string Comando
        {
            get;
            set;
        }
		public List<Parametro> Parametros
        {
            get;
            set;
        }
		public Definiciones.TipoSentencia Tipo
        {
            get;
            set;
        }
		public CommandType TipoComando
        {
            get;
            set;
        }
		public Definiciones.TipoResultado TipoResultado
        {
            get;
            set;
        }
		public Definiciones.TipoTransaccion TipoTransaccion
        {
            get;
            set;
        }

		#endregion
	}
}
