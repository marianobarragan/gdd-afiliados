using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Facturas
{
    public partial class DetalleFacturaCliente : Form
    {

        public int factura_id;
        public DetalleFacturaCliente(int id2)
        {
            factura_id = id2;
            InitializeComponent();
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
