<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AreaPersonal.aspx.cs" Inherits="TPC.AreaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mb-5">
        <h1>Area personal</h1>
    </div>

    <div class="row my-3 d-flex justify-content-between">
        <div class="col-7 datos-personales card p-3 py-5 bg-light d-flex flex-column justify-content-between text-center">
            <div>
                <asp:Label ID="lbEmpleado" Text="Empleado:" runat="server" CssClass="area-personal-label" />
                <asp:Label ID="lbNombreEmpleado" Text="" runat="server" CssClass="area-personal-text" />
            </div>
            <div>
                <asp:Label ID="lbEmail" Text="Email:" runat="server" CssClass="area-personal-label" />
                <asp:Label ID="lbEmailEmpleado" Text="" runat="server" CssClass="area-personal-text" />
            </div>
            <div>
                <asp:Label ID="lbPerfil" Text="Perfil:" runat="server" CssClass="area-personal-label" />
                <asp:Label ID="lbPerfilEmpleado" Text="" runat="server" CssClass="area-personal-text" />
            </div>
            <div>
                <asp:Button Text="Cambiar Clave" ID="btnCambiarClave" runat="server" OnClick="btnCambiarClave_Click" CssClass="btn btn-primary" />
            </div>
        </div>



        <div class="col-4">

            <div>
                <asp:Image ID="ImagenPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-fluid mb-3" />
            </div>

            <div class="mb-3">
                <input type="file" id="txtImagen" runat="server" class="mb-3" />
                <div class="text-center">
                    <asp:Button Text="Actualizar imagen" ID="btnImagen" runat="server" OnClick="btnImagen_Click" CssClass="btn btn-success" />
                </div>

            </div>
        </div>

    </div>


    <% if (Session["Perfil"].Equals(2))
        { %>
    <div class="text-center">
        <h2 style="padding-bottom: 30px; padding-top: 30px">Mis incidencias asignadas</h2>

        <div class="card px-5 pt-3  pb-2  bg-light mb-3">
            <div class="my-3 d-flex align-items-center " style="padding-bottom: 3px">
                <div style="font-size: 20px; font-weight: bold; margin-right: 5px;">
                    <asp:Label Text="Estado:" runat="server" />
                </div>
                <asp:DropDownList ID="dwEstados" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" CssClass="btn btn-success ml-3" />
            </div>
            <div class="mb-3 pb-3 d-flex align-items-center">
                <div style="font-size: 20px; font-weight: bold; margin-right: 5px;">
                    <asp:Label Text="Cliente:" runat="server" />
                </div>
                <asp:TextBox runat="server" ID="FiltroClientesI" AutoPostBack="true" OnTextChanged="FiltroClientesI_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del cliente.." />
            </div>

        </div>
        <%} %>


        <asp:GridView AutoGenerateColumns="false"
            CssClass="table table-hover w-100 border-dark bg-light"
            ID="dgvIncidenciasAsignadas" runat="server"
            DataKeyNames="Id"
            Style="text-align: center">
            <Columns>
                <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombres" />
                <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Descripcion" />
                <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                <asp:BoundField HeaderText="FechaDeAlta" DataField="FechaDeAlta" />

                <asp:TemplateField HeaderText="">
                    <ItemTemplate>

                        <asp:ImageButton ID="BtnModificar"
                            Text="Modificar"
                            OnClick="BtnModificar_Click"
                            runat="server"
                            ImageUrl="./Images/lapiz.png" Width="20" AlternateText="Modificar" ToolTip="Modificar" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>


                        <asp:ImageButton ID="BtnResolver"
                            Text="Resolver"
                            runat="server"
                            OnClick="BtnResolver_Click"
                            ImageUrl="./Images/check.png" Width="20" AlternateText="Resolver" ToolTip="Resolver" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnCerrar"
                            Text="Cerrar"
                            runat="server"
                            OnClick="BtnCerrar_Click"
                            ImageUrl="./Images/cancel.png" Width="20" AlternateText="Cerrar" ToolTip="Cerrar" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Detalle">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalleI"
                        Text="Detalle"
                        OnClick="BtnDetalleI_Click"
                        runat="server"
                        ImageUrl="./Images/lupa.png" Width="20" AlternateText="Ver detalle" ToolTip="Ver detalle"/>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
