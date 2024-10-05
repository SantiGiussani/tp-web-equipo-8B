using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TP_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (!IsPostBack)
            {
                rptArticulos.DataSource = negocio.listar();
                rptArticulos.DataBind();
            }
        }

        protected void btnElegirPremio_Click(object sender, EventArgs e)
        {
            string IDArticulo = ((Button)sender).CommandArgument;
            Session.Add("idArticulo", IDArticulo);
            //Response.Redirect("Contacto.aspx?ID=" + IDArticulo);
        }
    }
}