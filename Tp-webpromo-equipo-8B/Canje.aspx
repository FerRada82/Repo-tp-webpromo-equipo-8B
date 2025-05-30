
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Canje.aspx.cs" Inherits="Tp_webpromo_equipo_8B.Canje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="row justify-content-center mt-4">
    <div class="col-12 col-md-8 col-lg-6">
        <div class="mb-4">
            <label for="exampleFormControlInput1" class="form-label fw-semibold" style="color: #7c3aed;">Ingresa el código del voucher</label>
            <div class="input-group">
                <span class="input-group-text" style="background-color: lavender;">
                    <i class="bi bi-ticket-perforated" style="color: #7c3aed;"></i>
                </span>
                <asp:TextBox CssClass="form-control form-control-lg" ID="exampleFormControlInput1" 
                    placeholder="Ej: XyZ456" runat="server" style="border-color: #7c3aed;"/>
            </div>
        </div>
        
        <div class="d-grid">
            <asp:Button Text="Siguiente" CssClass="btn btn-lg py-2 fw-semibold" 
                ID="btnSiguiente" OnClick="btnSiguiente_Click" runat="server"
                style="background-color: #7c3aed; border-color:#7c3aed; color: white;"/>
        </div>
    </div>
</div>
</asp:Content>

