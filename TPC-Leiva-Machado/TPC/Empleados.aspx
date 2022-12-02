<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="TPC.Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mb-5">
        <h1>Empleados</h1>
    </div>
    <div class="card px-5 pt-3  pb-3  bg-light mb-3">
     <div class="d-flex align-items-center" >  
         <div style="font-size: 15px; font-weight: bold; margin-right: 5px;" >
                <asp:Label Text="Busqueda:" runat="server" />
            </div>     
        <asp:TextBox runat="server" ID="FiltroEmpleados" AutoPostBack="true" OnTextChanged="FiltroEmpleados_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del empleado.." />
    </div>
        </div>

    <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-hover w-100 border-dark bg-light"
        ID="dgvEmpleados" runat="server"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvEmpleados_SelectedIndexChanged"
        OnPageIndexChanging="dgvEmpleados_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        style= "text-align:center; border-top-color: black;">
        <Columns>
            <asp:BoundField HeaderText="Nombres" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
            <asp:BoundField HeaderText="DNI" DataField="DNI" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
             <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Perfil" DataField="Perfil.Descripcion" />
                      
       
        
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnModificarE"
                        Text="Modificar"
                        OnClick="BtnModificarE_Click"
                        runat="server" 
                        ImageUrl="./Images/lapiz.png" width="20" AlternateText="Modificar" ToolTip="Modificar"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalleE"
                        Text="Detalle"
                        OnClick="BtnDetalleE_Click"
                        runat="server" 
                        ImageUrl="./Images/lupa.png" width="20" AlternateText="Ver detalle" ToolTip="Ver detalle"/>
                </ItemTemplate>
            </asp:TemplateField>    
        </Columns>
    </asp:GridView>
    <div class="row mb-3 d-flex align-items-center">
        <div class="col-12">
            <a class="btn btn-primary btn-block" href="FormularioEmpleados.aspx">Agregar empleado</a>
        </div>
    </div>
</asp:Content>
