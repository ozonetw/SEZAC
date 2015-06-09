using Sezac.Control.Comun;

namespace Sezac.Control.Entidades
{
    public class Programa
    {
        #region Propiedades

		public AnioFiscal AnioFiscal
		{
			get;
			set;
		}
		public Dependencia Dependencia
		{
			get;
			set;
		}
		public Definiciones.TipoEstatusPrograma Estatus
		{
			get;
			set;
		}
        public int Id
        {
            get;
            set;
        }
        public string Descripcion
        {
            get;
            set;
        }

        #endregion
    }
}
