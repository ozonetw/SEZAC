using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoEncargados : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				O.Dependencia oDependencia = new O.Dependencia();
				selectDependencias.DataSource = oDependencia.ObtenerDependencia(0);
				selectDependencias.DataTextField = "Descripcion";
				selectDependencias.DataValueField = "Id";
				selectDependencias.DataBind();
			}

		}
		protected void ButtonEncargados_Click(object sender, EventArgs e)
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
						Id = int.Parse(selectDependencias.Value)
					},
					Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
					Login = inputUser.Value,
					Nombre = inputNombre.Value,
					Tipo = O.Comun.Definiciones.TipoUsuario.Encargado
				};
				if (oUsuario.ExisteUsuario(eUsuario.Login, eUsuario.Tipo))
				{
					Mensaje.InnerText = "El encargado ya existe";
				}
				else
				{
					oUsuario.InsertarUsuario(eUsuario);
					Mensaje.InnerText = "El encargado se creo exitosamente";
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
				FormsAuthentication.RedirectToLoginPage();
			}
			catch
			{
				throw;
			}
		}
	}
}