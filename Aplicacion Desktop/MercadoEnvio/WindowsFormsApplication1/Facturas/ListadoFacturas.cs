using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Facturas
{
    public partial class ListadoFacturas : Form
    {

        public int usuario_id;

        public ListadoFacturas(int usuario_id)
        {
            this.usuario_id = usuario_id;
            InitializeComponent();
        }

        private void ListadoFacturas_Load(object sender, EventArgs e)
        {
            string query;
            query = "SELECT * FROM DBME.factura";
            /*
            if (chkRazonSocial.Checked)
            {
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
            */
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
            int id2 = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());

            Facturas.DetalleFactura detalle = new DetalleFactura(id2);
            detalle.Show();

        }
    }
}
