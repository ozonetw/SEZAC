﻿using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
	public class Beneficiario
	{
		#region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Beneficiario()
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

		public DataTable Buscar(string item, Comun.Definiciones.TipoParametroBusqueda tipoParametroBusqueda)
        {
			Entidades.Usuario usuario = new Entidades.Usuario();
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Parametros = new List<Parametro>(),
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };

			#region Establecer comando

			switch (tipoParametroBusqueda)
			{
				case Comun.Definiciones.TipoParametroBusqueda.RFC:
					sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario b,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.rfc LIKE @Item";
					break;
				case Comun.Definiciones.TipoParametroBusqueda.Nombre:
					sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario b,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.nombres LIKE @Item";
					break;
				case Comun.Definiciones.TipoParametroBusqueda.ApellidoPaterno:
					sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario b,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.apellidopaterno LIKE @Item";
					break;
				case Comun.Definiciones.TipoParametroBusqueda.ApellidoMaterno:
					sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario b,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.apellidomaterno LIKE @Item";
					break;
				default:
					break;
			}

			sentencia.Parametros.Add(new Parametro()
				#region Inicializar

				{
					Direccion = ParameterDirection.Input,
					Nombre = "@Item",
					Tipo = DbType.String,
					Valor = "%" + item.Replace(" ","%") + "%"
				}

				#endregion
			);

			#endregion

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

		public bool Evaluar(List<Entidades.Evaluacion> evaluaciones)
		{
			List<Sentencia> sentencias = new List<Sentencia>();
			bool esBeneficiarioVetado = false;

			#region Preparar sentencias

			for (int indice = 0; indice < evaluaciones.Count; indice++)
			{
				sentencias.Add( new Sentencia()
					{
						#region Inicializar

						Comando = "UPDATE sezac.programa SET estatus=" + ((int)evaluaciones[indice].ProgramaEstatus).ToString() + " WHERE id=" +  evaluaciones[indice].ProgramaId,
						Tipo = Definiciones.TipoSentencia.NoQuery,
						TipoComando = CommandType.Text,
						TipoTransaccion = Definiciones.TipoTransaccion.Continuar,
						TipoResultado = Definiciones.TipoResultado.Entero

						#endregion
					}
				);


				if (evaluaciones[indice].ProgramaEstatus == Comun.Definiciones.TipoEstatusPrograma.NoCompletado)
					esBeneficiarioVetado = true;
			}

			sentencias.Add( new Sentencia()
				{
					#region Inicializar

					Comando = "UPDATE sezac.beneficiario SET estatusbeneficiarioid=" + ((esBeneficiarioVetado) ? "2" : "1") + " WHERE rfc='" +  evaluaciones[0].Rfc + "'",
					Tipo = Definiciones.TipoSentencia.NoQuery,
					TipoComando = CommandType.Text,
					TipoTransaccion = Definiciones.TipoTransaccion.Continuar,
					TipoResultado = Definiciones.TipoResultado.Entero

					#endregion
				}
			);

			if (sentencias.Count == 1)
				sentencias[0].TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion;
			else 
			{
				sentencias[0].TipoTransaccion = Definiciones.TipoTransaccion.Iniciar;
				sentencias[sentencias.Count - 1].TipoTransaccion = Definiciones.TipoTransaccion.Finalizar;
			}

			#endregion

			_planificador.Despachar(_conexion, sentencias);
			return true;
		}

		public bool ExisteInscripcion(int organizacionId, string rfc)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT * FROM sezac.organizacionesbeneficiarios WHERE organizacionid=" + organizacionId + " AND beneficiariorfc='" + rfc + "'",
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

		public bool InscribirEnOrganizacion(int organizacionId, string rfc)
		{
			Sentencia sentencia = new Sentencia()
			{
				#region Inicializar

				Comando = "INSERT INTO sezac.organizacionesbeneficiarios (organizacionid,beneficiariorfc) VALUES (" + organizacionId + ",'" + rfc + "')",
				Tipo = Definiciones.TipoSentencia.NoQuery,
				TipoComando = CommandType.Text,
				TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
				TipoResultado = Definiciones.TipoResultado.Entero

				#endregion
			};

			_planificador.Despachar(
				#region Inicializar

				_conexion, 
				new List<Sentencia>() 
				{
					sentencia
				}

				#endregion
			);
            return true;
		}

		public DataTable ObtenerBeneficiario(string rfc)
        {
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT rfc AS Id,TRIM(CONCAT(nombres,' ',apellidopaterno,' ',apellidomaterno)) AS Descripcion FROM beneficiario WHERE rfc=COALESCE(" + ((string.IsNullOrEmpty(rfc)) ? "NULL" : rfc) + ",rfc)",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            
			return (DataTable)_planificador.Despachar(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );
        }

		public List<Entidades.Evaluacion> ObtenerDatosEvaluacion(string item)
        {

			List<Entidades.Evaluacion> evaluaciones = new List<Entidades.Evaluacion>();
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,b.EstatusBeneficiarioId,eb.descripcion AS EstatusBeneficiario,o.Organizacion,o.ProgramaId,o.Programa,o.Dependencia,o.AnioFiscal,o.Estatus AS EstatusPrograma FROM sezac.beneficiario b,sezac.estatusbeneficiario eb,sezac.organizacionesbeneficiarios ob,(SELECT o.Id,o.nombre AS Organizacion,p.id AS ProgramaId,p.nombre AS Programa,p.Dependencia,p.AnioFiscal,p.Estatus FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid) o WHERE eb.id=b.estatusbeneficiarioid AND ob.beneficiariorfc=b.rfc AND ob.organizacionid=o.id AND UPPER(b.rfc)='" + item + "'",
				Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
			DataTable datos = (DataTable)_planificador.Despachar(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );

			#region Recuperar información

            for (int indice = 0; indice < datos.Rows.Count; indice++)
            {
                #region Establecer valores

				evaluaciones.Add(new Entidades.Evaluacion()
					{
						#region Inicializar

						AnioFiscal = int.Parse(datos.Rows[indice]["AnioFiscal"].ToString()),
						BeneficiarioEstatus = (Comun.Definiciones.TipoEstatusBeneficiario)int.Parse(datos.Rows[indice]["EstatusBeneficiarioId"].ToString()),
						BeneficiarioNombre = datos.Rows[indice]["Nombre"].ToString(),
						Correo = datos.Rows[indice]["Correo"].ToString(),
						Dependencia = datos.Rows[indice]["Dependencia"].ToString(),
						Organizacion = datos.Rows[indice]["Organizacion"].ToString(),
						Programa = datos.Rows[indice]["Programa"].ToString(),
						ProgramaEstatus = (Comun.Definiciones.TipoEstatusPrograma)int.Parse(datos.Rows[indice]["EstatusPrograma"].ToString()),
						ProgramaId = int.Parse(datos.Rows[indice]["ProgramaId"].ToString()),
						Rfc = datos.Rows[indice]["Rfc"].ToString()

						#endregion
					}
				);

                #endregion
            }

            #endregion

			return evaluaciones;
        }

		public string ObtenerEstatus(string rfc)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT eb.Descripcion FROM sezac.beneficiario b,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND UPPER(b.rfc)='" + rfc.ToUpper() + "'",
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

            return resultado.Rows[0]["Descripcion"].ToString();
        }

		public DataTable ObtenerVetados(string item, Comun.Definiciones.TipoParametroBusqueda tipoParametroBusqueda)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT Rfc,TRIM(CONCAT(nombres,' ',apellidopaterno,' ',apellidomaterno)) AS Nombre,Correo FROM sezac.beneficiario WHERE estatusbeneficiarioid=2",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };

			#region Establecer comando

			if (!string.IsNullOrEmpty(item))
			{
				switch (tipoParametroBusqueda)
				{
					case Comun.Definiciones.TipoParametroBusqueda.RFC:
						sentencia.Comando += " AND UPPER(rfc) LIKE @Item";
						break;
					case Comun.Definiciones.TipoParametroBusqueda.Nombre:
						sentencia.Comando += " AND UPPER(nombres) LIKE @Item";
						break;
					case Comun.Definiciones.TipoParametroBusqueda.ApellidoPaterno:
						sentencia.Comando += " AND UPPER(apellidopaterno) LIKE @Item";
						break;
					case Comun.Definiciones.TipoParametroBusqueda.ApellidoMaterno:
						sentencia.Comando += " AND UPPER(apellidomaterno) LIKE @Item";
						break;
					default:
						break;
				}

				sentencia.Parametros = new List<Parametro>();
				sentencia.Parametros.Add(new Parametro()
					#region Inicializar

					{
						Direccion = ParameterDirection.Input,
						Nombre = "@Item",
						Tipo = DbType.String,
						Valor = "%" + item.ToUpper().Replace(" ", "%") + "%"
					}

					#endregion
				);
			}

			#endregion

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
