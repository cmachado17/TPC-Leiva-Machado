<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleEmpleados.aspx.cs" Inherits="TPC.DetalleEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="text-center" style="padding-bottom:30px" >
        <h1>Detalle Empleado</h1>
    </div>


    <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-striped w-100"
        ID="dgvDetalleEmpleados" runat="server"
        DataKeyNames="Id" 
        style= "text-align:center">
        <Columns>
            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Perfil" DataField="Perfil.Descripcion" />
            <asp:BoundField HeaderText="Fecha alta" DataField="FechaDeAlta" />
            <asp:BoundField HeaderText="Fecha baja" DataField="FechaDeBaja" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
       </Columns>
    </asp:GridView>
       
        <div class="row mb-3 d-flex align-items-center">
        <div class="col-12 text-center">
             <asp:Button ID="btnDetalle" runat="server" Text="Volver" type="submit" CssClass="btn btn-primary btn-block" onclick="btnDetalle_Click"/>
           
        </div>

    </div>
</asp:Content>


