using Sezac.Persistencia.Comun;
using Sezac.Persistencia.Entidades;
using Sezac.Persistencia.Reglas;
using System.Collections.Generic;
using System.Data;

namespace Sezac.Control
{
	public class Historial
	{
		#region Atributos

        Conexion _conexion;
        Scheduler _planificador;

        #endregion

        #region Constructor

        public Historial()
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

        public Entidades.Historial ObtenerHistorialInscripciones(string item, Comun.Definiciones.TipoHistorial tipoHistorial, Comun.Definiciones.TipoParametroBusqueda tipoParametroBusqueda)
        {
			Entidades.Historial historial = new Entidades.Historial();
			Sentencia sentencia = new Sentencia()
            {
                #region Inicializar

				Parametros = new List<Parametro>(),
                Tipo = Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoTransaccion = Definiciones.TipoTransaccion.NoTransaccion,
                TipoResultado = Definiciones.TipoResultado.Conjunto

                #endregion
            };
            
			#region Establecer comando

			switch (tipoHistorial)
			{
				case Comun.Definiciones.TipoHistorial.Beneficiario:
					#region determinar parámetro

					switch (tipoParametroBusqueda)
					{
						case Comun.Definiciones.TipoParametroBusqueda.RFC:
							sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,b.EstatusBeneficiarioId,eb.descripcion AS EstatusBeneficiario,o.Organizacion,o.ProgramaId,o.Programa,o.Dependencia,o.AnioFiscal,o.Estatus AS EstatusPrograma FROM sezac.beneficiario b,sezac.estatusbeneficiario eb,sezac.organizacionesbeneficiarios ob,(SELECT o.Id,o.nombre AS Organizacion,p.id AS ProgramaId,p.nombre AS Programa,p.Dependencia,p.AnioFiscal,p.Estatus FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid) o WHERE eb.id=b.estatusbeneficiarioid AND ob.beneficiariorfc=b.rfc AND ob.organizacionid=o.id AND UPPER(b.rfc) LIKE @Item";
							break;
						case Comun.Definiciones.TipoParametroBusqueda.Nombre:
							sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,b.EstatusBeneficiarioId,eb.descripcion AS EstatusBeneficiario,o.Organizacion,o.ProgramaId,o.Programa,o.Dependencia,o.AnioFiscal,o.Estatus AS EstatusPrograma FROM sezac.beneficiario b,sezac.estatusbeneficiario eb,sezac.organizacionesbeneficiarios ob,(SELECT o.Id,o.nombre AS Organizacion,p.id AS ProgramaId,p.nombre AS Programa,p.Dependencia,p.AnioFiscal,p.Estatus FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid) o WHERE eb.id=b.estatusbeneficiarioid AND ob.beneficiariorfc=b.rfc AND ob.organizacionid=o.id AND UPPER(b.nombres) LIKE @Item";
							break;
						case Comun.Definiciones.TipoParametroBusqueda.ApellidoPaterno:
							sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,b.EstatusBeneficiarioId,eb.descripcion AS EstatusBeneficiario,o.Organizacion,o.ProgramaId,o.Programa,o.Dependencia,o.AnioFiscal,o.Estatus AS EstatusPrograma FROM sezac.beneficiario b,sezac.estatusbeneficiario eb,sezac.organizacionesbeneficiarios ob,(SELECT o.Id,o.nombre AS Organizacion,p.id AS ProgramaId,p.nombre AS Programa,p.Dependencia,p.AnioFiscal,p.Estatus FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid) o WHERE eb.id=b.estatusbeneficiarioid AND ob.beneficiariorfc=b.rfc AND ob.organizacionid=o.id AND UPPER(b.apellidopaterno) LIKE @Item";
							break;
						case Comun.Definiciones.TipoParametroBusqueda.ApellidoMaterno:
							sentencia.Comando = "SELECT b.Rfc,TRIM(CONCAT(b.nombres,' ',b.apellidopaterno,' ',b.apellidomaterno)) AS Nombre,b.Correo,b.EstatusBeneficiarioId,eb.descripcion AS EstatusBeneficiario,o.Organizacion,o.ProgramaId,o.Programa,o.Dependencia,o.AnioFiscal,o.Estatus AS EstatusPrograma FROM sezac.beneficiario b,sezac.estatusbeneficiario eb,sezac.organizacionesbeneficiarios ob,(SELECT o.Id,o.nombre AS Organizacion,p.id AS ProgramaId,p.nombre AS Programa,p.Dependencia,p.AnioFiscal,p.Estatus FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid) o WHERE eb.id=b.estatusbeneficiarioid AND ob.beneficiariorfc=b.rfc AND ob.organizacionid=o.id AND UPPER(b.apellidomaterno) LIKE @Item";
							break;
						default:
							break;
					}

					#endregion
					break;
				case Comun.Definiciones.TipoHistorial.Organizacion:
					sentencia.Comando = "SELECT o.Id,o.nombre AS Organizacion,p.nombre AS Programa,p.Dependencia,p.AnioFiscal,p.Estatus FROM sezac.organizacion o,(SELECT p.*,d.nombre AS Dependencia FROM sezac.programa p,sezac.dependencia d WHERE d.id=p.dependenciaid) p WHERE p.id=o.programaid AND UPPER(o.nombre) LIKE @Item";
					break;
				default:
					break;
			}

			sentencia.Parametros.Add(new Parametro()
				#region Inicializar

				{
					Direccion = ParameterDirection.Input,
					Nombre = "@Item",
					Tipo = DbType.String,
					Valor = "%" + item.ToUpper().Replace(" ", "%") + "%"
				}

				#endregion
			);

			#endregion

			historial.Tipo = tipoHistorial;
			historial.Datos = (DataTable)_planificador.Despachar(
                #region Inicializar

                _conexion, new List<Sentencia>() 
                { 
                    sentencia
                }

                #endregion
            );
            return historial;
        }

        #endregion
	}
}
