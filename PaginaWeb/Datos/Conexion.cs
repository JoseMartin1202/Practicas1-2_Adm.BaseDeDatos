
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection conexion;
        static string usuario = "Usuario3";
        static string password = "Mar-max1";
        static string bd = "PaginaWeb";
        static string servidor = "20.106.132.173";

        public static bool conectar()
        {
            try
            {
                //conexion = new SqlConnection("Database=" + bd + ";Data Source=" + servidor +
                //    ";Port=" + puerto + ";User Id=" + usuario + ";Password=" + password);
                conexion = new SqlConnection("Data Source = " + servidor+";Database=" + bd +
                    ";User ID="+ usuario+";Password=" + password);
                conexion.Open();
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
                conexion.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
