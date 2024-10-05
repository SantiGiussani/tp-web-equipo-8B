<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TP_Web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row g-3">
        <div class="row g-3">
            <div class="col-md-2">
                <label for="txtDNI" class="form-label">DNI:</label>
                <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtDNI" AutoPostBack="True" OnTextChanged="txtDNI_TextChanged"/>
            </div>
        </div>

        <div class="col-md-1">
            <label for="txtID" class="form-label">ID:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtID" Enabled="false"/>
        </div>

        <div class="col-md-4">
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtNombres" Enabled="false"/>
        </div>

        <div class="col-md-4">
            <label for="txtApellido" class="form-label">Apellido:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtApellidos" Enabled="false"/>
        </div>

        <div class="col-md-4">
            <label for="validationCustom03" class="form-label">Direccion:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtDireccion" Enabled="false"/>
        </div>

        <div class="col-md-3">
            <label for="validationCustom04" class="form-label">Ciudad:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtCiudad" Enabled="false"/>
        </div>

        <div class="col-md-2">
            <label for="validationCustom05" class="form-label">Cod. Postal: </label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtCP" Enabled="false"/>
        </div>

        <div class="col-md-6">
            <label for="validationCustomUsername" class="form-label">Email:</label>
            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtEmail" Enabled="false"/>
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
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" runat="server" Enabled="false"/>
        </div>
    </div>

</asp:Content>
