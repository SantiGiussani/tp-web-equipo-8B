<%@ Page Title="Proceso Exitoso!" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FinalizacionExitosa.aspx.cs" Inherits="TP_Web.FinalizacionExitosa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row">
            <asp:Label ID="lblFinalizacionExitosa" CssClass="alert alert-success" runat="server"
                Text="El proceso ha sido exitoso y se ha cargado correctamente en el sistema. Suerte en el sorteo!"></asp:Label>
        </div>
        <div class="col-5">
            <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al Inicio" OnClick="btnVolverInicio_Click" CssClass="btn btn-secondary w-100" />
        </div>
    </div>
</asp:Content>
