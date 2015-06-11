using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;
namespace SEZAC
{
	public partial class BeneficiarioEstado : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

                O.Beneficiario oBeneficiario = new O.Beneficiario();
                E.Usuario eUsuario = (E.Usuario)Session["Usuario"];
                Mensaje.InnerText = oBeneficiario.ObtenerEstatus(eUsuario.Login);

                switch (eUsuario.Tipo)
                {
                    case Sezac.Control.Comun.Definiciones.TipoUsuario.Administrador:
                        logImage.ImageUrl = "~/images/circle_sm.png";
                        break;
                    case Sezac.Control.Comun.Definiciones.TipoUsuario.Beneficiario:
                        logImage.ImageUrl = "~/images/circle_b.png";
                        break;
                    case Sezac.Control.Comun.Definiciones.TipoUsuario.Encargado:
                        logImage.ImageUrl = "~/images/circle_c.png";
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