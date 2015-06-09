<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoHistorial.aspx.cs" Inherits="SEZAC.EncargadoHistorial" MasterPageFile="~/Sezac.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="hihi" runat="server">
        <!-- Menu-->
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
            Inicio > Historial
        </div>
    </div>
    <!--Contenido-->
    <div id="eh_content">
        <div class="col col-1">
            <asp:Label Text="Campo: " runat="server"></asp:Label>
        </div>
        <div class="col col-2">
            <asp:DropDownList ID="encargadohistdrop"  runat="server"></asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="gridviewer" runat="server"></asp:GridView>
        </div>
        <div class="col col-3">
            <asp:TextBox ID="histoserach" runat="server" Width="270px"></asp:TextBox>
        </div>
        <div class="col col-4">
            <asp:Image ImageUrl="~/images/loop.png" runat="server"></asp:Image>
        </div>
    </div>
    <!--Footer de Confirmación-->
    <div class="confirm">
        <br />
        <br />
        <br />        
        <br />
        <br />
        <asp:Label Text="Empty" runat="server"></asp:Label>
    </div>
</asp:Content>