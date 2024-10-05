using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP_Web
{
    public partial class Contacto : System.Web.UI.Page
    {
        private Cliente clienteAux = new Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDNI.Attributes.Add("required", "required");
                txtApellido.Attributes.Add("required", "required");
                txtNombre.Attributes.Add("required", "required");
                txtDireccion.Attributes.Add("required", "required");
                txtCiudad.Attributes.Add("required", "required");
                txtCP.Attributes.Add("required", "required");
                txtEmail.Attributes.Add("required", "required");
            }
            else
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCP.Enabled = false;
                txtEmail.Enabled = false;
                btnConfirmar.Enabled = true;
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
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtDireccion.Enabled = true;
                        txtCiudad.Enabled = true;
                        txtCP.Enabled = true;
                        txtEmail.Enabled = true;
                        btnConfirmar.Enabled = true;
                        break;

                    case true:
                        //Cliente ya registrado
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('DNI cargado correctamente!');", true);
                        Session.Add("DNI", txtDNI.Text);

                        clienteAux = ingreso.buscarCliente(txtDNI.Text);

                        txtID.Text = clienteAux.id.ToString();
                        txtDNI.Text = clienteAux.documento;
                        txtNombre.Text = clienteAux.nombre;
                        txtApellido.Text = clienteAux.apellido;
                        txtDireccion.Text = clienteAux.direccion;
                        txtCiudad.Text = clienteAux.ciudad;
                        txtEmail.Text = clienteAux.email;
                        txtCP.Text = clienteAux.codigoPostal.ToString();
                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El tamaño del codigo es inapropiado.');", true);
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();

            if (!negocio.verificarCliente(txtDNI.Text))
            {
                try
                {
                    //CARGA NUEVO CLIENTE
                    clienteAux.documento = txtDNI.Text;
                    clienteAux.nombre = txtNombre.Text;
                    clienteAux.apellido = txtApellido.Text;
                    clienteAux.direccion = txtDireccion.Text;
                    clienteAux.ciudad = txtCiudad.Text;
                    clienteAux.email = txtEmail.Text;
                    clienteAux.codigoPostal = int.Parse(txtCP.Text);

                    negocio.agregarCliente(clienteAux);

                    

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar el código de cliente.", ex);
                }
            }
            else
            {
                //CARGA CLIENTE UTILIZADO
            }

            Response.Redirect("FinalizacionExitosa.aspx", false);
        }
    }
}