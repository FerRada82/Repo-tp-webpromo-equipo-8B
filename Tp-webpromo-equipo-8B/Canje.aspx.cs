using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Tp_webpromo_equipo_8B
{
    public partial class Canje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = exampleFormControlInput1.Text;

            if (string.IsNullOrEmpty(codigoVoucher))
            {
                Response.Write("<script>alert('Por favor, ingrese un código de voucher válido.');</script>");
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            if (voucherNegocio.ValidarVoucherNoUtilizado(codigoVoucher))
            {
                Session["codigoVoucher"] = codigoVoucher;
                Response.Redirect("Premio.aspx");
                Session.Add("codigoVoucher", codigoVoucher);
            }
            else
            {
                Response.Write("<script>alert('El código de voucher no existe.');</script>");
            }
        }
    }
}