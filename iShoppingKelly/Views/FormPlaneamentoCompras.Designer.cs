namespace iShoppingKelly.Views
{
    partial class FormPlaneamentoCompras
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminarOrc = new System.Windows.Forms.Button();
            this.btnEditarOrc = new System.Windows.Forms.Button();
            this.btnNovoOrc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 175);
            this.dataGridView1.TabIndex = 23;
            // 
            // btnEliminarOrc
            // 
            this.btnEliminarOrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarOrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarOrc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarOrc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarOrc.Location = new System.Drawing.Point(242, 215);
            this.btnEliminarOrc.Name = "btnEliminarOrc";
            this.btnEliminarOrc.Size = new System.Drawing.Size(86, 34);
            this.btnEliminarOrc.TabIndex = 22;
            this.btnEliminarOrc.Text = "Eliminar";
            this.btnEliminarOrc.UseVisualStyleBackColor = false;
            // 
            // btnEditarOrc
            // 
            this.btnEditarOrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditarOrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarOrc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarOrc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarOrc.Location = new System.Drawing.Point(140, 215);
            this.btnEditarOrc.Name = "btnEditarOrc";
            this.btnEditarOrc.Size = new System.Drawing.Size(86, 34);
            this.btnEditarOrc.TabIndex = 21;
            this.btnEditarOrc.Text = "Editar";
            this.btnEditarOrc.UseVisualStyleBackColor = false;
            // 
            // btnNovoOrc
            // 
            this.btnNovoOrc.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNovoOrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoOrc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoOrc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovoOrc.Location = new System.Drawing.Point(12, 215);
            this.btnNovoOrc.Name = "btnNovoOrc";
            this.btnNovoOrc.Size = new System.Drawing.Size(111, 34);
            this.btnNovoOrc.TabIndex = 20;
            this.btnNovoOrc.Text = "Nova Compra";
            this.btnNovoOrc.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Purple;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(347, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 34);
            this.button1.TabIndex = 24;
            this.button1.Text = "Exportar CSV";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FormPlaneamentoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminarOrc);
            this.Controls.Add(this.btnEditarOrc);
            this.Controls.Add(this.btnNovoOrc);
            this.Name = "FormPlaneamentoCompras";
            this.Text = "FormPlaneamentoCompras";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminarOrc;
        private System.Windows.Forms.Button btnEditarOrc;
        private System.Windows.Forms.Button btnNovoOrc;
        private System.Windows.Forms.Button button1;
    }
}