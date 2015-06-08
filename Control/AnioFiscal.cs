using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class AnioFiscal
    {
        #region Atributos

        Cifrado _cifrado;
        Conexion _conexion;
        Planificador _planificador;

        #endregion

        #region Constructor

        public AnioFiscal()
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

                TextoComando = "SELECT * FROM sezac.aniofiscal WHERE anio=COALESCE(" + ((anio == 0) ? "NULL" : anio.ToString()) + ",anio)",
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            DataTable resultado = (DataTable)_planificador.Servir(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );

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

            return anioFiscal;
        }

        #endregion
    }
}
