using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web
{
    public partial class ErrorVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bandera = "0";

            if (Request.QueryString["tipo"] != null)
            {
                bandera = Request.QueryString["tipo"].ToString();
            }
            
            if (bandera == "0")
            {
                lblErrorVoucher.CssClass = "alert alert-danger";
                lblErrorVoucher.Text = "El código del voucher ingresado es incorrecto. Por favor, verifica e intenta nuevamente.";
            }
            else if (bandera == "1")
            {
                lblErrorVoucher.CssClass = "alert alert-warning";
                lblErrorVoucher.Text = "El voucher ya ha sido utilizado. No es posible usarlo nuevamente.";
            }
        }

        protected void btnVolverInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}