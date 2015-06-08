using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
    public class Dependencia
    {
        #region Atributos

        Cifrado _cifrado;
        Conexion _conexion;
        Planificador _planificador;

        #endregion

        #region Constructor

        public Dependencia()
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

        public bool InsertarDependencia(Entidades.Dependencia dependencia)
        {
            return true;
        }

        public List<Entidades.Dependencia> ObtenerDependencia(int id)
        {
            List<Entidades.Dependencia> dependencias = new List<Entidades.Dependencia>();
            Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

                TextoComando = "SELECT * FROM sezac.dependencia WHERE id=COALESCE(" + ((id == 0) ? "NULL" : id.ToString()) + ",id)",
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

                dependencias.Add(new Entidades.Dependencia()
                    {
                        Id = int.Parse(resultado.Rows[indice]["DependenciaId"].ToString()),
                        Descripcion = resultado.Rows[indice]["Nombe"].ToString()
                    }
                );

                #endregion
            }

            return dependencias;
        }

        #endregion
    }
}
