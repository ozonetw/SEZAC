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