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

namespace MercadoEnvio.ComprarOfertar
{
    public partial class ListadoPublicaciones : Form
    {
        public Sesion sesionActual;
        public List<Rubro> rubros;
        public string queryRubros;
        public DataTable dt;
        public int pagina_actual;
        public int paginas_totales;

        public ListadoPublicaciones(Sesion sesion)
        {
            InitializeComponent();
            sesionActual = sesion;

            cargar_rubros();
            chklRubros.SelectedIndex = 0;
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
                chklRubros.Items.Add(desc);
            }
            btnSeleccionarTodosLosRubros_Click(null, null);
        }

        private void armarQueryRubros() {
           
            queryRubros = " AND r.descripcion_corta IN (";
            
            foreach (String rubro_string in chklRubros.CheckedItems)
            {
                queryRubros = queryRubros + "'"+ rubro_string +"',";
            }
            queryRubros = queryRubros + "'asasas')";
            //MessageBox.Show(queryRubros, "T", MessageBoxButtons.OK);
        }

        private void ListadoPublicaciones_Load(object sender, EventArgs e)
        {
            
        }

        public void actualizar_busqueda()
        {
            btnBuscar_Click(null,null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query;
            armarQueryRubros();

            query = "SELECT p.publicacion_id, p.publicacion_tipo, p.descripcion, p.stock, p.valor_actual, p.precio, p.estado, p.autor_id, p.permite_preguntas, p.realiza_envio, r.descripcion_corta, v.visibilidad_descripcion FROM DBME.publicacion p JOIN DBME.rubro r ON (r.rubro_id = p.rubro_id ) JOIN DBME.visibilidad v ON (p.visibilidad_id = v.visibilidad_id) WHERE p.fecha_creacion < DBME.getHoraDelSistema() AND p.autor_id !=" + sesionActual.usuarioActual.usuario_id + " AND p.descripcion LIKE '%" + txtDescripción.Text + "%'" + queryRubros + " AND (p.estado = 'ACTIVA' OR p.estado = 'PAUSADA') ORDER BY v.visibilidad_precio, p.fecha_creacion DESC";

            

            dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }

            paginas_totales = dt.Rows.Count / 50;
            mostrar_pagina(1);

            
        }

        private void mostrar_pagina(int numero_pagina)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }

            DataTable pagina = new DataTable();
            pagina = dt.Clone();

            int inicio = (numero_pagina - 1) * 50;

            if (dt.Rows.Count < 50)         // caso excepcional, solo si hay menos de 50 resultados
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pagina.ImportRow(dt.Rows[i]);
                }

                dataGridView1.DataSource = pagina;
                return;
            }

            for (int i = inicio; i < (inicio + 50); i++)
            {
                pagina.ImportRow(dt.Rows[i]);
            }

            dataGridView1.DataSource = pagina;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtDescripción.Text = null;
            chklRubros.Items.Clear();
            cargar_rubros();
            chklRubros.SelectedIndex = 0;

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM DBME.compra WHERE (autor_id = " + sesionActual.usuarioActual.usuario_id + " AND esta_calificada = 0)";
            DataTable dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            
            int cantidadComprasSinCalificar = Int32.Parse(dt.Rows[0][0].ToString());

            if (cantidadComprasSinCalificar > 3)
            {
                MessageBox.Show("Tiene más de 3 compras sin calificar. No puede realizar más compras", "Problema", MessageBoxButtons.OK);
                this.Close();
                return;
            }
                        
            int publicacion_id = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            string tipo = (dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            string descripcion = (dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            int stock = Int32.Parse(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            double precio;
            string estado = (dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value.ToString());

            if (estado == "PAUSADA")
            {
                MessageBox.Show("No puede ofertar/comprar en una publicación pausada.", "Problema", MessageBoxButtons.OK);
                return;
            }

            //MessageBox.Show(tipo, "hol", MessageBoxButtons.OK);
            if (tipo == "Compra Inmediata")
             {
                 /* p.publicacion_id, p.publicacion_tipo, p.descripcion, p.stock, p.precio, p.autor_id, p.permite_preguntas, p.realiza_envio, r.descripcion_corta, v.visibilidad_descripcion */

                 /* string id,string descripcion,float precio,string stock,int usuario_id */
                 precio = Double.Parse(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString()); 
                ComprarOfertar.ComprarProducto comprarProducto = new ComprarProducto( publicacion_id, descripcion, precio, stock, sesionActual.usuarioActual.usuario_id, this);
                 //ComprarOfertar.ComprarProducto comprarProducto = new ComprarOfertar.ComprarProducto(,,,,sesionActual.usuarioActual.usuario_id); //id,string descripcion,float precio,string stock,int usuario_id
                comprarProducto.Show();
            }
            else{
                precio = Double.Parse(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                ComprarOfertar.OfertarProducto ofertarProducto = new ComprarOfertar.OfertarProducto(publicacion_id, descripcion, precio, stock, sesionActual.usuarioActual.usuario_id, this);
                ofertarProducto.Show();

            }
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            if (pagina_actual == 1) {
                return;
            }
            pagina_actual -= 1;
            try
            {
                mostrar_pagina(pagina_actual);
            }
            catch { 
            
            }

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            if (pagina_actual >= paginas_totales)
            {
                return;
            }
            pagina_actual += 1;
            try
            {
                mostrar_pagina(pagina_actual);
            }
            catch
            {

            }
        }

        private void btnSeleccionarTodosLosRubros_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklRubros.Items.Count; i++)
            {
                chklRubros.SetItemChecked(i, true);
            }
    
        }

        private void btnDeseleccionarTodosLosRubros_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklRubros.Items.Count; i++)
            {
                chklRubros.SetItemChecked(i, false);
            }
        }
        
    }
}
