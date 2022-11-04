<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TPC.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Incidencias</h2>
    <%--<asp:Button Text="Cargar incidencia" runat="server" cssclass="btn btn-primary" href="Incidentes.aspx"/>--%>

    <a class="btn btn-primary" href="FormularioIncidencia.aspx">Cargar Incidencia</a>

     <asp:GridView cssclass="table table-striped" ID="dgvIncidencias" runat="server"></asp:GridView>
</asp:Content>
