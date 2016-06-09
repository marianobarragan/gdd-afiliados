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

        public ModificarRol(string contenido)
        {
            InitializeComponent();
            nombreRol = contenido;

        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

            string comando1 = "SELECT descripcion FROM DBME.rol r JOIN DBME.rol_x_funcionalidad rxf ON (r.rol_id = rxf.rol_id) JOIN DBME.funcionalidad f ON (rxf.funcionalidad_id = f.funcionalidad_id)	WHERE r.nombre_rol = '" + nombreRol + "'";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(comando1);

            lstFuncionalidadesActuales.Items.Clear();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                //int idf = Convert.ToInt32(dt.Rows[i][0]);
                lstFuncionalidadesActuales.Items.Add(dt.Rows[i][0]);
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
            
        }
        
        public bool noContieneLaFuncion(string funcion)
        {
            for (int i = 0; i < lstFuncionalidadesActuales.Items.Count; i++)
            {
                if (lstFuncionalidadesActuales.GetItemText(lstFuncionalidadesActuales.Items[i]).ToString() == funcion)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
