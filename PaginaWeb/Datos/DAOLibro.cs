using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Datos
{
    public class DAOLibro
    {
        /// <summary>
        /// Metodo que se encarga mostrar todos los registros de libros de la base de datos
        /// </summary>
        /// <returns>Retorna una lista de Libros</returns>
        /// <exception cref="Exception">se genera si la operacion falla</exception>
        public List<Libro> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    SqlCommand comando = new SqlCommand(
                        @"select Titulo,Autores, Sinopsis, yearpublicacion,pais,carrera 
                            from Libro order by Titulo desc, autores;");
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;

                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    List<Libro> lista = new List<Libro>();
                    Libro objLibro = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objLibro = new Libro();
                        objLibro.Titulo = fila["Titulo"].ToString();
                        objLibro.Autor = fila["Autores"].ToString();
                        objLibro.Sinopsis = fila["sinopsis"].ToString();
                        objLibro.Year = Convert.ToInt32(fila["yearpublicacion"].ToString());
                        objLibro.Pais = fila["pais"].ToString();
                        objLibro.Carrera = fila["carrera"].ToString();
                        lista.Add(objLibro);
                    }
                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener la información de los usuarios");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que se encarga de insertar un Objeto Libro en la tabla Libro en la base de datos
        /// </summary>
        /// <param name="Libro">Recibe un objeto de tipo Libro</param>
        /// <returns>retorna un entero que representa el numero de filas afectadas</returns>
        /// <exception cref="Exception">se genera si la operacion falla</exception>
        public int agregar(Libro Libro)
        {
            try
            {
                if (Conexion.conectar())
                {
                    SqlCommand comando = new SqlCommand(
                       @"insert into Libro(ISBN,Titulo,Noedicion,Yearpublicacion,Autores,Pais,Sinopsis,Carrera,Materia) values
                        (@ISBN,@Titulo,@edicion,@Yearpublicacion,
                        @Autor,@Pais, @Sinopsis,@Carrera,@Materia);");
                    comando.Parameters.AddWithValue("ISBN", Libro.ISBN);
                    comando.Parameters.AddWithValue("Titulo", Libro.Titulo);
                    comando.Parameters.AddWithValue("edicion", Libro.NoEdicion);
                    comando.Parameters.AddWithValue("Yearpublicacion", Libro.Year);
                    comando.Parameters.AddWithValue("Autor", Libro.Autor);
                    comando.Parameters.AddWithValue("Pais", Libro.Pais);
                    comando.Parameters.AddWithValue("Sinopsis", Libro.Sinopsis);
                    comando.Parameters.AddWithValue("Carrera", Libro.Carrera);
                    comando.Parameters.AddWithValue("Materia", Libro.Mareria);
                    //Se establece la conexión con la que se ejecutará la consulta
                    comando.Connection = Conexion.conexion;
                    int filasAgregadas = comando.ExecuteNonQuery();

                    return filasAgregadas;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 1062)// duplicidad del nombre de usuario
                {
                    throw new Exception("El libro ya se encuentra registrado");
                }
                throw new Exception("No se pudo agregar el Libro");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
