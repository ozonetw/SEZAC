﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAniosFiscales.aspx.cs" Inherits="SEZAC.AdminAniosFiscales" MasterPageFile="~/Sezac.Master"%>
<asp:Content ID="scripts" ContentPlaceHolderID="head" runat="server">
    <script>
        function borrar(componente)
        {
            componente.value = "";
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="navholder" ID="AdminMenu" runat="server">
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
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Dependencias</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminDependencias.aspx" target="_self">Crear</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Encargados</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminEncargados.aspx" target="_self">Crear</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Años Fiscales</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminAniosFiscales.aspx" target="_self">Crear</a></li>                            
                        </ul>
                    </li>                    
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <asp:Image ID="logImage" runat="server"/>
                    </li>
                    <li><a>Bievenido, <asp:LoginName ID="LoginName1" runat="server" /></a></li>
                    <li><asp:LinkButton Text="Salir" runat="server" ID="btnsalir" OnClick="btnsalir_Click" /></li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="Anios" runat="server">
     <div>
        <p class="lead">
            Administrador > Año Fiscal.
        </p>
    </div>
    <div class="form-group">
        <label class="control-label" for="focusedInput">Año:</label>
        <input class="form-control" runat="server" id ="CampoTexto" type="text" value="Por favor, ingrese el año fiscal a capturar." onfocus="javascript:borrar(this);"/>
    </div>
    <div>
		<asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
    </div>
    <div>
        <p>
            <br/>
                <label class="control-label text-success" runat="server" id="Mensaje"></label>
            <br/>
        </p>
    </div>
</asp:Content>