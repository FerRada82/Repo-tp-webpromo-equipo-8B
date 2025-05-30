<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Premio.aspx.cs" Inherits="Tp_webpromo_equipo_8B.Premio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<style>
    .hover-effect:hover {
        transform: translateY(-5px);
        box-shadow: 0 10px 20px rgba(108, 92, 231, 0.1);
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row row-cols-1 row-cols-md-3 g-4"> 
    <% foreach (Dominio.Articulo arti in ListaArticulo) { %>
        <div class="col mb-4"> 
            <div class="card h-100 border-0 hover-effect" style="transition: transform 0.3s, box-shadow 0.3s;">
              
                <div id="carousel-<%= arti.Id %>" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner rounded-top-3">
                        <% for (int i = 0; i < arti.RutasImagenes.Count; i++) { %>
                            <div class="carousel-item <%= i == 0 ? "active" : "" %>">
                                <img src="<%= arti.RutasImagenes[i] %>" 
                                     class="d-block w-100 card-img-top" 
                                     style="height: 220px; object-fit: cover; filter: brightness(0.95);"
                                     alt="<%= arti.Nombre %>">
                            </div>
                        <% } %>
                    </div>
                  
                    <% if (arti.RutasImagenes.Count > 1) { %>
                        <div class="carousel-indicators position-static mt-2 mx-0">
                            <% for (int i = 0; i < arti.RutasImagenes.Count; i++) { %>
                                <button type="button" 
                                        data-bs-target="#carousel-<%= arti.Id %>" 
                                        data-bs-slide-to="<%= i %>"
                                        class="<%= i == 0 ? "active" : "" %> bg-dark opacity-75 mx-1"
                                        style="width: 8px; height: 8px; border-radius: 50%; border: 0;">
                                </button>
                            <% } %>
                        </div>
                    <% } %>
                </div>

                <div class="card-body pt-3 pb-0 px-4">
                    <div class="d-flex justify-content-between align-items-start mb-2">
                        <h5 class="card-title mb-0 fw-semibold text-dark"><%= arti.Nombre %></h5>
                        <span class="badge bg-light text-dark border">Nuevo</span>
                    </div>
                    <p class="card-text text-secondary mb-3" style="font-size: 0.9rem;"><%= arti.Descripcion %></p>
                    
                    <div class="d-flex justify-content-between align-items-center border-top pt-3">
                        <span class="fw-bold fs-5" style="color: #6c5ce7;">$<%= arti.Precio %></span>
                        <a href="FormularioCliente.aspx?id=<%: arti.Id %>" 
                           class="btn btn-sm px-3 py-2" 
                           style="background-color: #6c5ce7; color: white; border-radius: 8px;">
                            Ver detalles
                        </a>
                    </div>
                </div>
            </div>
        </div>
    <% } %>
</div>


</asp:Content>