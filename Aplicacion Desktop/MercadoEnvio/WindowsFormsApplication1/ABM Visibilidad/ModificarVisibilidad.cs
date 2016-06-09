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
        public int id;
        public string descripcion;
        public int precio;
        public int porcentaje;
        public int costo_envio;

        public ModificarVisibilidad(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ModificarVisibilidad_Load(object sender, EventArgs e)
        {

        }
    }
}
