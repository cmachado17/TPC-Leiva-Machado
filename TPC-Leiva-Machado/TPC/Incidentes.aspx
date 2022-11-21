<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TPC.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Incidencias</h2>
    <%--<asp:Button Text="Cargar incidencia" runat="server" cssclass="btn btn-primary" href="Incidentes.aspx"/>--%>
     <asp:GridView  CssClass="table table-striped w-100" 
         ID="dgvIncidencias" runat="server"
         AutoGenerateColumns="false"
         DataKeyNames="Id"
        OnPageIndexChanging="dgvIncidencias_PageIndexChanging"
        AllowPaging="true" PageSize="10"
        style= "text-align:center">
         <Columns>
            
            <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombres" />
             <asp:BoundField HeaderText="DNI" DataField="Cliente.DNI" />
             <asp:BoundField HeaderText="Email" DataField="Cliente.Email" />
             <asp:BoundField HeaderText="Numero Incidente" DataField="Id" />
             <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Descripcion" />
             <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
            <asp:BoundField HeaderText="FechaDeAlta" DataField="FechaDeAlta" />
         <asp:BoundField HeaderText="Empleado Asignado" DataField="EmpleadoAsignado.Nombres" />  
        
             
         
                    <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="BtnDetalleI"
                        Text="Detalle"
                        OnClick="BtnDetalleI_Click"
                        runat="server" 
                        ImageUrl="lupa.png" width="20" />
                </ItemTemplate>
            </asp:TemplateField>



         
         </Columns>
     </asp:GridView>
</asp:Content>
