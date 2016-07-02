using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using MercadoEnvio.Controller;
using MercadoEnvio.Domain;
using MercadoEnvio.Facturas;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class AltaCompraInmediata : Form
    {
        public List<Rubro> rubros;
        public List<Visibilidad2> visibilidades;
        public Sesion sesion_actual;

        public AltaCompraInmediata(Sesion sesion)
        {
            this.sesion_actual = sesion;
            InitializeComponent();
            

            cargar_rubros();
            cmbRubros.SelectedIndex = 0;

            cargar_visibilidad();

            cmbEstado.SelectedIndex = 0;

            actualizar_costo_total();
        }


        public void cargar_rubros(){

            string comando = "select rubro_id, descripcion_corta from dbme.rubro";
            DataTable dataroles = (new ConexionSQL()).cargarTablaSQL(comando);
            rubros = new List<Rubro>();

            //obtener los roles HABILITADOS de la data

            for (int i = 0; i <= (dataroles.Rows.Count - 1); i++)
            {
               // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                rubros.Add(new Rubro(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
            }

            for (int j = 0; j < rubros.Count ; j++)
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
            actualizar_costo_total();
        }

        public void actualizar_costo_total() {

            lblPrecio.Text = visibilidades[cmbVisibilidad.SelectedIndex].precio.ToString();
            lblPorcentaje.Text = visibilidades[cmbVisibilidad.SelectedIndex].porcentaje.ToString();
            lblcosto_envio.Text = visibilidades[cmbVisibilidad.SelectedIndex].costo_envio.ToString();

            double costo_total;
            double porcentaje = double.Parse(visibilidades[cmbVisibilidad.SelectedIndex].porcentaje.ToString());
            
            costo_total = visibilidades[cmbVisibilidad.SelectedIndex].precio;
            //costo_total = visibilidades[cmbVisibilidad.SelectedIndex].porcentaje;

            if (chkRealizaEnvio.Checked) {
                costo_total = costo_total + visibilidades[cmbVisibilidad.SelectedIndex].costo_envio;
            }

            //costo_total = costo_total + porcentaje * (double.Parse(txtPrecio.Text));
            //costo_total = costo_total + porcentaje * 
            txtCostoTotal.Text = costo_total.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AltaCompraInmediata_Load(object sender, EventArgs e)
        {
            dateFechaInicio.Value = DateTime.Parse(Program.fechaSistema()+1);
            dateFechaVencimiento.Value = DateTime.Parse(Program.fechaSistema()+1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmdGenerarCompra_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripción.Text;
            uint stock;
            uint precio;
            uint precio_decimal;
            uint rubro;
            int visibilidad_id;
            bool permitePreguntas = chkPermitePreguntas.Checked;
            string estado;


            DateTime fechaInicio;
            DateTime fechaVencimiento;
            bool realiza_envio = chkRealizaEnvio.Checked;
            double costo_total = Double.Parse(txtCostoTotal.Text);
            
            try
            {
                rubro = rubros[cmbRubros.SelectedIndex].rubro_id;
                visibilidad_id = cmbVisibilidad.SelectedIndex +1;
                estado = cmbEstado.GetItemText(cmbEstado.SelectedItem);
                fechaInicio = DateTime.Parse(dateFechaInicio.Text);
                fechaVencimiento = DateTime.Parse(dateFechaVencimiento.Text);
                stock = UInt32.Parse(txtStock.Text);
                precio = UInt32.Parse(txtPrecio.Text);
                precio_decimal = UInt32.Parse(txtPrecioDecimal.Text);
                costo_total = Double.Parse(txtCostoTotal.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ingrese solamente numeros en los formularios verdes, sin puntos", "Nueva Compra", MessageBoxButtons.OK);
                return;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nueva Compra", MessageBoxButtons.OK);
                return;
            }
            
            if (precio_decimal < 0 || precio_decimal > 100)
            {
                MessageBox.Show("La parte decimal del precio supera los limites", "Problema", MessageBoxButtons.OK);
                return;
            }

            if (cmbVisibilidad.GetItemText(cmbVisibilidad.SelectedItem) == "Gratis" && chkRealizaEnvio.Checked == true)
            {
                MessageBox.Show("Esta visibilidad no permite realizar envios", "Don't let your dreams be dreams", MessageBoxButtons.OK);
                return;
            }
           //validar fechas
            int ant1 = DateTime.Compare(fechaInicio, DateTime.Parse(Program.fechaSistema()));

            if (ant1 == -1)
            {
                MessageBox.Show("La fecha de inicio no puede ser anterior a la fecha del sistema", "Problema", MessageBoxButtons.OK);
                return;
            }

            int ant2 = DateTime.Compare(fechaInicio, fechaVencimiento);

            if (ant2 != -1)
            {
                MessageBox.Show("La fecha de inicio no puede ser despues de la de finalización ", "Problema", MessageBoxButtons.OK);
                return;
            }

            try
            {
                string comando = "EXECUTE DBME.crearCompraInmediata '" + descripcion + "'," + stock + ",'" + fechaInicio + "','" + fechaVencimiento + "'," + precio + "." + txtPrecioDecimal.Text + "," + rubro + "," + visibilidad_id + "," + sesion_actual.usuarioActual.usuario_id + "," + estado + "," + permitePreguntas + "," + realiza_envio + "," + costo_total;
                DataTable factura_id = new ConexionSQL().cargarTablaSQL(comando);
                

                if (estado == "ACTIVA") {
                    
                    DetalleFactura det = new DetalleFactura(Int32.Parse(factura_id.Rows[0][0].ToString()));
                    det.Show();
                }

                MessageBox.Show("Publicacion creada exitosamente", "Alta Compra Inmediata", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void cmbVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar_costo_total();
        }

        private void chkRealizaEnvio_CheckedChanged(object sender, EventArgs e)
        {
            actualizar_costo_total();
        }

        private void txtCostoTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
