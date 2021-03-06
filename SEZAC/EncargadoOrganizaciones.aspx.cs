﻿using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoOrganizaciones : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				O.Programa oPrograma = new O.Programa();

				selectPrograma.DataSource = oPrograma.ObtenerPrograma(0);
				selectPrograma.DataValueField = "Id";
				selectPrograma.DataTextField = "Descripcion";
				selectPrograma.DataBind();


               
                    E.Usuario usuario = (E.Usuario)Session["Usuario"];

                    switch (usuario.Tipo)
                    {
                        case Sezac.Control.Comun.Definiciones.TipoUsuario.Administrador:
                            logImage.ImageUrl = "~/images/circle_sm.png";
                            break;
                        case Sezac.Control.Comun.Definiciones.TipoUsuario.Beneficiario:
                            logImage.ImageUrl = "~/images/circle_b.png";
                            break;
                        case Sezac.Control.Comun.Definiciones.TipoUsuario.Encargado:
                            logImage.ImageUrl = "~/images/circle_c.png";
                            break;
                        default:
                            break;
                    }

                
            }
		}

		protected void btnConfirmar_Click(object sender, EventArgs e)
		{
			Mensaje.InnerText = "";

			try
			{
				O.Organizacion oOrganizacion = new O.Organizacion();
				E.Organizacion eOrganizacion = new E.Organizacion()
				{
					Programa = new E.Programa
					{
						Id = int.Parse(selectPrograma.Value)
					},
					Descripcion = inputOrganizacion.Value
				};
				if (oOrganizacion.ExisteOrganizacion(eOrganizacion.Descripcion))
				{
					Mensaje.InnerText = "Ya existe la organización";
				}
				else
				{
					oOrganizacion.InsertarOrganizacion(eOrganizacion);
					Mensaje.InnerText = "La organización se ha creado exitosamente";
				}
			}
			catch (Exception)
			{

			}
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
