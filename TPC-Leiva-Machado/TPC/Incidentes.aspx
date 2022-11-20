<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TPC.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Incidencias</h2>
    <%--<asp:Button Text="Cargar incidencia" runat="server" cssclass="btn btn-primary" href="Incidentes.aspx"/>--%>
     <asp:GridView cssclass="table table-striped" ID="dgvIncidencias" runat="server">
         <Columns>
            <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombres" />
            <asp:BoundField HeaderText="Telefonista" DataField="EmpleadoAsignado.Nombres" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Descripcion" />
             <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
            <asp:BoundField HeaderText="FechaDeAlta" DataField="FechaDeAlta" />
           </Columns>
     </asp:GridView>
</asp:Content>
