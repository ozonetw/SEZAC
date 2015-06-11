using Sezac.Control.Comun;
using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoVetados : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

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

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			try
			{
				O.Beneficiario oBeneficiario = new O.Beneficiario();

				vetadGrid.DataSource = oBeneficiario.ObtenerVetados(inputDef.Value, (Definiciones.TipoParametroBusqueda)int.Parse(tipoParametro.SelectedItem.Value));
				vetadGrid.DataBind();
			}
			catch
			{
				throw;
			}
		}
	}
}