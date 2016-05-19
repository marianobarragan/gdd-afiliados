using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class SeleccionarListado : Form
    {
        public SeleccionarListado()
        {
            InitializeComponent();
        }

        private void lstOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstOpciones.SelectedIndex = 0;
        }
    }
}
