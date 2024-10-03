protected void btnIngresoVoucher_Click(object sender, EventArgs e)
{
    voucherNegocio ingreso = new voucherNegocio();
    if (ingreso.existeCodigo(txtVoucher.Text))
    {
        // Muestra un mensaje de éxito
        string script = "alert('Ingreso exitoso!');";
        ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", script, true);

        Response.Redirect("Articulos.aspx");
    }
    else
    {
        // Muestra un mensaje de error
        string script = "alert('Código de voucher no válido.');";
        ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
    }
}