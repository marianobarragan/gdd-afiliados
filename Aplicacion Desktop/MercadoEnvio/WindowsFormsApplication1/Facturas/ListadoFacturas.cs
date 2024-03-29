﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Facturas;

namespace MercadoEnvio.Facturas
{
    public partial class ListadoFacturas : Form
    {

        public int usuario_id;
        public DataTable dt;
        public int pagina_actual;
        public int paginas_totales;
        string query;

        public ListadoFacturas(int usuario_id)
        {
            this.usuario_id = usuario_id;
            InitializeComponent();
        }


        private void btnAccion_Click(object sender, EventArgs e)
        {
            int id2 = Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());

            DetalleFactura detalle = new DetalleFactura(id2);
            detalle.Show();

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

        private void ListadoFacturas_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Value = DateTime.Parse(Program.fechaSistema() + 1);
            dateTimePicker2.Value = DateTime.Parse(Program.fechaSistema() + 1);

            query = "SELECT * FROM DBME.factura";

            /*
            dt = (new Controller.ConexionSQL().cargarTablaSQL(query));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados", "Problema", MessageBoxButtons.OK);
                dataGridView1.DataSource = null;
                return;
            }
            */

        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = chkFechas.Checked;
            dateTimePicker2.Enabled = chkFechas.Checked;

        }

        private void chkImporte_CheckedChanged(object sender, EventArgs e)
        {
            txtInicioIntervalo.Enabled = chkImporte.Checked;
            txtFinIntervalo.Enabled = chkImporte.Checked;
        }

        private void chkDetalles_CheckedChanged(object sender, EventArgs e)
        {
            txtContenido.Enabled = chkDetalles.Checked;
        }

        private void chkDirigida_CheckedChanged(object sender, EventArgs e)
        {
            txtDirigida.Enabled = chkDirigida.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint inicio_intervalo;
            uint fin_intervalo;
            DateTime fecha_inicio;
            DateTime fecha_fin;

            query = "SELECT f.factura_id,f.publicacion_id,f.fecha,f.monto_total,f.usuario_id, d.tipo_de_item FROM DBME.factura f JOIN DBME.factura_detalle d ON (f.factura_id = d.factura_id) where f.factura_id IS NOT NULL";

            if (chkFechas.Checked)
            {
                fecha_inicio = DateTime.Parse(dateTimePicker1.Text);
                fecha_fin = DateTime.Parse(dateTimePicker2.Text);

                query += " AND f.fecha BETWEEN '" + fecha_inicio + "' AND '" + fecha_fin + "'";
            }

            if (chkImporte.Checked)
            {
                try
                {
                    inicio_intervalo = UInt32.Parse(txtInicioIntervalo.Text);
                    fin_intervalo = UInt32.Parse(txtFinIntervalo.Text);
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
                if (inicio_intervalo < 0 || fin_intervalo < 0)
                {
                    MessageBox.Show("Ingrese numeros positivos en los formularios verdes", "Nuevo Cliente", MessageBoxButtons.OK);
                    return;
                }

                query += " AND f.monto_total BETWEEN " + inicio_intervalo + " AND " + fin_intervalo;
            }

            if (chkDetalles.Checked)
            {
                query += " AND d.tipo_de_item LIKE '%" + txtContenido.Text + "%'";
            }

            if (chkDirigida.Checked)
            {
                query += " AND f.factura_id IN ( SELECT f.factura_id FROM dbme.factura f JOIN dbme.usuario u ON (u.usuario_id = f.usuario_id) WHERE u.username LIKE '%" + txtDirigida.Text + "%') ORDER BY f.fecha desc, f.factura_id";
            }

            ;

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkFechas.Checked = false;
            chkImporte.Checked = false;
            chkDetalles.Checked = false;
            chkDirigida.Checked = false;
            txtInicioIntervalo.Text = null;
            txtFinIntervalo.Text = null;
            txtContenido.Text = null;
            txtDirigida.Text = null;
            dataGridView1.DataSource = null;
        }
    }
}