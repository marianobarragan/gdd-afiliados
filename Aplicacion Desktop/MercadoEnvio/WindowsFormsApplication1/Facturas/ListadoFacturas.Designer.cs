namespace MercadoEnvio.Facturas
{
    partial class ListadoFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAccion = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDirigida = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinIntervalo = new System.Windows.Forms.TextBox();
            this.txtInicioIntervalo = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chkDetalles = new System.Windows.Forms.CheckBox();
            this.chkImporte = new System.Windows.Forms.CheckBox();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDirigida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccion
            // 
            this.btnAccion.Location = new System.Drawing.Point(472, 625);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(130, 40);
            this.btnAccion.TabIndex = 12;
            this.btnAccion.Text = "Ver";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(590, 395);
            this.dataGridView1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDirigida);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFinIntervalo);
            this.groupBox1.Controls.Add(this.txtInicioIntervalo);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.chkDetalles);
            this.groupBox1.Controls.Add(this.chkImporte);
            this.groupBox1.Controls.Add(this.chkFechas);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtDirigida);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContenido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 195);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Facturas";
            // 
            // chkDirigida
            // 
            this.chkDirigida.AutoSize = true;
            this.chkDirigida.Checked = true;
            this.chkDirigida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDirigida.Location = new System.Drawing.Point(411, 162);
            this.chkDirigida.Name = "chkDirigida";
            this.chkDirigida.Size = new System.Drawing.Size(15, 14);
            this.chkDirigida.TabIndex = 16;
            this.chkDirigida.UseVisualStyleBackColor = true;
            this.chkDirigida.CheckedChanged += new System.EventHandler(this.chkDirigida_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "A quien está dirigida (username)";
            // 
            // txtFinIntervalo
            // 
            this.txtFinIntervalo.BackColor = System.Drawing.Color.PaleGreen;
            this.txtFinIntervalo.Location = new System.Drawing.Point(304, 81);
            this.txtFinIntervalo.Name = "txtFinIntervalo";
            this.txtFinIntervalo.Size = new System.Drawing.Size(85, 20);
            this.txtFinIntervalo.TabIndex = 14;
            // 
            // txtInicioIntervalo
            // 
            this.txtInicioIntervalo.BackColor = System.Drawing.Color.PaleGreen;
            this.txtInicioIntervalo.Location = new System.Drawing.Point(189, 80);
            this.txtInicioIntervalo.Name = "txtInicioIntervalo";
            this.txtInicioIntervalo.Size = new System.Drawing.Size(93, 20);
            this.txtInicioIntervalo.TabIndex = 13;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(189, 48);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(189, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // chkDetalles
            // 
            this.chkDetalles.AutoSize = true;
            this.chkDetalles.Checked = true;
            this.chkDetalles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDetalles.Location = new System.Drawing.Point(411, 127);
            this.chkDetalles.Name = "chkDetalles";
            this.chkDetalles.Size = new System.Drawing.Size(15, 14);
            this.chkDetalles.TabIndex = 10;
            this.chkDetalles.UseVisualStyleBackColor = true;
            this.chkDetalles.CheckedChanged += new System.EventHandler(this.chkDetalles_CheckedChanged);
            // 
            // chkImporte
            // 
            this.chkImporte.AutoSize = true;
            this.chkImporte.Checked = true;
            this.chkImporte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImporte.Location = new System.Drawing.Point(411, 87);
            this.chkImporte.Name = "chkImporte";
            this.chkImporte.Size = new System.Drawing.Size(15, 14);
            this.chkImporte.TabIndex = 9;
            this.chkImporte.UseVisualStyleBackColor = true;
            this.chkImporte.CheckedChanged += new System.EventHandler(this.chkImporte_CheckedChanged);
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.Checked = true;
            this.chkFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechas.Location = new System.Drawing.Point(411, 28);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(15, 14);
            this.chkFechas.TabIndex = 8;
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(445, 51);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(445, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDirigida
            // 
            this.txtDirigida.Location = new System.Drawing.Point(189, 158);
            this.txtDirigida.Name = "txtDirigida";
            this.txtDirigida.Size = new System.Drawing.Size(200, 20);
            this.txtDirigida.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intervalo de fechas";
            // 
            // txtContenido
            // 
            this.txtContenido.Location = new System.Drawing.Point(189, 121);
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(200, 20);
            this.txtContenido.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Intervalos de importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contenido de detalles de factura";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Crimson;
            this.btnSiguiente.Font = new System.Drawing.Font("Wingdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSiguiente.Location = new System.Drawing.Point(314, 625);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(119, 45);
            this.btnSiguiente.TabIndex = 14;
            this.btnSiguiente.Text = "è";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAnterior.Font = new System.Drawing.Font("Wingdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAnterior.Location = new System.Drawing.Point(189, 625);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(119, 45);
            this.btnAnterior.TabIndex = 13;
            this.btnAnterior.Text = "ç";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // ListadoFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(617, 677);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnAccion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ListadoFacturas";
            this.Text = "ListadoFacturas";
            this.Load += new System.EventHandler(this.ListadoFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDetalles;
        private System.Windows.Forms.CheckBox chkImporte;
        private System.Windows.Forms.CheckBox chkFechas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDirigida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFinIntervalo;
        private System.Windows.Forms.TextBox txtInicioIntervalo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDirigida;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
    }
}