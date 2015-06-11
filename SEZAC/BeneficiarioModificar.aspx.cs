using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;
namespace SEZAC
{
    public partial class BeneficiarioModificar : Page
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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Mensaje.InnerText = "";
            try
            {
                O.Usuario oUsuario = new O.Usuario();
                E.Usuario eUsuario = new E.Usuario()
                {
                    ApellidoPaterno = inputPaterno.Value,
                    ApellidoMaterno = inputMaterno.Value,
                    Correo = inputEmail.Value,
                    Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
                    Login = ((E.Usuario)Session["Usuario"]).Login,
                    Nombre = inputName.Value,
                    Tipo = O.Comun.Definiciones.TipoUsuario.Beneficiario
                };
                oUsuario.ActualizarUsuario(eUsuario);
                Mensaje.InnerText = "El beneficiario se ha actualizado";
            }
            catch (Exception)
            {

            }
        }
    }
}