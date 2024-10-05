<%@ Page Title="Vouchers" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TP_Web.Pagina1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <br/>
                <label for="txtCodigo" class="form-label">Ingresá el código de tu voucher!</label>
            </div>
            <div class="row g-3 align-items-center">
                <div class="col-auto">
                    <label for="txtCodigo" class="col-form-label">Codigo:</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox ID="txtVoucher" CssClass="form-control" placeholder="XXXXXXXXXXXXXXX" runat="server" />
                </div>
                <div class="col-auto">
                    <span id="maxLongVoucher" class="form-text">Máximo 50 caracteres.
                    </span>
                </div>
            </div>
            <br/>
            <asp:Button Text="Siguiente" ID="btnIngresoVoucher" CssClass="btn btn-primary" OnClick="btnIngresoVoucher_Click" runat="server" />
        </div>
    </div>

<% /*<div class="row">
<div class="col-2"></div>
<div class="col">
<div class="mb-3">
<br />
<label for="txtCodigo" class="form-label">Ingresá el código de tu voucher!</label>
<asp:TextBox ID="txtVoucher" CssClass="form-control" placeholder="XXXXXXXXXXXXXXX" runat="server" />
<br />
<asp:Button Text="Siguiente" ID="btnIngresoVoucher" CssClass="btn btn-primary" OnClick="btnIngresoVoucher_Click" runat="server" />
</div>
</div>
<div class="col-2"></div>
</div>*/%>

</asp:Content>

