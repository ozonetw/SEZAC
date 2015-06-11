using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class AdminDependencias : Page
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
				O.Dependencia oDependencia = new O.Dependencia();
				E.Dependencia eDependencia = new E.Dependencia()
				{
					Descripcion = dependencia.Value
				};
				if (oDependencia.ExisteDependencia(eDependencia.Descripcion))
				{
					Mensaje.InnerText = "Ya Existe";
				}
				else
				{
					oDependencia.InsertarDependencia(eDependencia);
					Mensaje.InnerText = "La Dependencia fue creada exitosamente";
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