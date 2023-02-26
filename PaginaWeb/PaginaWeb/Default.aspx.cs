using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Datos;
using System.Security.Cryptography.X509Certificates;

namespace PaginaWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    gvdLibros.DataSource = new DAOLibro().ObtenerTodos();
                    gvdLibros.DataBind();
                    gvdLibros.HeaderRow.Cells[2].Text = "Titulo";
                    gvdLibros.HeaderRow.Cells[4].Text = "Año de publicación";
                    gvdLibros.HeaderRow.Cells[5].Text = "Autor";
                    gvdLibros.HeaderRow.Cells[6].Text = "País";
                    gvdLibros.HeaderRow.Cells[7].Text = "Sinopsis";
                    gvdLibros.HeaderRow.Cells[8].Text = "Carrera";

                    gvdLibros.HeaderRow.Cells[0].Visible = false;
                    for (int i = 0; i < gvdLibros.Rows.Count; i++)
                        gvdLibros.Rows[i].Cells[0].Visible = false;

                    gvdLibros.HeaderRow.Cells[1].Visible = false;
                    for (int i = 0; i < gvdLibros.Rows.Count; i++)
                        gvdLibros.Rows[i].Cells[1].Visible = false;

                    gvdLibros.HeaderRow.Cells[3].Visible = false;
                    for (int i = 0; i < gvdLibros.Rows.Count; i++)
                        gvdLibros.Rows[i].Cells[3].Visible = false;

                    gvdLibros.HeaderRow.Cells[9].Visible = false;
                    for (int i = 0; i < gvdLibros.Rows.Count; i++)
                        gvdLibros.Rows[i].Cells[9].Visible = false;
                }
            }
        }
    }
}