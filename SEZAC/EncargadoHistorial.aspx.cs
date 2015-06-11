using Sezac.Control.Comun;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
    public partial class EncargadoHistorial : Page
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

		protected void tipoHistorial_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataTable parametros = new DataTable()
			{
				#region Inicializar

				Columns = {
					new DataColumn("Id", typeof(int)),
					new DataColumn("Descripcion", typeof(string))
				}

				#endregion
			};

			switch (((DropDownList)sender).SelectedIndex)
			{
				case (int)Definiciones.TipoHistorial.Beneficiario:
					parametros.Rows.Add(new object[] { 0, "R.F.C." });
					parametros.Rows.Add(new object[] { 1, "Nombre" });
					parametros.Rows.Add(new object[] { 2, "Apellido Paterno" });
					parametros.Rows.Add(new object[] { 3, "Apellido Materno" });
					break;
				case (int)Definiciones.TipoHistorial.Organizacion:
					parametros.Rows.Add(new object[] { 1, "Nombre" });
					break;
				default:
					break;
			}

			tipoParametro.DataSource = parametros;
			tipoParametro.DataValueField = "Id";
			tipoParametro.DataTextField = "Descripcion";
			tipoParametro.DataBind();
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			try
			{
				O.Historial oHistorial = new O.Historial();
				E.Historial eHistorial = new E.Historial();

				eHistorial = oHistorial.ObtenerHistorialInscripciones((string.IsNullOrEmpty(textoBusqueda.Value)) ? "----" : textoBusqueda.Value, (Definiciones.TipoHistorial)int.Parse(tipoHistorial.SelectedItem.Value), (Definiciones.TipoParametroBusqueda)int.Parse(tipoParametro.SelectedItem.Value));
				histoGrid.DataSource = eHistorial.Datos;
				histoGrid.DataBind();
			}
			catch
			{
				throw;
			}
		}
    }
}