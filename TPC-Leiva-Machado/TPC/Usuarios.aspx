<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPC.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>Usuarios</h1>
    </div>

    <div class="form-label mb-3" style= "padding-top:30px; font-size:20px; font-weight:bold">
        <asp:Label Text="Busqueda:" runat="server"  cssclass="form-label"/>
    </div>
    <div class="mb-3" style= "padding-bottom:3px">      
        <asp:TextBox runat="server" ID="FiltroUsuarios" AutoPostBack="true" OnTextChanged="FiltroUsuarios_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del usuario.." />
    </div>
    <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-striped w-100"
        ID="dgvUsuarios" runat="server"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged"
        OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        style= "text-align:center">
        <Columns>
            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Perfil" DataField="Perfil.Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:BoundField HeaderText="Fecha alta" DataField="FechaDeAlta" />
            <asp:BoundField HeaderText="Fecha baja" DataField="FechaDeBaja" />
           
       
          </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnModificarU"
                        Text="Modificar"
                        OnClick="BtnModificarU_Click"
                        runat="server" 
                        ImageUrl="lapiz.png" width="20" />
                </ItemTemplate>
            </asp:TemplateField>
                      <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalleU"
                        Text="Detalle"
                        OnClick="BtnDetalleU_Click"
                        runat="server" 
                        ImageUrl="lupa.png" width="20" />
                </ItemTemplate>
            </asp:TemplateField>    
        </Columns>
    </asp:GridView>
    <div class="row mb-3 d-flex align-items-center">
        <div class="col-12">
            <a class="btn btn-primary btn-block" href="FormularioUsuarios.aspx">Agregar usuario</a>
        </div>
    </div>
</asp:Content>
