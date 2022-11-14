<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <h1>Clientes</h1>
    </div>
    <div class="form-group mb-3">
        <asp:Label Text="Busqueda:" runat="server" />
        <asp:TextBox runat="server" ID="FiltroClientes" AutoPostBack="true" OnTextChanged="FiltroClientes_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del cliente.." />
    </div>
    <%-- OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" --%>
    <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-striped w-100"
        ID="dgvClientes" runat="server"
        DataKeyNames="Id"
        OnPageIndexChanging="dgvClientes_PageIndexChanging"
        AllowPaging="true" PageSize="10">
        <Columns>
            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
           
            <%-- <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar"/>
                    <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Detalle"/>--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button ID="BtnIncidencia"
                        Text=" Agregar Incidencia"
                        OnClick="BtnIncidencia_Click"
                        runat="server" 
                        cssclass="btn btn-primary"/>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnModificar"
                        Text="Modificar"
                        OnClick="BtnModificar_Click"
                        runat="server" 
                        ImageUrl="lapiz.png" width="20" />
                </ItemTemplate>
            </asp:TemplateField>
                      <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalle"
                        Text="Detalle"
                        OnClick="BtnDetalle_Click"
                        runat="server" 
                        ImageUrl="lupa.png" width="20" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="row mb-3 d-flex align-items-center">
        <div class="col-12">
            <a class="btn btn-primary btn-block" href="FormularioClientes.aspx">Agregar Cliente</a>
        </div>

    </div>

</asp:Content>
