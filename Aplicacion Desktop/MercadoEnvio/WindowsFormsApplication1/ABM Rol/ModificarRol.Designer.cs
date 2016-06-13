namespace MercadoEnvio.ABM_Rol
{
    partial class ModificarRol
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
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstTodasLasFunciones = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEstaHabilitado = new System.Windows.Forms.CheckBox();
            this.lstFuncionesActuales = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificarRol
            // 
            this.btnModificarRol.Location = new System.Drawing.Point(257, 359);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(175, 51);
            this.btnModificarRol.TabIndex = 20;
            this.btnModificarRol.Text = "Modificar Rol";
            this.btnModificarRol.UseVisualStyleBackColor = true;
            this.btnModificarRol.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.Font = new System.Drawing.Font("Wingdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button3.Location = new System.Drawing.Point(286, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 45);
            this.button3.TabIndex = 19;
            this.button3.Text = "è";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(24, 381);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(111, 29);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Listado de todas las Funcionalidades ";
            // 
            // lstTodasLasFunciones
            // 
            this.lstTodasLasFunciones.FormattingEnabled = true;
            this.lstTodasLasFunciones.Location = new System.Drawing.Point(411, 25);
            this.lstTodasLasFunciones.Name = "lstTodasLasFunciones";
            this.lstTodasLasFunciones.Size = new System.Drawing.Size(241, 316);
            this.lstTodasLasFunciones.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre";
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(71, 48);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(194, 20);
            this.txtNombreRol.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Wingdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.Location = new System.Drawing.Point(287, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "ç";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEstaHabilitado);
            this.groupBox1.Controls.Add(this.lstFuncionesActuales);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 329);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rol Actual";
            // 
            // chkEstaHabilitado
            // 
            this.chkEstaHabilitado.AutoSize = true;
            this.chkEstaHabilitado.Location = new System.Drawing.Point(12, 68);
            this.chkEstaHabilitado.Name = "chkEstaHabilitado";
            this.chkEstaHabilitado.Size = new System.Drawing.Size(101, 17);
            this.chkEstaHabilitado.TabIndex = 7;
            this.chkEstaHabilitado.Text = "Esta habilitado?";
            this.chkEstaHabilitado.UseVisualStyleBackColor = true;
            this.chkEstaHabilitado.CheckedChanged += new System.EventHandler(this.chkEstaHabilitado_CheckedChanged);
            // 
            // lstFuncionesActuales
            // 
            this.lstFuncionesActuales.FormattingEnabled = true;
            this.lstFuncionesActuales.Location = new System.Drawing.Point(12, 114);
            this.lstFuncionesActuales.Name = "lstFuncionesActuales";
            this.lstFuncionesActuales.Size = new System.Drawing.Size(241, 173);
            this.lstFuncionesActuales.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Listado de Funcionalidades actuales";
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(672, 428);
            this.Controls.Add(this.btnModificarRol);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstTodasLasFunciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificarRol;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstTodasLasFunciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEstaHabilitado;
        private System.Windows.Forms.ListBox lstFuncionesActuales;
        private System.Windows.Forms.Label label2;

    }
}