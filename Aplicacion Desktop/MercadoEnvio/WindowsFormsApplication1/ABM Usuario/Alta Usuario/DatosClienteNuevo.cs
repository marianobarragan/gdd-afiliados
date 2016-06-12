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

namespace MercadoEnvio.ABM_Usuario.Alta_Usuario
{
    public partial class DatosClienteNuevo : Form
    {
        public string username;
        public string password;
        public string email;

        public DatosClienteNuevo(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            InitializeComponent();
        }

        private void DatosClienteNuevo_Load(object sender, EventArgs e)
        {

            cmbTipoDocumento.SelectedIndex = 0;
            /*
            string comando = "select distinct  from dbme.funcionalidad";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            lstTodasLasFunciones.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                //int idf = Convert.ToInt32(dt.Rows[i][0]);
                lstTodasLasFunciones.Items.Add(dt.Rows[i][1]);
                //lstTodasLasFunciones.Items.Insert(i, new Funcionalidad(idf, dt.Rows[i][1].ToString(), this));
            }
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text;
            string nombre = txtNombre.Text;
            uint documento;
            DateTime fechaNacimiento;
            string tipoDocumento = cmbTipoDocumento.Items[cmbTipoDocumento.SelectedIndex].ToString();

            string ciudad = txtCiudad.Text;
            string localidad = txtLocalidad.Text;
            uint codigo_postal;
            string domicilio_calle = txtDomicilioCalle.Text;
            uint altura_calle;
            uint numero_piso;
            string departamento = txtDepartamento.Text;
            uint numero_telefono;

            try
            {
                documento = UInt32.Parse(txtDocumento.Text);
                fechaNacimiento = DateTime.Parse(dateNacimiento.Text);

                codigo_postal = UInt32.Parse(txtCodigoPostal.Text);
                altura_calle = UInt32.Parse(txtAlturaCalle.Text);
                numero_piso = UInt32.Parse(txtNumeroPiso.Text);
                numero_telefono = UInt32.Parse(txtNumeroTelefono.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ingrese solamente numeros en los formularios verdes, sin puntos", "Nuevo Cliente", MessageBoxButtons.OK);
                return;
            }
            catch (System.OverflowException) {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nuevo Cliente", MessageBoxButtons.OK);
                return;
            }

            
            int ant1 = DateTime.Compare(fechaNacimiento, DateTime.Parse(Program.fechaSistema()));
            
            if (ant1 != -1  )
            {
                MessageBox.Show("Ingrese una fecha de nacimiento válida", "Nuevo Cliente", MessageBoxButtons.OK);
                return;
            }

            /* insertar nuevo cliente */
            
            try {
                
                string comando = "EXECUTE DBME.nuevoCliente '" + username + "','" + password + "','" + email + "','" + nombre + "','" + apellido + "','" + fechaNacimiento + "','" + tipoDocumento + "'," + documento + ",'" + ciudad + "','" + localidad + "','" + codigo_postal + "','" + domicilio_calle + "'," + altura_calle + "," + numero_piso + ",'" + departamento + "'," + numero_telefono ;
                //MessageBox.Show(comando, "A", MessageBoxButtons.OK);
                (new ConexionSQL()).ejecutarComandoSQL(comando);
                
                MessageBox.Show("Cliente creado exitosamente", "A", MessageBoxButtons.OK);
            }
            catch (Exception er) {
                MessageBox.Show(er.Message,"Error",MessageBoxButtons.OK);
                return;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
