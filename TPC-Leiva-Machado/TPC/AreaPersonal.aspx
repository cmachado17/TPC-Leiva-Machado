<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AreaPersonal.aspx.cs" Inherits="TPC.AreaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mb-5">
         <h1>Area personal</h1>
    </div>
   
    <div class="row my-3">
        <div class="col-8">
            <div class="mb-5">
                <asp:Label ID="lbEmpleado" Text="Empleado:" runat="server" />
                <asp:Label ID="lbNombreEmpleado" Text="" runat="server" />
            </div>
            <div class="mb-5">
                <asp:Label ID="lbEmail" Text="Email:" runat="server" />
                <asp:Label ID="lbEmailEmpleado" Text="" runat="server" />
            </div>
            <div class="mb-5">
                <asp:Label ID="lbPerfil" Text="Perfil:" runat="server" />
                <asp:Label ID="lbPerfilEmpleado" Text="" runat="server" />
            </div>

        </div>

        <div class="col-4">
            <div>
                <input type="file" id="txtImagen" runat="server"  class="form-control" />
                <asp:Button Text="Actualizar imagen" ID="btnImagen" runat="server" onclick="btnImagen_Click"/>
            </div>
            <div>
 <asp:Image ID="ImagenPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-fluid mb-3" />
            </div>
           
        </div>

    </div>

    <div class="text-center">
        <% if (Session["Perfil"].Equals(2))
            { %>

        <h2>Mis incidencias asignadas</h2>
        <div class="mb-3 form-label" style="padding-top: 30px; font-size: 20px; font-weight: bold">
            <asp:Label Text="Estado:" runat="server" CssClass="form-label" />
        </div>
        <div class="mb-3 d-flex" style="padding-bottom: 3px">
            <asp:DropDownList ID="dwEstados" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" CssClass="btn btn-success ml-3" />
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
