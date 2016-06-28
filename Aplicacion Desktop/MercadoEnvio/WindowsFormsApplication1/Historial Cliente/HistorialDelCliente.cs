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
        public DataTable dt;
        public int pagina_actual;
        public int paginas_totales;

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
            //string query = "SELECT * FROM DBME.compra WHERE autor_id = "+idCliente;
                string query = "EXECUTE DBME.historialComprasYSubastas " + idCliente;
                dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se han encontrado resultados", "Problema" , MessageBoxButtons.OK);
                    dataGridView1.DataSource = null;
                    return;
                }
                //dataGridView1.DataSource = dt;

            }
            if (listBox1.GetItemText(listBox1.SelectedItem) == "Resumen De Estrellas")
            {

                //string dsd = textBox1.Text;
                string query = "EXECUTE DBME.cantidadDeCalificacionesDelUsuario " + idCliente;
                dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                    dataGridView1.DataSource = null;
                    return;
                }
                //dataGridView1.DataSource = dt;

            }
            if (listBox1.GetItemText(listBox1.SelectedItem) == "Operaciones Que Faltan Por Calificar") 
            {
                string query = "SELECT * from DBME.compra WHERE (autor_id = " + idCliente+" AND esta_calificada = 0)";
                dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                    dataGridView1.DataSource = null;
                    return;
                }
                //dataGridView1.DataSource = dt;

                
            }
            
            paginas_totales = dt.Rows.Count / 50;
            mostrar_pagina(1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pagina_actual == 1)
            {
                return;
            }
            pagina_actual -= 1;
            try
            {
                mostrar_pagina(pagina_actual);
            }
            catch
            {

            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (pagina_actual >= paginas_totales)
            {
                return;
            }
            pagina_actual += 1;
            try
            {
                mostrar_pagina(pagina_actual);
            }
            catch
            {

            }
        }

        private void mostrar_pagina(int numero_pagina)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }

            DataTable pagina = new DataTable();
            pagina = dt.Clone();

            int inicio = (numero_pagina - 1) * 50;

            if (dt.Rows.Count < 50)         // caso excepcional, solo si hay menos de 50 resultados
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pagina.ImportRow(dt.Rows[i]);
                }

                dataGridView1.DataSource = pagina;
                return;
            }

            for (int i = inicio; i < (inicio + 50); i++)
            {
                pagina.ImportRow(dt.Rows[i]);
            }

            dataGridView1.DataSource = pagina;
        }
    }
}
