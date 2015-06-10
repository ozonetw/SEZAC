<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDependencias.aspx.cs" Inherits="SEZAC.AdminDependencias" MasterPageFile="~/Sezac.Master"%>
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
                            <li><a href="AdminDependenciasListado.aspx" target="_self">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Encargados</a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="AdminEncargados.aspx" target="_self">Crear</a></li>
                            <li><a href="AdminEncargadosListado.aspx" target="_self">Listado</a></li>
                        </ul>
                    </li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Años Fiscales</a>
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
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="AdminDep" runat="server">
    <div>
        <p class="lead">
            Administrador > Creación de Dependencias.
        </p>
    </div>
    <div class="form-group">
        <label class="control-label" for="focusedInput">Nombre:</label>
        <input class="form-control" runat="server" id="dependencia" type="text" value="Por favor, ingrese el nombre de la dependencia a crear." onfocus="javascript:borrar(this);"/>
    </div>
    <div>
        <button type="submit" runat="server" id="btnDependencias" onserverclick="btnDependencias_Click">Confirmar</button>
    </div>
    <div>
        <br/>
        <label runat="server" class="control-label text-success" id="Mensaje"></label>
        <br/>
    </div>
</asp:Content>
 