﻿using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class Dependencia
    {
        #region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Dependencia()
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

		public bool ExisteDependencia(string nombreDependencia)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT * FROM sezac.dependencia WHERE UPPER(nombre)='" + nombreDependencia.ToUpper() + "'",
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

        public bool InsertarDependencia(Entidades.Dependencia dependencia)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "INSERT INTO sezac.dependencia (nombre) VALUES ('" + dependencia.Descripcion + "')",
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

        public List<Entidades.Dependencia> ObtenerDependencia(int id)
        {
            List<Entidades.Dependencia> dependencias = new List<Entidades.Dependencia>();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                Comando = "SELECT * FROM sezac.dependencia WHERE id=COALESCE(" + ((id == 0) ? "NULL" : id.ToString()) + ",id)",
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

                dependencias.Add(new Entidades.Dependencia()
                    {
                        Id = int.Parse(resultado.Rows[indice]["Id"].ToString()),
                        Descripcion = resultado.Rows[indice]["Nombre"].ToString()
                    }
                );

                #endregion
            }

            #endregion
            return dependencias;
        }

        #endregion
    }
}
