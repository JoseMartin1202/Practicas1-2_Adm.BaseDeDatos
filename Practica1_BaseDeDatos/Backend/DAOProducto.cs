using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Datos
{
    public class DAOProducto
    {
        public List<Producto> obtenerTodos()
        {
            try
            {
                if (Conexion.Conectar())
                {
                    //Simulación de que el nombre de usuario es el firstname del usuario y  
                    //city es el password
                    MySqlCommand comando = new MySqlCommand(
                        @"select * from inventario i join Areas a on i.Areas_id=a.id;");

                
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.connection;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Producto> lista = new List<Producto>();
                    Producto producto = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas
                    foreach (DataRow fila in resultado.Rows)
                    {
                        producto = new Producto();
                        producto.Id = int.Parse(fila["id"].ToString());
                        producto.NombreCorto = fila["NombreCorto"].ToString();
                        producto.Serie = fila["Serie"].ToString();
                        producto.Color = fila["Color"].ToString();
                        producto.Areas_id = fila["Areas_id"].ToString();
                        producto.TipoAdquision = fila["TipoAdquision"].ToString();
                        producto.FechaAdquision = (DateTime)fila["FechaAdquision"];
                        producto.Descripcion = fila["Descripcion"].ToString();
                        producto.Observaciones = fila["Observaciones"].ToString();
                        lista.Add(producto);
                    }
                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del usuario");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Producto obtenerUno(int ID)
        {
            try
            {
                if (Conexion.Conectar())
                {
                    //Simulación de que el nombre de usuario es el firstname del usuario y  
                    //city es el password
                    MySqlCommand comando = new MySqlCommand(
                        @"Select*from inventario where id=@ID");

                    comando.Parameters.AddWithValue("@ID", ID);
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.connection;

                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Producto producto = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow fila = resultado.Rows[0];
                        producto= new Producto();
                        producto.Id = int.Parse(fila["id"].ToString());
                        producto.NombreCorto = fila["NombreCorto"].ToString();
                        producto.Serie = fila["Serie"].ToString();
                        producto.Color = fila["Color"].ToString();
                        producto.Areas_id = fila["Areas_id"].ToString();
                        producto.FechaAdquision = (DateTime)fila["FechaAdquision"];
                        producto.TipoAdquision = fila["TipoAdquision"].ToString();
                        producto.Descripcion= fila["Descripcion"].ToString();
                        producto.Observaciones=fila["Observaciones"].ToString();
                    }

                    return producto;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del usuario");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int agregar(Producto producto)
        {
            try
            {
                if (Conexion.Conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                       @"insert into inventario values(@ID,@NombreCorto,@Descripcion,@Serie,@Color,@FechaAdquisicion,@TipoAdquisicion,@Observaciones,@Area);");
                    comando.Parameters.AddWithValue("@ID", producto.Id);
                    comando.Parameters.AddWithValue("@NombreCorto", producto.NombreCorto);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Serie", producto.Serie);
                    comando.Parameters.AddWithValue("@Color", producto.Color);
                    comando.Parameters.AddWithValue("@FechaAdquisicion", producto.FechaAdquision);
                    comando.Parameters.AddWithValue("@TipoAdquisicion", producto.TipoAdquision);
                    comando.Parameters.AddWithValue("@Observaciones", producto.Observaciones);
                    comando.Parameters.AddWithValue("@Area", producto.Areas_id);
                   
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.connection;

                    int filasAgregadas = comando.ExecuteNonQuery();

                    return filasAgregadas;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo agregar el producto");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public int actualizar(Producto producto,int id)
        {
            try
            {
                if (Conexion.Conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                       @"update inventario set id=@ID,NombreCorto=@NombreCorto,Descripcion=@Descripcion,Serie=@Serie,Color=@Color,FechaAdquision=@FechaAdquision,TipoAdquision=@TipoAdquision,Observaciones=@Observaciones,Areas_id=@Area where id="+id+";");
                    comando.Parameters.AddWithValue("@ID", producto.Id);
                    comando.Parameters.AddWithValue("@NombreCorto", producto.NombreCorto);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Serie", producto.Serie);
                    comando.Parameters.AddWithValue("@Color", producto.Color);
                    comando.Parameters.AddWithValue("@FechaAdquision", producto.FechaAdquision);
                    comando.Parameters.AddWithValue("@TipoAdquision", producto.TipoAdquision);
                    comando.Parameters.AddWithValue("@Observaciones", producto.Observaciones);
                    comando.Parameters.AddWithValue("@Area", producto.Areas_id);

                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.connection;

                    int filasAgregadas = comando.ExecuteNonQuery();

                    return filasAgregadas;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number==1062)
                {
                    MessageBox.Show("Ya existe un producto con ese ID favor de escoger otro.");
                    return -1;
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto");
                    return 0;
                }
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public bool eliminar(int ID) {
            try
            {
                if (Conexion.Conectar())
                {
                    //Simulación de que el nombre de usuario es el firstname del usuario y  
                    //city es el password
                    MySqlCommand comando = new MySqlCommand(
                        @"delete from inventario where id=@ID");

                    comando.Parameters.AddWithValue("@ID", ID);
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.connection;

                    int filasBorradas = comando.ExecuteNonQuery();

                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo eliminar el producto");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        
    }
}
