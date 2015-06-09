using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class Organizacion
    {
        #region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Organizacion()
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

		public bool ExisteOrganizacion(string nombreOrganizacion)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT * FROM sezac.organizacion WHERE UPPER(nombre)='" + nombreOrganizacion.ToUpper() + "'",
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

		public bool InsertarOrganizacion(Entidades.Organizacion organizacion)
		{
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "INSERT INTO sezac.organizacion (nombre,programaid) VALUES ('" + organizacion.Descripcion + "',"+ organizacion.Programa.Id + ")",
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

        public List<Entidades.Organizacion> ObtenerOrganizacion(int id)
        {
            List<Entidades.Organizacion> organizaciones = new List<Entidades.Organizacion>();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT o.*,p.nombre AS Programa,p.dependenciaid,p.dependencia,p.aniofiscal FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid AND o.id=COALESCE(" + ((id == 0) ? "NULL" : id.ToString()) + ",o.id)",
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

                organizaciones.Add(new Entidades.Organizacion()
                    {
						Id = int.Parse(resultado.Rows[indice]["Id"].ToString()),
						Descripcion = resultado.Rows[indice]["Nombre"].ToString(),
						Programa = new Entidades.Programa()
						{
							Id = int.Parse(resultado.Rows[indice]["ProgramaId"].ToString()),
							Descripcion = resultado.Rows[indice]["Programa"].ToString(),
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
                    }
                );

                #endregion
            }

            #endregion
            return organizaciones;
        }
        
		#endregion
    }
}
