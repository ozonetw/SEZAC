using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class Programa
    {
        #region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Programa()
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

		public bool ExistePrograma(string nombrePrograma)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT * FROM sezac.programa WHERE UPPER(nombre)='" + nombrePrograma.ToUpper() + "'",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Entero

                #endregion
            };
			DataTable resultado = (DataTable)_planificador.Despachar(
                #region Ejecutar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );

            return resultado.Rows.Count > 0;
        }

		public bool InsertarPrograma(Entidades.Programa programa)
		{
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "INSERT INTO sezac.programa (nombre,dependenciaid,aniofiscal) VALUES ('" + programa.Descripcion + "',"+ programa.Dependencia.Id + "," + programa.AnioFiscal.Anio + ")",
				Tipo = Definiciones.TipoSentencia.NoQuery,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Entero

                #endregion
            };

			_planificador.Despachar(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );
            return true;
		}

        public List<Entidades.Programa> ObtenerPrograma(int id)
        {
            List<Entidades.Programa> programas = new List<Entidades.Programa>();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid AND p.id=COALESCE(" + ((id == 0) ? "NULL" : id.ToString()) + ",p.id)",
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

            #region Recuperar registros

            for (int indice = 0; indice < resultado.Rows.Count; indice++)
            {
                #region Establecer valores

                programas.Add(new Entidades.Programa()
                    {
						Id = int.Parse(resultado.Rows[indice]["Id"].ToString()),
						Descripcion = resultado.Rows[indice]["Nombre"].ToString(),
						Dependencia = new Entidades.Dependencia()
						{
							Id = int.Parse(resultado.Rows[indice]["DependenciaId"].ToString()),
							Descripcion = resultado.Rows[indice]["Dependencia"].ToString()
						},
						AnioFiscal = new Entidades.AnioFiscal()
						{
							Anio = int.Parse(resultado.Rows[indice]["AnioFiscal"].ToString())
						}
                    }
                );

                #endregion
            }

            #endregion
            return programas;
        }
        
		#endregion
    }
}
