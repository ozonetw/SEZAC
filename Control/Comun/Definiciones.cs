namespace Sezac.Control.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

        public enum TipoUsuario
        { 
			Administrador = 1,
			Encargado,
			Beneficiario
		};
		public enum TipoEstatus
		{
			SinAsignar,
			Activo,
			Vetado
		};

		#endregion
	}
}
