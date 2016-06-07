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
        Sesion sesion;
        Usuario usuario;
        List<Rol> rolesDisponibles;


        public LoginAvanzado(Usuario u)
        {
            InitializeComponent();
            //var rolesDisponibles = new List<Rol>();
            rolesDisponibles = new Controller.Controller().obtenerRolesDelUsuario(u);
            usuario = u;

            for (int i = 0; i < rolesDisponibles.Count; i++) // agregar elementos al combobox
            {
                comboBox1.Items.Add(rolesDisponibles[i].nombre);
            }

            if (rolesDisponibles.Count == 1)
            {
                funcion_sapo();
                this.Hide();
            }
            
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
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcion_sapo();   
        }

        public void funcion_sapo()
        {
            comboBox1.SelectedIndex = 0;
            this.sesion = new Sesion(usuario.usuario_id, usuario.nombreUsuario, rolesDisponibles[comboBox1.SelectedIndex]);
            VistaPrincipal.VistaPrincipal vista = new VistaPrincipal.VistaPrincipal(sesion);
            this.Hide();
            vista.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
