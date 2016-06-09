using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Visibilidad
{
    public partial class ListadoVisibilidad : Form
    {
        public string tipo;

        public ListadoVisibilidad(string tipo)
        {
            InitializeComponent();
            radioButton1.Checked = true;
            this.tipo = tipo;
            btnEditar.Text = tipo;
        }

        private void ListadoVisibilidad_Load(object sender, EventArgs e)
        {

        }

        private void btnBorrarDatos_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;

            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            if (radioButton1.Checked)
            {
                query = "SELECT visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio FROM DBME.visibilidad where visibilidad_descripcion LIKE '%" + textBox2.Text + "%'";

            }
            else
            {
                query = "SELECT visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio FROM DBME.visibilidad where visibilidad_descripcion =  '" + textBox1.Text + "'";
            }

            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (dataGridView1.Rows.Count == 0) //si la tabla esta vacia, no apuntas a nadie
            {
                return;
            }

            string contenido = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            if (tipo == "Modificar visibilidad")
            {   //TODO terminar esto
                //MessageBox.Show(contenido, "Problema", MessageBoxButtons.OK);
                ModificarVisibilidad mod = new ModificarVisibilidad(contenido);
                mod.Show();
                this.Close();
                return;
            }
            else { 
                
                //TODO eliminar la visibilidad
            }



            button2_Click(null, null);
        }
    }
}
