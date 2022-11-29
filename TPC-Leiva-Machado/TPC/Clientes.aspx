﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center" style="margin-bottom: 30px" >
        <h1>Clientes</h1>
    </div>

    <div class="mb-3 pb-3 d-flex align-items-center" >  
            <div style="font-size: 15px; font-weight: bold" >
                <asp:Label Text="Busqueda por Nombre:" runat="server" />
            </div>
        <asp:TextBox runat="server" ID="FiltroClientes" AutoPostBack="true" OnTextChanged="FiltroClientes_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del cliente.." />
    </div>
        <div class="mb-3 pb-3 d-flex align-items-center" >  
            <div style="font-size: 15px; font-weight: bold; margin-right: 25px;" >
                <asp:Label Text="Busqueda por DNI:" runat="server" />
            </div>
        <asp:TextBox runat="server" ID="FiltroClientesDNI" AutoPostBack="true" OnTextChanged="FiltroClientesDNI_TextChanged" CssClass="form-control" placeholder="Ingrese el DNI del cliente.." />
    </div>

      <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-hover w-100 border-dark"
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
                        ImageUrl="lapiz.png" width="20" AlternateText="Modificar" ToolTip="Modificar"/>
                </ItemTemplate>
            </asp:TemplateField>

                      <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalle"
                        Text="Detalle"
                        OnClick="BtnDetalle_Click"
                        runat="server" 
                        ImageUrl="lupa.png" width="20"  AlternateText="Ver detalle" ToolTip="Ver detalle"/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
   

        <%if (!Session["Perfil"].Equals(3))
            { %>
    <div class="row mb-3 d-flex align-items-center">
        <div class="col-12">
            <a class="btn btn-primary btn-block" href="FormularioClientes.aspx">Agregar Cliente</a>
        </div>

    </div>
    <%} %>

</asp:Content>
