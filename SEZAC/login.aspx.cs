using Sezac.Control;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sezac.IU
{
    public partial class Login : Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Login1.Focus();
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Usuario usuario = new Usuario();

            e.Authenticated = usuario.Validar(Login1.UserName, Login1.Password);

            if (e.Authenticated)
                Session["Usuario"] = usuario.ObtenerUsuario(Login1.UserName);
            else
                Session["Usuario"] = null;
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
			FormsAuthentication.RedirectFromLoginPage(((global::System.Web.UI.WebControls.Login)sender).UserName, false);
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
			((global::System.Web.UI.WebControls.Login)sender).FailureText = "Usuario no v&aacute;lido";
        }

        #endregion
    }
}
