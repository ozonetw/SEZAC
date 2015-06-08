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
        public Dependencia Dependencia
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
        public string Password
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
