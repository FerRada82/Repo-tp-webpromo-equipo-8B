<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="Tp_webpromo_equipo_8B.FormularioCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 6px 20px rgba(108, 92, 231, 0.1);
            padding: 2.5rem;
        }
        
        .form-title {
            color: #6c5ce7;
            font-weight: 600;
            margin-bottom: 1.5rem;
            text-align: center;
            font-size: 1.8rem;
        }
        
        .form-label {
            font-weight: 500;
            color: #4a4a4a;
            margin-bottom: 0.5rem;
        }
        
        .form-control {
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            padding: 0.75rem 1rem;
            transition: all 0.3s;
        }
        
        .form-control:focus {
            border-color: #6c5ce7;
            box-shadow: 0 0 0 0.25rem rgba(108, 92, 231, 0.25);
        }
        
        .input-group-text {
            background-color: #f8f9fa;
            border: 1px solid #e0e0e0;
            color: #6c5ce7;
        }
        
        .btn-submit {
            background-color: #6c5ce7;
            border: none;
            border-radius: 8px;
            padding: 0.75rem 2rem;
            font-weight: 500;
            letter-spacing: 0.5px;
            transition: all 0.3s;
            width: 100%;
        }
        
        .btn-submit:hover {
            background-color: #5649c0;
            transform: translateY(-2px);
        }
        
        .form-check-input:checked {
            background-color: #6c5ce7;
            border-color: #6c5ce7;
        }
        
        .form-check-label {
            color: #6a6a6a;
        }
        
        .form-section {
            margin-bottom: 2rem;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="form-container">
                    <h1 class="form-title">Completa tus datos</h1>
                    
                    <div class="form-section">
                        <div class="mb-4">
                            <label for="txtDni" class="form-label">DNI</label>
                            <asp:TextBox ID="txtDni" AutoPostBack="true" placeholder="45234543" CssClass="form-control" runat="server" OnTextChanged="txtDni_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="form-section">
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <label for="txtNombre" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-4">
                                <label for="txtApellido" class="form-label">Apellido</label>
                                <asp:TextBox ID="txtApellido" placeholder="Apellido" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="mb-4">
                            <label for="txtEmail" class="form-label">Email</label>
                            <div class="input-group">
                                <span class="input-group-text" id="basic-addon1">@</span>
                                <asp:TextBox ID="txtEmail" type="email" placeholder="email@email.com" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="form-section">
                        <div class="mb-4">
                            <label for="txtDireccion" class="form-label">Dirección</label>
                            <asp:TextBox ID="txtDireccion" placeholder="Calle 123" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <label for="txtCiudad" class="form-label">Ciudad</label>
                                <asp:TextBox ID="txtCiudad" placeholder="Mi Ciudad" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-4">
                                <label for="txtCP" class="form-label">Código Postal</label>
                                <asp:TextBox ID="txtCP" type="number" placeholder="XXXX" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="form-section">
                        <div class="form-check mb-4">
                            <asp:CheckBox ID="CheckTermCond" class="form-check-input" runat="server" />
                            <label class="form-check-label" for="Check">
                                Acepto los términos y condiciones
                            </label>
                        </div>
                    </div>
                    
                    <div class="d-grid">
                        <asp:Button ID="btnParticipar" OnClick="Button1_Click" CssClass="btn-submit" runat="server" Text="Participar" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>