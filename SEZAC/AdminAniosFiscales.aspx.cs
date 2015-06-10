﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;


namespace SEZAC
{
    public partial class AdminAniosFiscales : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

		protected void btnAnios_Click(object sender, EventArgs e)
		{
            Mensaje.InnerText="";
			try
			{
				O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
				E.AnioFiscal eAnioFiscal = new E.AnioFiscal()
				{
					Anio = int.Parse(CampoTexto.Value)
				};
                if (oAnioFiscal.ExisteAnioFiscal(eAnioFiscal.Anio))
                {
                    Mensaje.InnerText = "Ya existe";
                  
                }
                else
                {
                    oAnioFiscal.InsertarAnioFiscal(eAnioFiscal);
                    Mensaje.InnerText = "Se ha creado exitosamente";
                }
            }
			catch(Exception)
			{

			}
        }
    }
}