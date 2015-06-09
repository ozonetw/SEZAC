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
            Label2.Text="";
			try
			{
				O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
				E.AnioFiscal eAnioFiscal = new E.AnioFiscal()
				{
					Anio = int.Parse(TextBox1.Text)
				};
                if (oAnioFiscal.ExisteAnioFiscal(eAnioFiscal.Anio))
                {
                    Label2.Text = "Ese año ya existe";
                }
                else
                {
                    oAnioFiscal.InsertarAnioFiscal(eAnioFiscal);
                    Label2.Text = "Año guardado exitosaente";
                }
            }
			catch(Exception)
			{

			}
		}
    }
}