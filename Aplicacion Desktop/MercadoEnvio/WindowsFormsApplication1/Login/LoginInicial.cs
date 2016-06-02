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
//using MercadoEnvio.Controller.Controller;

namespace MercadoEnvio.Login
{
    public partial class LoginInicial : Form
    {
        public LoginInicial()
        {
            InitializeComponent();
        }

        private void LoginInicial_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           //Usuario usuario = new Usuario();
           Usuario usuarioValidado = new Controller.Controller().obtenerUsuario(textBox1.Text,textBox2.Text);
           
 
        }
    }
}
