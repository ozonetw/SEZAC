using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sezac.Control
{
	public class Historial
	{
		#region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Historial()
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

        public Entidades.Historial ObtenerHistorialInscripciones(Comun.Definiciones.TipoHistorial tipoHistorial)
        {
			Entidades.Historial historial = new Entidades.Historial();
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            
			#region Establecer comando

			switch (historial.Tipo)
			{
				case Comun.Definiciones.TipoHistorial.Beneficiario:
					sentencia.Comando = "";
					break;
				case Comun.Definiciones.TipoHistorial.Organizacion:
					sentencia.Comando = "";
					break;
				default:
					break;
			}

			#endregion
			historial.Tipo = tipoHistorial;
			historial.Datos = (DataTable)_planificador.Despachar(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );
            return historial;
        }

        #endregion
	}
}
