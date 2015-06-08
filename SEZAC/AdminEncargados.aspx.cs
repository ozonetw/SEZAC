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
    public partial class AdminEncargados : System.Web.UI.Page
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            O.Usuario oUsuario = new O.Usuario();
            E.Usuario eUsuario = new E.Usuario()
            {
                ApellidoPaterno = Text2.Value,
                ApellidoMaterno = Text3.Value,
                Contrasenia = Password1.Value,
                Dependencia = new E.Dependencia()
                {
                    Id = int.Parse(DropDownList1.SelectedItem.Value)
                },
                Imagen = (FileUpload1.HasFile) ? FileUpload1.FileBytes : null,
                Login = Text4.Value,
                Nombre = Text1.Value,
                Tipo = O.Comun.Definiciones.TipoUsuario.Encargado
            };

            
        }
    }
}