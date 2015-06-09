<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoHome.aspx.cs" Inherits="SEZAC.EncargadoHome" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="encargadoHome" runat="server">
    <div class="menu_en">
        <asp:Menu runat="server" Orientation="Horizontal" BackColor="#669900" ForeColor="White" Width="1300px" Font-Size="Large" Font-Underline="true" RenderingMode="List" Font-Names="Tahoma">
        <Items>
            <asp:MenuItem Text="Inico |" NavigateUrl="~/Admin_Home.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Programas |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Encargados |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Organizaciones |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Beneficiarios |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Historial |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Evaluacion |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Vetados |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Busqueda |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Salir |" NavigateUrl="#"></asp:MenuItem>
        </Items>
        </asp:Menu>
    </div>
    <!--Barra para la bienvenida de usuario y posicion en el mapa-->
    <div class="top_bar_en">
        <div>
            Inicio
        </div>
    </div>
    <center>
    <div class="home_en">
        <!--  Outer wrapper for presentation only, this can be anything you like -->
      <div id="banner-fade">

        <!-- start Basic Jquery Slider -->
        <ul class="bjqs">
          <li><img src="images/b1.jpg" title=""></li>
          <li><img src="images/b2.jpg" title=""></li>
          <li><img src="images/b3.jpg" title=""></li>
        </ul>
        <!-- end Basic jQuery Slider -->

      </div>
      <!-- End outer wrapper -->

      <script class="secret-source">
        jQuery(document).ready(function($) {

          $('#banner-fade').bjqs({
            height      : 320,
            width       : 620,
            responsive  : true
          });

        });
      </script>
    </div>
    </center>


</asp:Content>