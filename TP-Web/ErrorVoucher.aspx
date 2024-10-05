<%@ Page Title="Voucher Inválido" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ErrorVoucher.aspx.cs" Inherits="TP_Web.ErrorVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <asp:Label ID="lblErrorVoucher" runat="server"></asp:Label>
        </div>
        <div class="col-5">
            <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al Inicio" OnClick="btnVolverInicio_Click" CssClass="btn btn-secondary w-100" />
        </div>
    </div>


</asp:Content>
