namespace MercadoEnvio.ABM_Usuario.Modificar_Usuario
{
    partial class ModificarContraseña
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
            this.txtContraseñaVieja = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContraseñaNueva1 = new System.Windows.Forms.TextBox();
            this.txtContraseñaNueva2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContraseñaVieja
            // 
            this.txtContraseñaVieja.Location = new System.Drawing.Point(206, 19);
            this.txtContraseñaVieja.Name = "txtContraseñaVieja";
            this.txtContraseñaVieja.Size = new System.Drawing.Size(195, 20);
            this.txtContraseñaVieja.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContraseñaNueva2);
            this.groupBox1.Controls.Add(this.txtContraseñaNueva1);
            this.groupBox1.Controls.Add(this.txtContraseñaVieja);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtContraseñaNueva1
            // 
            this.txtContraseñaNueva1.Location = new System.Drawing.Point(206, 60);
            this.txtContraseñaNueva1.Name = "txtContraseñaNueva1";
            this.txtContraseñaNueva1.Size = new System.Drawing.Size(195, 20);
            this.txtContraseñaNueva1.TabIndex = 1;
            // 
            // txtContraseñaNueva2
            // 
            this.txtContraseñaNueva2.Location = new System.Drawing.Point(206, 101);
            this.txtContraseñaNueva2.Name = "txtContraseñaNueva2";
            this.txtContraseñaNueva2.Size = new System.Drawing.Size(195, 20);
            this.txtContraseñaNueva2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese su vieja contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingrese su nueva contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingrese su nueva contraseña de nuevo";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(133, 166);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(176, 37);
            this.btnCambiar.TabIndex = 2;
            this.btnCambiar.Text = "Cambiar Contraseña";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // ModificarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(461, 214);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModificarContraseña";
            this.Text = "ModificarContraseña";
            this.Load += new System.EventHandler(this.ModificarContraseña_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtContraseñaVieja;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseñaNueva2;
        private System.Windows.Forms.TextBox txtContraseñaNueva1;
        private System.Windows.Forms.Button btnCambiar;
    }
}