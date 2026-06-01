namespace iShoppingKelly.Views
{
    partial class FormTiposArtigo
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
            this.btnEliminarTipo = new System.Windows.Forms.Button();
            this.btnEditarTipo = new System.Windows.Forms.Button();
            this.btnNovoTipo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 175);
            this.dataGridView1.TabIndex = 15;
            // 
            // btnEliminarTipo
            // 
            this.btnEliminarTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTipo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarTipo.Location = new System.Drawing.Point(236, 225);
            this.btnEliminarTipo.Name = "btnEliminarTipo";
            this.btnEliminarTipo.Size = new System.Drawing.Size(86, 34);
            this.btnEliminarTipo.TabIndex = 14;
            this.btnEliminarTipo.Text = "Eliminar";
            this.btnEliminarTipo.UseVisualStyleBackColor = false;
            // 
            // btnEditarTipo
            // 
            this.btnEditarTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditarTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarTipo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarTipo.Location = new System.Drawing.Point(134, 225);
            this.btnEditarTipo.Name = "btnEditarTipo";
            this.btnEditarTipo.Size = new System.Drawing.Size(86, 34);
            this.btnEditarTipo.TabIndex = 13;
            this.btnEditarTipo.Text = "Editar";
            this.btnEditarTipo.UseVisualStyleBackColor = false;
            // 
            // btnNovoTipo
            // 
            this.btnNovoTipo.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNovoTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoTipo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoTipo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNovoTipo.Location = new System.Drawing.Point(31, 225);
            this.btnNovoTipo.Name = "btnNovoTipo";
            this.btnNovoTipo.Size = new System.Drawing.Size(86, 34);
            this.btnNovoTipo.TabIndex = 12;
            this.btnNovoTipo.Text = "Novo";
            this.btnNovoTipo.UseVisualStyleBackColor = false;
            // 
            // FormTiposArtigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 286);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminarTipo);
            this.Controls.Add(this.btnEditarTipo);
            this.Controls.Add(this.btnNovoTipo);
            this.Name = "FormTiposArtigo";
            this.Text = "FormTiposArtigo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminarTipo;
        private System.Windows.Forms.Button btnEditarTipo;
        private System.Windows.Forms.Button btnNovoTipo;
    }
}