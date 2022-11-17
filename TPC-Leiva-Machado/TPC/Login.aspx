<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="mb-3">
      <asp:Label ID="lbUser" runat="server" Text="User" for="exampleInputUser" cssclass="form-label">Usuario</asp:Label>
      <asp:TextBox placeholder="Ingrese su usuario" ID="txtUser" runat="server" type="user" cssclass="form-control"></asp:TextBox>
   </div>
    <div class="mb-3">
      <asp:Label ID="lbClave" runat="server" Text="Clave" for="exampleInputPassword1" cssclass="form-label">Clave</asp:Label>
      <asp:TextBox placeholder="Ingrese su clave" ID="txtClave" runat="server" type="password" class="form-control"></asp:TextBox>

    <div id="passwordHelpBlock" class="form-text"  style= "font-size:10px;">
  Su contraseña debe tener entre 8 y 20 caracteres, contener letras y números, y no debe contener espacios, caracteres especiales ni emoji.
</div>
           </div>
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" type="submit" cssclass="btn btn-primary" OnClick="btnIngresar_Click"/>




</asp:Content>
