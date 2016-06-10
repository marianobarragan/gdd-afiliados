using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ABM_Usuario.Alta_Usuario
{
    public partial class DatosEmpresaNuevo : Form
    {
        public string username;
        public string password;
        public string email;

        public DatosEmpresaNuevo(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            InitializeComponent();
        }

        private void DatosEmpresaNuevo_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string razon_social = txtRazonSocial.Text;
            string nombre = txtNombre.Text;
            uint CUIT;
            string rubro = txtRubro.Text;

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
                CUIT = UInt32.Parse(txtCUIT.Text);
                

                codigo_postal = UInt32.Parse(txtCodigoPostal.Text);
                altura_calle = UInt32.Parse(txtAlturaCalle.Text);
                numero_piso = UInt32.Parse(txtNumeroPiso.Text);
                numero_telefono = UInt32.Parse(txtNumeroTelefono.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Ingrese solamente numeros en los formularios verdes, sin puntos", "Nueva Empresa", MessageBoxButtons.OK);
                return;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nueva Empresa", MessageBoxButtons.OK);
                return;
            }

            try // insertar nueva empresa
            {
                
                string comando = "EXECUTE DBME.nuevaEmpresa '" + username + "','" + password + "','" + email + "','" + nombre + "','" + razon_social + "','" + CUIT + "','" + rubro  + "','" + ciudad + "','" + localidad + "','" + codigo_postal + "','" + domicilio_calle + "','" + altura_calle + "','" + numero_piso + "','" + departamento + "','" + numero_telefono + "'";
                MessageBox.Show(comando, "Alta", MessageBoxButtons.OK);
                //(new ConexionSQL()).ejecutarComandoSQL(comando);

                //MessageBox.Show("Empresa creada exitosamente", "A", MessageBoxButtons.OK);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }

        }
    }
}
