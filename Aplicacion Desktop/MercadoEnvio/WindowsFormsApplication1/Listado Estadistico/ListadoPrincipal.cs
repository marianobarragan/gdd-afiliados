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
        //public string descripcionVisibilidad;
        //public Boolean hayVisibilidad;
        public List<Visibilidad2> visibilidades;

        public ListadoPrincipal(int index)
        {
            InitializeComponent();
            indice = index;
            
            cargar_rubros();
            cmbRubros.SelectedIndex = 0;

            cargar_visibilidad();
            lstTrimestre.SelectedIndex = 0;
          
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
            cmbRubros.SelectedIndex = 0;
        }

        public void cargar_visibilidad()
        {

            string comando = "select visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje, visibilidad_costo_envio,visibilidad_id from dbme.visibilidad";
            DataTable dataVisibilidades = (new ConexionSQL()).cargarTablaSQL(comando);

            //obtener los roles HABILITADOS de la data
            visibilidades = new List<Visibilidad2>();
            for (int i = 0; i <= (dataVisibilidades.Rows.Count - 1); i++)
            {
                visibilidades.Add(new Visibilidad2(dataVisibilidades.Rows[i][0].ToString(), dataVisibilidades.Rows[i][1].ToString(), dataVisibilidades.Rows[i][2].ToString(), dataVisibilidades.Rows[i][3].ToString(), dataVisibilidades.Rows[i][4].ToString()));
                cmbVisibilidad.Items.Add(dataVisibilidades.Rows[i][0].ToString());
            }

            cmbVisibilidad.SelectedIndex = 0;
            
        }

        private void lstTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            uint rubro;
            int trimestre;
            uint anio;
            string visibilidad_descripcion;
                       
            try
            {
                anio = UInt32.Parse(txtAño.Text);
                trimestre = lstTrimestre.SelectedIndex + 1;
                rubro = rubros[cmbRubros.SelectedIndex].rubro_id;
                visibilidad_descripcion = cmbVisibilidad.GetItemText(cmbVisibilidad.SelectedItem);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ingrese solamente numeros en los formularios verdes, sin puntos", "Listado Estadistico", MessageBoxButtons.OK);
                return;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Listado Estadistico", MessageBoxButtons.OK);
                return;
            }      
              
            if (indice == 0) {
                //topVendedoresConMayorCantidadDeProductosNoVendidos();
                string comando2 = "SELECT * FROM DBME.topVendedoresConMayorCantidadDeProductosNoVendidos ('" + trimestre + "','" + anio + "','" + visibilidad_descripcion + "')";
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
            

        }

        private void ListadoPrincipal_Load(object sender, EventArgs e)
        {
            
            
            if (indice == 0)
            {
                //topVendedoresConMayorCantidadDeProductosNoVendidos();
                this.Text = this.Text + " - Vendedores con mayor cantidad de productos no vendidos";
                
            }
            if (indice == 1)
            {
                //topClientesConMayorCantidadDeProductosComprados();
                this.Text = this.Text + " - Clientes con mayor cantidad de productos comprados";
                cmbRubros.Enabled = true;

                label4.Visible = false;
                cmbVisibilidad.Visible = false;
            }
            if (indice == 2)
            {
                //topVendedoresConMayorCantidadDeFacturas();
                this.Text = this.Text + " - Vendedores con mayor cantidad de facturas";

                label4.Visible = false;
                cmbVisibilidad.Visible = false;
            }
            if (indice == 3)
            {
                //topVendedoresConMayorMontoFacturado();
                this.Text = this.Text + " - Vendedores con mayor monto facturado";

                label4.Visible = false;
                cmbVisibilidad.Visible = false;
            }

            
            lstTrimestre.Enabled = true;
            btnBuscar.Enabled = true;


              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtAño.Text = "";
            lstTrimestre.SelectedIndex = 0;
            cmbRubros.SelectedIndex = 0;
            cmbVisibilidad.SelectedIndex = 0;
        }

        private void lstVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
    }
}
