using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TP_Web
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            else
            {
                txtNombres.Enabled = false;
                txtApellidos.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCP.Enabled = false;
                txtEmail.Enabled = false;
            }
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio ingreso = new ClienteNegocio();
            bool estado = ingreso.verificarCliente(txtDNI.Text);

            if (txtDNI.Text.Length <= 50)
            {
                switch (estado)
                {
                    case false:
                        //Cliente inexistente
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El DNI ingresado no existe. Registrese a continuación');", true);
                        txtNombres.Enabled = true;
                        txtApellidos.Enabled = true;
                        txtDireccion.Enabled = true;
                        txtCiudad.Enabled = true;
                        txtCP.Enabled = true;
                        txtEmail.Enabled = true;
                        break;

                    case true:
                        //Cliente ya registrado
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('DNI cargado correctamente!');", true);
                        Session.Add("DNI", txtDNI.Text);

                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El tamaño del codigo es inapropiado.');", true);
            }
        }
    }
}