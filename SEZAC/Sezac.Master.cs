using Sezac.Control.Entidades;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Sezac.IU
{
    public partial class Template : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Request.Browser.Adapters.Clear();
        }
    }
}