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
    public partial class EncargadoProgramas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                O.Dependencia oDependencia = new O.Dependencia();

                DropDownList1.DataSource = oDependencia.ObtenerDependencia(0);
                DropDownList1.DataTextField = "Descripcion";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();
                O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
                DropDowList2.DataSource = oAnioFiscal.ObtenerAnioFiscal(0);
                DropDowList2.DataValueField= "Anio";
                DropDowList2.DataBind();
               
            }
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            Programa.Text = "";
            try
            {
                O.Programa oPrograma= new O.Programa();
                E.Programa ePrograma = new E.Programa()
                {
                    AnioFiscal = new E.AnioFiscal()
                    {
                        Anio = int.Parse(DropDowList2.SelectedItem.Value)
                    },
                    Dependencia = new E.Dependencia()
                    {
                        Id = int.Parse(DropDownList1.SelectedItem.Value)
                    },
                    Descripcion = TextBoxPrograma.Text
                };
                if (oPrograma.ExistePrograma(ePrograma.Descripcion))
                {
                    Programa.Text = "El programa ya existe";
                }
                else
                {
                    oPrograma.InsertarPrograma(ePrograma);
                    Programa.Text = "El programa se ha creado exitosamente";
                }
            }
            catch(Exception)
            {

            }

        }
    }
}