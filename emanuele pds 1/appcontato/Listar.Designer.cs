namespace AppContatoForm
{
    partial class Listar
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
            this.dgvContato = new System.Windows.Forms.DataGridView();
            this.cbListar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContato)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContato
            // 
            this.dgvContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContato.Location = new System.Drawing.Point(36, 59);
            this.dgvContato.Name = "dgvContato";
            this.dgvContato.Size = new System.Drawing.Size(682, 350);
            this.dgvContato.TabIndex = 0;
            // 
            // cbListar
            // 
            this.cbListar.FormattingEnabled = true;
            this.cbListar.Location = new System.Drawing.Point(159, 12);
            this.cbListar.Name = "cbListar";
            this.cbListar.Size = new System.Drawing.Size(512, 21);
            this.cbListar.TabIndex = 1;
            // 
            // Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbListar);
            this.Controls.Add(this.dgvContato);
            this.Name = "Listar";
            this.Text = "Listar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContato;
        private System.Windows.Forms.ComboBox cbListar;
    }
}