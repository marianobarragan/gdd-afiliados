using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MercadoEnvio.Controller;
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
            if (textBox1.Text == "" || textBox2.Text == "") {
                MessageBox.Show("Ingrese usuario y contrasña", "Login", MessageBoxButtons.OK);
                return;
            }

            try { 
                Usuario usuarioValidado = new Controller.Controller().obtenerUsuario(textBox1.Text,textBox2.Text);
                LoginAvanzado elegirRol = new LoginAvanzado(usuarioValidado);
                this.Hide();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Login", MessageBoxButtons.OK);
                return;
            }

            
        }
    }
}
