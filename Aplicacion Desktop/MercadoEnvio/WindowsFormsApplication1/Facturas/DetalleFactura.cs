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

namespace MercadoEnvio.Facturas
{
    public partial class DetalleFactura : Form
    {

        public int factura_id;
        public DetalleFactura(int factura_id)
        {
            InitializeComponent();
            this.factura_id = factura_id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            lblNumeroFactura.Text = factura_id.ToString();
            string comando = "SELECT YEAR(fecha), MONTH(fecha), DAY(fecha), usuario_id,monto_total FROM DBME.factura WHERE factura_id = " + factura_id;
            DataTable dataFactura = (new ConexionSQL().cargarTablaSQL(comando));
            txtAnio.Text = dataFactura.Rows[0][0].ToString();
            txtMes.Text = dataFactura.Rows[0][1].ToString();
            txtDia.Text = dataFactura.Rows[0][2].ToString();
            txtTotal.Text = dataFactura.Rows[0][4].ToString();

            string idUsuario = dataFactura.Rows[0][3].ToString();
            string comando2 = "SELECT username,mail FROM DBME.usuario WHERE usuario_id = "+idUsuario;
            DataTable dataUsuario = (new ConexionSQL().cargarTablaSQL(comando2));
            lbl1.Text = "Username: ";
            lbl2.Text = "Mail: ";
            lbl5.Text = dataUsuario.Rows[0][0].ToString();
            lbl6.Text = dataUsuario.Rows[0][1].ToString();

            string comando3 = "execute dbme.devolverInformacionFactura " + idUsuario;
            DataTable dataUsuario2 = (new ConexionSQL().cargarTablaSQL(comando3));

            if (dataUsuario2.Rows[0][0].ToString() == "empresa")
            {
                string comando4 = "SELECT cuit,nombre_contacto FROM DBME.empresa WHERE usuario_id = " + idUsuario;
                DataTable dataUsuario3 = (new ConexionSQL().cargarTablaSQL(comando4));
                lbl3.Text = "CUIT: ";
                lbl4.Text = "Nombre Contacto: ";
                lbl7.Text = dataUsuario3.Rows[0][0].ToString();
                lbl8.Text = dataUsuario3.Rows[0][1].ToString();
            }else{
                string comando5 = "SELECT nombre +' ' +apellido,numero_documento FROM dbme.cliente WHERE usuario_id =  " + idUsuario;
                DataTable dataUsuario3 = (new ConexionSQL().cargarTablaSQL(comando5));
                lbl3.Text = "Nombre y Apellido: ";
                lbl4.Text = "Numero Documento: ";
                lbl7.Text = dataUsuario3.Rows[0][0].ToString();
                lbl8.Text = dataUsuario3.Rows[0][1].ToString();
            }

            string comando6 = "SELECT * FROM DBME.factura_detalle WHERE factura_id = " + factura_id;
            DataTable dataFactura2 = (new ConexionSQL().cargarTablaSQL(comando6));

            dataGridView1.DataSource = dataFactura2;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
