using Sezac.Control.Comun;

namespace Sezac.Control.Entidades
{
    public class Usuario
    {
        #region Propiedades

        public string ApellidoPaterno
        {
            get;
            set;
        }
        public string ApellidoMaterno
        {
            get;
            set;
        }
		public string Contrasenia
		{
			get;
			set;
		}
		public string Correo
		{
			get;
			set;
		}
        public Dependencia Dependencia
        {
            get;
            set;
        }
		public Definiciones.TipoEstatusBeneficiario Estatus
		{
			get;
			set;
		}
        public byte[] Imagen
        {
            get;
            set;
        }
        public string Login
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public Definiciones.TipoUsuario Tipo
        {
            get;
            set;
        }

        #endregion
    }
}
