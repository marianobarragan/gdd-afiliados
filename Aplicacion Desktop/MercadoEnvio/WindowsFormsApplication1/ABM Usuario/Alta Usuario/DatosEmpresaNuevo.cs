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

namespace MercadoEnvio.ABM_Usuario.Alta_Usuario
{
    public partial class DatosEmpresaNuevo : Form
    {
        public string username;
        public string password;
        public string email;
        public List<Rubro> rubros;

        public DatosEmpresaNuevo(string username, string password, string email)
        {
            
            //comboBox1.SelectedIndex = 0;
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.email = email;
            cargar_rubros();
            cmbRubros.SelectedIndex = 0;
        }


        public void cargar_rubros(){

            string comando = "select rubro_id, descripcion_corta from dbme.rubro";
            DataTable dataroles = (new ConexionSQL()).cargarTablaSQL(comando);
            rubros = new List<Rubro>();

            //obtener los roles HABILITADOS de la data

            for (int i = 0; i <= (dataroles.Rows.Count - 1); i++)
            {
               // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                rubros.Add(new Rubro(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
            }

            for (int j = 0; j < rubros.Count ; j++)
            {
                // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                string desc = rubros[j].descripcion_corta;
                cmbRubros.Items.Add(desc);
            }

        }


        private void DatosEmpresaNuevo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string razon_social = txtRazonSocial.Text;
            string nombre = txtNombre.Text;
            string CUIT = txtCUIT.Text;
            uint rubro;

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
                rubro = rubros[cmbRubros.SelectedIndex].rubro_id;
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
                
                string comando = "EXECUTE DBME.nuevaEmpresa '" + username + "','" + password + "','" + email + "','" + nombre + "','" + razon_social + "','" + CUIT + "'," + rubro  + ",'" + ciudad + "','" + localidad + "','" + codigo_postal + "','" + domicilio_calle + "','" + altura_calle + "','" + numero_piso + "','" + departamento + "','" + numero_telefono + "'";
                //MessageBox.Show(comando, "Alta", MessageBoxButtons.OK);
                (new ConexionSQL()).ejecutarComandoSQL(comando);
                MessageBox.Show("Empresa creada exitosamente", "Alta Empresa", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
