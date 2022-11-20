<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioIncidencia.aspx.cs" Inherits="TPC.FormularioIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h2>Formulario incidencia</h2>
    </div>


    <div class="mb-3">
        <asp:Label ID="lbTipo" runat="server" Text="TipoIncidencia" CssClass="form-label">Tipo</asp:Label>
        <asp:DropDownList ID="dwTipo" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbPrioridad" runat="server" Text="Prioridad" CssClass="form-label">Prioridad</asp:Label>
        <asp:DropDownList ID="dwPrioridad" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbProblematica" runat="server" Text="Problematica" CssClass="form-label">Problematica</asp:Label>
        <asp:textbox id="txProblematica" TextMode="multiline" Height="100" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <asp:Label ID="lbMotivo" runat="server" Text="Motivo" CssClass="form-label">Motivo</asp:Label>
         <asp:DropDownList ID="dwMotivo" runat="server" CssClass="form-control"></asp:DropDownList>
         <asp:Label ID="lbComentario" runat="server" Text="Comentario" CssClass="form-label">Comentario</asp:Label>
        <asp:textbox id="txComentario" TextMode="multiline" Height="100" runat="server" CssClass="form-control" />
    </div>
    <div class="row">
        <div class="col-12 text-center mb-2 d-flex">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" type="submit" CssClass="btn btn-primary btn-block my-1 mx-5" onclick="btnAceptar_Click"/>
            <a href="Clientes.aspx" class="btn btn-danger btn-block my-1 mx-5">Cancelar</a>
        </div>
    </div>

</asp:Content>
