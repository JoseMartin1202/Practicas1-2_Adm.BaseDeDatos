using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PaginaWeb
{
    public partial class AgregarLibro : System.Web.UI.Page
    {
        public bool validar()
        {
            int contador=0;
            if(txtISBN.Text != "")
            {
                contador++;
            }
            else
            {
                txtISBN.BackColor = Color.LightCoral;
            }
            if (txtTitulo.Text != "")
            {
                contador++;
            }
            else
            {
                txtTitulo.BackColor = Color.LightCoral;
            }
            if (txtAutor.Text != "")
            {
                contador++;
            }
            else
            {
                txtAutor.BackColor = Color.LightCoral;
            }
            if (txtNoedicion.Text != "")
            {
                contador++;
            }
            else
            {
                txtNoedicion.BackColor = Color.LightCoral;
            }
            if (txtCarrera.Text != "")
            {
                contador++;
            }
            else
            {
                txtCarrera.BackColor = Color.LightCoral;
            }
            if (txtPais.Text != "")
            {
                contador++;
            }
            else
            {
                txtPais.BackColor = Color.LightCoral;
            }
            if (txtYearpublicacion.Text != "")
            {
                contador++;
            }
            else
            {
                txtYearpublicacion.BackColor = Color.LightCoral;
            }
            if (txtMateria.Text != "")
            {
                contador++;
            }
            else
            {
                txtMateria.BackColor = Color.LightCoral;
            }
            if (txtSinpsis.Text !="")
            {
                contador++;
            }
            else
            {
                txtSinpsis.BackColor = Color.LightCoral;
            }
            if (contador == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Libro libro = new Libro();
                libro.ISBN = txtISBN.Text;
                libro.Titulo = txtTitulo.Text;
                libro.Autor = txtAutor.Text;
                libro.NoEdicion = Convert.ToInt32(txtNoedicion.Text);
                libro.Year = Convert.ToInt32(txtYearpublicacion.Text);
                libro.Pais = txtPais.Text;
                libro.Carrera = txtCarrera.Text;
                libro.Mareria = txtMateria.Text;
                libro.Sinopsis = txtSinpsis.Text;
                if (new DAOLibro().agregar(libro)!=0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   "alert(' Libro registrado correctamente');window.location ='Default.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   "alert('No se pudo agregar el Libro');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert",
               "alert('Faltan campos por llenar');", true);
            }
        }

        protected void txtTitulo_TextChanged(object sender, EventArgs e)
        {
            txtTitulo.BackColor = Color.White;
        }

        protected void txtISBN_TextChanged(object sender, EventArgs e)
        {
            txtISBN.BackColor = Color.White;
        }

        protected void txtAutor_TextChanged(object sender, EventArgs e)
        {
            txtAutor.BackColor = Color.White;
        }

        protected void txtNoedicion_TextChanged(object sender, EventArgs e)
        {
            txtNoedicion.BackColor = Color.White;
        }

        protected void txtYearpublicacion_TextChanged(object sender, EventArgs e)
        {
            txtYearpublicacion.BackColor = Color.White;
        }

        protected void txtPais_TextChanged(object sender, EventArgs e)
        {
            txtPais.BackColor = Color.White;
        }

        protected void txtCarrera_TextChanged(object sender, EventArgs e)
        {
            txtCarrera.BackColor = Color.White;
        }

        protected void txtMateria_TextChanged(object sender, EventArgs e)
        {
            txtMateria.BackColor = Color.White;
        }

        protected void txtSinpsis_TextChanged(object sender, EventArgs e)
        {
            txtSinpsis.BackColor = Color.White;
        }
    }
}