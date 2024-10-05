using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

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
                txtboxNombre.Enabled = false;
                txtboxApellido.Enabled = false;
                txtboxDireccion.Enabled = false;
                txtboxCiudad.Enabled = false;
                txtboxEmail.Enabled = false;
                txtboxCP.Enabled = false;
            }
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio ingreso = new ClienteNegocio();
            bool estado = ingreso.verificarCliente(txtboxDNI.Text);

            if (txtboxDNI.Text.Length <= 50)
            {
                switch (estado)
                {
                    case false:
                        //Cliente inexistente
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El DNI ingresado no existe. Registrese a continuación');", true);
                        txtboxNombre.Enabled = true;
                        txtboxApellido.Enabled = true;
                        txtboxDireccion.Enabled = true;
                        txtboxCiudad.Enabled = true;
                        txtboxCP.Enabled = true;
                        txtboxEmail.Enabled = true;
                        break;

                    case true:
                        //Cliente ya registrado
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('DNI cargado correctamente!');", true);
                        Session.Add("DNI", txtboxDNI.Text);

                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El tamaño del codigo es inapropiado.');", true);
            }
        }

        protected bool validarCasillas()
        {
            if (txtboxDNI.Text == ""
                || txtboxNombre.Text == ""
                || txtboxApellido.Text == ""
                || txtboxEmail.Text == "" ||
                txtboxDireccion.Text == ""
                || txtboxCiudad.Text == ""
                || txtboxCP.Text == "")
                return false;
            return true;
        }

        protected void Click(object sender, EventArgs e)
        {
            bool val;
            val = validarCasillas();
            if (val)
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente.documento = txtboxDNI.Text;
                cliente.nombre = txtboxNombre.Text;
                cliente.apellido = txtboxApellido.Text;
                cliente.email = txtboxEmail.Text;
                cliente.direccion = txtboxDireccion.Text;
                cliente.ciudad = txtboxCiudad.Text;
                cliente.codigoPostal = int.Parse(txtboxCP.Text);
                clienteNegocio.AgregarCliente(cliente);
            }
            else
            {
                Incompleto.Visible = true;
            }

        }
    }
}