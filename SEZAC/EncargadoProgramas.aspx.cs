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
                selectDependencia.DataSource = oDependencia.ObtenerDependencia(0);
                selectDependencia.DataTextField = "Descripcion";
                selectDependencia.DataValueField = "Id";
                selectDependencia.DataBind();

                O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
                selectAño.DataSource = oAnioFiscal.ObtenerAnioFiscal(0);
                selectAño.DataValueField = "Anio";
                selectAño.DataBind();

            }
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            Mensaje.InnerText = "";
            try
            {
                O.Programa oPrograma = new O.Programa();
                E.Programa ePrograma = new E.Programa()
                {
                    AnioFiscal = new E.AnioFiscal()
                    {
                        Anio = int.Parse(selectAño.Value)

                    },
                    Dependencia = new E.Dependencia()
                    {
                        Id = int.Parse(selectDependencia.Value)
                    },
                    Estatus = Sezac.Control.Comun.Definiciones.TipoEstatusPrograma.NoCompletado,
                    Descripcion = inputPrograma.Value
                };
                if (oPrograma.ExistePrograma(ePrograma.Descripcion))
                {
                    Mensaje.InnerText = "El programa ya existe";
                }
                else
                {
                    oPrograma.InsertarPrograma(ePrograma);
                    Mensaje.InnerText = "El programa se ha creado exitosamente";
                }
            }
            catch (Exception) {
            }
        }

    }
}