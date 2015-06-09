using System;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
    public partial class AdminAniosFiscales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		protected void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
				E.AnioFiscal eAnioFiscal = new E.AnioFiscal()
				{
					//Anio = int.Parse(TextBox1.Text)
				};

				oAnioFiscal.InsertarAnioFiscal(eAnioFiscal);
                //Label2.Text = "Año guardado exitosaente";
            }
			catch(Exception)
			{

			}
		}
    }
}