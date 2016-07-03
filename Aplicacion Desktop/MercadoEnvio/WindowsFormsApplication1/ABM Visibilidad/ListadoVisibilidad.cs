using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Controller;

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
                query = "SELECT visibilidad_id, visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio,posee_baja_logica FROM DBME.visibilidad where visibilidad_descripcion LIKE '%" + textBox2.Text + "%'";

            }
            else
            {
                query = "SELECT visibilidad_id, visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio,posee_baja_logica FROM DBME.visibilidad where visibilidad_descripcion =  '" + textBox1.Text + "'";
            }

            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;
            /*
            for(int i = 0;i<dataGridView1.Columns.Count;i++)
            {
                dataGridView1.Columns[i].HeaderText = dataGridView1.Columns[i].HeaderText.Substring(12);
            }
            */
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (dataGridView1.Rows.Count == 0 || dataGridView1.CurrentRow == null) //si la tabla esta vacia, no apuntas a nadie
            {
                return;
            }
            
            //int id = Int32.Parse( dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            
            //MessageBox.Show(this.tipo, "BORRAR ROL", MessageBoxButtons.OK);
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un elemento antes", "Problema", MessageBoxButtons.OK);
                return;
            }
            int id2 = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            if (this.tipo == "Modificar visibilidad")
            {   //TODO terminar esto
                //MessageBox.Show(id.ToString(), "Problema", MessageBoxButtons.OK);
                
                ModificarVisibilidad mod = new ModificarVisibilidad(id2);
                mod.Show();
                this.Close();
                return;
            } else { 
                
                //TODO eliminar la visibilidad
                DialogResult h = MessageBox.Show("¿Seguro que desea dar de baja el rol seleccionado?", "ROL", MessageBoxButtons.YesNo);
                
                if (h == DialogResult.Yes)
                {
                    string query = "UPDATE DBME.visibilidad SET posee_baja_logica = 1 WHERE visibilidad_id = " + id2;
                    (new ConexionSQL()).ejecutarComandoSQL(query);
                }
                else
                {
                    return;
                }
                


                
            }


            button2_Click(null, null); //actualizar la tablita
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
