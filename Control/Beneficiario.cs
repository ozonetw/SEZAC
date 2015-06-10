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

		public DataTable Buscar(string item, Comun.Definiciones.TipoParametroBeneficiario tipoParametro)
        {
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

			switch (tipoParametro)
			{
				case Comun.Definiciones.TipoParametroBeneficiario.RFC:
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
				case Comun.Definiciones.TipoParametroBeneficiario.Nombre:
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
				case Comun.Definiciones.TipoParametroBeneficiario.ApellidoPaterno:
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
				case Comun.Definiciones.TipoParametroBeneficiario.ApellidoMaterno:
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

            return resultado;
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
