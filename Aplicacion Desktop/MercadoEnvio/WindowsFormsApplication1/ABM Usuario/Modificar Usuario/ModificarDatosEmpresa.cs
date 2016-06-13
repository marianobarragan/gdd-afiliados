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

namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    public partial class ModificarDatosEmpresa : Form
    {
        public uint empresa_id;
        public List<Rubro> rubros;

        public ModificarDatosEmpresa(uint id2)
        {
            empresa_id = id2;
            InitializeComponent();
            cargar_rubros();
            cmbRubros.SelectedIndex = 0;
        }

        public void cargar_rubros()
        {

            string comando = "select rubro_id, descripcion_corta from dbme.rubro";
            DataTable dataroles = (new ConexionSQL()).cargarTablaSQL(comando);
            rubros = new List<Rubro>();

            //obtener los roles HABILITADOS de la data

            for (int i = 0; i <= (dataroles.Rows.Count - 1); i++)
            {
                // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                rubros.Add(new Rubro(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
            }

            for (int j = 0; j < rubros.Count; j++)
            {
                // rubros.Add(obtenerRol(dataroles.Rows[i][0].ToString(), dataroles.Rows[i][1].ToString()));
                string desc = rubros[j].descripcion_corta;
                cmbRubros.Items.Add(desc);
            }

        }

        private void ModificarDatosEmpresa_Load(object sender, EventArgs e)
        {
            string comando = "SELECT e.razon_social,e.nombre_contacto,e.cuit,e.rubro_id,u.telefono, d.ciudad, d.localidad, d.codigo_postal,d.domicilio_calle,d.numero_calle, d.piso, d.departamento FROM DBME.empresa e JOIN DBME.usuario u ON (e.usuario_id = u.usuario_id) JOIN DBME.domicilio d ON (u.domicilio_id = d.domicilio_id) WHERE empresa_id = " + empresa_id;
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            txtRazonSocial.Text = dt.Rows[0][0].ToString();
            txtNombre.Text = dt.Rows[0][1].ToString();
            txtCUIT.Text = dt.Rows[0][2].ToString();
            cmbRubros.SelectedIndex = Int32.Parse(dt.Rows[0][3].ToString());
            txtNumeroTelefono.Text = dt.Rows[0][4].ToString();
            txtCiudad.Text = dt.Rows[0][5].ToString();
            txtLocalidad.Text = dt.Rows[0][6].ToString();
            txtCodigoPostal.Text = dt.Rows[0][7].ToString();
            txtDomicilioCalle.Text = dt.Rows[0][8].ToString();
            txtAlturaCalle.Text = dt.Rows[0][9].ToString();
            txtNumeroPiso.Text = dt.Rows[0][10].ToString();
            txtDepartamento.Text = dt.Rows[0][11].ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

                string comando = "EXECUTE DBME.updateEmpresa " + empresa_id + ",'" + nombre + "','" + razon_social + "','" + CUIT + "'," + rubro + ",'" + ciudad + "','" + localidad + "','" + codigo_postal + "','" + domicilio_calle + "','" + altura_calle + "','" + numero_piso + "','" + departamento + "','" + numero_telefono + "'";
                //MessageBox.Show(comando, "Update", MessageBoxButtons.OK);
                (new ConexionSQL()).ejecutarComandoSQL(comando);
                MessageBox.Show("Empresa actualizada exitosamente", "Update", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
