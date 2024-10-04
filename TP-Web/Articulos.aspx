<%@ Page Title="Artículos" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TP_Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Elegi el premio por el cual queres participar!</h1>
    <br />

    <div class="row row-cols-1 row-cols-md-2 row-cols-lg-4 g-4 d-flex justify-content-center">
        <asp:Repeater runat="server" ID="rptArticulos">
            <ItemTemplate>
                <div class="col d-flex justify-content-center">
                    <div class="card" style="width: 90%; max-width: 18rem; height: auto;">

                        <div id="carousel<%# Container.ItemIndex %>" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater runat="server" ID="rptImagenes" DataSource='<%# Eval("ListaImagenes") %>'>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src='<%# Eval("Url") %>' class="d-block w-100 img-fluid" alt="..." style="height: 25rem; object-fit: cover;">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Container.ItemIndex %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Container.ItemIndex %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>

                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title text-center"><strong><%# Eval("Nombre") %></strong></h5>
                            <p class="card-text text-center"><%# Eval("Descripcion") %></p>
                            <div class="mt-auto d-flex justify-content-center">
                                <asp:Button Text="Elegir" ID="btnElegirPremio" CssClass="btn btn-primary" runat="server"
                                    CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" OnClick="btnElegirPremio_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
