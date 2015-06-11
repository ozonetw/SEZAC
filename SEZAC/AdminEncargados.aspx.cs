using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class AdminEncargados : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				O.Dependencia oDependencia = new O.Dependencia();

				select.DataSource = oDependencia.ObtenerDependencia(0);
				select.DataTextField = "Descripcion";
				select.DataValueField = "Id";
				select.DataBind();
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
					Contrasenia = inputPassword.Value,
					Dependencia = new E.Dependencia()
					{
						Id = int.Parse(select.Value)
					},
					Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
					Login = inputUser.Value,
					Nombre = inputName.Value,
					Tipo = O.Comun.Definiciones.TipoUsuario.Encargado
				};
				if (oUsuario.ExisteUsuario(eUsuario.Login, eUsuario.Tipo))
				{
					Mensaje.InnerText = "El encargado ya existe";
				}
				else
				{
					oUsuario.InsertarUsuario(eUsuario);
					Mensaje.InnerText = "El encargado se creó exitosamente";
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