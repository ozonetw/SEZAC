using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
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
            Entidades.Usuario usuario = new Entidades.Usuario()
            {
                #region Inicializar

                #endregion
            };

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

        public bool CrearDependencia(string nombre)
        {
            string insertar = "INSERT INTO `sezac`.`dependencia` (`Nombre`) VALUES('" + nombre + "')";
            return true;
        }

        public bool AltaBeneficiario(string[] datos, byte[] foto)
        {
            string insertar = "INSERT INTO `sezac`.`beneficiario` (`RFC`, `Nombres`, `ApellidoPaterno`, `ApellidoMaterno`, `Correo`, `Imagen`, `TipoUsuarioId`, `EstatusBeneficiarioId`) VALUES('" + datos[0] + "', '" + datos[1] + "', '" + datos[2] + "', '" + datos[3] + "', '" + datos [4] + "', " + foto + ", '3', '1')";
            return true;
        }

        public bool AltaAnioFiscal(int anio)
        {
            string insertar = "INSERT INTO `sezac`.`aniofiscal` (`Anio`) VALUES('" + anio + "')";
            return true;
        }

        #endregion
    }
}
