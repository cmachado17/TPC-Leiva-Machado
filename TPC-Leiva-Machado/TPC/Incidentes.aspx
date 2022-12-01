<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TPC.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center" style="margin-bottom: 30px" >
        <h1 >Incidencias</h1>
    </div>

       <div class="text-center">
      
         <div class="my-3 d-flex align-items-center " style="padding-bottom: 3px">
            <div style="font-size: 20px; font-weight: bold; margin-right: 5px;" >
                <asp:Label Text="Estado:" runat="server" />
            </div>
            <asp:DropDownList ID="dwEstadosI" AutoPostBack="false" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:Button ID="btnBuscarI" Text="Buscar" runat="server" OnClick="btnBuscarI_Click" CssClass="btn btn-success ml-3" />
        </div>
        <div class="mb-3 pb-3 d-flex align-items-center" >  
            <div style="font-size: 20px; font-weight: bold; margin-right: 5px;" >
                <asp:Label Text="Cliente:" runat="server" />
            </div>
        <asp:TextBox runat="server" ID="FiltroClientesIn" AutoPostBack="true" OnTextChanged="FiltroClientesIn_TextChanged" CssClass="form-control" placeholder="Ingrese el nombre del cliente.." />
    </div>
       

    <%--<asp:Button Text="Cargar incidencia" runat="server" cssclass="btn btn-primary" href="Incidentes.aspx"/>--%>
    <asp:GridView CssClass="table table-striped w-100 my-3"
        ID="dgvIncidencias" runat="server"
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        OnPageIndexChanging="dgvIncidencias_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        Style="text-align: center">
        <Columns>

            <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombres" />
            <asp:BoundField HeaderText="DNI" DataField="Cliente.DNI" />
            <asp:BoundField HeaderText="Email" DataField="Cliente.Email" />
            <asp:BoundField HeaderText="Numero Incidente" DataField="Id" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Descripcion" />
            <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
            <asp:BoundField HeaderText="Empleado Asignado" DataField="EmpleadoAsignado.Nombres" />

            <asp:TemplateField HeaderText="Re-asignar">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnReAsignar"
                        Text="Detalle"
                        OnClick="BtnReAsignar_Click"
                        runat="server"
                        ImageUrl="lupa.png" Width="20" AlternateText="Reasignar" ToolTip="Reasignar"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Detalle">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalleI"
                        Text="Detalle"
                        OnClick="BtnDetalleI_Click"
                        runat="server"
                        ImageUrl="lupa.png" Width="20" AlternateText="Ver detalle" ToolTip="Ver detalle"/>
                </ItemTemplate>
            </asp:TemplateField>




        </Columns>
    </asp:GridView>
</asp:Content>
