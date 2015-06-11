using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class AdminAniosFiscales : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                E.Usuario usuario = (E.Usuario)Session["Usuario"];

                switch (usuario.Tipo)
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

		protected void btnConfirmar_Click(object sender, EventArgs e)
		{
			Mensaje.InnerText = "";

			try
			{
				O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
				E.AnioFiscal eAnioFiscal = new E.AnioFiscal()
				{
					Anio = int.Parse(CampoTexto.Value)
				};

				if (oAnioFiscal.ExisteAnioFiscal(eAnioFiscal.Anio))
				{
					Mensaje.InnerText = "Ya existe";
				}
				else
				{
					oAnioFiscal.InsertarAnioFiscal(eAnioFiscal);
					Mensaje.InnerText = "Se ha creado exitosamente";
				}
			}
			catch (Exception)
			{

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
