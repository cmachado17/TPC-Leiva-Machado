<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="text-center mb-5">
         <h1>Ingresar al sistema</h1>
    </div>
  <div class="mb-3">
      <asp:Label ID="lbUser" runat="server" Text="User" for="exampleInputUser" cssclass="form-label">Dirección de correo electrónico</asp:Label>
      <asp:TextBox placeholder="Ingrese su email" ID="txtUser" runat="server" type="Email" cssclass="form-control"></asp:TextBox>
     <asp:TextBox style= "background:none; color:crimson; border-style:none" ID="txtErrorEmail" runat="server" cssclass="form-control"></asp:TextBox>    
  </div>
   
    <div class="mb-3">
      <asp:Label ID="lbClave" runat="server" Text="Clave" for="exampleInputPassword1" cssclass="form-label">Clave</asp:Label>
      <asp:TextBox type="Password" placeholder="Ingrese su clave" ID="txtClave" runat="server" cssclass="form-control"></asp:TextBox>
        <asp:TextBox style= "background:none; color:crimson; border-style:none" ID="txtErrorClave" runat="server" cssclass="form-control"></asp:TextBox>
      </div>
       
    <!--<div id="passwordHelpBlock" class="form-text"  style= "font-size:10px;">
  Su contraseña debe tener entre 8 y 20 caracteres, contener letras y números, y no debe contener espacios, caracteres especiales ni emoji.
</div>-->
           
    <asp:Button AutoPostBack="true"  ID="btnIngresar" runat="server" Text="Ingresar" type="submit" cssclass="btn btn-primary" OnClick="btnIngresar_Click"/>




</asp:Content>
