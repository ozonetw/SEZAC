using Sezac.Control.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
    public partial class EncargadoEvaluar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			estatusBenef.SelectedIndex = 0;
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

		protected void btnEvaluar_Click(object sender, EventArgs e)
		{
			List<E.Evaluacion> evaluaciones = new List<E.Evaluacion>();
			O.Beneficiario oBeneficiario = new O.Beneficiario();

			for (int indice = 0; indice < programaGrid.Rows.Count; indice++)
				evaluaciones.Add(new E.Evaluacion()
					{
						#region Inicializar

						Rfc = ((Label)programaGrid.Rows[indice].FindControl("lblRfc")).Text,
						ProgramaId = int.Parse(((Label)programaGrid.Rows[indice].FindControl("lblProgramaId")).Text),
						ProgramaEstatus = (Definiciones.TipoEstatusPrograma)Convert.ToInt32(((CheckBox)programaGrid.Rows[indice].FindControl("chbEstatusPrograma")).Checked)

						#endregion
					}
				);

			oBeneficiario.Evaluar(evaluaciones);
			estatusBenef.SelectedItem.Text = oBeneficiario.ObtenerEstatus(evaluaciones[0].Rfc);
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			O.Beneficiario oBeneficiario = new O.Beneficiario();
			List<E.Evaluacion> datos = oBeneficiario.ObtenerDatosEvaluacion(inputDef.Value);

			programaGrid.DataSource = datos;
			programaGrid.DataBind();

			if (datos.Count > 0)
				estatusBenef.SelectedIndex = (int)datos[0].BeneficiarioEstatus - 1;
		}
    }
}