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
using MercadoEnvio.Controller;

namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    public partial class ModificarContraseña : Form
    {
        Sesion sesion;

        public ModificarContraseña(Sesion sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
        }

        private void ModificarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (sesion.usuarioActual.contraseña != txtContraseñaVieja.Text)
            {
                MessageBox.Show("La contraseña vieja es incorrecta", "Error", MessageBoxButtons.OK);
                return;
            }
            if (txtContraseñaNueva1.Text != txtContraseñaNueva2.Text)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden", "Error", MessageBoxButtons.OK);
                return;
            }

            if (txtContraseñaNueva2.Text.Length <= 4)
            {
                MessageBox.Show("La contraseña debe tener más de 4 caracteres", "Error", MessageBoxButtons.OK);
                return;
            
            }

            try
            {
                string query = "EXECUTE DBME.cambiarContrasenia "+sesion.usuarioActual.usuario_id+",'"+txtContraseñaNueva2.Text+"'";
                (new ConexionSQL()).ejecutarComandoSQL(query);
                MessageBox.Show("La contraseña ha sido actualizada", "Exito", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }

        }
    }
}
