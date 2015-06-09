<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoEncargados.aspx.cs" Inherits="SEZAC.EncargadoEncargados" MasterPageFile="~/Sezac.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="dota" runat="server">
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
            Inicio > Encargados
        </div>
    </div>
    <div class="encargados_encargados_content">
        <div class="col_a">
            <asp:Image ID="encargado_encargado_im" runat="server"/>
            <br />
            <asp:FileUpload ID="encargado_encargado_browser" runat="server" />
        </div>
        <div class="col_b">
            <asp:Label text="Nombre: " runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="encargado_encargado_nombre_tb" runat="server" Width="204px"></asp:TextBox>
            <br />
            <asp:Label Text="Apellido Paterno: " runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="encargado_encargado_paterno_tb" runat="server" Width="204px"></asp:TextBox>
            <br />
            <asp:Label Text="Apellido Materno: " runat="server"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="encargado_encargado_materno_tb" runat="server" Width="204px"></asp:TextBox>
            <br />
            <asp:Label Text="Usuario" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="encargado_encargado_usuario" runat="server" Width="204px"></asp:TextBox>
            <br />
            <asp:Label Text="Contraseña" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="encargado_encargado_pw" type="password" />
            <br />
            <br />
            <br />
            <asp:Button Text="Guardar"  runat="server"/>
        </div>
    </div>
    <div class="confirm">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label Text="Empty" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #encargado_encargado_pw {
            width: 204px;
        }
    </style>
</asp:Content>

