<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="TPC.ModificarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Modificar cliente</h2>  
    <div class="mb-3">
      <asp:Label ID="lbModificarNombre" runat="server" Text="Nombres" cssclass="form-label">Nombres</asp:Label>
      <asp:TextBox ID="txtModificarNombre" runat="server"  cssclass="form-control"></asp:TextBox>
   </div>
    <div class="mb-3">
      <asp:Label ID="lbModificarApellido" runat="server" Text="Apellidos" cssclass="form-label">Apellidos</asp:Label>
      <asp:TextBox ID="txtModificarApellido" runat="server" cssclass="form-control"></asp:TextBox>
   </div>
   <div class="mb-3">
      <asp:Label ID="lbModificarDNI" runat="server" Text="Mdni" cssclass="form-label">DNI</asp:Label>
      <asp:TextBox ID="txtModificarDNI" runat="server" cssclass="form-control"></asp:TextBox>
   </div>
   <div class="mb-3">
      <asp:Label ID="lbModificarEmail" runat="server" Text="MEmail" cssclass="form-label">Email</asp:Label>
      <asp:TextBox ID="txtModificarEmail" type="email" runat="server" cssclass="form-control"></asp:TextBox>
   </div>
   <div class="mb-3">
      <asp:Label ID="lbModificarTelefono" runat="server" Text="MTelefono" cssclass="form-label">Telefono</asp:Label>
      <asp:TextBox ID="txtModificarTelefono" runat="server" cssclass="form-control"></asp:TextBox>
   </div>
    <asp:Button AutoPostBack="false" OnClick="btnConfirmarM_Click"  ID="btnConfirmarM" runat="server" Text="Confirmar"  CssClass="btn btn-primary" />
    <asp:Button ID="btnCancelarM" runat="server" Text="Cancelar" type="submit" CssClass="btn btn-danger" />
</asp:Content>
