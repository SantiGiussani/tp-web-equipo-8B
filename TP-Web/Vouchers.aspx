<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Vouchers.aspx.cs" Inherits="TP_Web.Pagina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <br />
                <label for="txtCodigo" class="form-label">Ingresá el código de tu voucher!</label>
                <asp:TextBox runat="server" CssClass="form-control" placeholder="XXXXXXXXXXXXXXX" ID="txtCodigo" />
                <br />
                <asp:Button Text="Siguiente" CssClass="btn btn-primary" runat="server" ID="btnSiguiente" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
