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
                Usuario usuarioValidado = new Controller.Controller().loginUsuario(textBox1.Text,textBox2.Text);
                LoginAvanzado elegirRol = new LoginAvanzado(usuarioValidado);
                elegirRol.Show();
                //this.Hide();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Login", MessageBoxButtons.OK);
                return;
            }

            
        }

        public void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        /*
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        */
        private void LoginInicial_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
