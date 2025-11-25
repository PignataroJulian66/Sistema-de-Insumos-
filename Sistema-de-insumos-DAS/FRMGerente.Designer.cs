namespace Sistema_de_insumos_DAS
{
    partial class FRMGerente
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPerfilToolStripMenuItem,
            this.operacionesClientesToolStripMenuItem,
            this.operacionesEmpleadosToolStripMenuItem,
            this.operacionesProveedoresToolStripMenuItem,
            this.operacionesInsumosToolStripMenuItem,
            this.operacionesProductosToolStripMenuItem,
            this.verRegistrosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // verPerfilToolStripMenuItem
            // 
            this.verPerfilToolStripMenuItem.Name = "verPerfilToolStripMenuItem";
            this.verPerfilToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.verPerfilToolStripMenuItem.Text = "Ver perfil";
            this.verPerfilToolStripMenuItem.Click += new System.EventHandler(this.verPerfilToolStripMenuItem_Click);
            // 
            // operacionesClientesToolStripMenuItem
            // 
            this.operacionesClientesToolStripMenuItem.Name = "operacionesClientesToolStripMenuItem";
            this.operacionesClientesToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.operacionesClientesToolStripMenuItem.Text = "Operaciones Clientes";
            this.operacionesClientesToolStripMenuItem.Click += new System.EventHandler(this.operacionesClientesToolStripMenuItem_Click);
            // 
            // operacionesEmpleadosToolStripMenuItem
            // 
            this.operacionesEmpleadosToolStripMenuItem.Name = "operacionesEmpleadosToolStripMenuItem";
            this.operacionesEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.operacionesEmpleadosToolStripMenuItem.Text = "Operaciones Empleados";
            this.operacionesEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.operacionesEmpleadosToolStripMenuItem_Click);
            // 
            // operacionesProveedoresToolStripMenuItem
            // 
            this.operacionesProveedoresToolStripMenuItem.Name = "operacionesProveedoresToolStripMenuItem";
            this.operacionesProveedoresToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.operacionesProveedoresToolStripMenuItem.Text = "Operaciones Proveedores";
            this.operacionesProveedoresToolStripMenuItem.Click += new System.EventHandler(this.operacionesProveedoresToolStripMenuItem_Click);
            // 
            // operacionesInsumosToolStripMenuItem
            // 
            this.operacionesInsumosToolStripMenuItem.Name = "operacionesInsumosToolStripMenuItem";
            this.operacionesInsumosToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.operacionesInsumosToolStripMenuItem.Text = "Operaciones Insumos";
            this.operacionesInsumosToolStripMenuItem.Click += new System.EventHandler(this.operacionesInsumosToolStripMenuItem_Click);
            // 
            // operacionesProductosToolStripMenuItem
            // 
            this.operacionesProductosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.bajaToolStripMenuItem,
            this.modificacionToolStripMenuItem});
            this.operacionesProductosToolStripMenuItem.Name = "operacionesProductosToolStripMenuItem";
            this.operacionesProductosToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.operacionesProductosToolStripMenuItem.Text = "Operaciones Productos";
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.altaToolStripMenuItem.Text = "Alta";
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.bajaToolStripMenuItem.Text = "Baja";
            this.bajaToolStripMenuItem.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // modificacionToolStripMenuItem
            // 
            this.modificacionToolStripMenuItem.Name = "modificacionToolStripMenuItem";
            this.modificacionToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.modificacionToolStripMenuItem.Text = "Modificacion";
            this.modificacionToolStripMenuItem.Click += new System.EventHandler(this.modificacionToolStripMenuItem_Click);
            // 
            // verRegistrosToolStripMenuItem
            // 
            this.verRegistrosToolStripMenuItem.Name = "verRegistrosToolStripMenuItem";
            this.verRegistrosToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.verRegistrosToolStripMenuItem.Text = "Ver Registros";
            this.verRegistrosToolStripMenuItem.Click += new System.EventHandler(this.verRegistrosToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // FRMGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRMGerente";
            this.Text = "FRMGerente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMGerente_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operacionesClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesInsumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verRegistrosToolStripMenuItem;
    }
}