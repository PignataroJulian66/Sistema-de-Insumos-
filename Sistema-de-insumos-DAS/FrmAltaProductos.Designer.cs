namespace Sistema_de_insumos_DAS
{
    partial class FrmAltaProductos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnidadInsumo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btnLimpiarLista = new System.Windows.Forms.Button();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmbinsumo = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtnombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "Unidad";
            // 
            // txtUnidadInsumo
            // 
            this.txtUnidadInsumo.Location = new System.Drawing.Point(306, 69);
            this.txtUnidadInsumo.Name = "txtUnidadInsumo";
            this.txtUnidadInsumo.Size = new System.Drawing.Size(120, 20);
            this.txtUnidadInsumo.TabIndex = 97;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 96;
            this.label10.Text = "Cantidad de insumo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 95;
            this.label9.Text = "Insumo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 94;
            this.label8.Text = "Rubro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Nombre";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(306, 95);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 91;
            // 
            // btnLimpiarLista
            // 
            this.btnLimpiarLista.Location = new System.Drawing.Point(508, 204);
            this.btnLimpiarLista.Name = "btnLimpiarLista";
            this.btnLimpiarLista.Size = new System.Drawing.Size(147, 50);
            this.btnLimpiarLista.TabIndex = 90;
            this.btnLimpiarLista.Text = "Limpiar lista";
            this.btnLimpiarLista.UseVisualStyleBackColor = true;
            this.btnLimpiarLista.Click += new System.EventHandler(this.btnLimpiarLista_Click);
            // 
            // btnAgregarInsumo
            // 
            this.btnAgregarInsumo.Location = new System.Drawing.Point(280, 124);
            this.btnAgregarInsumo.Name = "btnAgregarInsumo";
            this.btnAgregarInsumo.Size = new System.Drawing.Size(147, 50);
            this.btnAgregarInsumo.TabIndex = 89;
            this.btnAgregarInsumo.Text = "Agregar Insumo";
            this.btnAgregarInsumo.UseVisualStyleBackColor = true;
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarInsumo_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(10, 204);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(147, 50);
            this.btnAlta.TabIndex = 88;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(61, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 27);
            this.label6.TabIndex = 87;
            this.label6.Text = "Producto";
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(57, 136);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(120, 20);
            this.txtRubro.TabIndex = 86;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(456, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 186);
            this.listBox1.TabIndex = 85;
            // 
            // cmbinsumo
            // 
            this.cmbinsumo.FormattingEnabled = true;
            this.cmbinsumo.Location = new System.Drawing.Point(306, 42);
            this.cmbinsumo.Name = "cmbinsumo";
            this.cmbinsumo.Size = new System.Drawing.Size(121, 21);
            this.cmbinsumo.TabIndex = 84;
            this.cmbinsumo.SelectedIndexChanged += new System.EventHandler(this.cmbinsumo_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(57, 96);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 83;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(57, 58);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(120, 20);
            this.txtnombre.TabIndex = 82;
            // 
            // FrmAltaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUnidadInsumo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.btnLimpiarLista);
            this.Controls.Add(this.btnAgregarInsumo);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRubro);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmbinsumo);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.txtnombre);
            this.Name = "FrmAltaProductos";
            this.Text = "FrmAltaProductos";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnidadInsumo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btnLimpiarLista;
        private System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cmbinsumo;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txtnombre;
    }
}