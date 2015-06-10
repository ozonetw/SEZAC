﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeneficiarioModificar.aspx.cs" Inherits="SEZAC.BeneficiarioModificar" MasterPageFile="~/Sezac.Master" %>
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
                    <li class="active"><a href="Admin_Home.aspx" target="_self">Inicio</a></li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Información</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminDependencias.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminDependenciasListado.aspx" target="_self">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Historial</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminEncargados.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminEncargadosListado.aspx" target="_self">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Estado</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminAniosFiscales.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Listado</a></li>
                        </ul>
                    </li>
                    </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a>Bievenido, <asp:LoginName ID="LoginName1" runat="server" /></a></li>
                    <li><a target="_blank">Salir</a></li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="hi" runat="server">
    <div>
        <p class="lead">
            Beneficiario > Modificación de datos.
        </p>
        <p>
            Modifique su información segun sea necesario.
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
            <asp:FileUpload id="fotoUp" runat="server" />
        </div>
    </div>    
  </fieldset>
</form>
            </div>
            <div class="col-lg-5">
                <form class="form-horizontal">
                      <fieldset>
                        <legend>Datos</legend>
                          <div class="form-group">
                              <label for="inputName" class="col-lg-2 control-label">Nombre</label>
                              <div class="col-lg-10">
                                <input type="text" class="form-control" id="inputName" placeholder="Nombre" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label for="inputPaterno" class="col-lg-2 control-label">Apellido Paterno</label>
                              <div class="col-lg-10">
                                <input type="text" class="form-control" id="inputPaterno" placeholder="Apellido Paterno" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label for="inputMaterno" class="col-lg-2 control-label">Apellido Materno</label>
                              <div class="col-lg-10">
                                <input type="text" class="form-control" id="inputMaterno" placeholder="Apellido Materno" />
                              </div>
                          </div>
                          <div class="form-group">
                              <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                              <div class="col-lg-10">
                                <input type="text" class="form-control" id="inputEmail" placeholder="Email" />
                             </div>
                          </div>
                        <div class="form-group">
                          <div class="col-lg-10 col-lg-offset-2">
                            <button type="submit" class="btn btn-primary">Confirmar</button>
                          </div>
                        </div>
                      </fieldset>
                    </form>
            </div>
        </div>

    </div>
</asp:Content>