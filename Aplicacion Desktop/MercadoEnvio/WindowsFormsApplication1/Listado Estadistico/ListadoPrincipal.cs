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
using MercadoEnvio.Domain;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class ListadoPrincipal : Form
    {
        int indice;
        public List<Rubro> rubros;
        public string descripcionVisibilidad;
        public Boolean hayVisibilidad;

        public ListadoPrincipal(int index)
        {
            InitializeComponent();
            indice = index;
            textBox1.Text = indice.ToString();
            descripcionVisibilidad = "Ninguno";
            hayVisibilidad = false;
          

            if (indice == 1)
            {
                cmbRubros.Enabled = true;
                /*
                string comando = "SELECT descripcion_corta FROM DBME.rubro";
                DataTable dataCalificacion = (new ConexionSQL()).cargarTablaSQL(comando);

                foreach (DataRow row in dataCalificacion.Rows)
                {
                    cmbRubros.Items.Add(row[0].ToString());
                }
                cmbRubros.SelectedIndex = 0;*/
            }
            
            cargar_rubros();
            cmbRubros.SelectedIndex = 0;
          
            
        }


        public void cargar_rubros()
        {

            string comando = "select rubro_id, descripcion_corta from dbme.rubro";
            DataTable dataroles = (new ConexionSQL()).cargarTablaSQL(comando);
            rubros = new List<Rubro>();

            //obtener los roles HABILITADOS de la data

            for (int i = 0; i <= (dataroles.Rows.Count - 1); i++)
            {
                // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                rubros.Add(new Rubro(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
            }

            for (int j = 0; j < rubros.Count; j++)
            {
                // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                string desc = rubros[j].descripcion_corta;
                cmbRubros.Items.Add(desc);
            }

        }
        private void lstTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            uint rubro;
            int trimestre;
            uint anio;
                    
            if(hayVisibilidad == true)
            {
                descripcionVisibilidad = lstVisibilidad.SelectedItem.ToString();
            } 
                       
            try
            {
                anio = UInt32.Parse(txtAño.Text);
                trimestre = lstTrimestre.SelectedIndex + 1;
                rubro = rubros[cmbRubros.SelectedIndex].rubro_id;
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
              
            if (indice == 0) {
                //topVendedoresConMayorCantidadDeProductosNoVendidos();
                string comando2 = "SELECT * FROM DBME.topVendedoresConMayorCantidadDeProductosNoVendidos ('" + trimestre + "','" + anio + "','" + descripcionVisibilidad + "')";
                //string comando2 = "SELECT * FROM DBME.topVendedoresConMayorCantidadDeProductosNoVendidos (1,2015, 'Ninguno')";
                this.ejecutarComando(comando2);
            }
            if (indice == 1) {
                //topClientesConMayorCantidadDeProductosComprados();
                string comando3 = "SELECT * from DBME.topClientesConMayorCantidadDeProductosComprados ('" + trimestre + "','" + anio + "','" + rubro + "')";
                this.ejecutarComando(comando3);
                //string comando3 = "SELECT * from DBME.topClientesConMayorCantidadDeProductosComprados (1,2016,1)";
            }
            if (indice == 2)
            {
                //topVendedoresConMayorCantidadDeFacturas();
                string comando4 = "SELECT * FROM DBME.topVendedoresConMayorCantidadDeFacturas ('" + trimestre + "','" + anio + "')";
                this.ejecutarComando(comando4);
                //string comando4 = "SELECT * FROM DBME.topVendedoresConMayorCantidadDeFacturas (1,2015,'1')";

            }
            if (indice == 3) 
            {
                //topVendedoresConMayorMontoFacturado();
                string comando5 = "SELECT * FROM DBME.topVendedoresConMayorMontoFacturado ('" + trimestre + "','" + anio + "')";
                //string comando5 = "SELECT * FROM DBME.topVendedoresConMayorMontoFacturado (1,2015,'1')";
                this.ejecutarComando(comando5);
            }
            button1.Enabled = true; 
                           
             
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
            cmbRubros.SelectedIndex = 0;

            lstVisibilidad.Enabled = true;
            lstTrimestre.Enabled = true;
            btnBuscar.Enabled = true;


              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void lstVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            hayVisibilidad = true;
        }
       
         }
}
