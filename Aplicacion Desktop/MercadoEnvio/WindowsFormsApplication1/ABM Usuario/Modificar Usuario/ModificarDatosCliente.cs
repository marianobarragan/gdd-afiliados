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

namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    public partial class ModificarDatosCliente : Form
    {
        public uint cliente_id;

        public ModificarDatosCliente(uint id2)
        {
            cliente_id = id2;
            InitializeComponent();
        }

        private void ModificarDatosCliente_Load(object sender, EventArgs e)
        {
            string comando = "select c.apellido, c.nombre, c.tipo_documento, c.numero_documento, c.fecha_nacimiento, u.telefono, d.ciudad, d.localidad, d.codigo_postal,d.domicilio_calle,d.numero_calle, d.piso, d.departamento from dbme.cliente JOIN DBME.usuario ON (u.usuario_id = c.usuario_id) JOIN DBME.domicilio d ON (u.domicilio_id = d.domicilio_id) WHERE cliente_id = " + cliente_id;
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            txtApellido.Text = dt.Rows[0][0].ToString();

            //DataTable dataVisibilidad = (new ConexionSQL()).cargarTablaSQL(comando);
        }

        private void btnCrear_Click(object sender, EventArgs e)
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
            catch (System.OverflowException)
            {
                MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nuevo Cliente", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
