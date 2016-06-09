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
    public partial class ModificarVisibilidad : Form
    {
        public string contenido;

        public ModificarVisibilidad(string contenido)
        {
            InitializeComponent();
            this.contenido = contenido;
        }

        private void ModificarVisibilidad_Load(object sender, EventArgs e)
        {

        }
    }
}
