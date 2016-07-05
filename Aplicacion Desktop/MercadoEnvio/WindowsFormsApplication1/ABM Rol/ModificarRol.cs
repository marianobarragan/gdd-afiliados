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


namespace MercadoEnvio.ABM_Rol
{
    public partial class ModificarRol : Form
    {
        public string nombreRol;
        public string check;

        public ModificarRol(string contenido)
        {
            InitializeComponent();
            nombreRol = contenido;
            txtNombreRol.Text = nombreRol;
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

            string comando1 = "SELECT descripcion FROM DBME.rol r JOIN DBME.rol_x_funcionalidad rxf ON (r.rol_id = rxf.rol_id) JOIN DBME.funcionalidad f ON (rxf.funcionalidad_id = f.funcionalidad_id)	WHERE r.nombre_rol = '" + nombreRol + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando1);



            lstFuncionesActuales.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                //int idf = Convert.ToInt32(dt.Rows[i][0]);
                lstFuncionesActuales.Items.Add(dt.Rows[i][0]);
                //lstTodasLasFunciones.Items.Insert(i, new Funcionalidad(idf, dt.Rows[i][1].ToString(), this));
            }

            
            string comando = "SELECT descripcion FROM DBME.funcionalidad f WHERE f.descripcion NOT IN (	SELECT descripcion FROM DBME.rol r JOIN DBME.rol_x_funcionalidad rxf ON (r.rol_id = rxf.rol_id) JOIN DBME.funcionalidad f ON (rxf.funcionalidad_id = f.funcionalidad_id) WHERE r.nombre_rol = '"+nombreRol +"')";
            DataTable dt2 = (new ConexionSQL()).cargarTablaSQL(comando);


            lstTodasLasFunciones.Items.Clear();
            for (int i = 0; i <= (dt2.Rows.Count - 1); i++)
            {
                //int idf = Convert.ToInt32(dt.Rows[i][0]);

                lstTodasLasFunciones.Items.Add(dt2.Rows[i][0]);
                /*if (noContieneLaFuncion(lstTodasLasFunciones.GetItemText(lstTodasLasFunciones.Items[i])))
                {
                    
                }*/
                
                //lstTodasLasFunciones.Items.Insert(i, new Funcionalidad(idf, dt.Rows[i][1].ToString(), this));
            }

            string comando3 = "SELECT es_rol_habilitado FROM DBME.rol WHERE nombre_rol  = '"+nombreRol +"'";
            DataTable dt3 = (new ConexionSQL()).cargarTablaSQL(comando3);
            //MessageBox.Show(dt3.Rows[0][0].ToString() + "  nombre rol : " + nombreRol, "BAUZA", MessageBoxButtons.OK);
            if (dt3.Rows[0][0].ToString() == "True")
            {
                chkEstaHabilitado.Checked = true;
                check = "1";
            }
            else
            {
                chkEstaHabilitado.Checked = false;
                check = "0";
            }

        }
        
        public bool noContieneLaFuncion(string funcion)
        {
            for (int i = 0; i < lstFuncionesActuales.Items.Count; i++)
            {
                if (lstFuncionesActuales.GetItemText(lstFuncionesActuales.Items[i]).ToString() == funcion)
                {
                    return false;
                }
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            


            try
            {
                //string porcentajeString = txtPorcentaje.Text.Insert(0, "0.");
                DialogResult h = MessageBox.Show("¿Seguro que desea modificar el rol?", "MODIFICAR ROL", MessageBoxButtons.YesNo);
                string comando1;
                string comando2;
                if (h == DialogResult.Yes)
                {
                    //comando = "UPDATE DBME.visibilidad SET visibilidad_descripcion = '" + txtDescripcion.Text + "',visibilidad_precio = " + txtPrecio.Text + "." + txtPrecioDecimal.Text + ",visibilidad_porcentaje = " + porcentajeString + ",visibilidad_costo_envio = " + txtCostoEnvio.Text + "." + txtCostoEnvioDecimal.Text + " WHERE visibilidad_id = " + id;
                    
                    comando1 = "UPDATE DBME.rol SET nombre_rol = '" + txtNombreRol.Text + "', es_rol_habilitado = "  + check + " WHERE nombre_rol = '" + nombreRol + "'";
                    //MessageBox.Show(comando1, "a", MessageBoxButtons.OK);
                    (new ConexionSQL()).ejecutarComandoSQL(comando1);
                    comando2 = "DELETE FROM DBME.rol_x_funcionalidad WHERE rol_id = (SELECT rol_id FROM DBME.rol WHERE nombre_rol = '"+nombreRol+"')";
                    (new ConexionSQL()).ejecutarComandoSQL(comando2);
                    if (lstFuncionesActuales.Items.Count > 0)
                    {

                        for (int i = 0; i < lstFuncionesActuales.Items.Count; i++) // agregar elementos al combobox
                        {

                            comando2 = "EXECUTE DBME.enlazarRolXFuncionalidad '" + txtNombreRol.Text + "','" + lstFuncionesActuales.GetItemText(lstFuncionesActuales.Items[i]).ToString() + "'";
                            (new ConexionSQL()).ejecutarComandoSQL(comando2);

                        }

                    }
                    
                    this.Close();

                }
                return;

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Modificar Rol", MessageBoxButtons.OK);
                return;
            }



        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void chkEstaHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstaHabilitado.Checked == true)
            {
                check = "1";
            }
            else
            {
                check = "0";
            }
        }
    }
}
