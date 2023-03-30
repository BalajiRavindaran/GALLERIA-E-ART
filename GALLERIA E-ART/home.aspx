<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GALLERIA_E_ART.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .title {
            height: 91vh;
        }
        #bg-video {
             position: relative;
             z-index: -1;
             top: 0;
             left: 0;
             width: 100%; 
             height: 100%;
             object-fit: cover;
        }

        .about {
            text-align:center;
            padding: 25px 0 25px 0;
        }

        .about h1 {
            padding: 10px 0 10px 0;
            color:red;
        }

        .about p{
            padding: 0 25px 0 25px;
            font-size: 25px;
            font-weight: 400;
        }
    </style>

    <section class="title">
        <video autoplay muted loop id="bg-video">
            <source src="assets/GALLERIA%20E-ART.mp4" type="video/mp4"/>
        </video>
    </section>

    <section class="about">
        <h1>ABOUT</h1>
        <p>Galleria E-Art is an effortless platform for artists to add their work for recognition, where common users can easily come across numerous arts either for inspiration or to contact the artists for personalized creations.</p>
    </section>

</asp:Content>
