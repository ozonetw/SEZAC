﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
    public partial class AdminEncargados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                O.Dependencia oDependencia = new O.Dependencia();
                select.DataSource = oDependencia.ObtenerDependencia(0);
                select.DataTextField = "Descripcion";
                select.DataValueField = "Id";
                select.DataBind();
            }
        }
      
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Mensaje.InnerText = "";
            Response.Write("holi");
            try
            {
                O.Usuario oUsuario = new O.Usuario();
                E.Usuario eUsuario = new E.Usuario()
                {
                    ApellidoPaterno = inputPaterno.Value,
                    ApellidoMaterno = inputMaterno.Value,
                    Contrasenia = inputPassword.Value,
                    Dependencia = new E.Dependencia()
                    {
                        Id = int.Parse(select.Value)
                    },
                    Imagen = (fotoUp.HasFile) ? fotoUp.FileBytes : null,
                    Login = inputUser.Value,
                    Nombre = inputName.Value,
                    Tipo = O.Comun.Definiciones.TipoUsuario.Encargado
                };
                if (oUsuario.ExisteUsuario(eUsuario.Login, eUsuario.Tipo))
                {
                    Mensaje.InnerText = "El encargado ya existe";
                }
                else
                {
                    oUsuario.InsertarUsuario(eUsuario);
                    Mensaje.InnerText = "El encargado se creo exitosamente";
                }
            }
            catch (Exception)
            {

            }
        }
    }
}