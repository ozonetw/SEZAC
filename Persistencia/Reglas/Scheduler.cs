using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using System;
using System.Collections.Generic;

namespace Sezac.Persistencia.Reglas
{
	public class Scheduler
	{
		#region Metodos

		/// <summary>
		/// Atiende los requerimientos entrantes, provenientes del Control
		/// </summary>
		/// <param name="conexion">Parámetros de conexion a la base de datos</param>
		/// <param name="sentencia">Lista de sentencias a servir</param>
		/// <returns>Objeto que contiene el resultado de la ejecución del conjunto de sentencias</returns>
		public object Despachar(Conexion conexion, List<Sentencia> sentencia)
		{

			try
			{

				switch (conexion.TipoCliente)
				{
					case Definiciones.TipoCliente.MySql:
						ClienteMySql cliente = new ClienteMySql(conexion);

						return cliente.Ejecutar(sentencia);
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
