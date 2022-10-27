<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPC.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="mb-3">
      <asp:Label ID="lbCorreoContacto" runat="server" Text="EmailContacto" for="exampleInputEmail1" cssclass="form-label">Dirección de correo electrónico</asp:Label>
      <asp:TextBox placeholder="Ingrese su correo electrónico" ID="txtCorreoContacto" runat="server" type="email" cssclass="form-control"></asp:TextBox>
   </div>
    <div class="mb-3">
      <asp:Label ID="lbComentario" runat="server" Text="Comentario" for="exampleFormControlTextarea1" class="form-label">Comentarios</asp:Label>
        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
   </div>
   
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" type="submit" cssclass="btn btn-primary"/>





</asp:Content>
