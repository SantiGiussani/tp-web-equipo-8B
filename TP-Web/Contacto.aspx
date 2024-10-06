<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TP_Web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row g-3">
        <div class="row g-3">
            <div class="col-4 d-flex align-items-center">
                <label for="txtDNI" class="form-label me-2">DNI:</label>
                <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtDNI" AutoPostBack="True" OnTextChanged="txtDNI_TextChanged" />
            </div>
            <div class="col-6 d-flex align-items-center">
                <asp:Label for="txtDNI" CssClass="form-label" ID="lblDniAviso" runat="server" Text="Por favor, ingrese un Nro. de Documento."></asp:Label>
            </div>
        </div>
        <div class="col-md-1">
            <label for="txtID" class="form-label">ID:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtID" Enabled="false" />
        </div>

        <div class="col-md-4">
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtNombre" Enabled="false" />
        </div>

        <div class="col-md-4">
            <label for="txtApellido" class="form-label">Apellido:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtApellido" Enabled="false" />
        </div>

        <div class="col-md-4">
            <label for="validationCustom03" class="form-label">Direccion:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtDireccion" Enabled="false" />
        </div>

        <div class="col-md-3">
            <label for="validationCustom04" class="form-label">Ciudad:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtCiudad" Enabled="false" />
        </div>

        <div class="col-md-2">
            <label for="validationCustom05" class="form-label">Cod. Postal: </label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtCP" Enabled="false" />
        </div>

        <div class="col-md-6">
            <label for="validationCustomUsername" class="form-label">Email:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtEmail" Enabled="false" />
        </div>

        <div class="col-12">
            <div class="form-check">
                <input class="form-check-input" cssclass="form-control" type="checkbox" value="" id="invalidCheck" required>
                <label class="form-check-label" for="invalidCheck">
                    Acuerdo con los terminos y condiciones
                </label>
            </div>
        </div>

        <div class="col-12">
            <asp:Button Text="Confirmar" CssClass="btn btn-primary" ID="btnConfirmar" runat="server" Enabled="false" OnClick="btnConfirmar_Click" />
        </div>
    </div>

</asp:Content>
