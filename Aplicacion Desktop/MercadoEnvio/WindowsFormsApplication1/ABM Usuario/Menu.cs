using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Usuario
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lstOpciones.SelectedIndex = 0;
        }

        private void btnIrVista_Click(object sender, EventArgs e)
        {
            switch (lstOpciones.SelectedIndex)
            {
                case 0:
                    Alta_Usuario.AltaUsuario alta = new Alta_Usuario.AltaUsuario();
                    alta.Show();
                    break;
                case 1:
                    Modificar_Usuario.MenuModificacion baja = new Modificar_Usuario.MenuModificacion("Borrar");
                    baja.Show();
                    break;
                case 2:
                    Modificar_Usuario.MenuModificacion mod = new Modificar_Usuario.MenuModificacion("Modificar");
                    mod.Show();
                    break;
            }
        }
    }
}
