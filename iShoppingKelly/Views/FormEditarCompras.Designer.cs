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
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.btnElimItem = new System.Windows.Forms.Button();
            this.btnAdicItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNomeCom = new System.Windows.Forms.TextBox();
            this.btnGuardarNome = new System.Windows.Forms.Button();
            this.cBoxArtigo = new System.Windows.Forms.ComboBox();
            this.cBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblArtigo = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView7
            // 
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(12, 124);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(555, 157);
            this.dataGridView7.TabIndex = 17;
            this.dataGridView7.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView7_CellContentClick);
            // 
            // btnElimItem
            // 
            this.btnElimItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnElimItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElimItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnElimItem.Location = new System.Drawing.Point(244, 287);
            this.btnElimItem.Name = "btnElimItem";
            this.btnElimItem.Size = new System.Drawing.Size(102, 34);
            this.btnElimItem.TabIndex = 15;
            this.btnElimItem.Text = "Eliminar Item";
            this.btnElimItem.UseVisualStyleBackColor = false;
            this.btnElimItem.Click += new System.EventHandler(this.btnElimItem_Click);
            // 
            // btnAdicItem
            // 
            this.btnAdicItem.BackColor = System.Drawing.Color.Fuchsia;
            this.btnAdicItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdicItem.Location = new System.Drawing.Point(12, 287);
            this.btnAdicItem.Name = "btnAdicItem";
            this.btnAdicItem.Size = new System.Drawing.Size(115, 34);
            this.btnAdicItem.TabIndex = 14;
            this.btnAdicItem.Text = "+Adicionar Item";
            this.btnAdicItem.UseVisualStyleBackColor = false;
            this.btnAdicItem.Click += new System.EventHandler(this.btnAdicItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditItem.Location = new System.Drawing.Point(143, 287);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(86, 34);
            this.btnEditItem.TabIndex = 13;
            this.btnEditItem.Text = "Editar Item";
            this.btnEditItem.UseVisualStyleBackColor = false;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
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
            // txtNomeCom
            // 
            this.txtNomeCom.Location = new System.Drawing.Point(143, 29);
            this.txtNomeCom.Name = "txtNomeCom";
            this.txtNomeCom.Size = new System.Drawing.Size(233, 20);
            this.txtNomeCom.TabIndex = 18;
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
            this.btnGuardarNome.Click += new System.EventHandler(this.btnGuardarNome_Click);
            // 
            // cBoxArtigo
            // 
            this.cBoxArtigo.Location = new System.Drawing.Point(298, 67);
            this.cBoxArtigo.Name = "cBoxArtigo";
            this.cBoxArtigo.Size = new System.Drawing.Size(185, 21);
            this.cBoxArtigo.TabIndex = 0;
            // 
            // cBoxTipo
            // 
            this.cBoxTipo.Location = new System.Drawing.Point(56, 65);
            this.cBoxTipo.Name = "cBoxTipo";
            this.cBoxTipo.Size = new System.Drawing.Size(185, 21);
            this.cBoxTipo.TabIndex = 20;
            this.cBoxTipo.SelectedIndexChanged += new System.EventHandler(this.cBoxTipo_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(12, 67);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(38, 16);
            this.lblTipo.TabIndex = 21;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblArtigo
            // 
            this.lblArtigo.AutoSize = true;
            this.lblArtigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtigo.Location = new System.Drawing.Point(247, 67);
            this.lblArtigo.Name = "lblArtigo";
            this.lblArtigo.Size = new System.Drawing.Size(45, 16);
            this.lblArtigo.TabIndex = 22;
            this.lblArtigo.Text = "Artigo:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(12, 95);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(80, 16);
            this.lblQuantidade.TabIndex = 23;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(98, 94);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(55, 20);
            this.txtQuantidade.TabIndex = 24;
            // 
            // FormEditarCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 329);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblArtigo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cBoxTipo);
            this.Controls.Add(this.cBoxArtigo);
            this.Controls.Add(this.btnGuardarNome);
            this.Controls.Add(this.txtNomeCom);
            this.Controls.Add(this.dataGridView7);
            this.Controls.Add(this.btnElimItem);
            this.Controls.Add(this.btnAdicItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.lblNome);
            this.Name = "FormEditarCompras";
            this.Text = "FormEditarCompras";
            this.Load += new System.EventHandler(this.FormEditarCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.Button btnElimItem;
        private System.Windows.Forms.Button btnAdicItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNomeCom;
        private System.Windows.Forms.Button btnGuardarNome;
        private System.Windows.Forms.ComboBox cBoxArtigo;
        private System.Windows.Forms.ComboBox cBoxTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblArtigo;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
    }
}