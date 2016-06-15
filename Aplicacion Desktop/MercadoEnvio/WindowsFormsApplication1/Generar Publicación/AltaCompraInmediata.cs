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
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmdGenerarCompra_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripción.Text;
            uint stock;
            double precio;
            uint rubro;
            uint visibilidad;
            bool permitePreguntas = chkPermitePreguntas.Checked;
            int estado;


            DateTime fechaInicio;
            DateTime fechaVencimiento;
            bool realiza_envio = chkRealizaEnvio.Checked;
            double costo_total = Double.Parse(txtCostoTotal.Text);
            
            try
            {
                rubro = rubros[cmbRubros.SelectedIndex].rubro_id;
                visibilidad = UInt32.Parse(visibilidades[cmbEstado.SelectedIndex].id.ToString());
                estado = cmbEstado.SelectedIndex;
                fechaInicio = DateTime.Parse(dateFechaInicio.Text);
                fechaVencimiento = DateTime.Parse(dateFechaVencimiento.Text);
                stock = UInt32.Parse(txtStock.Text);
                precio = Double.Parse(txtPrecio.Text);
                costo_total = Double.Parse(txtCostoTotal.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ingrese solamente numeros en los formularios verdes, sin puntos", "Nueva Empresa", MessageBoxButtons.OK);
                return;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nueva Empresa", MessageBoxButtons.OK);
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
                string preciostring = precio.ToString().Replace(",", ".");
      
                //CREATE PROCEDURE DBME.crearCompraInmediata (@descripcion NVARCHAR(255),@stock NUMERIC(18,0),@fecha_creacion DATETIME,@fecha_vencimiento DATETIME,@precio NUMERIC(18,2), @rubro_id INT, @visibilidad_id INT, @autor_id INT, @estado NVARCHAR(255),@permite_preguntas bit,@realiza_envio bit)
                string comando = "EXECUTE DBME.CompraInmediata '" + descripcion + "'," + stock + ",'" + fechaInicio + "','" + fechaVencimiento + "'," + preciostring + "," + rubro + "," + visibilidad + "," + sesion_actual.usuarioActual.usuario_id + ",'" + estado + "'," + permitePreguntas + "," + realiza_envio ;
                MessageBox.Show(comando, "A", MessageBoxButtons.OK);
                //(new ConexionSQL()).ejecutarComandoSQL(comando);

                MessageBox.Show("Compra creada exitosamente", "A", MessageBoxButtons.OK);
                this.Close();
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
    }
}
