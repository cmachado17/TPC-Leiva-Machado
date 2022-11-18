<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Errores.aspx.cs" Inherits="TPC.Errores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2  style= "text-align:center; color:crimson; padding-top: 30px">ERROR</h2>
   
    <div class="text-center"  style= "padding-top: 20px">
    <asp:TextBox ID="txtError" runat="server"  style= "background:none; text-align:center; color:crimson; border-style:none"></asp:TextBox>
    </div>
</asp:Content>
