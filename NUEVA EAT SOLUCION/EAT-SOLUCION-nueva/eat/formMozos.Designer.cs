namespace eat
{
    partial class formMozos
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
            this.dataGridViewMozos = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oPCIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aGREGARMOZOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTARDISPONIBLESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTARDISPONIBLESToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTARTODOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMozos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMozos
            // 
            this.dataGridViewMozos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMozos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMozos.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewMozos.Name = "dataGridViewMozos";
            this.dataGridViewMozos.Size = new System.Drawing.Size(1709, 426);
            this.dataGridViewMozos.TabIndex = 0;
            this.dataGridViewMozos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMozos_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPCIONESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1709, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPCIONESToolStripMenuItem
            // 
            this.oPCIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aGREGARMOZOToolStripMenuItem,
            this.lISTARTODOSToolStripMenuItem,
            this.lISTARDISPONIBLESToolStripMenuItem,
            this.lISTARDISPONIBLESToolStripMenuItem1});
            this.oPCIONESToolStripMenuItem.Name = "oPCIONESToolStripMenuItem";
            this.oPCIONESToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.oPCIONESToolStripMenuItem.Text = "OPCIONES";
            // 
            // aGREGARMOZOToolStripMenuItem
            // 
            this.aGREGARMOZOToolStripMenuItem.Name = "aGREGARMOZOToolStripMenuItem";
            this.aGREGARMOZOToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aGREGARMOZOToolStripMenuItem.Text = "AGREGAR MOZO";
            this.aGREGARMOZOToolStripMenuItem.Click += new System.EventHandler(this.aGREGARMOZOToolStripMenuItem_Click);
            // 
            // lISTARDISPONIBLESToolStripMenuItem
            // 
            this.lISTARDISPONIBLESToolStripMenuItem.Name = "lISTARDISPONIBLESToolStripMenuItem";
            this.lISTARDISPONIBLESToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.lISTARDISPONIBLESToolStripMenuItem.Text = "LISTAR ACTIVADOS";
            this.lISTARDISPONIBLESToolStripMenuItem.Click += new System.EventHandler(this.lISTARDISPONIBLESToolStripMenuItem_Click);
            // 
            // lISTARDISPONIBLESToolStripMenuItem1
            // 
            this.lISTARDISPONIBLESToolStripMenuItem1.Name = "lISTARDISPONIBLESToolStripMenuItem1";
            this.lISTARDISPONIBLESToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.lISTARDISPONIBLESToolStripMenuItem1.Text = "LISTAR DISPONIBLES";
            this.lISTARDISPONIBLESToolStripMenuItem1.Click += new System.EventHandler(this.lISTARDISPONIBLESToolStripMenuItem1_Click);
            // 
            // lISTARTODOSToolStripMenuItem
            // 
            this.lISTARTODOSToolStripMenuItem.Name = "lISTARTODOSToolStripMenuItem";
            this.lISTARTODOSToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.lISTARTODOSToolStripMenuItem.Text = "LISTAR TODOS";
            this.lISTARTODOSToolStripMenuItem.Click += new System.EventHandler(this.lISTARTODOSToolStripMenuItem_Click);
            // 
            // formMozos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 450);
            this.Controls.Add(this.dataGridViewMozos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formMozos";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.formMozos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMozos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMozos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oPCIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aGREGARMOZOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISTARDISPONIBLESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISTARDISPONIBLESToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lISTARTODOSToolStripMenuItem;
    }
}