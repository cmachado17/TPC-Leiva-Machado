<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioUsuarios.aspx.cs" Inherits="TPC.FomularioUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>FormularioUsuarios</h2>

     <div class="mb-3">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
    <div class="mb-3">
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="form-label">Nombre</asp:Label>
        <asp:TextBox ID="txbNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbApellido" runat="server" Text="Apellido" CssClass="form-label">Apellido</asp:Label>
        <asp:TextBox ID="txbApellido" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbDNI" runat="server" Text="DNI" CssClass="form-label">DNI</asp:Label>
        <asp:TextBox ID="txbDNI" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="form-label">Email</asp:Label>
        <asp:TextBox ID="txbEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbPerfil" runat="server" Text="Perfil" CssClass="form-label">Perfil</asp:Label>
        <asp:DropDownList ID="ddlPerfil" CssClass="form-select" runat="server"></asp:DropDownList>
    </div>
     <div class="mb-3">
        <asp:Label ID="lbError" runat="server" Text="Revisar los campos marcados" CssClass="form-label">Revisar los campos marcados</asp:Label>
    </div>
    <asp:Button AutoPostBack="false" OnClick="btnConfirmar_Click" ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" />
    <a href="Usuarios.aspx" class="btn btn-danger">Cancelar</a>
    <% if (Request.QueryString["id"] != null)
       { %>
        <div class="mb-3">
            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
            <asp:Button Text="Desactivar" ID="btnDesactivar" OnClick="btnDesactivar_Click" CssClass="btn btn-warning" runat="server" />
        </div>
        <% if (ConfirmarEliminacion)
            { %>
        <div class="mb-3">
            <asp:CheckBox Text="Confirmar eliminacion" runat="server" ID="chkConfirmarEliminacion" />
            <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" ID="btnConfirmarEliminar" Onclick="btnConfirmarEliminar_Click"/>
        </div>
        <%} %>
    <%} %>
</asp:Content>
