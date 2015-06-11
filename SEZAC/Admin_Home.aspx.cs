using Sezac.Control.Entidades;
using System;
using System.Web.Security;
using System.Web.UI;

namespace SEZAC
{
    public partial class Admin_Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["Usuario"];

                switch (usuario.Tipo)
                {
                    case Sezac.Control.Comun.Definiciones.TipoUsuario.Administrador:
                        logImage.ImageUrl = "~/ images / circle_sm.png";
                        break;
                    case Sezac.Control.Comun.Definiciones.TipoUsuario.Beneficiario:
                        logImage.ImageUrl = "~/ images / circle_b.png";
                        break;
                    case Sezac.Control.Comun.Definiciones.TipoUsuario.Encargado:
                        logImage.ImageUrl = "~/ images / circle_c.png";
                        break;
                    default:
                        break;
                }

            }
            
           
        }

		protected void btnsalir_Click(object sender, EventArgs e)
		{
			try
			{
				FormsAuthentication.SignOut();
				Response.Redirect("login.aspx");
			}
			catch
			{
				throw;
			}
		}
    }
}