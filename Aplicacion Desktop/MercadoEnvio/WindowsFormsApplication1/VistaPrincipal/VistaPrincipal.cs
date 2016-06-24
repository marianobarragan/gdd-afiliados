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
            //MessageBox.Show(lstFunciones.GetItemText(lstFunciones.SelectedItem), "Login", MessageBoxButtons.OK);
            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "ABM DE ROL")
            {
                ABM_Rol.SeleccionRol seleccionRol = new ABM_Rol.SeleccionRol(this);
                seleccionRol.Show();
                //this.Hide();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "ABM DE VISIBILIDAD DE PUBLICACION")
            {
                ABM_Visibilidad.Menu menu = new ABM_Visibilidad.Menu();
                menu.Show();
                //this.Hide();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "ABM DE USUARIOS")
            {
                ABM_Usuario.Menu menu = new ABM_Usuario.Menu();
                menu.Show();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "HISTORIAL DEL CLIENTE")
            {
               Historial_Cliente.HistorialDelCliente historialPropio = new Historial_Cliente.HistorialDelCliente(sesion.usuarioActual.usuario_id);
               historialPropio.Show();

            }
            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "COMPRAR/OFERTAR") 
            {
               /*
                *Si el cliente posee más de 3 compras inmediatas o subastas sin calificar, el sistema
                 no le permitirá realizar ninguna otra operación de compra u oferta hasta que no califique
                 todo lo que tiene pendiente.
                * */
           
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "GENERAR PUBLICACION")
            {
                Generar_Publicación.Menu menu = new Generar_Publicación.Menu(sesion);
                menu.Show();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "COMPRAR/OFERTAR")
            {
                if (!poseeMasDeTresCompras()) {
                    ComprarOfertar.ListadoPublicaciones listadoPublicaciones = new ComprarOfertar.ListadoPublicaciones(sesion);
                    listadoPublicaciones.Show();
                }
                return;
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "HISTORIAL DEL CLIENTE")
            {
                Historial_Cliente.HistorialDelCliente historial = new Historial_Cliente.HistorialDelCliente(sesion.usuarioActual.usuario_id);
                historial.Show();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "CALIFICAR AL VENDEDOR")
            {
                Calificar.ListadoDePublicacionesSinCalificar lst = new Calificar.ListadoDePublicacionesSinCalificar(sesion.usuarioActual.usuario_id);
                lst.Show();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "CONSULTA DE FACTURAS REALIZADAS AL VENDEDOR")
            {
                Facturas.ListadoFacturas facturas = new Facturas.ListadoFacturas(sesion.usuarioActual.usuario_id);
                facturas.Show();
            }

            if (lstFunciones.GetItemText(lstFunciones.SelectedItem) == "LISTADO ESTADISTICO")
            {
                Listado_Estadistico.SeleccionarListado listadoEstadistico = new Listado_Estadistico.SeleccionarListado();
                listadoEstadistico.Show();
            }
            
        }

        private bool poseeMasDeTresCompras() {
            return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            this.Close();
        }

        private void VistaPrincipal_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sesion.listaFuncionalidades.Count; i++) // agregar elementos al combobox
            {
                lstFunciones.Items.Add(sesion.listaFuncionalidades[i].descripcion);
            }
            lstFunciones.SelectedIndex = 0;
            label4.Text = sesion.rolActual.nombre;
            label5.Text = sesion.usuarioActual.nombreUsuario;
            label6.Text = Program.fechaSistema();

            string c = "EXECUTE DBME.chequearVencimientoPublicaciones "+ Program.fechaSistema();
            new ConexionSQL().ejecutarComandoSQL(c);

            //string c = "EXEC ";
           // DataTable dt = new ConexionSQL().ejecutarComandoSQL(c);

            //new Controller.Controller().
        }

        private void lstFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
