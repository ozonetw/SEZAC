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
    public partial class AdminDependencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDependencias_Click(object sender, EventArgs e)
        {
            Mensaje.InnerText = "";
            try{
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
            catch(Exception)
            {
            }
            
        }
        
    }
}