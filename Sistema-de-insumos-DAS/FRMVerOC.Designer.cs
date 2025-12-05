namespace Sistema_de_insumos_DAS
{
    partial class FRMVerOC
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnCotizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOC
            // 
            this.dgvOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOC.Location = new System.Drawing.Point(12, 12);
            this.dgvOC.Name = "dgvOC";
            this.dgvOC.Size = new System.Drawing.Size(776, 245);
            this.dgvOC.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 305);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // btnCotizar
            // 
            this.btnCotizar.Location = new System.Drawing.Point(138, 302);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(93, 36);
            this.btnCotizar.TabIndex = 2;
            this.btnCotizar.Text = "Cotizar!";
            this.btnCotizar.UseVisualStyleBackColor = true;
            this.btnCotizar.Click += new System.EventHandler(this.btnCotizar_Click);
            // 
            // FRMVerOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCotizar);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dgvOC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMVerOC";
            this.Text = "FRMVerOC";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOC;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnCotizar;
    }
}