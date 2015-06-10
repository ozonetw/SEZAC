<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoBeneficiarios.aspx.cs" Inherits="SEZAC.EncargadoBeneficiarios" MasterPageFile="~/Sezac.Master" %>
<asp:Content ID="scripts" ContentPlaceHolderID="head" runat="server">
    <script>
        function imagePreview(input)
        {
            if (input.files && input.files[0]) {
                var fildr = new FileReader();
                fildr.onload = function (e)
                {
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
                    <li><a>Bievenido, <asp:LoginName ID="LoginName1" runat="server" /></a></li>
                    <li><asp:LinkButton Text="Salir" runat="server" ID="btnsalir"></asp:LinkButton></li>
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
                <form class="form-horizontal">
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
            <asp:FileUpload id="fotoUp" runat="server" onchange ="imagePreview(this);"/>
            <img id ="imgPre" />
        </div>
    </div>    
  </fieldset>
</form>
            </div>
            <div class="col-lg-5">
                <div class="form-horizontal">
                      <fieldset>
                        <legend>Datos</legend>
                          <div class="form-group">
                              <label for="inputRFC" class="col-lg-2 control-label">R.F.C</label>
                              <div class="col-lg-10">
                                <input type="text" runat="server" class="form-control" id="inputRFC" placeholder="Registro federal de causantes" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label for="inputName" class="col-lg-2 control-label">Nombre</label>
                              <div class="col-lg-10">
                                <input type="text" runat="server" class="form-control" id="inputName" placeholder="Nombre" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label for="inputPaterno" class="col-lg-2 control-label">Apellido Paterno</label>
                              <div class="col-lg-10">
                                <input type="text" runat="server" class="form-control" id="inputPaterno" placeholder="Apellido Paterno" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label for="inputMaterno" class="col-lg-2 control-label">Apellido Materno</label>
                              <div class="col-lg-10">
                                <input type="text" runat="server" class="form-control" id="inputMaterno" placeholder="Apellido Materno" />
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
                                <input type="text" runat="server" class="form-control" id="inputEmail" placeholder="Email" />
                             </div>
                          </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">Organizaciones</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <select class="form-control" runat="server" id="selectOrg">
                                            <option>1</option>                                            
                                        </select>
                                    </div>
                                    <div class="col-md-4"><a href="#" class="btn btn-primary btn-lg">>></a></div>
                                    <div class="col-md-4"><textarea class="form-control" rows="3" id="textArea" style="margin-left: -60px; margin-right: 0px; width: 180px;"></textarea></div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                          <div class="col-lg-10 col-lg-offset-2">
                            <button type="submit" runat="server" class="btn btn-primary" onserverclick="Unnamed_ServerClick" onclick="removeImage();">Confirmar</button>
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