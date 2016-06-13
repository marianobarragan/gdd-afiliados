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

namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    public partial class ListadoParaEmpresa : Form
    {
        public string discriminador;

        public ListadoParaEmpresa(string discriminador)
        {
            this.discriminador = discriminador;

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;

            txtCUIT.Text = null;
            txtRazonSocial.Text = null;
            txtMail.Text = null;
        }

        private void ListadoParaEmpresa_Load(object sender, EventArgs e)
        {
            btnAccion.Text = this.discriminador;

            chkCUIT.Checked = true;
            chkMail.Checked = true;
            chkRazonSocial.Checked = true;
            
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || dataGridView1.CurrentRow == null || dataGridView1.SelectedCells.Count == 0) //si la tabla esta vacia, no apuntas a nadie
            {
                MessageBox.Show("Seleccione una Fila", discriminador + " Cliente", MessageBoxButtons.OK);
                return;
            }

            uint id2 = UInt32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());

            if (discriminador == "Borrar")
            {
                DialogResult h = MessageBox.Show("¿Seguro que desea borrar la empresa seleccionada?", "BORRAR EMPRESA", MessageBoxButtons.YesNo);

                if (h == DialogResult.Yes)
                {
                    string q = "UPDATE FROM DBME.empresa SET habilitado = 0 WHERE cliente_id = " + id2; //baja logica del sistema
                    (new ConexionSQL()).ejecutarComandoSQL(q);
                }

                return;
            }

            if (discriminador == "Modificar")
            {
                ModificarDatosEmpresa mod_emp = new ModificarDatosEmpresa(id2);
                mod_emp.Show();
                this.Close();
            }
        }

        private void chkRazonSocial_CheckedChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Enabled = chkRazonSocial.Checked;
        }

        private void chkCUIT_CheckedChanged(object sender, EventArgs e)
        {
            txtCUIT.Enabled = chkCUIT.Checked;
        }

        private void chkMail_CheckedChanged(object sender, EventArgs e)
        {
            txtMail.Enabled = chkMail.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query;
            query = "SELECT e.empresa_id,e.razon_social,e.cuit,e.fecha_creacion,e.nombre_contacto, u.mail FROM DBME.empresa e JOIN DBME.usuario u ON (e.usuario_id = u.usuario_id) where e.habilitado = 1 ";

            if (chkRazonSocial.Checked) {
                query = query + " AND razon_social LIKE '%" + txtRazonSocial.Text + "%'";
            }

            if (chkMail.Checked)
            {
                query = query + " AND u.mail LIKE '%" + txtMail.Text + "%'";
            }

            if (chkCUIT.Checked)
            {
                query = query + " AND cuit = '" + txtCUIT.Text + "'";
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

        
    }
}
