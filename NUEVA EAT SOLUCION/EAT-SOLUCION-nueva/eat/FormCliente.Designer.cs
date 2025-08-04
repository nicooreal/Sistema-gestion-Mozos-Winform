namespace eat
{
    partial class FormCliente
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewCliente = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oPCIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aGREGARToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCliente
            // 
            this.dataGridViewCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCliente.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewCliente.Name = "dataGridViewCliente";
            this.dataGridViewCliente.Size = new System.Drawing.Size(1355, 390);
            this.dataGridViewCliente.TabIndex = 1;
            this.dataGridViewCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCliente_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oPCIONESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oPCIONESToolStripMenuItem
            // 
            this.oPCIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aGREGARToolStripMenuItem1});
            this.oPCIONESToolStripMenuItem.Name = "oPCIONESToolStripMenuItem";
            this.oPCIONESToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.oPCIONESToolStripMenuItem.Text = "OPCIONES";
            // 
            // aGREGARToolStripMenuItem1
            // 
            this.aGREGARToolStripMenuItem1.Name = "aGREGARToolStripMenuItem1";
            this.aGREGARToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aGREGARToolStripMenuItem1.Text = "AGREGAR";
            this.aGREGARToolStripMenuItem1.Click += new System.EventHandler(this.aGREGARToolStripMenuItem1_Click);
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridViewCliente);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

        private void initializeComponent()
        {
            this.dataGridViewCliente = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCliente
            // 
            this.dataGridViewCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCliente.Location = new System.Drawing.Point(2, 12);
            this.dataGridViewCliente.Name = "dataGridViewCliente";
            this.dataGridViewCliente.Size = new System.Drawing.Size(964, 301);
            this.dataGridViewCliente.TabIndex = 1;
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 450);
            this.Controls.Add(this.dataGridViewCliente);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).EndInit();
            this.ResumeLayout(false);
            this.dataGridViewCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCliente_CellContentClick);
        }


        private System.Windows.Forms.DataGridView dataGridViewCliente;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oPCIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aGREGARToolStripMenuItem1;
    }
}