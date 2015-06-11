using System;
using System.Web.Security;
using System.Web.UI;
using E = Sezac.Control.Entidades;
using O = Sezac.Control;

namespace SEZAC
{
	public partial class EncargadoProgramas : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				O.Dependencia oDependencia = new O.Dependencia();
				selectDependencia.DataSource = oDependencia.ObtenerDependencia(0);
				selectDependencia.DataTextField = "Descripcion";
				selectDependencia.DataValueField = "Id";
				selectDependencia.DataBind();

				O.AnioFiscal oAnioFiscal = new O.AnioFiscal();
				selectAño.DataSource = oAnioFiscal.ObtenerAnioFiscal(0);
				selectAño.DataValueField = "Anio";
				selectAño.DataBind();

                
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
				O.Programa oPrograma = new O.Programa();
				E.Programa ePrograma = new E.Programa()
				{
					AnioFiscal = new E.AnioFiscal()
					{
						Anio = int.Parse(selectAño.Value)

					},
					Dependencia = new E.Dependencia()
					{
						Id = int.Parse(selectDependencia.Value)
					},
					Estatus = Sezac.Control.Comun.Definiciones.TipoEstatusPrograma.NoCompletado,
					Descripcion = inputPrograma.Value
				};

				if (oPrograma.ExistePrograma(ePrograma.Descripcion))
				{
					Mensaje.InnerText = "El programa ya existe";
				}
				else
				{
					oPrograma.InsertarPrograma(ePrograma);
					Mensaje.InnerText = "El programa se ha creado exitosamente";
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