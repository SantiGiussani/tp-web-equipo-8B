using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
                reiniciarFormulario();
                Session["clienteID"] = 0;
            }
            else
            {
                int clienteID = (int)Session["clienteID"];
                if (clienteID != 0)
                {
                    reiniciarFormulario();
                }
                else
                {
                    conservarDatos();
                }
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
                        activarFormulario();
                        Session["clienteID"] = 0;
                        break;

                    case true:
                        //Cliente ya registrado
                        lblDniAviso.Text = "DNI cargado correctamente.";
                        Session.Add("DNI", txtDNI.Text);

                        clienteAux = ingreso.buscarCliente(txtDNI.Text);

                        Session["clienteID"] = clienteAux.id;

                        precargarCliente();

                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El tamaño del codigo es inapropiado.');", true);
            }

            conservarDatos();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            voucherNegocio agregar = new voucherNegocio();

            System.Diagnostics.Debug.WriteLine($"Voucher Usado: {voucherUsado}");

            clienteAux.id = 0;
            clienteAux.documento = txtDNI.Text;
            clienteAux.nombre = txtNombre.Text;
            clienteAux.apellido = txtApellido.Text;
            clienteAux.direccion = txtDireccion.Text;
            clienteAux.ciudad = txtCiudad.Text;
            clienteAux.email = txtEmail.Text;
            clienteAux.codigoPostal = 0;

            if (soloNumeros(txtCP.Text) && verificarDNI(txtDNI.Text) && verificarMail(txtEmail.Text))
            {
                clienteAux.documento = txtDNI.Text;
                clienteAux.codigoPostal = int.Parse(txtCP.Text);

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
                        clienteConId = negocio.buscarCliente(clienteAux.documento);
                        agregar.agregarVoucher(clienteConId, articuloElegido, voucherUsado);

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
            else
            {
                if (!soloNumeros(txtCP.Text))
                {
                    txtCP.CssClass = "form-control is-invalid";
                }
                else
                {
                    txtCP.CssClass = "form-control";
                }

                if (!verificarDNI(txtDNI.Text))
                {
                    txtDNI.CssClass = "form-control is-invalid";
                }
                else
                {
                    txtDNI.CssClass = "form-control";
                }




                if (!verificarMail(txtEmail.Text))
                {
                    txtEmail.CssClass = "form-control is-invalid";
                }
                else
                {
                    txtEmail.CssClass = "form-control";
                }



            }
        }

        protected void conservarDatos()
        {
            if (Session["cliente"] != null)
            {
                txtID.Text = clienteAux.id == 0 ? "" : clienteAux.id.ToString();
                txtNombre.Text = clienteAux.nombre;
                txtApellido.Text = clienteAux.apellido;
                txtDireccion.Text = clienteAux.direccion;
                txtCiudad.Text = clienteAux.ciudad;
                txtCP.Text = clienteAux.codigoPostal == 0 ? "" : clienteAux.codigoPostal.ToString();
                txtEmail.Text = clienteAux.email;
            }
        }

        protected void activarFormulario()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDireccion.Enabled = true;
            txtCiudad.Enabled = true;
            txtCP.Enabled = true;
            txtEmail.Enabled = true;
            btnConfirmar.Enabled = true;
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
            txtID.Text = clienteAux.id == 0 ? string.Empty : string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCP.Text = clienteAux.codigoPostal == 0 ? string.Empty : string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void precargarCliente()
        {
            txtID.Text = clienteAux.id.ToString();
            txtDNI.Text = clienteAux.documento;
            txtNombre.Text = clienteAux.nombre;
            txtApellido.Text = clienteAux.apellido;
            txtDireccion.Text = clienteAux.direccion;
            txtCiudad.Text = clienteAux.ciudad;
            txtEmail.Text = clienteAux.email;
            txtCP.Text = clienteAux.codigoPostal.ToString();
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            txtCiudad.Enabled = false;
            txtCP.Enabled = false;
            txtEmail.Enabled = false;
            btnConfirmar.Enabled = true;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }


        private bool verificarDNI(string cadena)
        {
            if (soloNumeros(cadena) && cadena.Length == 8 || cadena.Length == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool verificarMail(string cadena)
        {
            if ((cadena.Contains("@") && cadena.EndsWith(".com")))
            {
                return true;
            }
            else return false;

        }
    }
}