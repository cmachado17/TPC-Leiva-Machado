<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="row mb-3">
        <asp:Button Text="Agregar Cliente" runat="server" cssclass="btn btn-primary"/>
    </div>

          <asp:GridView cssclass="table table-striped w-100" ID="dgvClientes" runat="server"></asp:GridView>

  

</asp:Content>
