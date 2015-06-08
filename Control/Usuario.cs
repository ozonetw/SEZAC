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

        Cifrado _cifrado;
        Conexion _conexion;
        Planificador _planificador;

        #endregion

        #region Constructor

        public Usuario()
        {
            _cifrado = new Cifrado(Definiciones.TipoCifrado.AES);
            _conexion = new Conexion()
            {
                #region Inicializar

                BaseDatos = "sezac",
                Credenciales = new Credenciales()
                {
                    Usuario = "root",
                    Contrasenia = _cifrado.Cifrar("root"),
                    Cifrado = _cifrado
                },
                Servidor = "localhost",
                Tipo = Definiciones.TipoConexion.CredencialesExplicitas,

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

                TextoComando = "SELECT * FROM sezac.usuario where Usuario = '" + login + "'",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            DataTable resultado = (DataTable)_planificador.Servir(
                #region Ejecutar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );

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

            return usuario;
        }

        public bool Validar(string login, string password)
        {
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                TextoComando = "SELECT * FROM sezac.usuario where Usuario = '" + login + "' AND Contrasenia = '" + password + "'",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            DataTable resultado = (DataTable)_planificador.Servir(
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
