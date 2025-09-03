namespace eat
{
    partial class FormMozoEvento
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
            this.dataGridViewEventoMozo = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventoMozo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEventoMozo
            // 
            this.dataGridViewEventoMozo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventoMozo.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewEventoMozo.Name = "dataGridViewEventoMozo";
            this.dataGridViewEventoMozo.Size = new System.Drawing.Size(1013, 196);
            this.dataGridViewEventoMozo.TabIndex = 0;
            // 
            // FormMozoEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 450);
            this.Controls.Add(this.dataGridViewEventoMozo);
            this.Name = "FormMozoEvento";
            this.Text = "FormMozoEvento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventoMozo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEventoMozo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}