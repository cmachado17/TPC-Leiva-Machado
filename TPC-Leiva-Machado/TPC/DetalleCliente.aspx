<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleCliente.aspx.cs" Inherits="TPC.DetalleCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="text-center">
        <h1>Detalle Cliente</h1>
    </div>

    <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-striped w-100"
        ID="dgvDetalleCliente" runat="server"
        DataKeyNames="Id"
        OnPageIndexChanging="dgvClientes_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        style= "text-align:center">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Fecha alta" DataField="FechaDeAlta" />
            <asp:BoundField HeaderText="Fecha baja" DataField="FechaDeBaja" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
        </Columns>
    </asp:GridView>
    <div class="row mb-3 d-flex align-items-center">
        <div class="col-12">
            <a class="btn btn-primary btn-block" href="FormularioClientes.aspx">Volver</a>
        </div>

    </div>

</asp:Content>
