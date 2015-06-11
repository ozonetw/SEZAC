using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Sezac.Control
{
    public class Usuario
    {
        #region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Usuario()
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

		public bool ActualizarUsuario(Entidades.Usuario usuario)
		{
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Parametros = new List<Parametro>(),
				Tipo = Definiciones.TipoSentencia.NoQuery,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Entero

                #endregion
            };

			#region Establecer comando

			switch (usuario.Tipo)
			{
				case Comun.Definiciones.TipoUsuario.Beneficiario:
					sentencia.Comando = "UPDATE sezac.beneficiario SET nombres=@Nombre,apellidopaterno=@ApellidoPaterno,apellidomaterno=@ApellidoMaterno,contrasenia=@Contrasenia,correo=@Correo,imagen=@Imagen WHERE rfc=@Rfc";
					#region Parametros
					
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Nombre",
							Tipo = DbType.String,
							Valor = usuario.Nombre
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@ApellidoPaterno",
							Tipo = DbType.String,
							Valor = usuario.ApellidoPaterno
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@ApellidoMaterno",
							Tipo = DbType.String,
							Valor = usuario.ApellidoMaterno
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Contrasenia",
							Tipo = DbType.String,
							Valor = usuario.Contrasenia
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Correo",
							Tipo = DbType.String,
							Valor = usuario.Correo
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Imagen",
							Tipo = DbType.Binary,
							Valor = usuario.Imagen
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Rfc",
							Tipo = DbType.String,
							Valor = usuario.Login
						}
					);

					#endregion
					break;
				default:
					break;
			}

			#endregion
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

		public byte[] CargarImagen(string rutaArchivo)
		{
			byte[] imagen = null;

			using(FileStream archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
			{
				using(BinaryReader lector = new BinaryReader(archivo))
				{
					imagen = lector.ReadBytes((int)archivo.Length);
				}
			}

			return imagen;
		}

		public bool ExisteUsuario(string login, Comun.Definiciones.TipoUsuario tipoUsario)
        {
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Entero

                #endregion
            };

			#region Establecer comando

			switch (tipoUsario)
			{
				case Comun.Definiciones.TipoUsuario.Encargado:
					sentencia.Comando = "SELECT * FROM sezac.usuario WHERE UPPER(usuario)='" + login.ToUpper() + "'";
					break;
				case Comun.Definiciones.TipoUsuario.Beneficiario:
					sentencia.Comando = "SELECT * FROM sezac.beneficiario WHERE UPPER(rfc)='" + login.ToUpper() + "'";
					break;
				default:
					break;
			}

			#endregion

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

		public bool InsertarUsuario(Entidades.Usuario usuario)
		{
			Sentencia sentencia = new Sentencia()
			{
				#region Inicializar

				Parametros = new List<Parametro>(),
				Tipo = Definiciones.TipoSentencia.NoQuery,
				TipoComando = CommandType.Text,
				TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
				TipoResultado = Definiciones.TipoResultado.Entero

				#endregion
			};

			#region Establecer comando

			switch (usuario.Tipo)
			{
				case Comun.Definiciones.TipoUsuario.Encargado:
					sentencia.Comando = "INSERT INTO sezac.usuario (usuario,contrasenia,nombres,apellidopaterno,apellidomaterno,imagen,tipousuarioid,dependenciaid) VALUES (@Usuario,@Contrasenia,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Imagen,@TipoUsuario,@Dependencia)";
					#region Parametros
					
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Usuario",
							Tipo = DbType.String,
							Valor = usuario.Login
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Contrasenia",
							Tipo = DbType.String,
							Valor = usuario.Contrasenia
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Nombre",
							Tipo = DbType.String,
							Valor = usuario.Nombre
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@ApellidoPaterno",
							Tipo = DbType.String,
							Valor = usuario.ApellidoPaterno
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@ApellidoMaterno",
							Tipo = DbType.String,
							Valor = usuario.ApellidoMaterno
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Imagen",
							Tipo = DbType.Binary,
							Valor = usuario.Imagen
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@TipoUsuario",
							Tipo = DbType.Int32,
							Valor = (int)usuario.Tipo
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Dependencia",
							Tipo = DbType.Int32,
							Valor = usuario.Dependencia.Id
						}
					);

					#endregion
					break;
				case Comun.Definiciones.TipoUsuario.Beneficiario:
					sentencia.Comando = "INSERT INTO sezac.beneficiario (rfc,nombres,apellidopaterno,apellidomaterno,contrasenia,correo,imagen,tipousuarioid,estatusbeneficiarioid) VALUES (@Rfc,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Contrasenia,@Correo,@Imagen,@TipoUsuario,@Estatus)";
					#region Parametros
					
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Rfc",
							Tipo = DbType.String,
							Valor = usuario.Login
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Nombre",
							Tipo = DbType.String,
							Valor = usuario.Nombre
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@ApellidoPaterno",
							Tipo = DbType.String,
							Valor = usuario.ApellidoPaterno
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@ApellidoMaterno",
							Tipo = DbType.String,
							Valor = usuario.ApellidoMaterno
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Contrasenia",
							Tipo = DbType.String,
							Valor = usuario.Contrasenia
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Correo",
							Tipo = DbType.String,
							Valor = usuario.Correo
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Imagen",
							Tipo = DbType.Binary,
							Valor = usuario.Imagen
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@TipoUsuario",
							Tipo = DbType.Int32,
							Valor = (int)usuario.Tipo
						}
					);
					sentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "@Estatus",
							Tipo = DbType.Int32,
							Valor = (int)usuario.Estatus
						}
					);

					#endregion
					break;
				default:
					break;
			}

			#endregion
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

        public Entidades.Usuario ObtenerUsuario(string login)
        {
            Entidades.Usuario usuario = new Entidades.Usuario();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Comando = "SELECT u.*,d.nombre AS Dependencia,'' AS Correo,0 AS Estatus FROM sezac.usuario u LEFT JOIN sezac.dependencia d ON d.id=u.dependenciaid WHERE u.Usuario='" + login + "' " +
				          "UNION " +
						  "SELECT rfc AS Usuario,contrasenia,nombres,apellidopaterno,apellidomaterno,imagen,tipousuarioid,0 AS DependenciaId,'' AS Dependencia,correo,estatusbeneficiarioid AS Estatus FROM sezac.beneficiario WHERE rfc='" + login + "'",
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
				usuario.Correo = resultado.Rows[indice]["Correo"].ToString();
				usuario.Estatus = (Comun.Definiciones.TipoEstatusBeneficiario)int.Parse(resultado.Rows[indice]["Estatus"].ToString());
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

                Comando = "SELECT usuario AS Login FROM sezac.usuario WHERE UPPER(usuario)='" + login + "' AND contrasenia='" + password + "'" +
						  "UNION " +
						  "SELECT rfc AS Login FROM sezac.beneficiario WHERE UPPER(rfc)='" + login + "' AND contrasenia='" + password + "'",
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
