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

namespace MercadoEnvio.ABM_Rubro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string comando = "select c.apellido, c.nombre, c.tipo_documento, c.numero_documento, c.fecha_nacimiento, u.telefono, d.ciudad, d.localidad, d.codigo_postal,d.domicilio_calle,d.numero_calle, d.piso, d.departamento from dbme.cliente c JOIN DBME.usuario u ON (u.usuario_id = c.usuario_id) JOIN DBME.domicilio d ON (u.domicilio_id = d.domicilio_id) WHERE cliente_id = " + 29;
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            
            //MessageBox.Show(dt.Rows[0][4].ToString() + " mi date es: " + dateNacimiento.Value, "A", MessageBoxButtons.OK);
            dateTimePicker1.Value = DateTime.Parse(dt.Rows[0][4].ToString());
        }
    }
}
