using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;
using System.Text.RegularExpressions;


namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> ArticuloLista()
        {
            List<Articulo> Lista = new List<Articulo>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {

                Datos.setearConsulta("SELECT A.Id as idArti, " +
                                    "idMarca, " +
                                    "codigo, " +
                                    "nombre, " +
                                    "precio, " +
                                    "A.Descripcion, " +
                                    "M.Id as idMarcaObj, " +
                                    "M.Descripcion as marcaDescripcion, " +
                                    "C.Id as idCategoriaObj, " +
                                    "C.Descripcion as categoriaDescripcion, " +
                                    "A.idCategoria " +
                                    "FROM ARTICULOS A, MARCAS M, CATEGORIAS C " +
                                    "WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria");
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)Datos.Lector["idArti"];
                    aux.Codigo = (string)Datos.Lector["codigo"];
                    aux.Nombre = (string)Datos.Lector["nombre"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.IdMarca = (int)Datos.Lector["idMarca"];
                    aux.IdCategoria = (int)Datos.Lector["idCategoria"];
                    aux.Precio = (decimal)Datos.Lector["precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)Datos.Lector["idMarcaObj"];
                    aux.Marca.Descripcion = (string)Datos.Lector["marcaDescripcion"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)Datos.Lector["idCategoriaObj"];
                    aux.Categoria.Descripcion = (string)Datos.Lector["categoriaDescripcion"];

                    aux.RutasImagenes = ObtenerImagenesPorArticulo(aux.Id);

                    Lista.Add(aux);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
        public List<Articulo> ListarArtConSp()
        {
            List<Articulo> Lista = new List<Articulo>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {

                Datos.setearConsulta("SELECT A.Id as idArti, " +
                                    "idMarca, " +
                                    "codigo, " +
                                    "nombre, " +
                                    "precio, " +
                                    "A.Descripcion, " +
                                    "M.Id as idMarcaObj, " +
                                    "M.Descripcion as marcaDescripcion, " +
                                    "C.Id as idCategoriaObj, " +
                                    "C.Descripcion as categoriaDescripcion, " +
                                    "A.idCategoria " +
                                    "FROM ARTICULOS A, MARCAS M, CATEGORIAS C " +
                                    "WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria");
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)Datos.Lector["idArti"];
                    aux.Codigo = (string)Datos.Lector["codigo"];
                    aux.Nombre = (string)Datos.Lector["nombre"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.IdMarca = (int)Datos.Lector["idMarca"];
                    aux.IdCategoria = (int)Datos.Lector["idCategoria"];
                    aux.Precio = (decimal)Datos.Lector["precio"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)Datos.Lector["idMarcaObj"];
                    aux.Marca.Descripcion = (string)Datos.Lector["marcaDescripcion"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)Datos.Lector["idCategoriaObj"];
                    aux.Categoria.Descripcion = (string)Datos.Lector["categoriaDescripcion"];

                    aux.RutasImagenes = ObtenerImagenesPorArticulo(aux.Id);

                    Lista.Add(aux);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
        private List<string> ObtenerImagenesPorArticulo(int idArticulo)
        {
            List<string> imagenes = new List<string>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.setearConsulta("SELECT ImagenUrl FROM Imagenes WHERE IdArticulo = @IdArticulo");
                Datos.setearParametro("@IdArticulo", idArticulo);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    imagenes.Add((string)Datos.Lector["ImagenUrl"]);
                }

                return imagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }


        public void agregar(Articulo nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {

                Datos.setearConsulta("INSERT INTO ARTICULOS (codigo, nombre, descripcion,idMarca,idCategoria, precio) VALUES ('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "',@idMarca, @idCategoria," + nuevo.Precio + ")");
                Datos.setearParametro("@idMarca", nuevo.Marca.Id);
                Datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                Datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
        public void modificar(Articulo modificar)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.setearConsulta("UPDATE ARTICULOS SET " +
                   "codigo = @codigo, " +
                   "nombre = @nombre, " +
                   "descripcion = @descripcion, " +
                   "idMarca = @idMarca, " +
                   "idCategoria = @idCategoria, " +
                   "precio = @precio " +
                   "WHERE Id = @id");


                Datos.setearParametro("@id", modificar.Id);
                Datos.setearParametro("@codigo", modificar.Codigo);
                Datos.setearParametro("@nombre", modificar.Nombre);
                Datos.setearParametro("@descripcion", modificar.Descripcion);
                Datos.setearParametro("@idMarca", modificar.Marca.Id);
                Datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                Datos.setearParametro("@precio", modificar.Precio);

                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @id");
                Datos.setearParametro("@id", id);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

