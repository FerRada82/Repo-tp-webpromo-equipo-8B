﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using Negocio;

namespace Tp_webpromo_equipo_8B
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void agregarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Dni = txtDni.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Email = txtEmail.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.CP = int.Parse(txtCP.Text);

            if (cliente.CP < 0)
            {
                return;
            }

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clienteNegocio.agregar(cliente);

        }

        private bool campoVacio(string campo)
        {
            if (campo == "")
            {
                return true;
            }

            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(Request.QueryString["id"]);
            string mensajeError = "";


            if (campoVacio(txtDni.Text) || campoVacio(txtNombre.Text) || campoVacio(txtApellido.Text) || campoVacio(txtEmail.Text) || campoVacio(txtDireccion.Text) || campoVacio(txtCiudad.Text) || campoVacio(txtCP.Text))
            {
                mensajeError += "Debe cargar todos los campos para participar. ";
            }

            if (!(CheckTermCond.Checked))
            {
                mensajeError += "Debe aceptar los terminos y condiciones.";
            }

            if (mensajeError != "")
            {
                Response.Write("<script>alert('" + mensajeError + "');</script>");
                return;
            }

            string dni = txtDni.Text;
            ClienteNegocio auxNegocio = new ClienteNegocio();
            Cliente aux = auxNegocio.BuscarPorDni(dni);

            int IdCliente;


            if (aux != null && aux.Dni != "0")
            {
                IdCliente = auxNegocio.buscarId(dni);
                Response.Write("<script>alert('no se cargo , el id es: " + IdCliente + "');</script>");
            }
            else
            {
                agregarCliente();
                IdCliente = auxNegocio.buscarId(dni);  
                Response.Write("<script>alert('se cargo y el id es:" + IdCliente + "');</script>");

            }


            string codigoVoucher = Session["codigoVoucher"].ToString();

            VoucherNegocio vnegocio = new VoucherNegocio();
            vnegocio.canjearVoucher(codigoVoucher, IdCliente, idArticulo);

            Response.Redirect("Exito.aspx");
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente = clienteNegocio.BuscarPorDni(dni);
                if (cliente.Dni != "0")
                {
                    txtDni.Text = cliente.Dni;
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtCiudad.Text = cliente.Ciudad;
                    txtDireccion.Text = cliente.Direccion;
                    txtCP.Text = cliente.CP.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}