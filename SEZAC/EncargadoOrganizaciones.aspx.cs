using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;
namespace SEZAC
{
    public partial class EncargadoOrganizaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                O.Programa oPrograma = new O.Programa();
                programas_drop.DataSource = oPrograma.ObtenerPrograma(0);
                programas_drop.DataValueField = "Id";
                programas_drop.DataTextField= "Descripcion";
                programas_drop.DataBind();
                
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            CorfirmarOrg.Text = "";
            try
            {
                O.Organizacion oOrganizacion = new O.Organizacion();
                E.Organizacion eOrganizacion = new E.Organizacion()
                {
                    Programa = new E.Programa
                    {
                        Id = int.Parse(programas_drop.SelectedItem.Value)
                    },
                    Descripcion = programas_tb.Text
                };
                if (oOrganizacion.ExisteOrganizacion(eOrganizacion.Descripcion))
                {
                    CorfirmarOrg.Text = "ya existe la organizacion";
                }
                else
                {
                    oOrganizacion.InsertarOrganizacion(eOrganizacion);
                    CorfirmarOrg.Text = "La organizacion se ha creado exitosamente";
                }

            }
            catch (Exception)
            {

            }
        }
        }
}
