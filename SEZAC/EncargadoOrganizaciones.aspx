<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoOrganizaciones.aspx.cs" Inherits="SEZAC.EncargadoOrganizaciones" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="league" runat="server">
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
            Inicio > Organizaciones
        </div>
    </div>
    <!-- Content -->
    <div class="encargados_encargados_content">
        <div class="col_a">
            <asp:Label Text="Nombre: " runat="server"></asp:Label>
            <br />
            <asp:Label Text="Nombre Organizacio: " runat="server"></asp:Label>
            <br />
        </div>
        <div class="col_b">
            <asp:TextBox id="programas_tb" runat="server"></asp:TextBox>
            <br />
            <asp:DropDownList id="programas_drop" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button text="Guardar" runat="server" OnClick="Unnamed4_Click"/>
        </div>
    </div>
    <!-- Confirmation Footer -->
    <div class="confirm">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="CorfirmarOrg" Text="" runat="server"></asp:Label>
    </div>


</asp:Content>