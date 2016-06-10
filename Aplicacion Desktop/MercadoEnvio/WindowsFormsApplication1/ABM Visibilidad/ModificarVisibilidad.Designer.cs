namespace MercadoEnvio.ABM_Visibilidad
{
    partial class ModificarVisibilidad
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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblComa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.txtCostoEnvio = new System.Windows.Forms.TextBox();
            this.txtPrecioDecimal = new System.Windows.Forms.TextBox();
            this.txtCostoEnvioDecimal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cerrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCostoEnvioDecimal);
            this.groupBox1.Controls.Add(this.txtPrecioDecimal);
            this.groupBox1.Controls.Add(this.txtCostoEnvio);
            this.groupBox1.Controls.Add(this.txtPorcentaje);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblComa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(14, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 179);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visibilidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Modificar Visibilidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Porcentaje (0-100) ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Costo Envio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion:";
            // 
            // lblComa
            // 
            this.lblComa.AutoSize = true;
            this.lblComa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComa.Location = new System.Drawing.Point(188, 48);
            this.lblComa.Name = "lblComa";
            this.lblComa.Size = new System.Drawing.Size(18, 25);
            this.lblComa.TabIndex = 10;
            this.lblComa.Text = ",";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(188, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = ",";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(107, 20);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(126, 20);
            this.txtDescripcion.TabIndex = 14;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(107, 46);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(85, 20);
            this.txtPrecio.TabIndex = 15;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(107, 74);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(85, 20);
            this.txtPorcentaje.TabIndex = 16;
            // 
            // txtCostoEnvio
            // 
            this.txtCostoEnvio.Location = new System.Drawing.Point(107, 101);
            this.txtCostoEnvio.Name = "txtCostoEnvio";
            this.txtCostoEnvio.Size = new System.Drawing.Size(85, 20);
            this.txtCostoEnvio.TabIndex = 17;
            // 
            // txtPrecioDecimal
            // 
            this.txtPrecioDecimal.Location = new System.Drawing.Point(203, 46);
            this.txtPrecioDecimal.Name = "txtPrecioDecimal";
            this.txtPrecioDecimal.Size = new System.Drawing.Size(30, 20);
            this.txtPrecioDecimal.TabIndex = 18;
            // 
            // txtCostoEnvioDecimal
            // 
            this.txtCostoEnvioDecimal.Location = new System.Drawing.Point(203, 101);
            this.txtCostoEnvioDecimal.Name = "txtCostoEnvioDecimal";
            this.txtCostoEnvioDecimal.Size = new System.Drawing.Size(30, 20);
            this.txtCostoEnvioDecimal.TabIndex = 19;
            // 
            // ModificarVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarVisibilidad";
            this.Text = "ModificarVisibilidad";
            this.Load += new System.EventHandler(this.ModificarVisibilidad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCostoEnvioDecimal;
        private System.Windows.Forms.TextBox txtPrecioDecimal;
        private System.Windows.Forms.TextBox txtCostoEnvio;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}