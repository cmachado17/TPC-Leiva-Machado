<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPC.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row mb-3">
        <a class="btn btn-primary" href="FormularioUsuarios.aspx">Agregar usuario</a>
    </div>

     <div class="row mb-3">
         <asp:TextBox runat="server" ID="FiltroUsuarios" AutoPostBack="true" OnTextChanged="FiltroUsuarios_TextChanged" />
    </div>
          <asp:GridView AutoGenerateColumns="false"
          cssclass="table table-striped w-100"
          ID="dgvUsuarios" runat="server"
          DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged"
              OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
              AllowPaging="true" PageSize="4">
              <Columns>
                    <asp:BoundField HeaderText="Nombres" DataField="Nombres"/>
                    <asp:BoundField HeaderText="Apellidos" DataField="Apellidos"/>
                    <asp:BoundField HeaderText="DNI" DataField="DNI"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"/>
                   <asp:BoundField HeaderText="Descripcion" DataField="Perfil.Descripcion"/>
                    <asp:BoundField HeaderText="Activo" DataField="Activo"/>
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar"/>
                    <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Detalle"/>
              </Columns>
          </asp:GridView>
</asp:Content>
