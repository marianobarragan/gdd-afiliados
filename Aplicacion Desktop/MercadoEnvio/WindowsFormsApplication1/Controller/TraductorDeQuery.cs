﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MercadoEnvio.Controller
{
    public class TraductorDeQuery
    {
        public void llenarLaTablita(string query, DataGridView dataGrid)
        {
            //ConexionSQL conn = new ConexionSQL();
            //DataTable dt = conn.cargarTablaSQL(query);
            
            /*
            try
            {
                dataGrid.Columns.Remove("seleccionar");
            }
            catch { }
            dataGrid.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado resultados en la consulta", "Fallo la busqueda", MessageBoxButtons.OK);

            }
            else
            {

                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Seleccionar";
                boton.HeaderText = "Seleccionar";
                boton.Text = "Seleccionar";
                boton.UseColumnTextForButtonValue = true;
                dataGrid.Columns.Insert(dataGrid.Columns.Count, boton);
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }*/
        }
            
    }
}