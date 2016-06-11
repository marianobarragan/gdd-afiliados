using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Historial_Cliente
{
    public partial class HistorialDelCliente : Form
    {
        public int idCliente;
        public HistorialDelCliente(int ClienteID)
        {
            InitializeComponent();
            idCliente = ClienteID;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.GetItemText(listBox1.SelectedItem) == "Historial Del Cliente")
            {
              
            //string dsd = textBox1.Text;
            string query = "SELECT * FROM DBME.compra WHERE autor_id = "+idCliente;
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema" , MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;

            }
            if (listBox1.GetItemText(listBox1.SelectedItem) == "Resumen De Estrellas")
            {

                //string dsd = textBox1.Text;
                string query = "EXECUTE DBME.cantidadDeCalificacionesDelUsuario " + idCliente;
                DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = dt;

            }
            if (listBox1.GetItemText(listBox1.SelectedItem) == "Operaciones Que Faltan Por Calificar") 
            {
                string query = "SELECT * from DBME.compra WHERE (autor_id = " + idCliente+" AND esta_calificada = 0)";
                DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = dt;

            }

        }
        
    }
}
