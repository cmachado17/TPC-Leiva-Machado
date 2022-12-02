<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPC.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="text-align: center">
        <h1 class="card text-white bg-dark mb-0 py-3">Callcenter</h1>
    </div>
    <div id="carouselExampleIndicators" class="carousel slide my-3" data-bs-ride="true">
        <div class="carousel-inner text-center">
            <div class="carousel-item active">
                <img src="./Images/call6.jpg" class="img img-fluid w-100" alt="callcenter">
            </div>
            <div class="carousel-item">
                <img src="./Images/call7.jpg" class="img img-fluid w-100" alt="callcenter">
            </div>
            <div class="carousel-item">
                <img src="./Images/call8.jpg" class="img img-fluid w-100" alt="callcenter">
            </div>
            <div class="carousel-item">
                <img src="./Images/call9.jpg" class="img img-fluid w-100" alt="callcenter">
            </div>
            <div class="carousel-item">
                <img src="./Images/call10.jpg" class="img img-fluid w-100" alt="callcenter">
            </div>
        </div>
        <button class="carousel-control-prev control-carousel" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next control-carousel" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    <div class="mt-5 card bg-light mb-3 p-3">
        <div class="text-center" style="padding-bottom: 5px">
            <p class="text-primary" style="font-weight: bold; font-size: 20px">¿Cómo ver un incidente?</p>
            <p style="color:black; font-weight: bold">
                Para el perfil administrador y supervisor se habilitará el menú Incidentes; ingresando a la lupa de detalle se podrán ver más datos.
                El perfil telefonista deberá ingresar en Area Personal  y verá las incidencias asignadas.
            </p>
        </div>

        <div class="text-center" style="padding-bottom: 5px">
            <p class="text-primary" style="font-weight: bold; font-size: 20px">¿Cómo cargar un incidente?</p>
            <p style="color:black; font-weight: bold">
                Solo podrá cargar el Telefonista ingresando a la opción del menú Clientes, 
        ahí debe presionar el botón cargar incidencia, completar el formulario y por último el botón Ingresar.
            </p>
        </div>
        <div class="text-center" style="padding-bottom: 5px">
            <p class="text-primary" style="font-weight: bold; font-size: 20px">¿Que cambios se pueden hacer en el incidente?</p>
            <p style="color:black; font-weight: bold">
                El perfil Telefonista podrá modificar, resolver o cerrar ingresando al Area Personal, a mis incidencias asignadas.
                El perfil Supervisor podrá ingresar al menú Incidentes, en la lupa reasignar y gestionará el cambio de empleado asignado.
            </p>
        </div>
        <div class="text-center" style="padding-bottom: 5px">
            <p class="text-primary" style="font-weight: bold; font-size: 20px">¿Qué es el Area Personal?</p>
            <p style="color:black; font-weight: bold">
                Es donde se podrán ver los datos personales, cambiar la imagen, cambiar la clave asignada por el Administrador.
                Además en el caso de los Telefonistas, es donde gestionarán las incidencias.
            </p>
        </div>

        <div class="text-center" style="padding-bottom: 5px">
            <p class="text-primary" style="font-weight: bold; font-size: 20px">¿Qué opciones hay en clientes?</p>
            <p style="color:black; font-weight: bold">
                Las opciones se habilitarán de acuerdo al perfil. 
        Se puede cargar un cliente haciendo click en el botón agregar Cliente, se puede cargar una incidencia presionando cargar incidencia en el listado; se puede modificar el cliente
        haciendo click en el lapiz y se puede ver mas informacion haciendo click en la lupa del detalle.
            </p>
        </div>

        <div class="text-center" style="padding-bottom: 5px">
            <p class="text-primary" style="font-weight: bold; font-size: 20px">¿Como agregar y/o eliminar un usuario?</p>
            <p style="color:black; font-weight: bold">
                Ingresar a la opción del menú Empleados, que se habilitará de acuerdo al perfil. 
        Para agregar hacer click en el boton agregar empleado debajo del listado, completar el formulario y luego 
        el botón confirmar. Para eliminar el empleado se deberá hacer click
        en el lapiz, se podrá modificar desde el formulario y presionando confirmar o para eliminar
        simplemente presionar el boton eliminar o deshabilitar.
        También se puede ver mas informacion del empleado haciendo click en la lupa del detalle.
            </p>
        </div>
    </div>

    <div class="text-center">
        <h2 style="font-weight: bold; font-size: 40px">Contacto</h2>
    </div>


    <div class="mt-3 mb-5 card bg-light mb-3 p-3">
        <div>
            <div class="mb-3">
                <asp:Label ID="lbCorreoContacto" runat="server" Text="EmailContacto" for="exampleInputEmail1" CssClass="form-label">Dirección de correo electrónico</asp:Label>
                <asp:TextBox placeholder="Ingrese su correo electrónico" ID="txtCorreoContacto" runat="server" type="email" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lbComentario" runat="server" Text="Comentario" for="areaContacto" class="form-label">Comentarios</asp:Label>
                <asp:TextBox ID="txComentario" TextMode="multiline" Height="100" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Verificar campos marcados." runat="server" ID="lbError" />
            </div>
            <div class="text-right">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" type="submit" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
            </div>

        </div>
    </div>


</asp:Content>
