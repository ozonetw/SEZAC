using Sezac.Control;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SEZAC
{
    public partial class login : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Login1.Focus();
        }

        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            Usuario usuario = new Usuario();

            e.Authenticated = usuario.Validar(Login1.UserName, Login1.Password);

            if (e.Authenticated)
                Session["Usuario"] = usuario.ObtenerUsuario(Login1.UserName);
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            global::Sezac.Control.Entidades.Usuario usuario = (global::Sezac.Control.Entidades.Usuario)Session["Usuario"];

            switch (usuario.Tipo)
            {
                case global::Sezac.Control.Comun.Definiciones.TipoUsuario.Administrador:
                    Server.TransferRequest("Admin_Home.aspx");
                    break;
                case global::Sezac.Control.Comun.Definiciones.TipoUsuario.Encargado:
                    break;
                case global::Sezac.Control.Comun.Definiciones.TipoUsuario.Beneficiario:
                    break;
                default:
                    break;
            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
			((Login)sender).FailureText = "Usuario no v&aacute;lido";
        }

        #endregion
    }
}
