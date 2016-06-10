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
            float precio;
            float porcentaje;
            float costo;
            float precioDecimal;

            float costoDecimal;
            try
            {
                precio = float.Parse(txtPrecio.Text);
                porcentaje = float.Parse(txtPorcentaje.Text);
                costo = float.Parse(txtCostoEnvio.Text);
                precioDecimal = float.Parse(txtPrecioDecimal.Text);
                costoDecimal = float.Parse(txtCostoEnvioDecimal.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Valores invalidos en precio/porcentaje/costo de envio. Ingrese solamente numeros enteros ", "Alta Visibilidad", MessageBoxButtons.OK);
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
                string comando = "INSERT INTO DBME.visibilidad (visibilidad_descripcion,visibilidad_precio,visibilidad_porcentaje,visibilidad_costo_envio) VALUES ('" + txtDescripcion.Text + "'," + precio+ "." + precioDecimal + "," + porcentajeString + "," + costo +"."+costoDecimal+ ")";
                MessageBox.Show("¿Está seguro de que desea crear la visibilidad?", "Alta Visibilidad", MessageBoxButtons.OK);
                (new ConexionSQL()).ejecutarComandoSQL(comando);
            }
            catch (Exception er) {
                MessageBox.Show(er.Message, "Alta Visibilidad", MessageBoxButtons.OK);
                return;
            }

            
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
