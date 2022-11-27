<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPC.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="padding-bottom:30px; text-align:center">
    <h1>Bienvenidos al Call Center CriSan</h1>
   </div>
    <div style="padding-top:30px" id="carouselExampleIndicators" class="carousel slide my-3" data-bs-ride="true">
        <div class="carousel-inner text-center">
            <div class="carousel-item active">
                <img src="https://www.freeiconspng.com/thumbs/help-desk-icon/help-desk-icon-8.png" class="img" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://cdn-icons-png.flaticon.com/512/4961/4961759.png" class="img" alt="...">
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

    <div class="my-5">
        <div class="text-center"  style="padding-bottom:5px" >
    <p class="text-primary">¿Cómo ver un incidente?</p>
    <p class="text-secondary">De acuerdo al perfil se habilitará el menú Incidentes.</p>
  </div>

   <div class="text-center"  style="padding-bottom:5px" >
    <p class="text-primary">¿Cómo cargar un incidente?</p>
    <p class="text-secondary">Ingresar a la opción del menú Incidentes, 
        presionar el botón cargar incidencia, completar el formulario y por último el botón Ingresar.</p>
  </div>

   <div class="text-center"  style="padding-bottom:5px" >
    <p class="text-primary">¿´Qué opciones hay en clientes?</p>
    <p class="text-secondary">Ingresar a la opción del menú Clientes, que se habilitará de acuerdo al perfil. 
        Se puede cargar una incidencia presionando cargar incidencia en el listado; se puede modificar el cliente
        haciendo click en el lapiz y se puede ver mas informacion haciendo click en la lupa del detalle.
    </p>
  </div>

       <div class="text-center"  style="padding-bottom:5px" >
    <p class="text-primary">¿Como agregar y/o eliminar un usuario?</p>
    <p class="text-secondary">Ingresar a la opción del menú Usuarios, que se habilitará de acuerdo al perfil. 
        Para agregar hacer click en el boton agregar usuario debajo del listado, completar el formulario y luego 
        el botón confirmar. Para eliminar el usuario se debera hacer click
        en el lapiz, se podra modificar desde el formulario y presionando confirmar o para eliminar
        simplemente presionar el boton eliminar o deshabilitar.
        También se puede ver mas informacion del usuario haciendo click en la lupa del detalle.
    </p>
  </div>
    </div>
</asp:Content>
