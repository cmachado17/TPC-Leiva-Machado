<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioClientes.aspx.cs" Inherits="TPC.FormularioClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario Clientes</h2>

         <div class="mb-3">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
    <div class="mb-3">
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="form-label">Nombre</asp:Label>
        <asp:TextBox ID="txbNombre" runat="server" cssclass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
          <asp:Label ID="lbApellido" runat="server" Text="Apellido" CssClass="form-label">Apellido</asp:Label>
        <asp:TextBox ID="txbApellido" runat="server" cssclass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
      <asp:Label ID="lbDNI" runat="server" Text="DNI" CssClass="form-label">DNI</asp:Label>
        <asp:TextBox ID="txbDNI" runat="server" cssclass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="form-label">Email</asp:Label>
        <asp:TextBox ID="txbEmail" runat="server" cssclass="form-control"></asp:TextBox>
    </div>
     <div class="mb-3">
        <asp:Label ID="lbTelefono" runat="server" Text="Telefono" CssClass="form-label">Telefono</asp:Label>
        <asp:TextBox ID="txbTelefono" runat="server" cssclass="form-control"></asp:TextBox>
    </div>
    <asp:Button AutoPostBack="false" OnClick="BtnConfirmar_Click"  ID="btnConfirmar" runat="server" Text="Confirmar"  CssClass="btn btn-primary" />
     <a href="Clientes.aspx" class="btn btn-danger">Cancelar</a>

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
