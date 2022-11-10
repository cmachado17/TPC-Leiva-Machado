<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioClientes.aspx.cs" Inherits="TPC.FormularioClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario Clientes</h2>

    <div class="mb-3">
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="form-label">Nombre</asp:Label>
        <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
          <asp:Label ID="lbApellido" runat="server" Text="Apellido" CssClass="form-label">Apellido</asp:Label>
        <asp:TextBox ID="txbApellido" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
      <asp:Label ID="lbDNI" runat="server" Text="DNI" CssClass="form-label">DNI</asp:Label>
        <asp:TextBox ID="txbDNI" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="form-label">Email</asp:Label>
        <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
    </div>
     <div class="mb-3">
        <asp:Label ID="lbTelefono" runat="server" Text="Telefono" CssClass="form-label">Telefono</asp:Label>
        <asp:TextBox ID="txbTelefono" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" type="submit" CssClass="btn btn-primary" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" type="submit" CssClass="btn btn-danger" />
</asp:Content>
