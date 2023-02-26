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

namespace Practica1_BaseDeDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarProductos();
        }

        private void cargarProductos()
        {
            dgbTabla.AutoGenerateColumns=true;
            dgbTabla.DataSource = new DAOProducto().obtenerTodos();
            dgbTabla.Columns["Id"].Visible=false;
            dgbTabla.Columns["FechaAdquision"].Visible = false;
            dgbTabla.Columns["TipoAdquision"].Visible=false;
            dgbTabla.Columns["Observaciones"].Visible=true;
            dgbTabla.Columns["Descripcion"].Visible = true;
            dgbTabla.Columns["NombreCorto"].HeaderText = "Nombre Corto";
            dgbTabla.Columns["Areas_id"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.Guardado)
            {
                cargarProductos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgbTabla.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para modificar");
            }
            else
            {
                Producto producto = new DAOProducto().obtenerUno(int.Parse(dgbTabla.SelectedRows[0].Cells[0].Value.ToString()));
                Form2 form2 = new Form2(producto,true);
                form2.ShowDialog();
                if (form2.Guardado)
                {
                    cargarProductos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgbTabla.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para eliminar");
            }
            else
            {
                Producto producto = new DAOProducto().obtenerUno(int.Parse(dgbTabla.SelectedRows[0].Cells[0].Value.ToString()));
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionado?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.OK)
                {
                    if (new DAOProducto().eliminar(producto.Id))
                    {
                        MessageBox.Show("Producto eliminado con exito");
                        cargarProductos();
                    }
                }
            }
        }
    }
}
