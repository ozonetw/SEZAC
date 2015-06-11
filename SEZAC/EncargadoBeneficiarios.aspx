<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoBeneficiarios.aspx.cs" Inherits="SEZAC.EncargadoBeneficiarios" MasterPageFile="~/Sezac.Master" %>
<asp:Content ID="scripts" ContentPlaceHolderID="head" runat="server">
	<script>
		function imagePreview(input) {
			if (input.files && input.files[0]) {
				var fildr = new FileReader();
				fildr.onload = function (e) {
					$('#imgPre').attr('src', e.target.result)
				}
				fildr.readAsDataURL(input.files[0]);
			}
		}
		function removeImage() {
			$('#imgPre').attr('src', this.removeImage)
		}
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
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="hi" runat="server">
	<div>
		<p class="lead">
			Encargado > Alta de Beneficiarios.
		</p>
		<p>
			Por favor ingrese los datos del beneficiario a registrar.
		</p>
	</div>
	<div class="container">
		<div class="row">
			<div class="col-lg-5">
				<div class="form-horizontal">
					<fieldset>
						<legend>Imagen</legend>
						<div class="form-group">
							<label for="inputEmail" class="col-lg-2 control-label">Fotografía</label>
							<div class="col-lg-10">
								<asp:Image ID="foto" runat="server" />
							</div>
						</div>
						<div class="form-group">
							<div class="col-lg-10">
								<asp:FileUpload ID="fotoUp" runat="server" onchange="imagePreview(this);" />
								<img id="imgPre" />
							</div>
						</div>
					</fieldset>
				</div>
			</div>
			<div class="col-lg-5">
				<div class="form-horizontal">
					<fieldset>
						<legend>Datos</legend>
						<div class="form-group">
							<label for="inputRFC" class="col-lg-2 control-label">R.F.C</label>
							<div class="col-lg-10">
								<input type="text" runat="server" class="form-control" id="inputRFC" placeholder="Registro federal de causantes" onfocus="javascript:borrar(this);" />
							</div>
						</div>
						<div class="form-group">
							<label for="inputName" class="col-lg-2 control-label">Nombre</label>
							<div class="col-lg-10">
								<input type="text" runat="server" class="form-control" id="inputName" name="inputName" placeholder="Nombre" onfocus="javascript:borrar(this);"/>
							</div>
						</div>
						<div class="form-group">
							<label for="inputPaterno" class="col-lg-2 control-label">Apellido Paterno</label>
							<div class="col-lg-10">
								<input type="text" runat="server" class="form-control" id="inputPaterno" name="inputPaterno" placeholder="Apellido Paterno" onfocus="javascript:borrar(this);"/>
							</div>
						</div>
						<div class="form-group">
							<label for="inputMaterno" class="col-lg-2 control-label">Apellido Materno</label>
							<div class="col-lg-10">
								<input type="text" runat="server" class="form-control" id="inputMaterno" name="inputMaterno" placeholder="Apellido Materno" onfocus="javascript:borrar(this);"/>
							</div>
						</div>
						<div class="form-group">
							<label for="inputPassword" class="col-lg-2 control-label">Password</label>
							<div class="col-lg-10">
								<input type="password" runat="server" class="form-control" id="pass1" placeholder="Password" />
							</div>
						</div>
						<div class="form-group">
							<label for="inputEmail" class="col-lg-2 control-label">Email</label>
							<div class="col-lg-10">
								<input type="text" runat="server" class="form-control" id="inputEmail" placeholder="Email" onfocus="javascript:borrar(this);"/>
							</div>
						</div>
						<div class="form-group">
							<div class="col-lg-10 col-lg-offset-2">
								<asp:Button ID="btnConfirmar" runat="server" CssClass="btn btn-primary" OnClientClick="removeImage();" Text="Confirmar" OnClick="btnConfirmar_Click" />
							</div>
						</div>
					</fieldset>
				</div>
				<div>
					<p>
						<br />
						<label class="control-label text-success" runat="server" id="Mensaje"></label>
						<br />
					</p>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
