<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Home.aspx.cs" Inherits="SEZAC.Admin_Home" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="adminhomeform" runat="server">
<asp:Menu runat="server" Orientation="Horizontal" BackColor="#669900" ForeColor="White" Width="1300px" Font-Size="Large" Font-Underline="True" RenderingMode="List" Font-Names="Tahoma">
    <Items>
        <asp:MenuItem Text="Inicio |" NavigateUrl="~/Admin_Home.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Dependencias |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Encargados |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Años Fiscales |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Salir |" NavigateUrl="#"></asp:MenuItem>
    </Items>
</asp:Menu>
    <div id="container">
  
      <h2></h2>

      <!--  Outer wrapper for presentation only, this can be anything you like -->
      <div id="banner-fade">

        <!-- start Basic Jquery Slider -->
        <ul class="bjqs">
          <li><img src="images/b1.jpg" title="Automatically generated caption"></li>
          <li><img src="images/b2.jpg" title="Automatically generated caption"></li>
          <li><img src="images/b3.jpg" title="Automatically generated caption"></li>
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
      <!-- End outer wrapper -->
      
      <!-- attach the plug-in to the slider parent element and adjust the settings as required -->
      <script class="secret-source">
        jQuery(document).ready(function($) {
          
          $('#banner-slide').bjqs({
            animtype      : 'slide',
            height        : 320,
            width         : 620,
            responsive    : true,
            randomstart   : true
          });
          
        });
      </script>

    </div>
 
</asp:Content>