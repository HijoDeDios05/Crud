using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Conexion sql = new Conexion();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgwMostrar.DataSource = sql.MostrarDatos();

        }

        private void vgw(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgwMostrar.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(fila.Cells[0].Value);
            txtNombre.Text = Convert.ToString(fila.Cells[1].Value);
            txtPrecio.Text = Convert.ToString(fila.Cells[2].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtID.Text = dgwMostrar.Rows.Count.ToString();
            if (sql.Insertar(txtID.Text, txtNombre.Text, txtPrecio.Text))
            {
                MessageBox.Show("Datos insertados");
                dgwMostrar.DataSource = sql.MostrarDatos();
            }
            else MessageBox.Show("No se han podido insertar los datos");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sql.Eliminar(txtID.Text))
            {
                MessageBox.Show("Datos eliminados");
                dgwMostrar.DataSource = sql.MostrarDatos();
            }
            else MessageBox.Show("No se han podido eliminar los datos");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (sql.Actualizar(txtID.Text, txtNombre.Text, txtPrecio.Text))
            {
                MessageBox.Show("Datos actualizados");
                dgwMostrar.DataSource = sql.MostrarDatos();
            }
            else MessageBox.Show("No se han podido actualizar los datos");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "") dgwMostrar.DataSource = sql.Buscar(txtBuscar.Text);
            else dgwMostrar.DataSource = sql.MostrarDatos();
        }
    }
}
