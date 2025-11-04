namespace Sistema_de_insumos_DAS
{
    partial class FRMRealizarCompra
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
            this.dgvOrdenCompra = new System.Windows.Forms.DataGridView();
            this.lstCotizaciones = new System.Windows.Forms.ListBox();
            this.btnRealizarCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdenCompra
            // 
            this.dgvOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenCompra.Location = new System.Drawing.Point(12, 16);
            this.dgvOrdenCompra.Name = "dgvOrdenCompra";
            this.dgvOrdenCompra.Size = new System.Drawing.Size(420, 313);
            this.dgvOrdenCompra.TabIndex = 1;
            // 
            // lstCotizaciones
            // 
            this.lstCotizaciones.FormattingEnabled = true;
            this.lstCotizaciones.Location = new System.Drawing.Point(447, 16);
            this.lstCotizaciones.Name = "lstCotizaciones";
            this.lstCotizaciones.Size = new System.Drawing.Size(151, 316);
            this.lstCotizaciones.TabIndex = 2;
            // 
            // btnRealizarCompra
            // 
            this.btnRealizarCompra.Location = new System.Drawing.Point(217, 354);
            this.btnRealizarCompra.Name = "btnRealizarCompra";
            this.btnRealizarCompra.Size = new System.Drawing.Size(157, 41);
            this.btnRealizarCompra.TabIndex = 3;
            this.btnRealizarCompra.Text = "REALIZAR COMPRA";
            this.btnRealizarCompra.UseVisualStyleBackColor = true;
            // 
            // FRMRealizarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRealizarCompra);
            this.Controls.Add(this.lstCotizaciones);
            this.Controls.Add(this.dgvOrdenCompra);
            this.Name = "FRMRealizarCompra";
            this.Text = "FRMRealizarCompra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenCompra;
        private System.Windows.Forms.ListBox lstCotizaciones;
        private System.Windows.Forms.Button btnRealizarCompra;
    }
}