<%@ Page Title="Participación Registrada" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="Tp_webpromo_equipo_8B.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
        .congrats-container {
            max-width: 600px;
            margin: 5rem auto;
            padding: 2.5rem;
            border-radius: 15px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.1);
            background: white;
            text-align: center;
        }
        .congrats-icon {
            font-size: 4rem;
            color: #28a745;
            margin-bottom: 1.5rem;
        }
        .btn-home {
            padding: 0.5rem 1.5rem;
            border-radius: 50px;
            font-weight: 600;
        }
        @media (max-width: 576px) {
            .congrats-container {
                margin: 2rem auto;
                padding: 1.5rem;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="congrats-container">
            <div class="congrats-icon">
                <i class="fas fa-check-circle"></i>
            </div>
            <h1 class="mb-3 text-success">¡Felicitaciones!</h1>
            <h3 class="mb-4">Su participación ha sido registrada correctamente</h3>
            <p class="text-muted mb-4">Gracias por participar. Hemos recibido tu información satisfactoriamente.</p>
            
            <div class="d-flex justify-content-center">
                <a href="Default.aspx" class="btn btn-success btn-home">
                    <i class="fas fa-home me-2"></i>Volver al inicio
                </a>
            </div>
            
            <div class="mt-4 pt-3 border-top">
                <p class="small text-muted mb-0">¿Necesitas ayuda? <a href="Contacto.aspx">Contáctanos</a></p>
            </div>
        </div>
    </div>

</asp:Content>