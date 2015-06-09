namespace Sezac.Control.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

		public enum TipoEstatusBeneficiario
		{
			SinAsignar,
			Activo,
			Vetado
		};
		public enum TipoEstatusPrograma
		{
			NoCompletado,
			Completado
		};
		public enum TipoHistorial
		{
			Beneficiario,
			Organizacion
		};
        public enum TipoUsuario
        { 
			Administrador = 1,
			Encargado,
			Beneficiario
		};

		#endregion
	}
}
