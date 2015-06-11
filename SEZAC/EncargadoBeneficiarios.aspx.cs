using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoBeneficiarios : Page
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
				O.Usuario oUsuario = new O.Usuario();
				E.Usuario eUsuario = new E.Usuario()
				{
					ApellidoPaterno = inputPaterno.Value,
					ApellidoMaterno = inputMaterno.Value,
					Contrasenia = pass1.Value,
					Correo = inputEmail.Value,
					Estatus = O.Comun.Definiciones.TipoEstatusBeneficiario.Activo,
					Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
					Login = inputRFC.Value,
					Nombre = inputName.Value,
					Tipo = O.Comun.Definiciones.TipoUsuario.Beneficiario
				};
				if (oUsuario.ExisteUsuario(eUsuario.Login, eUsuario.Tipo))
				{
					Mensaje.InnerText = "El beneficiario ya existe";
				}
				else
				{
					oUsuario.InsertarUsuario(eUsuario);
					Mensaje.InnerText = "El beneficiario se creó exitosamente";
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