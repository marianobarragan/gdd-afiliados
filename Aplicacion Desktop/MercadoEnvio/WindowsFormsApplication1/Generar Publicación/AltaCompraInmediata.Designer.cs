namespace MercadoEnvio.Generar_Publicación
{
    partial class AltaCompraInmediata
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
            this.txtPrecioDecimal = new System.Windows.Forms.TextBox();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.chkPermitePreguntas = new System.Windows.Forms.CheckBox();
            this.dateFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.cmbRubros = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2l = new System.Windows.Forms.Label();
            this.lpo = new System.Windows.Forms.Label();
            this.lblcosto_envio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.chkRealizaEnvio = new System.Windows.Forms.CheckBox();
            this.cmbVisibilidad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cmdGenerarCompra = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripción = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrecioDecimal);
            this.groupBox1.Controls.Add(this.dateFechaInicio);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.chkPermitePreguntas);
            this.groupBox1.Controls.Add(this.dateFechaVencimiento);
            this.groupBox1.Controls.Add(this.cmbRubros);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtStock);
            this.groupBox1.Controls.Add(this.cmdGenerarCompra);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescripción);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 369);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Compra Inmediata";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtPrecioDecimal
            // 
            this.txtPrecioDecimal.BackColor = System.Drawing.Color.PaleGreen;
            this.txtPrecioDecimal.Location = new System.Drawing.Point(214, 170);
            this.txtPrecioDecimal.Name = "txtPrecioDecimal";
            this.txtPrecioDecimal.Size = new System.Drawing.Size(72, 20);
            this.txtPrecioDecimal.TabIndex = 41;
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Location = new System.Drawing.Point(133, 248);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(226, 20);
            this.dateFechaInicio.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Fecha de Inicio";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "BORRADOR",
            "ACTIVA",
            "PAUSADA"});
            this.cmbEstado.Location = new System.Drawing.Point(135, 313);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(151, 21);
            this.cmbEstado.TabIndex = 37;
            // 
            // chkPermitePreguntas
            // 
            this.chkPermitePreguntas.AutoSize = true;
            this.chkPermitePreguntas.Location = new System.Drawing.Point(520, 275);
            this.chkPermitePreguntas.Name = "chkPermitePreguntas";
            this.chkPermitePreguntas.Size = new System.Drawing.Size(15, 14);
            this.chkPermitePreguntas.TabIndex = 36;
            this.chkPermitePreguntas.UseVisualStyleBackColor = true;
            // 
            // dateFechaVencimiento
            // 
            this.dateFechaVencimiento.Location = new System.Drawing.Point(133, 277);
            this.dateFechaVencimiento.Name = "dateFechaVencimiento";
            this.dateFechaVencimiento.Size = new System.Drawing.Size(226, 20);
            this.dateFechaVencimiento.TabIndex = 35;
            // 
            // cmbRubros
            // 
            this.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubros.FormattingEnabled = true;
            this.cmbRubros.Location = new System.Drawing.Point(135, 208);
            this.cmbRubros.Name = "cmbRubros";
            this.cmbRubros.Size = new System.Drawing.Size(225, 21);
            this.cmbRubros.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPorcentaje);
            this.groupBox2.Controls.Add(this.lblPrecio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2l);
            this.groupBox2.Controls.Add(this.lpo);
            this.groupBox2.Controls.Add(this.lblcosto_envio);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCostoTotal);
            this.groupBox2.Controls.Add(this.chkRealizaEnvio);
            this.groupBox2.Controls.Add(this.cmbVisibilidad);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(410, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 229);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Costo Publicacion";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(102, 99);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(41, 13);
            this.lblPorcentaje.TabIndex = 33;
            this.lblPorcentaje.Text = "label14";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(102, 69);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(41, 13);
            this.lblPrecio.TabIndex = 32;
            this.lblPrecio.Text = "label14";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 31;
            // 
            // label2l
            // 
            this.label2l.AutoSize = true;
            this.label2l.Location = new System.Drawing.Point(16, 69);
            this.label2l.Name = "label2l";
            this.label2l.Size = new System.Drawing.Size(37, 13);
            this.label2l.TabIndex = 30;
            this.label2l.Text = "Precio";
            // 
            // lpo
            // 
            this.lpo.AutoSize = true;
            this.lpo.Location = new System.Drawing.Point(16, 99);
            this.lpo.Name = "lpo";
            this.lpo.Size = new System.Drawing.Size(58, 13);
            this.lpo.TabIndex = 29;
            this.lpo.Text = "Porcentaje";
            // 
            // lblcosto_envio
            // 
            this.lblcosto_envio.AutoSize = true;
            this.lblcosto_envio.Location = new System.Drawing.Point(99, 156);
            this.lblcosto_envio.Name = "lblcosto_envio";
            this.lblcosto_envio.Size = new System.Drawing.Size(35, 13);
            this.lblcosto_envio.TabIndex = 28;
            this.lblcosto_envio.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Costo envio:";
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtCostoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoTotal.Enabled = false;
            this.txtCostoTotal.Location = new System.Drawing.Point(102, 185);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.Size = new System.Drawing.Size(121, 20);
            this.txtCostoTotal.TabIndex = 26;
            // 
            // chkRealizaEnvio
            // 
            this.chkRealizaEnvio.AutoSize = true;
            this.chkRealizaEnvio.Location = new System.Drawing.Point(102, 132);
            this.chkRealizaEnvio.Name = "chkRealizaEnvio";
            this.chkRealizaEnvio.Size = new System.Drawing.Size(15, 14);
            this.chkRealizaEnvio.TabIndex = 25;
            this.chkRealizaEnvio.UseVisualStyleBackColor = true;
            this.chkRealizaEnvio.CheckedChanged += new System.EventHandler(this.chkRealizaEnvio_CheckedChanged);
            // 
            // cmbVisibilidad
            // 
            this.cmbVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisibilidad.FormattingEnabled = true;
            this.cmbVisibilidad.Location = new System.Drawing.Point(102, 35);
            this.cmbVisibilidad.Name = "cmbVisibilidad";
            this.cmbVisibilidad.Size = new System.Drawing.Size(121, 21);
            this.cmbVisibilidad.TabIndex = 24;
            this.cmbVisibilidad.SelectedIndexChanged += new System.EventHandler(this.cmbVisibilidad_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Costo Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Visibilidad";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Realiza Envio?";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.PaleGreen;
            this.txtPrecio.Location = new System.Drawing.Point(134, 170);
            this.txtPrecio.MaxLength = 254;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(74, 20);
            this.txtPrecio.TabIndex = 30;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.PaleGreen;
            this.txtStock.Location = new System.Drawing.Point(134, 140);
            this.txtStock.MaxLength = 254;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(152, 20);
            this.txtStock.TabIndex = 29;
            // 
            // cmdGenerarCompra
            // 
            this.cmdGenerarCompra.Location = new System.Drawing.Point(507, 309);
            this.cmdGenerarCompra.Name = "cmdGenerarCompra";
            this.cmdGenerarCompra.Size = new System.Drawing.Size(151, 47);
            this.cmdGenerarCompra.TabIndex = 28;
            this.cmdGenerarCompra.Text = "Generar Compra Inmediata";
            this.cmdGenerarCompra.UseVisualStyleBackColor = true;
            this.cmdGenerarCompra.Click += new System.EventHandler(this.cmdGenerarCompra_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(407, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Permite preguntas?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Estado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Rubro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fecha Vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Stock";
            // 
            // txtDescripción
            // 
            this.txtDescripción.Location = new System.Drawing.Point(133, 31);
            this.txtDescripción.MaxLength = 254;
            this.txtDescripción.Multiline = true;
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripción.Size = new System.Drawing.Size(227, 88);
            this.txtDescripción.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Descripción";
            // 
            // AltaCompraInmediata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(696, 393);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "AltaCompraInmediata";
            this.Text = "AltaCompraInmediata";
            this.Load += new System.EventHandler(this.AltaCompraInmediata_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripción;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdGenerarCompra;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkPermitePreguntas;
        private System.Windows.Forms.DateTimePicker dateFechaVencimiento;
        private System.Windows.Forms.ComboBox cmbRubros;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCostoTotal;
        private System.Windows.Forms.CheckBox chkRealizaEnvio;
        private System.Windows.Forms.ComboBox cmbVisibilidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcosto_envio;
        private System.Windows.Forms.Label label2l;
        private System.Windows.Forms.Label lpo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPrecioDecimal;
    }
}