using Sezac.Control.Comun;
using Sezac.Control.Entidades;
using System;
using System.Web.Security;
using System.Web.UI;

namespace Sezac.IU
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Usuario usuario = (Usuario)Session["Usuario"];

                switch (usuario.Tipo)
                {
                    case Definiciones.TipoUsuario.Administrador:
                        Response.Redirect("Admin_Home.aspx", true);
                        break;
                    case Definiciones.TipoUsuario.Encargado:
                        Response.Redirect("EncargadoHome.aspx", true);
                        break;
                    case Definiciones.TipoUsuario.Beneficiario:
                        Response.Redirect("BeneficiarioHome.aspx", true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}