using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Rol
{
    public partial class SeleccionRol : Form
    {
        public Form vista;

        public SeleccionRol(Form vista)
        {
            InitializeComponent();
            this.vista = vista;
        }

        private void SeleccionRol_Load(object sender, EventArgs e)
        {

        }

        private void btnIrVista_Click(object sender, EventArgs e)
        {
            switch (lstOpciones.SelectedIndex)
            {
                case 0:
                    AltaRol alta = new AltaRol();
                    alta.Show();
                    break;
                case 1:
                   
                    ListadoRol baja = new ListadoRol("Eliminar Rol");
                    baja.Show();
                    break;
                case 2:
                   
                    ListadoRol mod = new ListadoRol("Modificar Rol");
                    mod.Show();
                    break;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            vista.Show();
            this.Close();
        }

        private void lstOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
