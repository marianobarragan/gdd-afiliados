using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoPrincipal : Form
    {
        public ListadoPrincipal(int index)
        {
            InitializeComponent();
            int indice = index;
            textBox1.Text = indice.ToString();
            //Sacar esto de aca arriba
        }

        private void lstTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dsd = textBox1.Text;
            string query = "SELECT * FROM DBME.domicilio ";
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema" , MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            dataGridView1.DataSource = dt;

            /*
             * 
             * switch (indice)
                {
                case 0:
                    topVendedoresConMayorCantidadDeProductosNoVendidos();
                break;
                case 1:
                    topClientesConMayorCantidadDeProductosComprados();
                break;
                case 2:
                    topVendedoresConMayorCantidadDeFacturas();
                break;
                case 3:
                    topVendedoresConMayorMontoFacturado();
                break;

                default:
             *      imprimir un error
                break;
            }           
             * /
                
        }
       
         }
}
