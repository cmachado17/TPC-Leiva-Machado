<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mb-5">
        <h1>Ingresar al sistema</h1>
    </div>
    <div class="card bg-light mb-3 py-3 px-5">

  
    <div class="mb-3">
        <asp:Label ID="lbUser" runat="server" Text="User" for="exampleInputUser" CssClass="form-label">Dirección de correo electrónico</asp:Label>
        <asp:TextBox placeholder="Ingrese su email" ID="txtUser" runat="server" type="Email" CssClass="form-control my-2"></asp:TextBox>
        <asp:TextBox Style="background: none; color: crimson; border-style: none" ID="txtErrorEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="lbClave" runat="server" Text="Clave" for="exampleInputPassword1" CssClass="form-label">Clave</asp:Label>
        <asp:TextBox type="Password" placeholder="Ingrese su clave" ID="txtClave" runat="server" CssClass="form-control my-2"></asp:TextBox>
        <asp:TextBox Style="background: none; color: crimson; border-style: none" ID="txtErrorClave" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
        <div class="text-right">
            <asp:Button AutoPostBack="true" ID="btnOlvideMiPass" runat="server" Text="Olvide mi contraseña" type="submit" CssClass="btn btn-warning mx-2" OnClick="btnOlvideMiPass_Click"/>
            <asp:Button AutoPostBack="true" ID="btnIngresar" runat="server" Text="Ingresar" type="submit" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
        </div>
  </div>


</asp:Content>
