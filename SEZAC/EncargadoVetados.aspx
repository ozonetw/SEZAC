<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoVetados.aspx.cs" Inherits="SEZAC.EncargadoVetados" MasterPageFile="~/Sezac.Master"%>
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
                    <li><asp:LinkButton Text="Salir" runat="server" ID="btnsalir" OnClick="btnsalir_Click"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="lolks" runat="server">
     <div>
        <p class="lead">
            Encargado > Listado de Vetados.
        </p>
    </div>
    <div>
           <div class="row">
        <div class="col-md-1">
            <p>
                <label class="col-lg-2 control-label">Campos</label>
            </p>
        </div>
        <div class="col-md-2">
            <p>
                <select class="form-control" id="select">
                    <option>R.F.C</option>
                    <option>Nombre</option>
                    <option>Apellido</option>
                    <option>Organización</option>
                </select>
            </p>
        </div>
        <div class="col-md-5">
            <p>
                <input type="text" class="form-control" id="inputDef" placeholder="Introduzca el termino de busqueda..."/>
            </p>
        </div>
        <div class="col-md-2">
            <a href="#" class="btn btn-primary btn-lg">Buscar</a>
        </div>
    </div>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
