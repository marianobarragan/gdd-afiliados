using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    public partial class MenuModificacion : Form
    {
        public string tipo;

        public MenuModificacion(string discriminador)
        {
            
            InitializeComponent();
            button1.Text = discriminador + " Cliente";
            button2.Text = discriminador + " Empresa";
        }

        private void MenuModificacion_Load(object sender, EventArgs e)
        {

        }
    }
}
