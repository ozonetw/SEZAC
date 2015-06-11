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