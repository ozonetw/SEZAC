using Sezac.Control.Comun;
using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
    public partial class BeneficiarioHistorial : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
				O.Historial oHistorial = new O.Historial();
				E.Historial eHistorial = new E.Historial();
				E.Usuario eUsuario = (E.Usuario)Session["Usuario"];

				eHistorial = oHistorial.ObtenerHistorialInscripciones(eUsuario.Login, Definiciones.TipoHistorial.Beneficiario, Definiciones.TipoParametroBusqueda.RFC);
				histoGrid.DataSource = eHistorial.Datos;
				histoGrid.DataBind();
			}
			catch
			{
				throw;
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