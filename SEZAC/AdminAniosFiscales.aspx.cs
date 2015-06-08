using O = Sezac.Control;
using E = Sezac.Control.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEZAC
{
    public partial class AdminAniosFiscales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		protected void Button1_Click(object sender, EventArgs e)
		{
			O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
			E.AnioFiscal eAnioFiscal = new E.AnioFiscal()
			{
				Anio = int.Parse(TextBox1.Text)
			};

			oAnioFiscal.InsertarAnioFiscal(eAnioFiscal);
		}
    }
}