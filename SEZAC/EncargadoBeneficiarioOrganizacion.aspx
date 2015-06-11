<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoBeneficiarioOrganizacion.aspx.cs" Inherits="SEZAC.AdminBeneficiarioOrganizacion" MasterPageFile="~/Sezac.Master" %>

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
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="AdminDep" runat="server">
	<div>
		<p class="lead">
			Encargado > Asignación de organización a beneficiario.
		</p>
	</div>
	<div class="form-group">
		<label class="col-lg-2 control-label">Org.</label>
		<div class="col-lg-10">
			<select class="form-control" id="orgselect" runat="server">
				<option>1</option>
				<option>2</option>
				<option>3</option>
			</select>
		</div>
	</div>
	<div class="form-group">
		<label class="col-lg-2 control-label">Beneficiario</label>
		<div class="col-lg-10">
			<select class="form-control" id="benselect" runat="server">
				<option>1</option>
				<option>2</option>
				<option>3</option>
			</select>
		</div>
	</div>
	<div class="form-group">
		<div class="col-lg-10 col-lg-offset-2">
			<br />
			<br />
			<br />
			<asp:Button ID="btnInscribir" runat="server" CssClass="btn btn-primary" Text="Inscribir" OnClick="btnInscribir_Click" />
		</div>
	</div>
	<div>
        <p>
            <br/>
                <label class="control-label text-success" runat="server" id="Mensaje"></label>
            <br/>
        </p>
    </div>
</asp:Content>
