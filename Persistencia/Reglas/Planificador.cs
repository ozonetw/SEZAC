using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using System;
using System.Collections.Generic;

namespace Sezac.Persistencia.Reglas
{
	public class Planificador
	{
		#region Metodos

		/// <summary>
		/// Atiende los requerimientos entrantes, provenientes del Control
		/// </summary>
		/// <param name="poConexion">Parámetros de conexión a la base de datos</param>
		/// <returns>True, si los parámetros de conexión son válidos. False, en caso contrario.</returns>
		public bool Servir(Conexion conexion)
		{

			try
			{

				switch (conexion.TipoCliente)
				{
					case Definiciones.TipoCliente.MySql:
						ClienteMySql clienteMySql = new ClienteMySql(conexion);

						return clienteMySql.Validar();
					default:
						return false;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Atiende los requerimientos entrantes, provenientes del Control
		/// </summary>
		/// <param name="conexion">Parámetros de conexion a la base de datos</param>
		/// <param name="sentencia">Lista de sentencias a servir</param>
		/// <returns>Objeto que contiene el resultado de la ejecución del conjunto de sentencias</returns>
		public object Servir(Conexion conexion, List<Sentencia> sentencia)
		{

			try
			{

				switch (conexion.TipoCliente)
				{
					case Definiciones.TipoCliente.MySql:
						ClienteMySql loClienteMySql = new ClienteMySql(conexion);

						return loClienteMySql.Ejecutar(sentencia);
					default:
						return Definiciones.TipoResultado.Vacio;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		#endregion
	}
}
