<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Premio.aspx.cs" Inherits="Tp_webpromo_equipo_8B.Premio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row row-cols-1 row-cols-md-3 g-4"> 
    <% foreach (Dominio.Articulo arti in ListaArticulo) { %>
        <div class="col mb-4"> 
            <div class="card h-100 shadow-sm"> 
              
                <div id="carousel-<%= arti.Id %>" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < arti.RutasImagenes.Count; i++) { %>
                            <div class="carousel-item <%= i == 0 ? "active" : "" %>">
                                <img src="<%= arti.RutasImagenes[i] %>" 
                                     class="d-block w-100 card-img-top" 
                                     style="height: 200px; object-fit: cover;"
                                     alt="<%= arti.Nombre %>">
                            </div>
                        <% } %>
                    </div>
                  
                    <% if (arti.RutasImagenes.Count > 1) { %>
                        <div class="carousel-indicators position-static mt-2">
                            <% for (int i = 0; i < arti.RutasImagenes.Count; i++) { %>
                                <button type="button" 
                                        data-bs-target="#carousel-<%= arti.Id %>" 
                                        data-bs-slide-to="<%= i %>"
                                        class="<%= i == 0 ? "active" : "" %>"
                                        style="width: 10px; height: 10px; border-radius: 50%;">
                                </button>
                            <% } %>
                        </div>
                    <% } %>
                </div>


                <div class="card-body">
                    <h5 class="card-title"><%= arti.Nombre %></h5>
                    <p class="card-text text-muted"><%= arti.Descripcion %></p>
                    <div class="d-flex justify-content-between align-items-center">
                        <span class="fw-bold text-primary">$<%= arti.Precio %></span>
                        <a href="FormularioCliente.aspx?id=<%: arti.Id %>" class="btn btn-sm btn-outline-primary">Ver más</a>
                    </div>
                </div>
            </div>
        </div>
    <% } %>
</div>

</asp:Content>