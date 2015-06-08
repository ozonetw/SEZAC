using Sezac.Control;
using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SEZAC
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

		protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
		{
			Usuario usuario = new Usuario();

			e.Authenticated = usuario.Validar(((Login)sender).UserName, ((Login)sender).Password);

			if (e.Authenticated)
				Session["Usuario"] = usuario.ObtenerUsuario(((Login)sender).UserName);
		}

		protected void Login1_LoggedIn(object sender, EventArgs e)
		{
			FormsAuthentication.RedirectFromLoginPage(((Login)sender).UserName, false);
		}

		protected void Login1_LoginError(object sender, EventArgs e)
		{
			((Login)sender).FailureText = "Usuario no v&aacute;lido";
		}
    }
}