using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Visibilidad
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnIrVista_Click(object sender, EventArgs e)
        {
            switch (lstOpciones.SelectedIndex) { 
                case 0:
                    AltaVisibilidad alta = new AltaVisibilidad();
                    alta.Show();
                    break;
                case 1:
                    ListadoVisibilidad baja = new ListadoVisibilidad("Eliminar visibilidad");
                    baja.Show();
                    break;
                case 2:
                    ListadoVisibilidad mod = new ListadoVisibilidad("Modificar visibilidad");
                    mod.Show();
                    break;
                
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
