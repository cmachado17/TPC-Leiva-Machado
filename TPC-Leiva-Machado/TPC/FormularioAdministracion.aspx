<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioAdministracion.aspx.cs" Inherits="TPC.FormularioAdministracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center" style="padding-bottom:30px">
        <% if (Request.QueryString["categoria"] == "prioridad")
            { %>
        <h1>Agregar prioridad</h1>
        <%}
            else
            {%>
        <h1>Agregar tipo</h1>
        <%}%>
    </div>

   <div class="card bg-light px-5 py-2 mb-3" >
    <div class="mb-3">
       
          
        <asp:Label ID="lbDescripcion" runat="server" Text="Nombre" CssClass="form-label">Descripcion</asp:Label>
          <div class="row"> 
        <div class="col-6">
                <asp:TextBox ID="txbDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="col-3 text-center">
                <asp:Button AutoPostBack="false" OnClick="btnConfirmar_Click" ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary btn-block my-1 mx-5" />
            </div>
            <div class="col-3 text-center" style="padding-right:30px">
               <asp:Button AutoPostBack="false" OnClick="btnCancelar_Click" ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-block my-1 mx-5" />
            </div>
        
      </div>
        </div>
       </div>
</asp:Content>
