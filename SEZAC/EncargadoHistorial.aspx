<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoHistorial.aspx.cs" Inherits="SEZAC.EncargadoHistorial" MasterPageFile="~/Sezac.Master" %>

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
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="hihi" runat="server">
	<div>
		<p class="lead">
			Encargado > Historial.
		</p>
	</div>
	<div class="form-horizontal">
		<fieldset>
			<div class="form-group">
				<label for="select" class="col-lg-2 control-label">Buscar</label>
				<div class="col-lg-10">
					<asp:DropDownList ID="tipoHistorial" runat="server" CssClass="form-control" OnSelectedIndexChanged="tipoHistorial_SelectedIndexChanged" AutoPostBack="true">
						<asp:ListItem Value="0" Text="Beneficiario" Selected="True" />
						<asp:ListItem Value="1" Text="Organización" />
					</asp:DropDownList>
				</div>
			</div>
			<br />
			<div class="form-group">
                <div class="row">
				    <label for="select" class="col-lg-2 control-label">Datos</label>
				    <div class="col-md-2">
					    <asp:DropDownList ID="tipoParametro" runat="server" CssClass="form-control">
						    <asp:ListItem Value="0" Text="R.F.C." Selected="True" />
						    <asp:ListItem Value="1" Text="Nombre" />
						    <asp:ListItem Value="2" Text="Apellido Paterno" />
						    <asp:ListItem Value="3" Text="Apellido Materno" />
					    </asp:DropDownList>		
				    </div>
                    <div class="col-md-6">
						<input class="form-control" runat="server" id="textoBusqueda" type="text" value="Ingrese su búsqueda" onfocus="javascript:borrar(this);" />
                    </div>
                    <div class="col-md-2">
						<asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>                             
			</div>
			<br />
			<br />
		</fieldset>
	</div>
	<div>
		<asp:GridView ID="histoGrid" runat="server" EmptyDataText="No hay registros que coincidan con los parámetros de búsqueda suministrados" />
	</div>
</asp:Content>
