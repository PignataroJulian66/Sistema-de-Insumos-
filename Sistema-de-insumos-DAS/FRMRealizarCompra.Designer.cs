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
            this.dgvOC = new System.Windows.Forms.DataGridView();
            this.btnRealizarCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOC
            // 
            this.dgvOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOC.Location = new System.Drawing.Point(12, 16);
            this.dgvOC.Name = "dgvOC";
            this.dgvOC.Size = new System.Drawing.Size(613, 313);
            this.dgvOC.TabIndex = 1;
            // 
            // btnRealizarCompra
            // 
            this.btnRealizarCompra.Location = new System.Drawing.Point(631, 16);
            this.btnRealizarCompra.Name = "btnRealizarCompra";
            this.btnRealizarCompra.Size = new System.Drawing.Size(157, 41);
            this.btnRealizarCompra.TabIndex = 3;
            this.btnRealizarCompra.Text = "REALIZAR COMPRA";
            this.btnRealizarCompra.UseVisualStyleBackColor = true;
            this.btnRealizarCompra.Click += new System.EventHandler(this.btnRealizarCompra_Click);
            // 
            // FRMRealizarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRealizarCompra);
            this.Controls.Add(this.dgvOC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMRealizarCompra";
            this.Text = "FRMRealizarCompra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOC;
        private System.Windows.Forms.Button btnRealizarCompra;
    }
}