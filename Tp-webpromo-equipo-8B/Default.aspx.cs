using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Tp_webpromo_equipo_8B
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            ListaArticulo = articulo.ListarArtConSp();

            //repRepetidor.DataSource = ListaArticulo;
            //repRepetidor.DataBind();
            
        }
    }
}