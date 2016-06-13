namespace MercadoEnvio.Calificar
{
    partial class ListadoDePublicacionesSinCalificar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.calificarOperacion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calificarOperacion);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calificaciones Restantes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(474, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // calificarOperacion
            // 
            this.calificarOperacion.Location = new System.Drawing.Point(12, 190);
            this.calificarOperacion.Name = "calificarOperacion";
            this.calificarOperacion.Size = new System.Drawing.Size(154, 23);
            this.calificarOperacion.TabIndex = 1;
            this.calificarOperacion.Text = "Calificar Operacion";
            this.calificarOperacion.UseVisualStyleBackColor = true;
            this.calificarOperacion.Click += new System.EventHandler(this.calificarOperacion_Click);
            // 
            // ListadoDePublicacionesSinCalificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 341);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoDePublicacionesSinCalificar";
            this.Text = "ListadoDePublicacionesSinCalificar";
            this.Load += new System.EventHandler(this.ListadoDePublicacionesSinCalificar_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button calificarOperacion;
    }
}