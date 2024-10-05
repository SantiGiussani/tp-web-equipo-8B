<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TP_Web.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<div class="row g-3 needs-validation">
    <div class="row g-3 needs-validation">
    <div class="col-md-1">
  <label class="form-label">ID:</label>
   <asp:TextBox CssClass="form-control" runat="server" type="text" ID="txtboxID"/>
   </div>


    <div class="col-md-2">
  <label for="validationCustom01" class="form-label">DNI:</label>
   <asp:TextBox runat="server" CssClass="form-control" type="text" ID="textboxDNI"/>
    </div>

    </div>
    
  <div class="col-md-4">
    <label for="validationCustom01" class="form-label">Nombre:</label>
      <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtboxNombre"/>
  </div>

  <div class="col-md-4">
    <label for="validationCustom02" class="form-label">Apellido:</label>
      <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtboxApellido"/>
  </div>

  <div class="col-md-6">
    <label for="validationCustomUsername" class="form-label">Email:</label>
      <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtboxEmail"/>
    </div>
    
  <div class="col-md-4">
    <label for="validationCustom03" class="form-label">Direccion:</label>
      <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtboxDireccion"/>
  </div>

  <div class="col-md-4">
    <label for="validationCustom04" class="form-label">Ciudad:</label>
      <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtboxCiudad"/>
  </div>
  <div class="col-md-1">
    <label for="validationCustom05" class="col-form-label-sm"> Codigo postal: </label>
      <asp:TextBox runat="server" CssClass="form-control" type="text" ID="txtboxCP"/>
  </div>    

  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" CssClass="form-control" type="checkbox" value="" id="invalidCheck" required>
      <label class="form-check-label" for="invalidCheck">
        Acuerdo con los terminos y condiciones
      </label>
    </div>
  </div>

  <div class="col-12">
      <asp:Button Text="Registrarse" CssClass="btn btn-primary" runat="server"/>
  </div>
</div>
    
</asp:Content>
