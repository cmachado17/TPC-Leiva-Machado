<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleIncidentes.aspx.cs" Inherits="TPC.DetalleIncidentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="text-center" style="margin-bottom: 30px" >
        <h1>Detalle incidencia</h1>
    </div>

    <div class="card bg-light px-5 py-2 mb-3">
        <div class="mb-3">
        <asp:Label ID="lbTipoI" runat="server" Text="TipoIncidencia" CssClass="form-label">Tipo</asp:Label>
        <asp:DropDownList ID="dwTipoI" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbPrioridadI" runat="server" Text="Prioridad" CssClass="form-label">Prioridad</asp:Label>
        <asp:DropDownList ID="dwPrioridadI" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
       <div class="mb-3">
        <asp:Label ID="lbEstadoI" runat="server" Text="Estado" CssClass="form-label">Estado</asp:Label>
        <asp:DropDownList ID="dwEstadoI" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbProblematicaI" runat="server" Text="Problematica" CssClass="form-label">Problematica</asp:Label>
        <asp:textbox id="txProblematicaI" TextMode="multiline" Height="100" runat="server" CssClass="form-control" />
    </div>

     <div class="mb-3">
        <asp:Label ID="lbFechaAltaI" runat="server" Text="Fecha de alta" CssClass="form-label">Fecha de Alta</asp:Label>
        <asp:textbox id="txFechaAltaI"  runat="server" CssClass="form-control" />
    </div>

         <div class="mb-3">
        <asp:Label ID="lbFechaBajaI" runat="server" Text="Fecha de baja" CssClass="form-label">Fecha de Baja</asp:Label>
        <asp:textbox id="txFechaBajaI"  runat="server" CssClass="form-control" />
    </div>

      <div class="mb-3">
        <asp:Label ID="lbMotivoI" runat="server" Text="Motivo" CssClass="form-label">Motivo</asp:Label>
        <asp:DropDownList ID="dwMotivoI" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbComentarioI" runat="server" Text="Comentario" CssClass="form-label">Comentario</asp:Label>
        <asp:textbox id="txComentarioI" TextMode="multiline" Height="100" runat="server" CssClass="form-control" />
    </div>
    </div>
    
    
      <asp:Button ID="btnCancelar" runat="server" Text="Volver" type="submit" CssClass="btn btn-danger btn-block" onclick="btnCancelar_Click"/>


</asp:Content>
