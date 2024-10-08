﻿using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                rptArticulos.DataSource = negocio.listar();
                rptArticulos.DataBind();
            }

        }

        protected void VerDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleArticulo.aspx");
        }
    }
}