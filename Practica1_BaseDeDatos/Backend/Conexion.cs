using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        public static MySqlConnection connection;
        static string usuario = "root";
        static string password = "mar-max1"; 
        static string bd = "tienda"; 
        static string servidor = "localhost";
        static string puerto = "3306";

        public static bool Conectar()
        {
            // Establecer la cadena de conexión
        string connectionString = "Data Source="+servidor+";Initial Catalog="+bd+";User ID="+usuario+";Password="+password+";";

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();// Abrir la conexión
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void desconectar()
        {
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
