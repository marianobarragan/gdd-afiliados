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

namespace MercadoEnvio.ABM_Visibilidad
{
    public partial class AltaVisibilidad : Form
    {
        public AltaVisibilidad()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint precio;
            uint porcentaje;
            uint costo;
            uint precioDecimal;
            uint costoDecimal;
            
            try
            {
                precio = UInt32.Parse(txtPrecio.Text);
                porcentaje = UInt32.Parse(txtPorcentaje.Text);
                costo = UInt32.Parse(txtCostoEnvio.Text);
                precioDecimal = UInt32.Parse(txtPrecioDecimal.Text);
                costoDecimal = UInt32.Parse(txtCostoEnvioDecimal.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Valores invalidos en precio/porcentaje/costo de envio. Ingrese solamente numeros enteros ", "Alta Visibilidad", MessageBoxButtons.OK);
                return;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Alta Visibilidad", MessageBoxButtons.OK);
                return;
            }

            if (precio < 0 || porcentaje < 0 || costo < 0){
                MessageBox.Show("No se pueden ingresar valores negativos ", "Alta Visibilidad", MessageBoxButtons.OK);
                return;
            }

            if (txtDescripcion.Text == ""){
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
                string porcentajeString = porcentaje.ToString().Insert(0, "0.");
                string comando = "INSERT INTO DBME.visibilidad (visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio,posee_baja_logica) VALUES ('" + txtDescripcion.Text + "'," + precio+ "." + precioDecimal + "," + porcentajeString + "," + costo +"."+costoDecimal+ ",0)";                
                (new ConexionSQL()).ejecutarComandoSQL(comando);
                MessageBox.Show("Visibilidad creada exitosamente", "Alta Visibilidad", MessageBoxButtons.OK);
            }
            catch (Exception er) {
                MessageBox.Show(er.Message, "Alta Visibilidad", MessageBoxButtons.OK);
                return;
            }

            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AltaVisibilidad_Load(object sender, EventArgs e)
        {

        }
    }
}
