<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoEvaluar.aspx.cs" Inherits="SEZAC.EncargadoEvaluar" MasterPageFile="~/Sezac.Master" %>

<asp:Content ID="scripts" ContentPlaceHolderID="head" runat="server">
	<script>
		function borrar(componente) {
			componente.value = "";
		}
	</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="navholder" ID="encargadoNav" runat="server">
	<nav id="myNavbar" class="navbar navbar-default navbar-inverse navbar-fixed-top" role="navigation">
		<!-- Brand and toggle get grouped for better mobile display -->
		<div class="container">
			<div class="navbar-header">
				<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbarCollapse">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
				<a class="navbar-brand" href="#">Sezac</a>
			</div>
			<!-- Collect the nav links, forms, and other content for toggling -->
			<div class="collapse navbar-collapse" id="navbarCollapse">
				<ul class="nav navbar-nav">
					<li class="active"><a href="EncargadoHome.aspx" target="_self">Inicio</a></li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Programas</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="EncargadoProgramas.aspx" target="_self">Crear</a></li>
						</ul>
					</li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Encargados</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="EncargadoEncargados.aspx" target="_self">Crear</a></li>
						</ul>
					</li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Organizaciones</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="EncargadoOrganizaciones.aspx" target="_self">Crear</a></li>
						</ul>
					</li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Beneficiarios</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="EncargadoBeneficiarios.aspx" target="_self">Crear</a></li>
							<li><a href="EncargadoHistorial.aspx">Historial</a></li>
							<li><a href="EncargadoBeneficiarioOrganizacion.aspx">Asignación</a></li>
							<li><a href="EncargadoEvaluar.aspx">Evaluación</a></li>
							<li><a href="EncargadoVetados.aspx">Vetados</a></li>
						</ul>
					</li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Busqueda</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="EncargadoBuscar.aspx" target="_self">Consulta</a></li>
						</ul>
					</li>
				</ul>
				<ul class="nav navbar-nav navbar-right">
                    <li>
                        <asp:Image ID="logImage" runat="server"/>
                    </li>
					<li><a>Bievenido,
						<asp:LoginName ID="LoginName1" runat="server" />
					</a></li>
					<li>
						<asp:LinkButton Text="Salir" runat="server" ID="btnsalir" OnClick="btnsalir_Click"></asp:LinkButton></li>
				</ul>
			</div>
		</div>
	</nav>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="oversoul" runat="server">
	<div class="row">
		<div class="col-md-1">
			<p>
				<label class="col-lg-2 control-label">Campos</label>
			</p>
		</div>
		<div class="col-md-2">
			<p>
				<asp:DropDownList ID="tipoParametro" runat="server" CssClass="form-control" Enabled="false">
					<asp:ListItem Value="0" Text="R.F.C." Selected="True" />
					<asp:ListItem Value="1" Text="Nombre" />
					<asp:ListItem Value="2" Text="Apellido Paterno" />
					<asp:ListItem Value="3" Text="Apellido Materno" />
				</asp:DropDownList>
			</p>
		</div>
		<div class="col-md-5">
			<p>
				<input type="text" runat="server" class="form-control" id="inputDef" placeholder="Introduzca el término de busqueda..." onfocus="javascript:borrar(this);" />
			</p>
		</div>
		<div class="col-md-2">
			<asp:Button ID="btnBuscar" runat="server" class="btn btn-primary btn-lg" Text="Buscar" OnClick="btnBuscar_Click" />
		</div>
	</div>
	<br />
	<div class="col-lg-10">
		<div class="well bs-component">
			<div class="form-horizontal" style="width:100%;">
				<fieldset>
					<legend>Programas</legend>
					<div class="form-group">
						<div>
							<asp:GridView ID="programaGrid" runat="server" EmptyDataText="No hay registros que coincidan con los parámetros de búsqueda suministrados" AutoGenerateColumns="false" BorderColor="Gray" BorderStyle="Solid">
								<Columns>
									<asp:TemplateField>
										<HeaderTemplate>
											<table>
												<tr>
													<td style="width:100px;text-align:left;">
														<asp:Label runat="server" Text="R.F.C." />
													</td>
													<td style="width:240px;text-align:left;">
														<asp:Label runat="server" Text="Nombre" />
													</td>
													<td style="width:180px;text-align:left;">
														<asp:Label runat="server" Text="Correo" />
													</td>
													<td style="width:280px;text-align:left;">
														<asp:Label runat="server" Text="Organizacion" />
													</td>
													<td style="width:280px;text-align:left;">
														<asp:Label runat="server" Text="Programa" />
													</td>
													<td>
														<asp:Label runat="server" Text="Estatus" />
													</td>
												</tr>
											</table>
										</HeaderTemplate>
										<ItemTemplate>
											<table>
												<tr>
													<td style="width:100px;text-align:left;">
														<asp:Label ID="lblRFC" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("Rfc"))) %>' />
													</td>
													<td style="width:240px;text-align:left;">
														<asp:Label runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("BeneficiarioNombre"))) %>' />
													</td>
													<td style="width:180px;text-align:left;">
														<asp:Label runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("Correo"))) %>' />
													</td>
													<td style="width:280px;text-align:left;">
														<asp:Label runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("Organizacion"))) %>' />
													</td>
													<td style="width:280px;text-align:left;">
														<asp:Label runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("Programa"))) %>' />
														<asp:Label ID="lblProgramaId" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("ProgramaId"))) %>' Visible="false" />
													</td>
													<td>
														<asp:CheckBox ID="chbEstatusPrograma" runat="server" Checked='<%# (HttpUtility.HtmlEncode(Convert.ToString( Eval("ProgramaEstatus"))) == "NoCompletado") ? false : true %>' />
													</td>
												</tr>
											</table>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</div>
					</div>
					<div class="form-group">
						<label for="select" class="col-lg-2 control-label">Estado del Benef.</label>
						<div class="col-lg-10">
							<asp:DropDownList ID="estatusBenef" runat="server" CssClass="form-control" Enabled="false">
								<asp:ListItem Value="1" Text="ACTIVO" Selected="True" />
								<asp:ListItem Value="2" Text="VETADO" />
							</asp:DropDownList>
						</div>
					</div>
					<div class="col-lg-10 col-lg-offset-2">
						<br />
						<asp:Button ID="btnEvaluar" runat="server" CssClass="btn btn-primary" Text="Evaluar" OnClick="btnEvaluar_Click" />
					</div>
				</fieldset>
			</div>
		</div>
	</div>

</asp:Content>
