<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleIncidentes.aspx.cs" Inherits="TPC.DetalleIncidentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="text-center">
        <h2>Detalle incidencia</h2>
    </div>


    <div class="mb-3">
        <asp:Label ID="lbTipoI" runat="server" Text="TipoIncidencia" CssClass="form-label">Tipo</asp:Label>
        <asp:DropDownList ID="dwTipoI" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbPrioridadI" runat="server" Text="Prioridad" CssClass="form-label">Prioridad</asp:Label>
        <asp:DropDownList ID="dwPrioridadI" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbProblematicaI" runat="server" Text="Problematica" CssClass="form-label">Problematica</asp:Label>
        <asp:textbox id="txProblematicaI" TextMode="multiline" Height="100" runat="server" CssClass="form-control" />
    </div>
    

    <div class="mb-3">
        <asp:Label ID="lbEmpleadoAsignado" runat="server" Text="Empleado Asignado" CssClass="form-label">Empleado Asignado</asp:Label>
        <asp:DropDownList ID="dwEmpleadoAsignado" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>



    <div class="row">
        <div class="col-12 text-center mb-2 d-flex">
            <asp:Button ID="btnAceptarI" runat="server" Text="Aceptar" type="submit" CssClass="btn btn-primary btn-block my-1 mx-5" onclick="btnAceptarI_Click"/>
            <a href="Incidentes.aspx" class="btn btn-danger btn-block my-1 mx-5">Cancelar</a>
        </div>
    </div>


</asp:Content>
