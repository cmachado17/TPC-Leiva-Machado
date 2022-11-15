<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioAdministracion.aspx.cs" Inherits="TPC.FormularioAdministracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario administracion</h2>

     <div class="mb-3">
        <asp:Label ID="lbDescripcion" runat="server" Text="Nombre" CssClass="form-label">Descripcion</asp:Label>
        <asp:TextBox ID="txbDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
           <asp:Button AutoPostBack="false" OnClick="btnConfirmar_Click" ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary btn-block my-1 mx-5" />
            <a href="Administracion.aspx" class="btn btn-danger btn-block my-1 mx-5">Cancelar</a>
    </div>
</asp:Content>
