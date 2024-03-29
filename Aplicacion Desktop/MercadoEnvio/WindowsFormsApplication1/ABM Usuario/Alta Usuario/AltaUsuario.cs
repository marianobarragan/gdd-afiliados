﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MercadoEnvio.Controller;

namespace MercadoEnvio.ABM_Usuario.Alta_Usuario
{
    public partial class AltaUsuario : Form
    {
        public DataTable dt;

        public AltaUsuario()
        {
            InitializeComponent();
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {

            optCliente.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string password2 = txtPassword2.Text;
            string email = txtMail.Text;
            
            if (username == "" || password == "" || password2 == "" || email == ""){
                MessageBox.Show("No deje campos en blanco","Alta Usuario",MessageBoxButtons.OK );
                return;
            }

            if (password != password2){
                MessageBox.Show("Las contraseñas son distintas","Alta Usuario",MessageBoxButtons.OK );
                return;
            }

            if (password.Length <= 4)
            {
                MessageBox.Show("La contraseña debe tener más de 4 caracteres", "Alta Usuario", MessageBoxButtons.OK);
                return;
            }

            string query2 = "EXECUTE DBME.validarUsuarioExistente '"+ txtUsername.Text +"','" +txtMail.Text+"'";
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query2));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                return;
            }
            string respuesta = dt.Rows[0][0].ToString();
            if (respuesta == "true") {
                MessageBox.Show("Ya existe un usuario con ese nombre de usuario/mail ", "Alta Usuario", MessageBoxButtons.OK);
                return;
            }

            if (optCliente.Checked){

                DatosClienteNuevo cl = new DatosClienteNuevo(username, password, email);
                cl.Show();
                this.Close();
            }

            if (optEmpresa.Checked)
            {
                DatosEmpresaNuevo em = new DatosEmpresaNuevo(username, password, email);
                em.Show();
                this.Close();
            }
        }
    }
}
