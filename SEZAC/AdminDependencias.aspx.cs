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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try{
                O.Dependencia oDependencia = new O.Dependencia();
                E.Dependencia eDependencia = new E.Dependencia()
                {
                    Descripcion = Text1.Value
                };
                oDependencia.InsertarDependencia(eDependencia);
                Label2.Text = "La Dependencia fue creada exitosamente";
                
            }
            catch(Exception)
            {
                Label2.Text = "Ya Existe";
            }
            
        }
        
    }
}