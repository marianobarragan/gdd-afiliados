using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Controller;
using MercadoEnvio.Domain;

namespace MercadoEnvio.ABM_Visibilidad
{
    

    public partial class ModificarVisibilidad : Form
    {
        public int id;
        public string descripcion;
        public int precio;
        public int porcentaje;
        public int costo_envio;
        public string estadoVentana;
        public int precioDecimal;
        public int costo_envioDecimal;
        public Visibilidad visibilidadActual;

        public ModificarVisibilidad(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ModificarVisibilidad_Load(object sender, EventArgs e)
        {
            estadoVentana = "deshabilitado";
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtPorcentaje.Enabled = false;
            txtCostoEnvio.Enabled = false;
            txtCostoEnvioDecimal.Enabled = false;
            txtPrecioDecimal.Enabled = false;
            string comando = "select visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio from dbme.visibilidad WHERE visibilidad_id = "+ id;
           
            DataTable dataVisibilidad = (new ConexionSQL()).cargarTablaSQL(comando);
            //MessageBox.Show(datos2[0], "Alta Visibilidad", MessageBoxButtons.OK);
            visibilidadActual = new Visibilidad(dataVisibilidad);
            txtDescripcion.Text = visibilidadActual.descripcion;
            txtPrecio.Text = visibilidadActual.precio.ToString();
            txtPrecioDecimal.Text =visibilidadActual.precioDecimal.ToString();
            txtPorcentaje.Text = visibilidadActual.porcentaje.ToString();
            txtCostoEnvio.Text = visibilidadActual.costo_envio.ToString();
            txtCostoEnvioDecimal.Text = visibilidadActual.costo_envioDecimal.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cambiarEstadoVentana();
            
        }

        public void cambiarEstadoVentana()
        {
            if (estadoVentana == "deshabilitado")
            {
                txtDescripcion.Enabled = true;
                txtPrecio.Enabled = true;
                txtPorcentaje.Enabled = true;
                txtCostoEnvio.Enabled = true;
                txtCostoEnvioDecimal.Enabled = true;
                txtPrecioDecimal.Enabled = true;
                estadoVentana = "habilitado";
                button1.Text = "Guardar Cambios";
            }
            else 
            {
                try
                {
                    precio = Int32.Parse(txtPrecio.Text);
                    porcentaje = Int32.Parse(txtPorcentaje.Text);
                    costo_envio = Int32.Parse(txtCostoEnvio.Text);
                    precioDecimal = Int32.Parse(txtPrecioDecimal.Text);
                    costo_envioDecimal = Int32.Parse(txtCostoEnvioDecimal.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Valores invalidos en precio/porcentaje/costo de envio. Ingrese solamente numeros enteros ", "Alta Visibilidad", MessageBoxButtons.OK);
                    return;
                }

                if (precio < 0 || porcentaje < 0 || costo_envio < 0)
                {
                    MessageBox.Show("No se pueden ingresar valores negativos ", "Alta Visibilidad", MessageBoxButtons.OK);
                    return;
                }

                if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre", "Alta Visibilidad", MessageBoxButtons.OK);
                    return;
                }

                if (porcentaje > 100)
                {
                    MessageBox.Show("El porcentaje es mayor a lo permitido", "Alta Visibilidad", MessageBoxButtons.OK);
                    return;
                }



                try
                {
                    string porcentajeString = txtPorcentaje.Text.Insert(0, "0.");
                    string comando = "UPDATE DBME.visibilidad SET visibilidad_descripcion = '"+ txtDescripcion.Text+"',visibilidad_precio = "+txtPrecio.Text+"."+txtPrecioDecimal.Text+",visibilidad_porcentaje = "+porcentajeString+",visibilidad_costo_envio = "+txtCostoEnvio.Text+"."+txtCostoEnvioDecimal.Text+" WHERE visibilidad_id = "+id;
                    MessageBox.Show(comando, "Alta Visibilidad", MessageBoxButtons.OK);
                    MessageBox.Show("¿Está seguro de que desea guardar la visibilidad?", "Alta Visibilidad", MessageBoxButtons.OK);
                    (new ConexionSQL()).ejecutarComandoSQL(comando);
                    txtDescripcion.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    txtCostoEnvio.Enabled = false;
                    txtCostoEnvioDecimal.Enabled = false;
                    txtPrecioDecimal.Enabled = false;
                    estadoVentana = "deshabilitado";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Alta Visibilidad", MessageBoxButtons.OK);
                    return;
                }

                
            }
        }
    }
}
