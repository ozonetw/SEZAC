<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoOrganizaciones.aspx.cs" Inherits="SEZAC.EncargadoOrganizaciones" MasterPageFile="~/Sezac.Master"%>
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
                    <li class="active"><a href="Admin_Home.aspx" target="_self">Inicio</a></li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Programas</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminDependencias.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminDependenciasListado.aspx" target="_self">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Encargados</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminEncargados.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminEncargadosListado.aspx" target="_self">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Organizaciones</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminAniosFiscales.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Beneficiarios</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminAniosFiscales.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Historial</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Evaluación</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Vetados</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Busqueda</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminAniosFiscales.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Historial</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Evaluación</a></li>
                            <li><a href="AdminAniosFiscalesListado.aspx">Vetados</a></li>
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
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="league" runat="server">
    <div>
        <p class="lead">
            Encargado > Creación de Organizaciones y asignación de programas.
        </p>
    </div>
    <div class="form-group">
        <label class="control-label" for="focusedInput">Nombre:</label>
        <input class="form-control" id="focusedInput" type="text" value="Por favor, ingrese el nombre de la organización." />
    </div>
    <div class="form-group">
        <label class="control-label" for="focusedInput">Programa:</label>
        <select class="form-control" id="select">
            <option>Seleccione el programa aplicable de la lista.</option>
            <option>2</option>
            <option>3</option>
        </select>
    </div>
    <div>
        <button type="submit" class="btn btn-primary">Confirmar</button>
    </div>
</asp:Content>