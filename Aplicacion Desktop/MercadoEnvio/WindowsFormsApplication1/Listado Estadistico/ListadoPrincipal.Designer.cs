namespace MercadoEnvio.Listado_Estadistico
{
    partial class ListadoPrincipal
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstVisibilidad = new System.Windows.Forms.ListBox();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.lstMes = new System.Windows.Forms.ListBox();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.lstTrimestre = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstVisibilidad);
            this.groupBox1.Controls.Add(this.txtRubro);
            this.groupBox1.Controls.Add(this.lstMes);
            this.groupBox1.Controls.Add(this.txtAño);
            this.groupBox1.Controls.Add(this.lstTrimestre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 240);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Rubro particular:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(784, 171);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 40);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Año:";
            // 
            // lstVisibilidad
            // 
            this.lstVisibilidad.FormattingEnabled = true;
            this.lstVisibilidad.Location = new System.Drawing.Point(489, 40);
            this.lstVisibilidad.Name = "lstVisibilidad";
            this.lstVisibilidad.Size = new System.Drawing.Size(120, 160);
            this.lstVisibilidad.TabIndex = 10;
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(344, 17);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(100, 20);
            this.txtRubro.TabIndex = 9;
            this.txtRubro.Text = "rubro particular";
            // 
            // lstMes
            // 
            this.lstMes.FormattingEnabled = true;
            this.lstMes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.lstMes.Location = new System.Drawing.Point(68, 43);
            this.lstMes.Name = "lstMes";
            this.lstMes.Size = new System.Drawing.Size(142, 160);
            this.lstMes.TabIndex = 8;
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(68, 17);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(142, 20);
            this.txtAño.TabIndex = 7;
            this.txtAño.Text = "año obligatorio";
            // 
            // lstTrimestre
            // 
            this.lstTrimestre.FormattingEnabled = true;
            this.lstTrimestre.Items.AddRange(new object[] {
            "Primer trimestre",
            "Segundo trimestre",
            "Tercer trimestre"});
            this.lstTrimestre.Location = new System.Drawing.Point(754, 62);
            this.lstTrimestre.Name = "lstTrimestre";
            this.lstTrimestre.Size = new System.Drawing.Size(100, 69);
            this.lstTrimestre.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(953, 308);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(244, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(244, 100);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 17;
            // 
            // ListadoPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(986, 770);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ListadoPrincipal";
            this.Text = "ListadoPrincipal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstVisibilidad;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.ListBox lstMes;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.ListBox lstTrimestre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;

    }
}