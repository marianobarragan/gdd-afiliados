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

namespace MercadoEnvio.Generar_Publicación
{
    public partial class ListadoPublicacionesUsuario : Form
    {

        public DataTable dt;
        public int pagina_actual;
        public int paginas_totales;
        Sesion sesion_actual;

        public ListadoPublicacionesUsuario(Sesion sesion)
        {
            InitializeComponent();
            this.sesion_actual = sesion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query;

            query = "SELECT p.publicacion_id, p.publicacion_tipo, p.descripcion, p.estado, p.stock, p.precio, p.autor_id, p.permite_preguntas, p.realiza_envio, r.descripcion_corta, v.visibilidad_descripcion FROM DBME.publicacion p JOIN DBME.rubro r ON (r.rubro_id = p.rubro_id ) JOIN DBME.visibilidad v ON (p.visibilidad_id = v.visibilidad_id) where p.estado = 'BORRADOR' OR p.estado = 'PAUSADA' OR p.estado = 'ACTIVA'  ORDER BY v.visibilidad_precio DESC";



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
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            int publicacion_id = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            string tipo = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            
            if (tipo == "Compra Inmediata")
            {

                /* p.publicacion_id, p.publicacion_tipo, p.descripcion, p.stock, p.precio, p.autor_id, p.permite_preguntas, p.realiza_envio, r.descripcion_corta, v.visibilidad_descripcion */

                /* string id,string descripcion,float precio,string stock,int usuario_id */
                ModificarCompraInmediata mod = new ModificarCompraInmediata(publicacion_id, sesion_actual);
                mod.Show();
                this.Close();
                //ComprarOfertar.ComprarProducto comprarProducto = new ComprarProducto(publicacion_id, descripcion, precio, stock, sesionActual.usuarioActual.usuario_id);
                
                //comprarProducto.Show();
            }
            else
            {

                //ComprarOfertar.OfertarProducto ofertarProducto = new ComprarOfertar.OfertarProducto(publicacion_id, descripcion, precio, stock, sesionActual.usuarioActual.usuario_id);
                //ofertarProducto.Show();

            }


        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pagina_actual == 1)
            {
                return;
            }
            pagina_actual -= 1;
            try
            {
                mostrar_pagina(pagina_actual);
            }
            catch
            {

            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
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

    }
}
