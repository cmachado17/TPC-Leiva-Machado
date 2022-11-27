<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="TPC.Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>Empleados</h1>
    </div>

     <div class="mb-3 pb-3 d-flex align-items-center" >  
         <div style="font-size: 20px; font-weight: bold; margin-right: 5px;" >
                <asp:Label Text="Busqueda:" runat="server" />
            </div>     
        <asp:TextBox runat="server" ID="FiltroEmpleados" AutoPostBack="true" OnTextChanged="FiltroEmpleados_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del empleado.." />
    </div>



    <asp:GridView AutoGenerateColumns="false"
        CssClass="table table-striped w-100"
        ID="dgvEmpleados" runat="server"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvEmpleados_SelectedIndexChanged"
        OnPageIndexChanging="dgvEmpleados_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        style= "text-align:center">
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
                        ImageUrl="lapiz.png" width="20" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalleE"
                        Text="Detalle"
                        OnClick="BtnDetalleE_Click"
                        runat="server" 
                        ImageUrl="lupa.png" width="20" />
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
