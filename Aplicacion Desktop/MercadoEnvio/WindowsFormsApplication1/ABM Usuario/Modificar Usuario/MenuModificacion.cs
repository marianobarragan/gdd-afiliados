using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    public partial class MenuModificacion : Form
    {
        public string tipo;

        public MenuModificacion(string discriminador)
        {
            tipo = discriminador;
            InitializeComponent();
            button1.Text = discriminador + " Cliente";
            button2.Text = discriminador + " Empresa";
        }

        private void MenuModificacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoParaCliente listado_cliente = new ListadoParaCliente(tipo);
            listado_cliente.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ListadoParaEmpresa listado_empresa = new ListadoParaEmpresa(tipo);
            //listado_empresa.Show();
            this.Close();
        }
    }
}
