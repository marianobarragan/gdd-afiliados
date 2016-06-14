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

namespace MercadoEnvio.Generar_Publicación
{
    public partial class Menu : Form
    {
        public Sesion sesion;

        public Menu(Sesion sesion_actual)
        {
            InitializeComponent();
            sesion = sesion_actual;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lstOpciones.SelectedIndex = 0;
        }

        private void btnIrVista_Click(object sender, EventArgs e)
        {
            switch (lstOpciones.SelectedIndex) { 
                case 0:
                    AltaCompraInmediata compra_inmediata = new AltaCompraInmediata(sesion);
                    compra_inmediata.Show();
                    return;
                    //compra inmediata
                case 1:
                    return;
                    //subasta
                case 2:
                    return;//modificar
            
            }
        }
    }
}
