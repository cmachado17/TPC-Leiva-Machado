<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPC.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="padding-bottom:30px; text-align:center">
    <h1>Bienvenidos al Call Center CriSan</h1>
   </div>
    <div style="padding-top:30px" id="carouselExampleIndicators" class="carousel slide" data-bs-ride="true">
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
</asp:Content>
