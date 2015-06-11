<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeneficiarioHome.aspx.cs" Inherits="SEZAC.BeneficiarioHome" MasterPageFile="~/Sezac.Master" %>
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
                    <li>
                        <asp:Image ID="logImage" runat="server"/>
                    </li>
                    <li><a>Bievenido, <asp:LoginName ID="LoginName1" runat="server" /></a></li>
                    <li><asp:LinkButton Text="Salir" runat="server" ID="btnsalir" OnClick="btnsalir_Click"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="bHide" runat="server">
    <div>
        <p class="lead">Bienvenido Beneficiario, selecciona la tarea a realizar del menu en la barra superior.</p>
    </div>
    <div class="container">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
    <li data-target="#myCarousel" data-slide-to="3"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="images/b5.jpg" alt="zac0">
    </div>

    <div class="item">
      <img src="images/b6.jpg" alt="zac1">
    </div>

    <div class="item">
      <img src="images/b7.jpg" alt="zac2">
    </div>

    <div class="item">
      <img src="images/b8.jpg" alt="zac3">
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
        </div>
</asp:Content>