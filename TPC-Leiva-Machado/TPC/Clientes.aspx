<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <h1>Clientes</h1>
    </div>
    <div class="mb-3 form-label" style= "padding-top:30px; font-size:20px; font-weight:bold">
        <asp:Label Text="Busqueda:" runat="server" cssclass="form-label" />
     </div>
    <div class="mb-3" style= "padding-bottom:3px">    
        <asp:TextBox runat="server" ID="FiltroClientes" AutoPostBack="true" OnTextChanged="FiltroClientes_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del cliente.." />
    </div>

 
    
      <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-striped w-100"
        ID="dgvClientes" runat="server"
        DataKeyNames="Id"
        OnPageIndexChanging="dgvClientes_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        style= "text-align:center">
   
                
        <Columns>
            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
           
            
            <asp:TemplateField  HeaderText="">
                
                <ItemTemplate >
                     <asp:Button ID="BtnIncidencia"
                        Text="Cargar Incidencia"
                        OnClick="BtnIncidencia_Click"
                        runat="server" 
                        type="button" 
                        cssclass="btn btn-outline-primary"
                     />
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
