﻿using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoBeneficiarios : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
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
					Estatus = O.Comun.Definiciones.TipoEstatusBeneficiario.Activo,
					Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
					Login = inputRFC.Value,
					Nombre = inputName.Value,
					Tipo = O.Comun.Definiciones.TipoUsuario.Beneficiario
				};
				if (oUsuario.ExisteUsuario(eUsuario.Login, eUsuario.Tipo))
				{
					Mensaje.InnerText = "El beneficiario ya existe";
				}
				else
				{
					oUsuario.InsertarUsuario(eUsuario);
					Mensaje.InnerText = "El beneficiario se creo exitosamente";
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