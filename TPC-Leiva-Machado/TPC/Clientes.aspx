<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="row mb-3">
        <a class="btn btn-primary" href="FormularioClientes.aspx">Agregar Cliente</a>
    </div>

          <asp:GridView AutoGenerateColumns="false"
          cssclass="table table-striped w-100"
          ID="dgvClientes" runat="server"
          DataKeyNames="Id" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged"
              OnPageIndexChanging="dgvClientes_PageIndexChanging"
              AllowPaging="true" PageSize="4">

              <Columns>
                    <asp:BoundField HeaderText="Nombres" DataField="Nombres"/>
                    <asp:BoundField HeaderText="Apellidos" DataField="Apellidos"/>
                    <asp:BoundField HeaderText="DNI" DataField="DNI"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"/>
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="Modificar"/>
                    <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Detalle"/>
              </Columns>



          </asp:GridView>

  

</asp:Content>
