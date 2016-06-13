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
            string query = "SELECT * FROM DBME.compra WHERE (autor_id = " + idCliente+" AND esta_calificada = 0)" ;
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;

        }

        private void calificarOperacion_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 0 || dataGridView1.CurrentRow == null) //si la tabla esta vacia, no apuntas a nadie
            {
                return;
            }
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un elemento antes", "Problema", MessageBoxButtons.OK);
                return;
            }
            int id2 = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            Calificar.CalificarAlVendedor calificarVendedor = new Calificar.CalificarAlVendedor(id2, idCliente);
        }
    }
}
