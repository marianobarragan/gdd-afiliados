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

namespace MercadoEnvio.ABM_Rol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*for (int i = 0; i < sesion.listaFuncionalidades.Count; i++) // agregar elementos al combobox
            {
                lstFunciones.Items.Add(sesion.listaFuncionalidades[i].descripcion);
            }
            lstFunciones.SelectedIndex = 0;*/

            string comando = "select * from dbme.funcionalidad";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando);

            
            lstTodasLasFunciones.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                //int idf = Convert.ToInt32(dt.Rows[i][0]);
                lstTodasLasFunciones.Items.Add(dt.Rows[i][1]);
                //lstTodasLasFunciones.Items.Insert(i, new Funcionalidad(idf, dt.Rows[i][1].ToString(), this));
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lstFuncionesActuales.Items.Add(lstTodasLasFunciones.SelectedItem.ToString());
                lstTodasLasFunciones.Items.RemoveAt(lstTodasLasFunciones.SelectedIndex);
                lstFuncionesActuales.SelectedIndex = 0;
                lstTodasLasFunciones.SelectedIndex = 0;
                button3.Enabled = true;
                if (lstTodasLasFunciones.Items.Count == 0) { button1.Enabled = false; }
            }
            catch { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtNombreRol.Text == "") {
                MessageBox.Show("No ingreso el nombre del rol nuevo", "NUEVO ROL", MessageBoxButtons.OK);
            }

            string comando = "INSERT INTO DBME.rol (nombre_rol,es_rol_habilitado) VALUES ('" + txtNombreRol.Text + "','" + chkEstaHabilitado.Checked.ToString() + "')";
            (new ConexionSQL()).ejecutarComandoSQL(comando);

            if (lstFuncionesActuales.Items.Count > 0) {

                for (int i = 0; i < lstFuncionesActuales.Items.Count; i++) // agregar elementos al combobox
                {
                    
                    string comando2 = "EXECUTE DBME.enlazarRolXFuncionalidad '" + txtNombreRol.Text + "','" + lstFuncionesActuales.GetItemText(lstFuncionesActuales.Items[i]).ToString() + "'";
                    (new ConexionSQL()).ejecutarComandoSQL(comando2);
                    
                }
               
            }

            MessageBox.Show("Rol creado", "Login", MessageBoxButtons.OK);
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstFuncionesActuales.Items.Count == 0) { return; };
            try
            {
                lstTodasLasFunciones.Items.Add(lstFuncionesActuales.SelectedItem.ToString());
                lstFuncionesActuales.Items.RemoveAt(lstFuncionesActuales.SelectedIndex);
                lstTodasLasFunciones.SelectedIndex = 0;
                lstFuncionesActuales.SelectedIndex = 0;
                button1.Enabled = true;
                if (lstFuncionesActuales.Items.Count == 0) { button3.Enabled = false; };
            }
            catch { };
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
