<%@ Page Title="Artículos" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TP_Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvArticulos" CssClass="table table-dark table-hover" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText ="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText ="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText ="Marca" DataField="Marca_.Descripcion" />
            <asp:BoundField HeaderText ="Categoria" DataField="Categoria_.Descripcion" />
            <asp:BoundField HeaderText ="Precio" DataField="Precio" />
        </Columns>
    </asp:GridView>
</asp:Content>
