<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoProgramas.aspx.cs" Inherits="SEZAC.EncargadoProgramas" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="enProg" runat="server">
    <!--Menu-->
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
            Inicio > Programas
            <br />
            <br />
        </div>
    </div>

    <!--Contenido-->
    <div class="contenido_en_prog">
        <div class="col_a">
            <asp:Label Text="Nombre:" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Dependencia:" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Programa:" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Año Fiscal" runat="server"></asp:Label>
        </div>
        <div class="col_b">
            <asp:TextBox ID="TextBoxPrograma" runat="server"></asp:TextBox>
            <br />
            <asp:DropDownList runat="server" ID="DropDownList1" Height="25px" Width="126px" ></asp:DropDownList>
            <br />
            <br />
            <asp:DropDownList runat="server" ID="DropDowList2" Height="25px" Width="126px" ></asp:DropDownList>
            <br />
            <asp:Button Text="Guardar" runat="server" Width="126px" OnClick="Unnamed10_Click"/>
        </div>

        <asp:Label ID="Programa" runat="server" Text="Label"></asp:Label>

    </div>
</asp:Content>


