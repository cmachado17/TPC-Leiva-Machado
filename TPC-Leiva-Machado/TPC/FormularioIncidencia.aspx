<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioIncidencia.aspx.cs" Inherits="TPC.FormularioIncidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario incidencia</h2>

     <div class="mb-3">
      <asp:Label ID="lbTipo" runat="server" Text="TipoIncidencia" cssclass="form-label">Tipo</asp:Label>
         <asp:DropDownList ID="dwTipo" runat="server"></asp:DropDownList>
   </div>
    <div class="mb-3">
      <asp:Label ID="lbPrioridad" runat="server" Text="Prioridad" cssclass="form-label">Prioridad</asp:Label>
      <asp:DropDownList ID="dwPrioridad" runat="server"></asp:DropDownList>
   </div>
   <div class="mb-3">
      <asp:Label ID="lbProblematica" runat="server" Text="Problematica" cssclass="form-label">Problematica</asp:Label>
     <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
   </div>
     <div class="mb-3">
      <asp:Label ID="lbCliente" runat="server" Text="Cliente" cssclass="form-label">Cliente</asp:Label>
         <asp:TextBox ID="txbCliente" runat="server"></asp:TextBox> 
   </div>
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" type="submit" cssclass="btn btn-primary"/>
</asp:Content>
