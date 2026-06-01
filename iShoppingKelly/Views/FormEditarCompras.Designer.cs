namespace iShoppingKelly.Views
{
    partial class FormEditarCompras
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
            this.btnElimItem = new System.Windows.Forms.Button();
            this.btnAdicItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGuardarNome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 175);
            this.dataGridView1.TabIndex = 17;
            // 
            // btnElimItem
            // 
            this.btnElimItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnElimItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElimItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnElimItem.Location = new System.Drawing.Point(244, 241);
            this.btnElimItem.Name = "btnElimItem";
            this.btnElimItem.Size = new System.Drawing.Size(102, 34);
            this.btnElimItem.TabIndex = 15;
            this.btnElimItem.Text = "Eliminar Item";
            this.btnElimItem.UseVisualStyleBackColor = false;
            // 
            // btnAdicItem
            // 
            this.btnAdicItem.BackColor = System.Drawing.Color.Fuchsia;
            this.btnAdicItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdicItem.Location = new System.Drawing.Point(12, 241);
            this.btnAdicItem.Name = "btnAdicItem";
            this.btnAdicItem.Size = new System.Drawing.Size(115, 34);
            this.btnAdicItem.TabIndex = 14;
            this.btnAdicItem.Text = "+Adicionar Item";
            this.btnAdicItem.UseVisualStyleBackColor = false;
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditItem.Location = new System.Drawing.Point(143, 241);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(86, 34);
            this.btnEditItem.TabIndex = 13;
            this.btnEditItem.Text = "Editar Item";
            this.btnEditItem.UseVisualStyleBackColor = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(15, 28);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(122, 19);
            this.lblNome.TabIndex = 12;
            this.lblNome.Text = "Nome da Compra:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 18;
            // 
            // btnGuardarNome
            // 
            this.btnGuardarNome.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardarNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarNome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarNome.Location = new System.Drawing.Point(392, 20);
            this.btnGuardarNome.Name = "btnGuardarNome";
            this.btnGuardarNome.Size = new System.Drawing.Size(125, 34);
            this.btnGuardarNome.TabIndex = 19;
            this.btnGuardarNome.Text = "Guardar Nome";
            this.btnGuardarNome.UseVisualStyleBackColor = false;
            // 
            // FormEditarCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuardarNome);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnElimItem);
            this.Controls.Add(this.btnAdicItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.lblNome);
            this.Name = "FormEditarCompras";
            this.Text = "FormEditarCompras";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnElimItem;
        private System.Windows.Forms.Button btnAdicItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGuardarNome;
    }
}