using System;
using System.Web.Security;
using System.Web.UI;

namespace SEZAC
{
    public partial class AdminBeneficiarioOrganizacion : Page
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
    }
}