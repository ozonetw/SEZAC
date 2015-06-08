using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class Datos
    {
        public bool Validar(string usuario, string contrasenia)
        {
            Cifrado cifrado = new Cifrado(Definiciones.TipoCifrado.AES);
            Conexion conexion = new Conexion()
            {
                #region Inicializar 

                BaseDatos = "sezac",
                Credenciales = new Credenciales()
                {
                    Usuario = "root",
                    Contrasenia = cifrado.Cifrar("root"),
                    Cifrado = cifrado
                },
                Servidor = "localhost",
                Tipo = Definiciones.TipoConexion.CredencialesExplicitas,

                #endregion
            };
            Planificador planificador = new Planificador();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                TextoComando = "SELECT * FROM sezac.usuario where Usuario = '" + usuario + "' AND Contrasenia = '" + contrasenia + "'",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            DataTable resultado = (DataTable)planificador.Servir(
                #region Ejecutar

                conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );

            return true;
        }

        public bool CrearDependencia(string nombre)
        {
            string insertar = "INSERT INTO `sezac`.`dependencia` (`Nombre`) VALUES('"+nombre+"')";
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
    }
}
