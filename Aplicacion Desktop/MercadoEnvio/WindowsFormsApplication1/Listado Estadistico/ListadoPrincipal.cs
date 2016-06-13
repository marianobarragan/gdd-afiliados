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

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoPrincipal : Form
    {
        public int indice;
        public ListadoPrincipal(int index)
        {
            InitializeComponent();
            int indice = index;
            textBox1.Text = indice.ToString();
            //Sacar esto de aca arriba

            if (indice == 1)
            {
                comboBox1.Enabled = true;
                string comando = "SELECT descripcion_corta FROM DBME.rubro";
                DataTable dataCalificacion = (new ConexionSQL()).cargarTablaSQL(comando);

                foreach (DataRow row in dataCalificacion.Rows)
                {
                    comboBox1.Items.Add(row[0].ToString());
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        private void lstTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //int anio = Int32.Parse(txtAño.Text);
            //int trimestre = lstTrimestre.SelectedIndex + 1;
            //string visibilidad = lstVisibilidad.SelectedItem.ToString();
            
            /*
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
            */
            
              
              switch (indice)
                {
                case 0:
                    //topVendedoresConMayorCantidadDeProductosNoVendidos();
                    //string comando2 = "EXECUTE DBME.topVendedoresConMayorCantidadDeProductosNoVendidos '" + trimestre + "','" + anio + "'" + visibilidad + "";
                   string comando2 = "SELECT DBME.topVendedoresConMayorCantidadDeProductosNoVendidos (1,2015,'1')";
                   this.ejecutarComando(comando2);
                   
                break;
                case 1:
                    //topClientesConMayorCantidadDeProductosComprados();
                   //string comando3 = "EXECUTE DBME.topClientesConMayorCantidadDeProductosComprados '" + trimestre + "','" + anio + "'" + lstRubro.SelectedItem.ToString() + "";
                   string comando3 = "select * from DBME.topClientesConMayorCantidadDeProductosComprados (1,2015,'1')";
                   this.ejecutarComando(comando3);
                   
                   break;
                case 2:
                    //topVendedoresConMayorCantidadDeFacturas();
                   //string comando4 = "EXECUTE DBME.topVendedoresConMayorCantidadDeFacturas '" + trimestre + "','" + anio + "'";
                   string comando4 = "SELECT * FROM DBME.topVendedoresConMayorCantidadDeFacturas (1,2015,'1')";
                   this.ejecutarComando(comando4);
                   break;
                case 3:
                    //topVendedoresConMayorMontoFacturado();
                   //string comando5 = "EXECUTE DBME.topVendedoresConMayorMontoFacturado '" + trimestre + "','" + anio + "'";
                   string comando5 = "SELECT * FROM DBME.topVendedoresConMayorMontoFacturado (1,2015,'1')";
                   this.ejecutarComando(comando5);
                break;

                default:
             //      imprimir un error
                break;
            }           
             
             
        }
        public void ejecutarComando(string comandoAEjecutar)
        {
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(comandoAEjecutar));
            dataGridView1.DataSource = dt;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtAño_TextChanged(object sender, EventArgs e)
        {
            //char caracterIngresado = e; Tratando de chequear que sea numerico


            //if (caracterIngresado > '0' && caracterIngresado <'9')

            //else
            
            



            
           
        }

        private void ListadoPrincipal_Load(object sender, EventArgs e)
        {
            string comando = "SELECT visibilidad_descripcion FROM DBME.visibilidad";
            DataTable dataVisibilidad = (new ConexionSQL()).cargarTablaSQL(comando);

            foreach (DataRow row in dataVisibilidad.Rows)
            {
                lstVisibilidad.Items.Add(row[0].ToString());
            }
            comboBox1.SelectedIndex = 0;

            lstVisibilidad.Enabled = true;
            lstTrimestre.Enabled = true;
            btnBuscar.Enabled = true;


              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
       
         }
}
