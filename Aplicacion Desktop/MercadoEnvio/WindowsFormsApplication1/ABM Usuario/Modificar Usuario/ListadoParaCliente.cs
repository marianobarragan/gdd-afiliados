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
    public partial class ListadoParaCliente : Form
    {
        public string discriminador;

        public ListadoParaCliente(string discriminador)
        {
            this.discriminador = discriminador;
            
            InitializeComponent();
        }

        private void ListadoParaCliente_Load(object sender, EventArgs e)
        {
            btnAccion.Text = this.discriminador;

            chkApellido.Checked = true;
            chkDNI.Checked = true;
            chkNombre.Checked = true;
            chkEmail.Checked = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;

            txtNombre.Text = null;
            txtApellido.Text = null;
            txtEmail.Text = null;
            txtDNI.Text = null;
        }

        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = chkNombre.Checked;
        }

        private void chkApellido_CheckedChanged(object sender, EventArgs e)
        {
            txtApellido.Enabled = chkApellido.Checked;
        }

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        private void chkDNI_CheckedChanged(object sender, EventArgs e)
        {
            txtDNI.Enabled = chkDNI.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string query;
            query = "SELECT c.cliente_id,c.apellido,c.nombre,c.numero_documento,c.fecha_nacimiento, u.mail FROM DBME.cliente c JOIN DBME.usuario u ON (c.usuario_id = u.usuario_id) where cliente_id IS NOT NULL ";

            if (chkNombre.Checked) { 
                query = query + " AND nombre LIKE '%" + txtNombre.Text + "%'";
            }
            if (chkApellido.Checked) {
                query = query + " AND apellido LIKE '%" + txtApellido.Text + "%'";
            }
            if (chkEmail.Checked) {
                query = query + " AND u.mail LIKE '%" + txtEmail.Text + "%'";
                //query = query + " AND usuario_id IN (SELECT usuario_id FROM DBME.usuario WHERE mail LIKE '%" + txtEmail.Text + "%')";
            }
            if (chkDNI.Checked) {
                uint DNI;
                try {
                    DNI = uint.Parse(txtDNI.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Ingrese solamente numeros en los formularios verdes, sin puntos", "Nuevo Cliente", MessageBoxButtons.OK);
                    return;
                }
                catch (System.OverflowException)
                {
                    MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nuevo Cliente", MessageBoxButtons.OK);
                    return;
                }

                query = query + " AND tipo_documento = 'DNI' AND numero_documento = '" + txtDNI.Text + "'";
            }
            //MessageBox.Show(query,"A",MessageBoxButtons.OK);
            
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;
            
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || dataGridView1.CurrentRow == null || dataGridView1.SelectedCells.Count == 0) //si la tabla esta vacia, no apuntas a nadie
            {
                MessageBox.Show("Seleccione una Fila", discriminador + " Cliente", MessageBoxButtons.OK);
                return;
            }

            uint id2 = UInt32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());

            if (discriminador == "Borrar") {
                DialogResult h = MessageBox.Show("¿Seguro que desea borrar el rol seleccionado?", "BORRAR ROL", MessageBoxButtons.YesNo);

                if (h == DialogResult.Yes)
                {
                    string query = "UPDATE FROM DBME.cliente SET habilitado = 0 WHERE cliente_id = " + id2;
                    (new ConexionSQL()).ejecutarComandoSQL(query);
                }

                return;
            }

            if (discriminador == "Modificar")
            {
                ModificarDatosCliente mod_cli = new ModificarDatosCliente(id2);
                mod_cli.Show();
                this.Close();
            }

        }
    }
}
