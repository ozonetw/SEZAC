using Sezac.Control.Comun;

namespace Sezac.Control.Entidades
{
	public class Evaluacion
	{
		#region Propiedades

		public int AnioFiscal
		{
			get;
			set;
		}
		public string BeneficiarioNombre
		{
			get;
			set;
		}
		public Definiciones.TipoEstatusBeneficiario BeneficiarioEstatus
		{
			get;
			set;
		}
		public string Correo
		{
			get;
			set;
		}
		public string Dependencia
		{
			get;
			set;
		}
		public string Organizacion
		{
			get;
			set;
		}
		public string Programa
		{
			get;
			set;
		}
		public Definiciones.TipoEstatusPrograma ProgramaEstatus
		{
			get;
			set;
		}
		public int ProgramaId
		{
			get;
			set;
		}
		public string Rfc
		{
			get;
			set;
		}

		#endregion
	}
}
