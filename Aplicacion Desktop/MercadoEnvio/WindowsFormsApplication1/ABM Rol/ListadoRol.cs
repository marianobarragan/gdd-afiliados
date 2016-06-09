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

namespace MercadoEnvio.ABM_Rol
{
    public partial class ListadoRol : Form
    {
        public string tipo;

        public ListadoRol(string tipo)
        {
            InitializeComponent();
            radioButton1.Checked = true;
            this.tipo = tipo;
            btnEditar.Text = tipo;

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
                query = "SELECT nombre_rol FROM DBME.rol where es_rol_habilitado = 1 AND nombre_rol LIKE '%" + textBox2.Text + "%'";

            }
            else
            {
                query = "SELECT nombre_rol FROM DBME.rol where es_rol_habilitado = 1 AND nombre_rol =  '" + textBox1.Text + "'";
            }




            //(new ConexionSQL()).ejecutarComandoSQL(query);
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema" , MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;

            
        }

        private void ListadoRol_Load(object sender, EventArgs e)
        {

        }

        private void btnBorrarDatos_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;

            textBox1.Text = null;
            textBox2.Text = null;

           


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            string contenido = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            string query2 = "";
   
            if (tipo == "Modificar Rol")
            {
                MessageBox.Show(contenido, "Problema", MessageBoxButtons.OK);
                ModificarRol mod = new ModificarRol(contenido);
                mod.Show();
                this.Close();
                return;
            }
            else
            {
                DialogResult h = MessageBox.Show("¿Seguro que desea borrar?", "BORRAR ROL", MessageBoxButtons.YesNo);

                if (dataGridView1.CurrentRow != null && h == DialogResult.Yes)
                {
                    query2 = "UPDATE DBME.rol SET es_rol_habilitado = 0 WHERE nombre_rol = '" + contenido + "'";
                    (new ConexionSQL()).ejecutarComandoSQL(query2);
                }
                else
                {
                    return;
                }

            }
            
            string query;
            if (radioButton1.Checked)
            {
                query = "SELECT nombre_rol FROM DBME.rol where es_rol_habilitado = 1 AND nombre_rol LIKE '%" + textBox2.Text + "%'";

            }
            else
            {
                query = "SELECT nombre_rol FROM DBME.rol where es_rol_habilitado = 1 AND nombre_rol =  '" + textBox1.Text + "'";
            }

            (new ConexionSQL()).ejecutarComandoSQL(query2);
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
