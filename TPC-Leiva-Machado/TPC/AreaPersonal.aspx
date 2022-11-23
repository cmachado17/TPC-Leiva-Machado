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
        <% if (Session["Perfil"].Equals(2))
            { %>

        <h2>Mis incidencias asignadas</h2>
        <div class="mb-3 form-label" style="padding-top: 30px; font-size: 20px; font-weight: bold">
            <asp:Label Text="Estado:" runat="server" CssClass="form-label" />
        </div>
        <div class="mb-3" style="padding-bottom: 3px">
            <asp:DropDownList ID="dwEstados" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" onclick="btnBuscar_Click"/>
        </div>
        <%} %>


        <asp:GridView AutoGenerateColumns="false"
            CssClass="table table-striped w-100"
            ID="dgvIncidenciasAsignadas" runat="server"
            DataKeyNames="Id"
            Style="text-align: center">
            <Columns>
                <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombres" />
                <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Descripcion" />
                <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                <asp:BoundField HeaderText="FechaDeAlta" DataField="FechaDeAlta" />
                <asp:BoundField HeaderText="Problematica" DataField="Problematica" />

                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="BtnModificar"
                            Text="Modificar"
                            runat="server"
                            CssClass="btn btn-link"
                            OnClick="BtnModificar_Click" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="BtnResolver"
                            Text="Resolver"
                            runat="server"
                            CssClass="btn btn-link"
                            OnClick="BtnResolver_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="BtnCerrar"
                            Text="Cerrar"
                            runat="server"
                            CssClass="btn btn-link"
                            OnClick="BtnCerrar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
