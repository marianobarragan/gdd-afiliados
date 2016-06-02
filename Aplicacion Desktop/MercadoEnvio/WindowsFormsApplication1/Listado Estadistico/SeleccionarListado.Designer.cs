namespace MercadoEnvio.Listado_Estadistico
{
    partial class SeleccionarListado
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnIrVista = new System.Windows.Forms.Button();
            this.lstOpciones = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(62, 243);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(97, 44);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnIrVista
            // 
            this.btnIrVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrVista.Location = new System.Drawing.Point(402, 243);
            this.btnIrVista.Name = "btnIrVista";
            this.btnIrVista.Size = new System.Drawing.Size(97, 44);
            this.btnIrVista.TabIndex = 4;
            this.btnIrVista.Text = "IR!";
            this.btnIrVista.UseVisualStyleBackColor = true;
            this.btnIrVista.Click += new System.EventHandler(this.btnIrVista_Click);
            // 
            // lstOpciones
            // 
            this.lstOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOpciones.FormattingEnabled = true;
            this.lstOpciones.ItemHeight = 20;
            this.lstOpciones.Items.AddRange(new object[] {
            "Vendedores con mayor cantidad de productos no vendidos",
            "Clientes con mayor cantidad de productos comprados",
            "Vendedores con mayor cantidad de facturas",
            "Vendedores con mayor monto facturado"});
            this.lstOpciones.Location = new System.Drawing.Point(62, 37);
            this.lstOpciones.Name = "lstOpciones";
            this.lstOpciones.Size = new System.Drawing.Size(437, 164);
            this.lstOpciones.TabIndex = 3;
            this.lstOpciones.SelectedIndexChanged += new System.EventHandler(this.lstOpciones_SelectedIndexChanged);
            // 
            // SeleccionarListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(573, 322);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnIrVista);
            this.Controls.Add(this.lstOpciones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarListado";
            this.Text = "MERCADO ENVIO - LISTADO ESTADISTICO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnIrVista;
        private System.Windows.Forms.ListBox lstOpciones;
    }
}