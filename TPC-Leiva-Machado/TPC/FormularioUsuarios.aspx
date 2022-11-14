﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioUsuarios.aspx.cs" Inherits="TPC.FomularioUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <% if (Request.QueryString["id"] != null)
            { %>
        <h2>Modificar usuario</h2>
        <%}
            else
            {%>
        <h2>Agregar usuario</h2>
        <%}%>
    </div>
    <div class="mb-3">
        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="form-label">Nombre</asp:Label>
        <asp:TextBox ID="txbNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbApellido" runat="server" Text="Apellido" CssClass="form-label">Apellido</asp:Label>
        <asp:TextBox ID="txbApellido" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbDNI" runat="server" Text="DNI" CssClass="form-label">DNI</asp:Label>
        <asp:TextBox ID="txbDNI" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="form-label">Email</asp:Label>
        <asp:TextBox ID="txbEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbPerfil" runat="server" Text="Perfil" CssClass="form-label">Perfil</asp:Label>
        <asp:DropDownList ID="ddlPerfil" CssClass="form-control" runat="server"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <asp:Label ID="lbError" runat="server" Text="Revisar los campos marcados" CssClass="form-label">Revisar los campos marcados</asp:Label>
    </div>
    <div class="row">
        <div class="col-12 text-center mb-2 d-flex">
            <asp:Button AutoPostBack="false" OnClick="btnConfirmar_Click" ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary btn-block my-1 mx-5" />
            <a href="Usuarios.aspx" class="btn btn-danger btn-block my-1 mx-5">Cancelar</a>
        </div>
        <% if (Request.QueryString["id"] != null)
        { %>
        <div class="col-12 text-center d-flex">
            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-block my-1 mx-5" runat="server" />
            <asp:Button Text="Desactivar" ID="btnDesactivar" OnClick="btnDesactivar_Click" CssClass="btn btn-warning btn-block my-1 mx-5" runat="server" />
        </div>
        <% if (ConfirmarEliminacion)
        { %>
        <div class="col-12 mt-3 d-flex align-items-center justify-content-center">
            <div class="form-check">
                <asp:CheckBox runat="server" ID="chkConfirmarEliminacion" />
                <asp:Label Text="Confirmar eliminacion" runat="server" CssClass="mx-2" />
            </div>
            <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" ID="btnConfirmarEliminar" OnClick="btnConfirmarEliminar_Click" />
        </div>
        <%} %>
        <%} %>
    </div>
</asp:Content>