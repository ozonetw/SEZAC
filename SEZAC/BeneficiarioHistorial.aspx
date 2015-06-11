<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeneficiarioHistorial.aspx.cs" Inherits="SEZAC.BeneficiarioHistorial" MasterPageFile="~/Sezac.Master" %>

<asp:Content ID="scripts" ContentPlaceHolderID="head" runat="server">
	<script>
		function borrar(componente) {
			componente.value = "";
		}
	</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="navholder" ID="beneNav" runat="server">
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
					<li class="active"><a href="BeneficiarioHome.aspx" target="_self">Inicio</a></li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Información</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="BeneficiarioModificar.aspx" target="_self">Modificación</a></li>
						</ul>
					</li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Historial</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="BeneficiarioHistorial.aspx" target="_self">Consultar</a></li>
						</ul>
					</li>
					<li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Estado</a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="BeneficiarioEstado.aspx" target="_self">Consultar</a></li>
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
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="benhist" runat="server">
	<div>
		<p class="lead">
			Beneficiario > Historial.
		</p>
	</div>
	<div>
		<asp:GridView ID="histoGrid" runat="server" EmptyDataText="No hay registros que coincidan con los parámetros de búsqueda suministrados" />
	</div>

</asp:Content>
