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

namespace MercadoEnvio.VistaPrincipal
{
    public partial class VistaPrincipal : Form
    {
        public Sesion sesion;

        public VistaPrincipal(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //boton Logout
            Login.LoginInicial loginView = new Login.LoginInicial();
            loginView.Show();
            //this.Hide();  TODO
            //this.Close();
        }

        private void VistaPrincipal_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sesion.listaFuncionalidades.Count; i++) // agregar elementos al combobox
            {
                lstFunciones.Items.Add(sesion.listaFuncionalidades[i].descripcion);
            }
        }

        private void lstFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
