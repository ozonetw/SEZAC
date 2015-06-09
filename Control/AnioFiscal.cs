﻿using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class AnioFiscal
    {
        #region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public AnioFiscal()
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

        public bool InsertarAnioFiscal(Entidades.AnioFiscal anioFiscal)
        {
            return true;
        }

        public List<Entidades.AnioFiscal> ObtenerAnioFiscal(int anio)
        {
            List<Entidades.AnioFiscal> anioFiscal = new List<Entidades.AnioFiscal>();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                Comando = "SELECT * FROM sezac.aniofiscal WHERE anio=COALESCE(" + ((anio == 0) ? "NULL" : anio.ToString()) + ",anio)",
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

                anioFiscal.Add(new Entidades.AnioFiscal()
                    {
                        Anio = int.Parse(resultado.Rows[indice]["Anio"].ToString())
                    }
                );

                #endregion
            }

            #endregion
            return anioFiscal;
        }

        #endregion
    }
}