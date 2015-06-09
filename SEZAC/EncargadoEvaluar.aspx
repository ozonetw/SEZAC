<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoEvaluar.aspx.cs" Inherits="SEZAC.EncargadoEvaluar" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="oversoul" runat="server">
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
            Inicio > Evaluación de Beneficiarios
        </div>
    </div>
    <!--contenido-->
    <div class="contenido_ee">
        <div class="col col-1">
            <asp:Label Text="Campo: " runat="server"></asp:Label>
        </div>
        <div class="col col-2">
            <asp:DropDownList id="bDatosDrop" runat="server"></asp:DropDownList>
            <br />
            <div class="benedatos">
                <asp:Label Text="RFC" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Nombre" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Apellido Paterno" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Apellido Materno" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Correo Electronico" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Organizacion(es)" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Programa(s)" runat="server"></asp:Label>
                <br />
                <asp:Label Text="Estatus" runat="server"></asp:Label>
            </div>
        </div>
        <div class="col col-3">
            <asp:TextBox ID="bEvalBox" runat="server"></asp:TextBox>
            <br />
            <div class="beneCampos">
                <asp:TextBox ID="RFCtb" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="nombreTB" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="paternoTB" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="maternoTB" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="correoTB" runat="server"></asp:TextBox>
                <br />
                <asp:ListBox ID="orgaList" runat="server"></asp:ListBox>
                <br />
                <asp:ListBox ID="progList" runat="server"></asp:ListBox>
                <br />
                <asp:DropDownList ID="ListaProg" runat="server"></asp:DropDownList>
                <br />
                <asp:Button Text="Guardar" runat="server" />
            </div>
        </div>
        <div class="col col-4">
            <asp:Image ImageUrl="~/images/loop.png" ID="bESearch" runat="server" ></asp:Image>
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
