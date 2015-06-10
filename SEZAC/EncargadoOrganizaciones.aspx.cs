using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoOrganizaciones : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				O.Programa oPrograma = new O.Programa();

				selectPrograma.DataSource = oPrograma.ObtenerPrograma(0);
				selectPrograma.DataValueField = "Id";
				selectPrograma.DataTextField = "Descripcion";
				selectPrograma.DataBind();

			}
		}

		protected void Unnamed4_Click(object sender, EventArgs e)
		{
			Mensaje.InnerText = "";
			try
			{
				O.Organizacion oOrganizacion = new O.Organizacion();
				E.Organizacion eOrganizacion = new E.Organizacion()
				{
					Programa = new E.Programa
					{
						Id = int.Parse(selectPrograma.Value)
					},
					Descripcion = inputOrganizacion.Value
				};
				if (oOrganizacion.ExisteOrganizacion(eOrganizacion.Descripcion))
				{
					Mensaje.InnerText = "ya existe la organizacion";
				}
				else
				{
					oOrganizacion.InsertarOrganizacion(eOrganizacion);
					Mensaje.InnerText = "La organizacion se ha creado exitosamente";
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
