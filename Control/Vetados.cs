using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
	public class Vetados
	{
		#region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Vetados()
        {
            _conexion = new Conexion()
            {
                #region Inicializar

                Nombre = "SEZAC",
                Tipo = Definiciones.TipoConexion.NombreConexion,
                TipoCliente = Definiciones.TipoCliente.MySql

                #endregion
            };
            _planificador = new Scheduler();
        }

        #endregion

        #region Metodos

        public DataTable ObtenerListado()
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT b.Rfc,TRIM(b.nombres||' '||b.apellidopaterno||' '||b.apellidomaterno) AS Nombre,b.Correo FROM sezac.beneficiario b WHERE b.estatusbeneficiarioid=2",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
			DataTable resultado = (DataTable)_planificador.Despachar(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );

            return resultado;
        }

        #endregion
	}
}
