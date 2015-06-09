<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEncargados.aspx.cs" Inherits="SEZAC.AdminEncargados" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Encargados" runat="server">
    <asp:Menu runat="server" Orientation="Horizontal" BackColor="#669900" ForeColor="White" Width="1300px" Font-Size="Large" Font-Underline="True" RenderingMode="List" Font-Names="Tahoma">
    <Items>
        <asp:MenuItem Text="Inicio |" NavigateUrl="~/Admin_Home.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Dependencias |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Encargados |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Años Fiscales |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Salir |" NavigateUrl="#"></asp:MenuItem>
    </Items>
</asp:Menu>
    <div class="top_header">
        Inicio>Encargados
    </div>

<div class="main">
    <asp:Image ID="Image1" runat="server" />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" Height="16px" Width="229px" />


</div>
<div class="auto-style1">
    <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="Text1" runat="server" type="text" /><br />
    <asp:Label ID="Label2" runat="server" Text="Apellido Paterno:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="Text2" runat="server" type="text" /><br />
    <asp:Label ID="Label3" runat="server" Text="Apellido Materno:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="Text3" runat="server" type="text" /><br />
    <asp:Label ID="Label4" runat="server" Text="Usuario:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="Text4" runat="server" type="text" /><br />
    <asp:Label ID="Label5" runat="server" Text="Contraseña:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="Password1" runat="server" type="password" /><br />
    <asp:Label ID="Label6" runat="server" Text="Dependencia:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Guardar" Width="86px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Confirmar" runat="server" Text="" ForeColor="Red"></asp:Label>
    &nbsp;&nbsp;&nbsp;

</div>



    <br />
    <br />



</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #Text1 {
            width: 182px;
        }
        #Text2 {
            width: 182px;
        }
        #Text3 {
            width: 182px;
        }
        #Text4 {
            width: 182px;
        }
        #Password1 {
            width: 182px;
        }
        .auto-style1 {
            float: right;
            width: 733px;
            text-align: left;
            margin-left: 80px;
        }
    </style>
</asp:Content>


