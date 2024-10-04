<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TP_Web.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row g-3 needs-validation">
    <div class="col-md-4">
    <label for="validationCustom01" class="form-label">nombre:</label>
    <input type="text" class="form-control" id="validationCustom01" value="ingrese su nombre..." required>
    <div class="valid-feedback">
      bien!
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustom02" class="form-label">apellido:</label>
    <input type="text" class="form-control" id="validationCustom02" value="ingrese su apellido..." required>
    <div class="valid-feedback">
      bien!
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustomUsername" class="form-label">Mail:</label>
    <div class="input-group has-validation">
      <span class="input-group-text" id="inputGroupPrepend">@</span>
      <input type="text" class="form-control" id="validationCustomUsername" aria-describedby="inputGroupPrepend" required>
      <div class="invalid-feedback">
        no existe el mail
      </div>
    </div>
  </div>
  <div class="col-md-6">
    <label for="validationCustom03" class="form-label">provincia:</label>
    <input type="text" class="form-control" id="validationCustom03" required>
    <div class="invalid-feedback">
      No existe la provincia
    </div>
  </div>
  <div class="col-md-3">
    <label for="validationCustom04" class="form-label">ciudad:</label>
      <input type="text" class="form-control" id="validationCiudad" required/>
    <div class="invalid-feedback">
      Ingrse una ciudad correcta
    </div>
  </div>
  <div class="col-md-3">
    <label for="validationCustom05" class="form-label">Codigo postal:</label>
    <input type="text" class="form-control" id="validationCustom05" required>
    <div class="invalid-feedback">
      ingresar un codigo postal
    </div>
  </div>
  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" value="" id="invalidCheck" required>
      <label class="form-check-label" for="invalidCheck">
        Acuerdo con los terminos y condiciones
      </label>
      <div class="invalid-feedback">
         Debes estar de acuerdo antes de continuar
      </div>
    </div>
  </div>
  <div class="col-12">
    <button class="btn btn-primary" type="submit">registrarme</button>
  </div>

    </div>
    
</asp:Content>
