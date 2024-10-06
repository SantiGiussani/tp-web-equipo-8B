using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        int articuloElegido;
        string voucherUsado;
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

            if (Session["idArticulo"] != null && Session["idVoucher"] != null)
            {
                articuloElegido = int.Parse(Session["idArticulo"].ToString());//Como es una textbox primero tengo que pasarla a string y luego con parse pasarla a int
                voucherUsado = Session["idVoucher"].ToString();
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
                        lblDniAviso.Text = "Usted no se encuentra registrado. Registrese a continuación...";
                        reiniciarFormulario();
                        break;

                    case true:
                        //Cliente ya registrado
                        lblDniAviso.Text = "DNI cargado correctamente.";
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
            voucherNegocio agregar = new voucherNegocio();

            System.Diagnostics.Debug.WriteLine($"Voucher Usado: {voucherUsado}");

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
                    Cliente clienteConId = new Cliente();
                    clienteConId=negocio.buscarCliente(clienteAux.documento);
                    agregar.agregarVoucher(clienteConId,articuloElegido,voucherUsado);
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar el código de cliente.", ex);
                }
            }
            else
            {
                //CARGA CLIENTE UTILIZADO
                Cliente clienteConId = new Cliente();
                clienteConId = negocio.buscarCliente(txtDNI.Text);
                agregar.agregarVoucher(clienteConId, articuloElegido, voucherUsado);
            }

            Response.Redirect("FinalizacionExitosa.aspx", false);
        }

        protected void reiniciarFormulario()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDireccion.Enabled = true;
            txtCiudad.Enabled = true;
            txtCP.Enabled = true;
            txtEmail.Enabled = true;
            btnConfirmar.Enabled = true;
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCP.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}