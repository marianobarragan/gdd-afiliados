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

namespace MercadoEnvio.ComprarOfertar
{
    public partial class OfertarProducto : Form
    {
        int id_publ;
        int usuario;

        public OfertarProducto(int id, string descripcion, double precio, int stock, int usuario_id)
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
            double valor_a_ofertarDecimal;
           
            try
            {

                valor_a_ofertar = Double.Parse(txtOferta.Text);
                valor_a_ofertarDecimal = Double.Parse(txtOfertaDecimal.Text);
                
            }
            catch {
                
                MessageBox.Show("Ingrese un numero valido en el formulario verde", "Ofertar", MessageBoxButtons.OK);
                return;
            }

            try
            {
                if (valor_a_ofertarDecimal >= 100 || valor_a_ofertarDecimal < 0)
                {
                    MessageBox.Show("Debe ingresar un valor decimal entre 0 y 100", "Ofertar", MessageBoxButtons.OK);
                    return;
                }

                double valorOfertar = Double.Parse(txtOferta.Text + "." + txtOfertaDecimal.Text);
                if (valorOfertar <= Double.Parse(txtPrecio.Text))
                {
                    MessageBox.Show("Debe ingresar un valor mayor al actual", "Ofertar", MessageBoxButtons.OK);
                    return;
                }



                string crearOferta = "INSERT INTO DBME.oferta (fecha,monto,publicacion_id,autor_id) VALUES (DBME.getHoraDelSistema()," + txtOferta.Text + "." + txtOfertaDecimal.Text + "," + id_publ + "," + usuario + ")";
                string updatePublicacion = "UPDATE DBME.publicacion SET valor_actual = " + txtOferta.Text + "." + txtOfertaDecimal.Text + " WHERE publicacion_id = " + id_publ;
                MessageBox.Show(crearOferta, "A", MessageBoxButtons.OK);
                (new ConexionSQL()).ejecutarComandoSQL(crearOferta);
                (new ConexionSQL()).ejecutarComandoSQL(updatePublicacion);
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
