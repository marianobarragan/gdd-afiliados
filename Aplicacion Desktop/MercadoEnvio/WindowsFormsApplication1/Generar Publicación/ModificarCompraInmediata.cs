using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MercadoEnvio.Domain;
using MercadoEnvio.Controller;
using MercadoEnvio.Facturas;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class ModificarCompraInmediata : Form
    {
        public List<Rubro> rubros;
        public List<Visibilidad2> visibilidades;
        public Sesion sesion_actual;
        public int id_publicacion;
        public string estadoInicial;

        public ModificarCompraInmediata(int id, Sesion sesion)
        {
            InitializeComponent();
            id_publicacion = id;
            sesion_actual = sesion;

            cargar_rubros();
            
            
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

        public void cargar_visibilidad(int visibilidad)
        {
            string comando;

            if (estadoInicial == "ACTIVA" || estadoInicial == "PAUSADA")
            {
                comando = "select visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje, visibilidad_costo_envio,visibilidad_id from dbme.visibilidad where visibilidad_id =" + visibilidad;
            }
            else {
                comando = "select visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje, visibilidad_costo_envio,visibilidad_id from dbme.visibilidad where posee_baja_logica = 0";
            }

            
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

        public void actualizar_costo_total()
        {

            lblPrecio.Text = visibilidades[cmbVisibilidad.SelectedIndex].precio.ToString();
            lblPorcentaje.Text = visibilidades[cmbVisibilidad.SelectedIndex].porcentaje.ToString();
            lblcosto_envio.Text = visibilidades[cmbVisibilidad.SelectedIndex].costo_envio.ToString();

            double costo_total;
            double porcentaje = double.Parse(visibilidades[cmbVisibilidad.SelectedIndex].porcentaje.ToString());

            costo_total = visibilidades[cmbVisibilidad.SelectedIndex].precio;
            //costo_total = visibilidades[cmbVisibilidad.SelectedIndex].porcentaje;

            if (chkRealizaEnvio.Checked)
            {
                costo_total = costo_total + visibilidades[cmbVisibilidad.SelectedIndex].costo_envio;
            }

            //costo_total = costo_total + porcentaje * (double.Parse(txtPrecio.Text));
            //costo_total = costo_total + porcentaje * 
            txtCostoTotal.Text = costo_total.ToString();
        }

        private void ModificarCompraInmediata_Load(object sender, EventArgs e)
        {
            //string comando = "SELECT e.razon_social,e.nombre_contacto,e.cuit,e.rubro_id,u.telefono, d.ciudad, d.localidad, d.codigo_postal,d.domicilio_calle,d.numero_calle, d.piso, d.departamento FROM DBME.empresa e JOIN DBME.usuario u ON (e.usuario_id = u.usuario_id) JOIN DBME.domicilio d ON (u.domicilio_id = d.domicilio_id) WHERE empresa_id = " + empresa_id;
            string comando = "SELECT p.descripcion, p.stock , p.fecha_creacion, p.fecha_vencimiento, p.precio, p.rubro_id, p.visibilidad_id, p.estado, p.permite_preguntas, realiza_envio, p.costo FROM DBME.publicacion p WHERE p.publicacion_id = " + id_publicacion;
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);


            estadoInicial = dt.Rows[0][7].ToString();
            cargar_visibilidad(Int32.Parse(dt.Rows[0][6].ToString()));

            txtDescripción.Text = dt.Rows[0][0].ToString();
            txtStock.Text = dt.Rows[0][1].ToString();
            dateFechaInicio.Text = dt.Rows[0][2].ToString();
            dateFechaVencimiento.Text = dt.Rows[0][3].ToString();
            string[] datos = dt.Rows[0][4].ToString().Split(',');
            txtPrecio.Text = datos[0];
            txtPrecioDecimal.Text = datos[1];
            cmbRubros.SelectedIndex = Int32.Parse(dt.Rows[0][5].ToString());
            
            cmbVisibilidad.SelectedIndex = 0;
            cmbEstado.SelectedIndex = cmbEstado.FindString(dt.Rows[0][7].ToString());
            chkPermitePreguntas.Checked = Boolean.Parse(dt.Rows[0][8].ToString());
            chkRealizaEnvio.Checked = Boolean.Parse(dt.Rows[0][9].ToString());
            txtCostoTotal.Text = dt.Rows[0][10].ToString();

            

            if (estadoInicial == "ACTIVA") {
                txtDescripción.Enabled = false;
                txtStock.Enabled = false;
                txtPrecio.Enabled = false;
                txtPrecioDecimal.Enabled = false;
                cmbRubros.Enabled = false;
                dateFechaInicio.Enabled = false;
                dateFechaVencimiento.Enabled = false;
                cmbVisibilidad.Enabled = false;
                chkRealizaEnvio.Enabled = false;
                chkPermitePreguntas.Enabled = false;

                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("ACTIVA");
                cmbEstado.Items.Add("PAUSADA");
                cmbEstado.Items.Add("FINALIZADA");
                cmbEstado.SelectedIndex = cmbEstado.FindString(estadoInicial);
            }

            if (estadoInicial == "BORRADOR")
            {
                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("ACTIVA");
                cmbEstado.Items.Add("BORRADOR");
                cmbEstado.SelectedIndex = cmbEstado.FindString(estadoInicial);
            }

            if (estadoInicial == "PAUSADA")
            {
                txtDescripción.Enabled = false;
                txtStock.Enabled = false;
                txtPrecio.Enabled = false;
                txtPrecioDecimal.Enabled = false;
                cmbRubros.Enabled = false;
                dateFechaInicio.Enabled = false;
                dateFechaVencimiento.Enabled = false;
                cmbVisibilidad.Enabled = false;
                chkRealizaEnvio.Enabled = false;
                chkPermitePreguntas.Enabled = false;

                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("ACTIVA");
                cmbEstado.Items.Add("PAUSADA");
                cmbEstado.Items.Add("FINALIZADA");
                cmbEstado.SelectedIndex = cmbEstado.FindString(estadoInicial);
            }

            actualizar_costo_total();
        }
        
        private void cmbVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar_costo_total();
        }

        private void chkRealizaEnvio_CheckedChanged(object sender, EventArgs e)
        {
            actualizar_costo_total();
        }

        private void cmdGenerarCompra_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripción.Text;
            uint stock;
            uint precio;
            uint precio_decimal;
            uint rubro;
            int visibilidad_id;
            string visibilidad_descripcion;
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
                visibilidad_descripcion = cmbVisibilidad.GetItemText(cmbVisibilidad.SelectedItem);
                estado = cmbEstado.GetItemText(cmbEstado.SelectedItem);
                fechaInicio = DateTime.Parse(dateFechaInicio.Text);
                fechaVencimiento = DateTime.Parse(dateFechaVencimiento.Text);
                stock = UInt32.Parse(txtStock.Text);
                precio = UInt32.Parse(txtPrecio.Text);
                precio_decimal = UInt32.Parse(txtPrecioDecimal.Text);
                costo_total = Double.Parse(txtCostoTotal.Text);


                string comando5 = "SELECT visibilidad_id FROM DBME.visibilidad WHERE visibilidad_descripcion = '" + visibilidad_descripcion + "'";
                DataTable data_visibilidad = new ConexionSQL().cargarTablaSQL(comando5);
                visibilidad_id = Int32.Parse(data_visibilidad.Rows[0][0].ToString());
                

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

            if (ant1 == -1 && estadoInicial == "BORRADOR")
            {
                MessageBox.Show("La fecha de inicio no puede ser anterior a la fecha del sistema", "Problema", MessageBoxButtons.OK);
                return;
            }

            int ant2 = DateTime.Compare(fechaInicio, fechaVencimiento);

            if (ant2 != -1 && estadoInicial == "BORRADOR")
            {
                MessageBox.Show("La fecha de inicio no puede ser despues de la de finalización ", "Problema", MessageBoxButtons.OK);
                return;
            }

            try
            {
                //MessageBox.Show("estadoinicial:"+estadoInicial+"  estadoactual:"+estado, "Problema", MessageBoxButtons.OK);

                string comando = "UPDATE DBME.publicacion SET descripcion = '" + descripcion + "',stock = " + stock + ",fecha_creacion = '" + fechaInicio + "',fecha_vencimiento ='" + fechaVencimiento + "',precio=" + precio + "." + txtPrecioDecimal.Text + ",rubro_id=" + rubro + ",visibilidad_id=" + visibilidad_id + ",estado = '" + estado + "', permite_preguntas = '" + permitePreguntas + "', realiza_envio ='" + realiza_envio + "', costo =" + costo_total + "WHERE publicacion_id= " + id_publicacion;
                (new ConexionSQL()).ejecutarComandoSQL(comando);
                
                if (estadoInicial == "BORRADOR" && estado == "ACTIVA")
                {
                    string comando2 = "EXECUTE DBME.crearFacturasDelBorrador " + id_publicacion;
                    DataTable factura_id = new ConexionSQL().cargarTablaSQL(comando2);
                    DetalleFactura det = new DetalleFactura(Int32.Parse(factura_id.Rows[0][0].ToString()));
                    det.Show();
                }
                //string comando = "EXECUTE DBME.crearCompraInmediata '" + descripcion + "'," + stock + ",'" + fechaInicio + "','" + fechaVencimiento + "'," + precio + "." + precio_decimal + "," + rubro + "," + visibilidad_id + "," + sesion_actual.usuarioActual.usuario_id + "," + estado + "," + permitePreguntas + "," + realiza_envio + "," + costo_total;
                //comando = "UPDATE DBME.visibilidad SET visibilidad_descripcion = '" + txtDescripcion.Text + "',visibilidad_precio = " + txtPrecio.Text + "." + txtPrecioDecimal.Text + ",visibilidad_porcentaje = " + porcentajeString + ",visibilidad_costo_envio = " + txtCostoEnvio.Text + "." + txtCostoEnvioDecimal.Text + " WHERE visibilidad_id = " + id;
                

                MessageBox.Show("Publicacion actualizada exitosamente", "Compra Inmediata", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void chkRealizaEnvio_CheckedChanged_1(object sender, EventArgs e)
        {
            actualizar_costo_total();
        }

        private void cmbVisibilidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            actualizar_costo_total();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
