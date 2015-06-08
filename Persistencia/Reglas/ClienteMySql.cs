//using MySql.Data.MySqlClient;
using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

/*
namespace Sezac.Persistencia.Reglas
{
	internal class ClienteMySql : Cliente, ICliente
	{
		#region Atributos

		//private MySqlDataAdapter _adaptadorDatos;
		//private MySqlCommand _comando;
		//private MySqlConnection _conexion;
		//private MySqlTransaction _transaccion;
		
		#endregion

		#region Constructor

		internal ClienteMySql(Conexion conexion)
			: base((conexion.Tipo == Definiciones.TipoConexion.CredencialesExplicitas)
				? "server=" + conexion.Servidor + ";user id=" + conexion.Credenciales.Usuario + ";password=" + conexion.Credenciales.Cifrado.Descifrar(conexion.Credenciales.Contrasenia) + ";database=" + conexion.BaseDatos + ";pooling=false;"
				: ((conexion.Tipo == Definiciones.TipoConexion.NombreConexion)
				? ConfigurationManager.ConnectionStrings[conexion.Nombre].ConnectionString
				: string.Empty)
			)
		{

		}

		#endregion

		#region Metodos
		
		protected override bool Conectar()
		{

			if (_conexion != null && _conexion.State != ConnectionState.Closed)
				return false;

			try
			{

				if (_conexion == null)
				{
					_conexion = new MySqlConnection();
					_conexion.ConnectionString = base._cadenaConexion;
				}

				_conexion.Open();
				return true;
			}
			catch (DataException dex)
			{
				throw new Exception("Error al conectarse a la base de datos", dex);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected override void CrearComando(Sentencia sentencia)
		{
			
			try
			{
				_comando = new MySqlCommand();
				_comando.Connection = _conexion;
				_comando.CommandType = sentencia.TipoComando;
				_comando.CommandText = sentencia.TextoComando;
				_comando.CommandTimeout = 0;

				if (sentencia.TipoManejadorTransaccion == Definiciones.TipoManejadorTransaccion.IniciarTransaccion)
					_transaccion = _conexion.BeginTransaction(IsolationLevel.ReadCommitted);
					
				if (sentencia.Parametros != null)
					foreach (Parametro oParametro in sentencia.Parametros)
					{
						MySqlParameter loParametro = new MySqlParameter();

						loParametro.Direction = (ParameterDirection)oParametro.Direccion;
						loParametro.ParameterName = oParametro.Nombre;
						loParametro.Value = oParametro.Valor;
						loParametro.DbType = oParametro.Tipo;
						_comando.Parameters.Add(loParametro);
					}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected override bool Desconectar()
		{

			try
			{

				if (_conexion.State == ConnectionState.Open)
					_conexion.Close();

				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected override object EjecutarEscalar()
		{

			try
			{
				return _comando.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected override int EjecutarNoQuery()
		{

			try
			{
				return _comando.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected override DataTable EjecutarQuery()
		{
			
			try
			{
				DataTable resultado = new DataTable();

				_adaptadorDatos = new MySqlDataAdapter();
				_adaptadorDatos.SelectCommand = _comando;
				_adaptadorDatos.SelectCommand.CommandTimeout = 0;
				_adaptadorDatos.Fill(resultado);
				return resultado;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		protected override object ObtenerParametro(string nombreParametro)
		{
			return _comando.Parameters[nombreParametro].Value;
		}

		public object Ejecutar(List<Sentencia> sentencia)
		{
			object resultado = null;

			try
			{
				Conectar();

				switch (sentencia[0].Tipo)
				{
					case Definiciones.TipoSentencia.Escalar:
						CrearComando(sentencia[0]);
						resultado = EjecutarEscalar();
						break;
					case Definiciones.TipoSentencia.NoQuery:

						foreach (Sentencia oSentencia in sentencia)
						{
							CrearComando(oSentencia);
							resultado = EjecutarNoQuery();
						}

						if (sentencia[sentencia.Count - 1].TipoManejadorTransaccion == Definiciones.TipoManejadorTransaccion.FinalizarTransaccion)
							_transaccion.Commit();

						break;
					case Definiciones.TipoSentencia.Query:
						CrearComando(sentencia[0]);
						resultado = EjecutarQuery();

						if(sentencia[0].TipoComando == CommandType.StoredProcedure && sentencia[0].Parametros != null)
							foreach (Parametro oParametro in sentencia[0].Parametros)
							{
								
								if (oParametro.Direccion != ParameterDirection.InputOutput && 
									oParametro.Direccion != ParameterDirection.Output)
									continue;
								
								oParametro.Valor = ObtenerParametro(oParametro.Nombre);

								if (sentencia[0].TipoResultado != Definiciones.TipoResultado.Conjunto &&
									sentencia[0].TipoResultado != Definiciones.TipoResultado.Vacio)
									resultado = oParametro.Valor;
							}

						break;
					default:
						resultado = Definiciones.TipoResultado.Vacio;
						break;
				}
			}
			catch (Exception ex)
			{

				if (sentencia[sentencia.Count - 1].TipoManejadorTransaccion == Definiciones.TipoManejadorTransaccion.FinalizarTransaccion)
					_transaccion.Rollback();

				throw new Exception(ex.Message, ex);
			}
			finally
			{
				Desconectar();
			}

			return resultado;
		}

		public bool Validar()
		{
			
			if (Conectar())
				return Desconectar();

			return false;
		}

		#endregion
	}
}
*/
