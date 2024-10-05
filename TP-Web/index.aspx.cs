using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static negocio.voucherNegocio;

namespace TP_Web
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnIngresoVoucher_Click(object sender, EventArgs e)
        {
            voucherNegocio ingreso = new voucherNegocio();
            EstadoVoucher estado = ingreso.verificarCodigo(txtVoucher.Text);

            if (txtVoucher.Text.Length <= 50)
            {
                switch (estado)
                {
                    case EstadoVoucher.Inexistente:
                        // Mensaje de voucher inexistente
                        //ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El voucher ingresado no existe.');", true);
                        Response.Redirect("ErrorVoucher.aspx?tipo=0", false);
                        break;

                    case EstadoVoucher.Utilizado:
                        // Mensaje de voucher ya utilizado
                        //ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El voucher ya ha sido utilizado.');", true);
                        Response.Redirect("ErrorVoucher.aspx?tipo=1", false);
                        break;

                    case EstadoVoucher.Valido:
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Voucher cargado correctamente! Por favor elija el artículo que desea.'); window.location='Articulos.aspx';", true);
                        Session.Add("idVoucher", txtVoucher.Text);
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