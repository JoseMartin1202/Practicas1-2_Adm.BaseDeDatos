using Datos;
using Modelos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class DAOArea
    {
        public List<Area> obtenerTodos()
        {
            try
            {
                if (Conexion.Conectar())
                {
                    MySqlCommand comando = new MySqlCommand(@"select id,nombre from Areas;");
           

                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.connection;
                    //Este objeto nos ayudará a llenar una tabla con el resultado de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Area> lista = new List<Area>();
                    Area area = null;
                    //Cuando la consulta si obtuvo resultados la tabla trae filas
                    foreach (DataRow fila in resultado.Rows)
                    {
                        area = new Area();
                        area.Id = int.Parse(fila["id"].ToString());
                        area.Nombre = fila["nombre"].ToString();
                        
                        lista.Add(area);
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
                throw new Exception("No se pudo agregar el producto");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
