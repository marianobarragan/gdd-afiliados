namespace MercadoEnvio.Templates
{
    partial class ABM
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
            this.lstOpciones = new System.Windows.Forms.ListBox();
            this.btnIrVista = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstOpciones
            // 
            this.lstOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOpciones.FormattingEnabled = true;
            this.lstOpciones.ItemHeight = 20;
            this.lstOpciones.Items.AddRange(new object[] {
            "ALTA",
            "BORRAR",
            "MODIFICAR"});
            this.lstOpciones.Location = new System.Drawing.Point(12, 12);
            this.lstOpciones.Name = "lstOpciones";
            this.lstOpciones.Size = new System.Drawing.Size(200, 84);
            this.lstOpciones.TabIndex = 0;
            // 
            // btnIrVista
            // 
            this.btnIrVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrVista.Location = new System.Drawing.Point(115, 101);
            this.btnIrVista.Name = "btnIrVista";
            this.btnIrVista.Size = new System.Drawing.Size(97, 44);
            this.btnIrVista.TabIndex = 1;
            this.btnIrVista.Text = "IR!";
            this.btnIrVista.UseVisualStyleBackColor = true;
            this.btnIrVista.Click += new System.EventHandler(this.btnIrVista_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(12, 102);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(97, 44);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 160);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnIrVista);
            this.Controls.Add(this.lstOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ABM";
            this.Text = "ABM";
            this.Load += new System.EventHandler(this.ABM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstOpciones;
        private System.Windows.Forms.Button btnIrVista;
        private System.Windows.Forms.Button btnVolver;
    }
}