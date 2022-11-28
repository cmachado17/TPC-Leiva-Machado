<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="TPC.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="text-center mb-5">
         <h1>Ingresar al sistema</h1>
    </div>

    <div class="mb-3">
      <asp:Label ID="lbClaveActual" runat="server" Text="Clave Actual" for="exampleInputPassword1" cssclass="form-label">Clave Actual</asp:Label>
      <asp:TextBox type="Password" placeholder="Ingrese su clave actual" ID="txtClaveActual" runat="server" cssclass="form-control"></asp:TextBox>
        <asp:TextBox style= "background:none; color:crimson; border-style:none" ID="txtErrorClaveActual" runat="server" cssclass="form-control"></asp:TextBox>
      </div>
     <div class="mb-3">
      <asp:Label ID="lbNuevaClave" runat="server" Text="Clave Nueva" for="exampleInputPassword1" cssclass="form-label">Clave Nueva</asp:Label>
      <asp:TextBox type="Password" placeholder="Ingrese la nueva clave" ID="txtClaveNueva" runat="server" cssclass="form-control"></asp:TextBox>
        <asp:TextBox style= "background:none; color:crimson; border-style:none" ID="txtErrorClaveNueva" runat="server" cssclass="form-control"></asp:TextBox>
      </div>
       <div class="mb-3">
      <asp:Label ID="lbConfirmarClave" runat="server" Text="Confirmar nueva clave" for="exampleInputPassword1" cssclass="form-label">Confirmar nueva clave</asp:Label>
      <asp:TextBox type="Password" placeholder="Confirme la nueva clave" ID="TextBox1" runat="server" cssclass="form-control"></asp:TextBox>
        <asp:TextBox style= "background:none; color:crimson; border-style:none" ID="txtErrorConfirmarNuevaClave" runat="server" cssclass="form-control"></asp:TextBox>
      </div>

     <asp:Button AutoPostBack="true"  ID="btnConfirmarClave" runat="server" Text="Aceptar" type="submit" cssclass="btn btn-primary" OnClick="btnConfirmarClave_Click"/>

</asp:Content>
