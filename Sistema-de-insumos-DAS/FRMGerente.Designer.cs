﻿namespace Sistema_de_insumos_DAS
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
            this.operacionesClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesInsumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacionesClientesToolStripMenuItem,
            this.operacionesEmpleadosToolStripMenuItem,
            this.operacionesProveedoresToolStripMenuItem,
            this.operacionesInsumosToolStripMenuItem,
            this.operacionesProductosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
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
            // operacionesProductosToolStripMenuItem
            // 
            this.operacionesProductosToolStripMenuItem.Name = "operacionesProductosToolStripMenuItem";
            this.operacionesProductosToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.operacionesProductosToolStripMenuItem.Text = "Operaciones Productos";
            this.operacionesProductosToolStripMenuItem.Click += new System.EventHandler(this.operacionesProductosToolStripMenuItem_Click);
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
    }
}