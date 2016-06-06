using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MercadoEnvio.Domain;

namespace MercadoEnvio.Login
{
    public partial class LoginAvanzado : Form
    {
        public LoginAvanzado(Usuario u)
        {
            InitializeComponent();
            var rolesDisponibles = new List<Rol>();
            //rolesDisponibles = new Controller.Controller().obtenerRolesDelUsuario(u);
            var strings = new List<String>();
            //strings = rolesDisponibles.ForEach(getNombre);
        }

        private string getNombre(Rol rol)
        {
            return rol.nombre;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LoginAvanzado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
