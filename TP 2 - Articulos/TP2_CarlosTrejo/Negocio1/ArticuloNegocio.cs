using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio1;
using Negocio;
using Negocio1;
//using System.Data.SqlClient;




namespace TP2_CarlosTrejo
{
    public class ArticuloNegocio
    {
      /*  public List<Articulo> listar()

        {

            List<Articulo> listado = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=localhost\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Id, Nombre, Descripcion, IdMarca, IdCategoria, ImagenURL, Precio from Articulos";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    //aux.Nombre = (string)lector["nombre"];
                    if (!Convert.IsDBNull(lector["Id"]))
                        aux.ID = lector.GetInt32(0);

                    aux.Nombre = lector.GetString(1);
                    
                    if(!Convert.IsDBNull(lector["Descripcion"]))
                    aux.Descripcion = lector.GetString(2);

                    //if (!Convert.IsDBNull(lector["IdMarca"]))
                        //aux.IdMarca = lector.GetInt32(3);
                    
                    //aux.IDcategoria = lector.GetInt32(4);

                    aux.ImagenURL = lector.GetString(5);
                    //aux.Precio = (float)lector.GetDecimal(6);

                    
                    listado.Add(aux);


                }



                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }
        */
        public void agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
         

            try
            {

                conexion.ConnectionString = "data source=localhost\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into Articulos (Codigo, Nombre, Descripcion, IDMarca, IdCategoria, ImagenURL, Precio) Values (@Codigo, @Nombre, @Descripcion, @IDMarca, @IdCategoria, @ImagenURL, @Precio)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo.ToString());
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre.ToString());
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion.ToString());
                comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.IdMarca.ToString());
                comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.IdCategoria.ToString());
                comando.Parameters.AddWithValue("@ImagenURL", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);


                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {


                conexion.Close();
            }
        }


        public List <Articulo> listar2()
        {
            List<Articulo> lista = new List<Articulo>();
            Articulo aux;
           
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQery("Select Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenURL, Precio from Articulos");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Articulo();
                   
                    //aux.Nombre = (string)lector["nombre"];

                    if (!Convert.IsDBNull(datos.lector["Codigo"]))
                        aux.Codigo = datos.lector.GetString(0);

                    aux.Nombre = datos.lector.GetString(1);

                    if (!Convert.IsDBNull(datos.lector["Descripcion"]))
                        aux.Descripcion = datos.lector.GetString(2);
                    
                    
                    aux.Marca = new Marca();
                    if (!Convert.IsDBNull(datos.lector["IdMarca"]))
                    aux.Marca.IdMarca = datos.lector.GetInt32(3);


                    aux.Categoria = new Categoria();
                    if (!Convert.IsDBNull(datos.lector["IdCategoria"]))
                    aux.Categoria.IdCategoria = datos.lector.GetInt32(4);

                    aux.ImagenURL = datos.lector.GetString(5);

                    if (!Convert.IsDBNull(datos.lector["Precio"]))
                    aux.Precio = (double)datos.lector.GetDecimal(6);


                    lista.Add(aux);

                }
                

                return lista;
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
    }
}

