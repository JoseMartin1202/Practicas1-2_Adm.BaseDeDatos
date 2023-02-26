using Backend;
using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Practica1_BaseDeDatos
{
    public partial class Form2 : Form
    {
        public bool Guardado;
        private bool actualizar;
        private int id;
        public Form2()
        {
            InitializeComponent();
            areas();
            limpiar();
            
        }

        public Form2(Producto p,bool actualizar):this() 
        {
            txtID.Text = p.Id.ToString();
            txtNombre.Text = p.NombreCorto;
            txtSerie.Text = p.Serie;
            txtColor.Text = p.Color;
            txtDescripcion.Text = p.Descripcion;
            txtObservaciones.Text = p.Observaciones;
            if (p.TipoAdquision.Equals("Fisica"))
            {
                cmbAdquisicion.SelectedIndex = 0;
            }
            else
            {
                cmbAdquisicion.SelectedIndex = 1;
            }
            cmbArea.SelectedIndex = int.Parse(p.Areas_id)-1;
            dtpFechaAdquisicion.Value = p.FechaAdquision;
            this.actualizar = actualizar;
            id=p.Id;
        }

        private void limpiar()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtSerie.Text = "";
            txtColor.Text = "";
            txtDescripcion.Text = "";
            txtObservaciones.Text = "";
            cmbAdquisicion.SelectedIndex=0;
            cmbArea.SelectedIndex = 0;
            dtpFechaAdquisicion.Value = DateTime.Now;
        }

        private bool verificar()
        {
            if((txtID.Text=="") || (txtNombre.Text=="") || (txtSerie.Text=="") || (txtColor.Text.Equals("")) || (txtDescripcion.Text.Equals("")) || (txtObservaciones.Text.Equals("")))
            {
                return false;
            }
            return true;
        }

        private void areas()
        {
            cmbArea.DataSource=new DAOArea().obtenerTodos();
            cmbArea.DisplayMember= "Nombre";
            cmbArea.ValueMember= "id";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta= MessageBox.Show("¿Está seguro que desea cancelar el registro del producto?", "Advertencia", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (respuesta == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(verificar())
            {
                Producto p = new Producto(int.Parse(txtID.Text), txtNombre.Text, txtDescripcion.Text, txtSerie.Text, txtColor.Text, dtpFechaAdquisicion.Value, cmbAdquisicion.Text, txtObservaciones.Text, cmbArea.SelectedValue.ToString());
                int accion;
                if (actualizar) {
                    accion = new DAOProducto().actualizar(p,id);
                }
                else
                {
                    accion = new DAOProducto().agregar(p);
                }
                
                if (accion>0)
                {
                    if (actualizar)
                    {
                        MessageBox.Show("Producto actualizado con exito");
                    }
                    else
                    {
                        MessageBox.Show("Producto almacenado con exito");
                    }
                    Guardado= true;
                    this.Close();
                }
                else 
                {
                    Guardado= false;
                }

            }
            else
            {
                MessageBox.Show("Verifica que todos los campos se encuentren llenados correctamente", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
