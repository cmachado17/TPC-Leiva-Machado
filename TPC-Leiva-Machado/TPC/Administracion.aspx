<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="TPC.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h2>Administracion</h2>
    </div>
    <div class="row">
        <div class="col-6">
              <asp:Button Text="Agregar prioridad" ID="Prioridad" runat="server" class="btn btn-primary btn-block" OnClick="Prioridad_Click"/>
          <%--  <a class="btn btn-primary btn-block" href="FormularioAdministracion?categoria=prioridad.aspx">Agregar prioridad</a>--%>
            <asp:GridView AutoGenerateColumns="false"
                CssClass="table table-striped w-100"
                ID="dgvPrioridades" runat="server"
                DataKeyNames="Id"
                Style="text-align: center">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="BtnPrioridad"
                                Text="Borrar prioridad"
                                OnClick="BtnPrioridad_Click"
                                runat="server"
                                CssClass="btn btn-link" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
        <div class="col-6">
            <asp:Button Text="Agregar tipo" ID="Tipo" runat="server" class="btn btn-primary btn-block" OnClick="Tipo_Click"/>
           <%-- <a class="btn btn-primary btn-block" href="FormularioAdministracion?categoria=tipo.aspx">Agregar tipo</a>--%>
              <asp:GridView AutoGenerateColumns="false"
                CssClass="table table-striped w-100"
                ID="dgvTipoIncidencias" runat="server"
                DataKeyNames="Id"
                Style="text-align: center">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="BtnTipoIncidencias"
                                Text="Borrar tipo"
                                OnClick="BtnTipoIncidencias_Click"
                                runat="server"
                                CssClass="btn btn-link" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
