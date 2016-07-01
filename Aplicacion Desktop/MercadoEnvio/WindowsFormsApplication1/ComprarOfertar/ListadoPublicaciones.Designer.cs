namespace MercadoEnvio.ComprarOfertar
{
    partial class ListadoPublicaciones
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAccion = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeseleccionarTodosLosRubros = new System.Windows.Forms.Button();
            this.btnSeleccionarTodosLosRubros = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtDescripción = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chklRubros = new System.Windows.Forms.CheckedListBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSiguiente);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnAccion);
            this.groupBox2.Controls.Add(this.btnAnterior);
            this.groupBox2.Location = new System.Drawing.Point(13, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(925, 401);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Crimson;
            this.btnSiguiente.Font = new System.Drawing.Font("Wingdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSiguiente.Location = new System.Drawing.Point(477, 342);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(119, 45);
            this.btnSiguiente.TabIndex = 12;
            this.btnSiguiente.Text = "è";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(912, 317);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnAccion
            // 
            this.btnAccion.Location = new System.Drawing.Point(779, 342);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(119, 33);
            this.btnAccion.TabIndex = 3;
            this.btnAccion.Text = "Siguiente";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAnterior.Font = new System.Drawing.Font("Wingdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAnterior.Location = new System.Drawing.Point(352, 342);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(119, 45);
            this.btnAnterior.TabIndex = 11;
            this.btnAnterior.Text = "ç";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeseleccionarTodosLosRubros);
            this.groupBox1.Controls.Add(this.btnSeleccionarTodosLosRubros);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtDescripción);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chklRubros);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 125);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // btnDeseleccionarTodosLosRubros
            // 
            this.btnDeseleccionarTodosLosRubros.Location = new System.Drawing.Point(223, 91);
            this.btnDeseleccionarTodosLosRubros.Name = "btnDeseleccionarTodosLosRubros";
            this.btnDeseleccionarTodosLosRubros.Size = new System.Drawing.Size(165, 23);
            this.btnDeseleccionarTodosLosRubros.TabIndex = 7;
            this.btnDeseleccionarTodosLosRubros.Text = "Deseleccionar todos los rubros";
            this.btnDeseleccionarTodosLosRubros.UseVisualStyleBackColor = true;
            this.btnDeseleccionarTodosLosRubros.Click += new System.EventHandler(this.btnDeseleccionarTodosLosRubros_Click);
            // 
            // btnSeleccionarTodosLosRubros
            // 
            this.btnSeleccionarTodosLosRubros.Location = new System.Drawing.Point(223, 63);
            this.btnSeleccionarTodosLosRubros.Name = "btnSeleccionarTodosLosRubros";
            this.btnSeleccionarTodosLosRubros.Size = new System.Drawing.Size(165, 23);
            this.btnSeleccionarTodosLosRubros.TabIndex = 6;
            this.btnSeleccionarTodosLosRubros.Text = "Seleccionar todos los rubros";
            this.btnSeleccionarTodosLosRubros.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodosLosRubros.Click += new System.EventHandler(this.btnSeleccionarTodosLosRubros_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(836, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(83, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(747, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtDescripción
            // 
            this.txtDescripción.Location = new System.Drawing.Point(354, 20);
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(117, 20);
            this.txtDescripción.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción (texto libre)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chklRubros
            // 
            this.chklRubros.FormattingEnabled = true;
            this.chklRubros.Location = new System.Drawing.Point(7, 20);
            this.chklRubros.Name = "chklRubros";
            this.chklRubros.ScrollAlwaysVisible = true;
            this.chklRubros.Size = new System.Drawing.Size(196, 94);
            this.chklRubros.TabIndex = 0;
            // 
            // ListadoPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(950, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoPublicaciones";
            this.Text = "ListadoPublicaciones";
            this.Load += new System.EventHandler(this.ListadoPublicaciones_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.TextBox txtDescripción;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chklRubros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSeleccionarTodosLosRubros;
        private System.Windows.Forms.Button btnDeseleccionarTodosLosRubros;
    }
}