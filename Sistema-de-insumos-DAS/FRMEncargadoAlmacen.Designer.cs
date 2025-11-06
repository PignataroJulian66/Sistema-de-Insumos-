namespace Sistema_de_insumos_DAS
{
    partial class FRMEncargadoAlmacen
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
            this.registrarOrdenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verComprasPasadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPerfilToolStripMenuItem,
            this.registrarOrdenDeCompraToolStripMenuItem,
            this.realizarCompraToolStripMenuItem,
            this.verComprasPasadasToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registrarOrdenDeCompraToolStripMenuItem
            // 
            this.registrarOrdenDeCompraToolStripMenuItem.Name = "registrarOrdenDeCompraToolStripMenuItem";
            this.registrarOrdenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
            this.registrarOrdenDeCompraToolStripMenuItem.Text = "Registrar Orden de compra";
            this.registrarOrdenDeCompraToolStripMenuItem.Click += new System.EventHandler(this.registrarOrdenDeCompraToolStripMenuItem_Click);
            // 
            // realizarCompraToolStripMenuItem
            // 
            this.realizarCompraToolStripMenuItem.Name = "realizarCompraToolStripMenuItem";
            this.realizarCompraToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.realizarCompraToolStripMenuItem.Text = "Realizar Compra";
            this.realizarCompraToolStripMenuItem.Click += new System.EventHandler(this.realizarCompraToolStripMenuItem_Click);
            // 
            // verComprasPasadasToolStripMenuItem
            // 
            this.verComprasPasadasToolStripMenuItem.Name = "verComprasPasadasToolStripMenuItem";
            this.verComprasPasadasToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.verComprasPasadasToolStripMenuItem.Text = "Ver compras pasadas";
            this.verComprasPasadasToolStripMenuItem.Click += new System.EventHandler(this.verComprasPasadasToolStripMenuItem_Click);
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
            // verPerfilToolStripMenuItem
            // 
            this.verPerfilToolStripMenuItem.Name = "verPerfilToolStripMenuItem";
            this.verPerfilToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.verPerfilToolStripMenuItem.Text = "Ver perfil";
            this.verPerfilToolStripMenuItem.Click += new System.EventHandler(this.verPerfilToolStripMenuItem_Click);
            // 
            // FRMEncargadoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRMEncargadoAlmacen";
            this.Text = "FRMEncargadoAlmacen";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrarOrdenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verComprasPasadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPerfilToolStripMenuItem;
    }
}