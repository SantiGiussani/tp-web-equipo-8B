<%@ Page Title="Artículos" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TP_Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nuestros articulos</h1>
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="rptArticulos">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="width: 18rem; height: 40rem;">
                        <!-- Clase img-fluid hace que la imagen se ajuste al ancho del card -->
                        <img src='<%# Eval("ListaImagenes[0].Url") %>' class="card-img-top img-fluid" alt="..." style="height: 25rem; object-fit: cover;">
                        <div class="card-body">
                            <h5 class="card-title"><strong><%# Eval("Nombre") %></strong></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <asp:Button Text="Elegir" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
