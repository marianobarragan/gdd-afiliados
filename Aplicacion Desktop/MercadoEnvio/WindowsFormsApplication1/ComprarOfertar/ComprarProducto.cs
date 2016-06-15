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
    public partial class ComprarProducto : Form
    {
        int id_publ;
        string descripcion_Producto;
        float precio_Producto;
        int stock_Disponible;
        int usuario;

        public ComprarProducto(string id,string descripcion,float precio,string stock,int usuario_id)
        {
            InitializeComponent();
            id_publ = Int32.Parse(id);
            txtId.Text = id;

            descripcion_Producto = descripcion;
            txtDescripcion.Text = descripcion;
            
            precio_Producto = (precio);
            txtPrecio.Text = precio.ToString();

            stock_Disponible = Int32.Parse(stock);
            txtStock.Text = stock;

            usuario = usuario_id;

        }

        private void ComprarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            int cantidad_a_comprar;
            try
            {
                cantidad_a_comprar = Int32.Parse(txtCantidad.Text);
            }
            catch
            {

                MessageBox.Show("Ingrese un numero valido en el formulario verde", "Comprar", MessageBoxButtons.OK);
                return;
            }
            if (cantidad_a_comprar > stock_Disponible)
            {
                MessageBox.Show("No puede comprar más unidades de las disponibles", "Comprar Producto", MessageBoxButtons.OK);
                return;
            }

            if (cantidad_a_comprar == 0 )
            {
                MessageBox.Show("Debe ingresar un numero mayor a cero", "Comprar Producto", MessageBoxButtons.OK);
                return;
            }

            try
            {
                string crearCompra = "INSERT INTO DBME.compra	(cantidad,fecha,autor_id,publicacion_id,esta_calificada) VALUES (" + cantidad_a_comprar + ", GETDATE()," + usuario + "," + id_publ + ", 0)";
                string updatePublicacion = "UPDATE DBME.publicacion SET estado = 'FINALIZADA' WHERE publicacion_id = " + id_publ;
                //LLAMAR A FUNCION CREAR FACTURA Y MOSTRARLA

                (new ConexionSQL()).ejecutarComandoSQL(crearCompra);
                (new ConexionSQL()).ejecutarComandoSQL(updatePublicacion);

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
