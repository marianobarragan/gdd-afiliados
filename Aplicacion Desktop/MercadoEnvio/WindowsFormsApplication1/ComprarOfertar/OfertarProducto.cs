using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class OfertarProducto : Form
    {
        int id_publ;
        int usuario;

        public OfertarProducto(int id, string descripcion, float precio, int stock, int usuario_id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtDescripcion.Text = descripcion;
            txtPrecio.Text = precio.ToString();
            id_publ = id;
            usuario = usuario_id;
        }

        private void OfertarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            double valor_a_ofertar;
            try
            {
                valor_a_ofertar = Double.Parse(txtOferta.Text);
            }
            catch {
                
                MessageBox.Show("Ingrese un numero valido en el formulario verde", "Ofertar", MessageBoxButtons.OK);
                return;
            }

            try
            {

                string crearOferta = "INSERT INTO DBME.oferta (fecha,monto,publicacion_id,autor_id) VALUES (GETDATE()," +valor_a_ofertar+ "," + id_publ + ","+usuario+")";
                string updatePublicacion = "UPDATE DBME.publicacion SET valor_actual = "+valor_a_ofertar+" WHERE publicacion_id = " + id_publ;
                MessageBox.Show(crearOferta, "A", MessageBoxButtons.OK);
                //(new ConexionSQL()).ejecutarComandoSQL(comando);
                MessageBox.Show(updatePublicacion, "A", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            
            this.Close();
        }
    }
}
