<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AreaPersonal.aspx.cs" Inherits="TPC.AreaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Area personal</h1>
    <div class=" row my-3">
        <div class="col-8">
            <asp:Label ID="Nombre" Text="Nombre" runat="server" />
            <asp:Label ID="Apellido" Text="Apellido" runat="server" />
            <asp:Label ID="Email" Text="Email" runat="server" />
        </div>
        <div class="col-4">
            <asp:Image ID="ImagenPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-fluid mb-3" />
        </div>

    </div>

    <div class="text-center">
        <h2>Mis incidencias asignadas</h2>
        <asp:GridView AutoGenerateColumns="false"
            CssClass="table table-striped w-100"
            ID="dgvIncidenciasAsignadas" runat="server"
            Style="text-align: center">
      <Columns>
            <asp:BoundField HeaderText="Cliente" DataField="Problematica" />
          <%--  <asp:BoundField HeaderText="Telefonista" DataField="EmpleadoAsignado.Nombres" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Descripcion" />
            <asp:BoundField HeaderText="FechaDeAlta" DataField="FechaDeAlta" />--%>
           </Columns>
        </asp:GridView>
    </div>
</asp:Content>
