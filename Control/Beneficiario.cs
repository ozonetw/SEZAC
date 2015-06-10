using Sezac.Persistencia.Comun;
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

		public DataTable/*Entidades.Usuario*/ Buscar(string item, Comun.Definiciones.TipoParametroBusqueda tipoParametroBusqueda)
        {
			Entidades.Usuario usuario = new Entidades.Usuario();
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

			switch (tipoParametroBusqueda)
			{
				case Comun.Definiciones.TipoParametroBusqueda.RFC:
					sentencia.Comando = "SELECT b.Rfc,TRIM(b.nombres||' '||b.apellidopaterno||' '||b.apellidomaterno) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.rfc LIKE '%@Item%'";
					sentencia.Parametros.Add(new Parametro()
						#region Inicializar

						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Item",
							Tipo = DbType.String,
							Valor = item.Replace(" ","%")
						}

						#endregion
					);
					break;
				case Comun.Definiciones.TipoParametroBusqueda.Nombre:
					sentencia.Comando = "SELECT b.Rfc,TRIM(b.nombres||' '||b.apellidopaterno||' '||b.apellidomaterno) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.nombres LIKE '%@Item%'";
					sentencia.Parametros.Add(new Parametro()
						#region Inicializar

						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Item",
							Tipo = DbType.String,
							Valor = item.Replace(" ","%")
						}

						#endregion
					);
					break;
				case Comun.Definiciones.TipoParametroBusqueda.ApellidoPaterno:
					sentencia.Comando = "SELECT b.Rfc,TRIM(b.nombres||' '||b.apellidopaterno||' '||b.apellidomaterno) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.apellidopaterno LIKE '%@Item%'";
					sentencia.Parametros.Add(new Parametro()
						#region Inicializar

						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Item",
							Tipo = DbType.String,
							Valor = item.Replace(" ","%")
						}

						#endregion
					);
					break;
				case Comun.Definiciones.TipoParametroBusqueda.ApellidoMaterno:
					sentencia.Comando = "SELECT b.Rfc,TRIM(b.nombres||' '||b.apellidopaterno||' '||b.apellidomaterno) AS Nombre,b.Correo,eb.Descripcion AS Estatus FROM sezac.beneficiario,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.apellidomaterno LIKE '%@Item%'";
					sentencia.Parametros.Add(new Parametro()
						#region Inicializar

						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Item",
							Tipo = DbType.String,
							Valor = item.Replace(" ","%")
						}

						#endregion
					);
					break;
				default:
					break;
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

			#region Recuperar información

			//for (int indice = 0; indice < resultado.Rows.Count; indice++)
			//{
			//	#region Establecer valores

			//	usuario.Correo = resultado.Rows[indice]["Correo"].ToString();
			//	usuario.Estatus = (Comun.Definiciones.TipoEstatusBeneficiario)int.Parse(resultado.Rows[indice]["Estatus"].ToString());
			//	usuario.Login = resultado.Rows[indice]["Rfc"].ToString();
			//	usuario.Nombre = resultado.Rows[indice]["Nombre"].ToString();

			//	#endregion
			//}

            #endregion
            //return usuario;
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

			if (esBeneficiarioVetado)
				sentencias.Add( new Sentencia()
					{
						#region Inicializar

						Comando = "UPDATE sezac.beneficiario SET estatusbeneficiarioid=2 WHERE rfc=" +  evaluaciones[0].Rfc,
						Tipo = Definiciones.TipoSentencia.NoQuery,
						TipoComando = CommandType.Text,
						TipoTransaccion = Definiciones.TipoTransaccion.Continuar,
						TipoResultado = Definiciones.TipoResultado.Entero

						#endregion
					}
				);

			if (sentencias.Count > 0)
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

		public List<Entidades.Evaluacion> ObtenerDatosEvaluacion(string item, Comun.Definiciones.TipoParametroBusqueda tipoParametroBusqueda)
        {

			Historial historial = new Historial();
			List<Entidades.Evaluacion> evaluaciones = new List<Entidades.Evaluacion>();
			DataTable datos = historial.ObtenerHistorialInscripciones(item, Comun.Definiciones.TipoHistorial.Beneficiario, tipoParametroBusqueda).Datos;

			#region Recuperar información

            for (int indice = 0; indice < datos.Rows.Count; indice++)
            {
                #region Establecer valores

				evaluaciones.Add(new Entidades.Evaluacion()
					{
						#region Inicializar

						AnioFiscal = int.Parse(datos.Rows[indice]["AnioFiscal"].ToString()),
						BeneficiarioEstatus = (Comun.Definiciones.TipoEstatusBeneficiario)int.Parse(datos.Rows[indice]["EstatusBeneficiario"].ToString()),
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

				Comando = "SELECT eb.Descripcion FROM sezac.beneficiario,sezac.estatusbeneficiario eb WHERE eb.id=b.estatusbeneficiarioid AND b.rfc='" + rfc + "'",
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

        public DataTable ObtenerVetados()
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT Rfc,TRIM(nombres||' '||apellidopaterno||' '||apellidomaterno) AS Nombre,Correo FROM sezac.beneficiario WHERE estatusbeneficiarioid=2",
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
