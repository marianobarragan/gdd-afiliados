using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Calificar
{
    public partial class ListadoDePublicacionesSinCalificar : Form
    {
        public int idCliente;

        public ListadoDePublicacionesSinCalificar(int usuario_id)
        {
            InitializeComponent();
            idCliente = usuario_id;
        }

        private void ListadoDePublicacionesSinCalificar_Load(object sender, EventArgs e)
        {

            btnUltimasCalificaciones_Click(null, null);
            btnBuscar_Click(null, null);

        }

        private void calificarOperacion_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 0 || dataGridView1.CurrentRow == null) //si la tabla esta vacia, no apuntas a nadie
            {
                MessageBox.Show("Debe seleccionar un elemento antes", "Problema", MessageBoxButtons.OK);
                return;
            }
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un elemento antes", "Problema", MessageBoxButtons.OK);
                return;
            }
            int id2 = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            Calificar.CalificarAlVendedor calificarVendedor = new Calificar.CalificarAlVendedor(id2, idCliente);
            calificarVendedor.Show();
            this.Close();
        }

        private void btnUltimasCalificaciones_Click(object sender, EventArgs e)
        {
            string query2 = "SELECT TOP 5 fecha, calificacion_id,descripcion, compra_id FROM DBME.calificacion WHERE (autor_id = " + idCliente + ") ORDER BY fecha DESC";
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query2));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No posee calificaciones", "Calificar al vendedor", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                //this.Close();
                return;
            }

            dataGridView2.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM DBME.compra WHERE (autor_id = " + idCliente + " AND esta_calificada = 0)";
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No posee calificaciones pendientes", "Calificar al vendedor", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                //this.Close();
                return;
            }
            dataGridView1.DataSource = dt;
        }
    }
}
