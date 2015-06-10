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
    public partial class EncargadoBeneficiarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                O.Organizacion oOrganizacion = new O.Organizacion();
                selectOrg.DataSource = oOrganizacion.ObtenerOrganizacion(0);
                selectOrg.DataTextField = "Descripcion";
                selectOrg.DataValueField = "Id";
                selectOrg.DataBind();
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Mensaje.InnerText = "";
            try
            {
                O.Usuario oUsuario = new O.Usuario();
                E.Usuario eUsuario = new E.Usuario()
                {
                    ApellidoPaterno = inputPaterno.Value,
                    ApellidoMaterno = inputMaterno.Value,
                    Contrasenia = pass1.Value,
                    Correo = inputEmail.Value,
                    // = new E.Dependencia()
                    //{
                      //  Id = int.Parse(select.Value)
                    //},
                    Estatus = O.Comun.Definiciones.TipoEstatusBeneficiario.Activo,
                    Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
                    Login = inputRFC.Value,
                    Nombre = inputName.Value,
                    Tipo = O.Comun.Definiciones.TipoUsuario.Beneficiario
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
    }
}