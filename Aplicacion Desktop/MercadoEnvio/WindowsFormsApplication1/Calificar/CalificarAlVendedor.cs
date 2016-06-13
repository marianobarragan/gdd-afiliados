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

namespace MercadoEnvio.Calificar
{
    public partial class CalificarAlVendedor : Form
    {
        public int cliente_id;
        public int compra_id;
        public CalificarAlVendedor(int id_compra, int id_cliente)
        {
            //Realizar el chequeo para que el ID CLIENTE e ID COMPRA sean reales
            InitializeComponent();
            compra_id = id_compra;
            cliente_id = id_cliente;
        }

        private void CalificarAlVendedor_Load(object sender, EventArgs e)
        {
            string comando = "SELECT p.descripcion, p.precio, u.username FROM DBME.compra c JOIN DBME.publicacion p ON (c.publicacion_id = p.publicacion_id) JOIN DBME.usuario u ON(p.autor_id = u.usuario_id) WHERE (c.compra_id = "+compra_id+")";

            DataTable dataCalificacion = (new ConexionSQL()).cargarTablaSQL(comando);
            textEmpresa.Text = dataCalificacion.Rows[0][2].ToString();
            textPrecio.Text = dataCalificacion.Rows[0][1].ToString();
            textProducto.Text = dataCalificacion.Rows[0][0].ToString();
            lstCalificacion.SelectedIndex = 0;
               
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            string comando = "EXECUTE DBME.calificarAlVendedor " + compra_id + "," + cliente_id + ",'" + textBox4.Text +"',"+lstCalificacion.Text+"";
            (new ConexionSQL()).ejecutarComandoSQL(comando);
            MessageBox.Show("Calificacion Cargada Correctamente", "Exito", MessageBoxButtons.OK);
            
        }
    }
}
