using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
    public partial class AdminBeneficiarioOrganizacion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				O.Organizacion oOrganizacion = new O.Organizacion();

				orgselect.DataSource = oOrganizacion.ObtenerOrganizacion(0);
				orgselect.DataValueField = "Id";
				orgselect.DataTextField = "Descripcion";
				orgselect.DataBind();

				O.Beneficiario oBeneficiario = new O.Beneficiario();

				benselect.DataSource = oBeneficiario.ObtenerBeneficiario(null);
				benselect.DataValueField = "Id";
				benselect.DataTextField = "Descripcion";
				benselect.DataBind();
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

		protected void btnInscribir_Click(object sender, EventArgs e)
		{
			Mensaje.InnerText = "";

			try
			{
				O.Beneficiario oBeneficiario = new O.Beneficiario();

				if (oBeneficiario.ExisteInscripcion(int.Parse(orgselect.Value), benselect.Value))
				{
					Mensaje.InnerText = "El beneficiario ya está inscrito en la organización";
				}
				else
				{
					oBeneficiario.InscribirEnOrganizacion(int.Parse(orgselect.Value), benselect.Value);
					Mensaje.InnerText = "Inscripción realizada correctamente.";
				}
			}
			catch (Exception)
			{

			}
		}
    }
}