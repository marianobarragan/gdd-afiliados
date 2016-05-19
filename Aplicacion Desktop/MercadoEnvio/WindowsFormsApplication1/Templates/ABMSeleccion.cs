using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Templates
{
    public partial class ABMSeleccion : Form
    {
        public ABMSeleccion()
        {
            InitializeComponent();
        }

        private void ABM_Load(object sender, EventArgs e)
        {
            lstOpciones.SelectedIndex = 0;
        }

        private void btnIrVista_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(lstOpciones.SelectedIndex);
        }

        private void lstOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
