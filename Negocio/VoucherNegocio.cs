using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using Dominio;

namespace Negocio
{

    public class VoucherNegocio
    {

        public bool ValidarVoucherNoUtilizado(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            bool esValido = false;

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, FechaCanje FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codigoVoucher);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    if (datos.Lector["FechaCanje"] is DBNull)
                    {
                        esValido = true;
                    }
                }
                return esValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void canjearVoucher(string codVoucher, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"
            UPDATE Vouchers 
            SET IdCliente = @IdCliente, FechaCanje = GETDATE(), idArticulo = @IdArticulo 
            WHERE CodigoVoucher = @CodigoVoucher";

                datos.setearConsulta(consulta);
                datos.setearParametro("@CodigoVoucher", codVoucher);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@IdCliente", idCliente);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al canjear el voucher", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<Vouchers> Listar()
        {
            List<Vouchers> lista = new List<Vouchers>();
            AccesoDatos datos = new AccesoDatos();



            return lista;
        }
        public Vouchers BuscarPorCodigo(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            Vouchers voucher = new Vouchers();

            try
            {
                datos.setearConsulta("SELECT codigoVoucher, idCliente, fechaCanje, idArticulo FROM Vouchers WHERE codigoVoucher = @codigoVoucher");
                datos.setearParametro("@codigoVoucher", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    voucher.cliente = new Cliente();
                    voucher.articulo = new Articulo();

                    voucher.codigoVoucher = (string)datos.Lector["codigoVoucher"];

                    // Manejo seguro de valores NULL
                    voucher.cliente.ID = datos.Lector["idCliente"] != DBNull.Value ? (int)datos.Lector["idCliente"] : 0;
                    voucher.fechaCanje = datos.Lector["fechaCanje"] != DBNull.Value ? (DateTime)datos.Lector["fechaCanje"] : DateTime.MinValue;
                    voucher.articulo.Id = datos.Lector["idArticulo"] != DBNull.Value ? (int)datos.Lector["idArticulo"] : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el voucher", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return voucher;
        }

        /*public void agregar(Vouchers nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.ejecutar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }*/
    }
}
