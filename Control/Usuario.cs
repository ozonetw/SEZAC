using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class Usuario
    {
        #region Atributos

        Conexion _conexion;
        Planificador _planificador;

        #endregion

        #region Constructor

        public Usuario()
        {
            _conexion = new Conexion()
            {
                #region Inicializar

                Nombre = "SAZEC",
                Tipo = Definiciones.TipoConexion.NombreConexion,
                TipoCliente = Definiciones.TipoCliente.MySql

                #endregion
            };
            _planificador = new Planificador();
        }

        #endregion

        #region Metodos

        public Entidades.Usuario ObtenerUsuario(string login)
        {
            Entidades.Usuario usuario = new Entidades.Usuario();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                Comando = "SELECT u.*,d.nombre as dependencia FROM sezac.usuario u LEFT JOIN sezac.dependencia d ON d.id=u.dependenciaid WHERE u.Usuario='" + login + "'",
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

            #region Recuperar información

            for (int indice = 0; indice < resultado.Rows.Count; indice++)
            {
                #region Establecer valores

                usuario.ApellidoMaterno = resultado.Rows[indice]["ApellidoMaterno"].ToString();
                usuario.ApellidoPaterno = resultado.Rows[indice]["ApellidoPaterno"].ToString();
                usuario.Dependencia = new Entidades.Dependencia()
                {
                    Id = (resultado.Rows[indice]["DependenciaId"] == DBNull.Value) ? 0 : int.Parse(resultado.Rows[indice]["DependenciaId"].ToString()),
                    Descripcion = resultado.Rows[indice]["Dependencia"].ToString()
                };
                usuario.Imagen = (resultado.Rows[indice]["Imagen"] == DBNull.Value) ? null : (byte[])resultado.Rows[indice]["Imagen"];
                usuario.Login = login;
                usuario.Nombre = resultado.Rows[indice]["Nombres"].ToString();
                usuario.Tipo = (Comun.Definiciones.TipoUsuario)int.Parse(resultado.Rows[indice]["TipoUsuarioId"].ToString());

                #endregion
            }

            #endregion
            return usuario;
        }

        public bool Validar(string login, string password)
        {
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                Comando = "SELECT * FROM sezac.usuario WHERE Usuario='" + login + "' AND Contrasenia='" + password + "'",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

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

        #endregion
    }
}
