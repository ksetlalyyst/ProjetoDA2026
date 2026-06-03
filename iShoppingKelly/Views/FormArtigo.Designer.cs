namespace iShoppingKelly.Views
{
    partial class FormArtigo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.btnNovoArtigo = new System.Windows.Forms.Button();
            this.btnEditarArtigo = new System.Windows.Forms.Button();
            this.btnEliminarArtigo = new System.Windows.Forms.Button();
            this.comboBoxFiltrarTipo = new System.Windows.Forms.ComboBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.lblArtigoNome = new System.Windows.Forms.Label();
            this.txtArtigoNome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrar.Location = new System.Drawing.Point(15, 31);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(102, 19);
            this.lblFiltrar.TabIndex = 3;
            this.lblFiltrar.Text = "Filtrar por Tipo:";
            // 
            // btnNovoArtigo
            // 
            this.btnNovoArtigo.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnNovoArtigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoArtigo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoArtigo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNovoArtigo.Location = new System.Drawing.Point(31, 244);
            this.btnNovoArtigo.Name = "btnNovoArtigo";
            this.btnNovoArtigo.Size = new System.Drawing.Size(86, 34);
            this.btnNovoArtigo.TabIndex = 7;
            this.btnNovoArtigo.Text = "Novo";
            this.btnNovoArtigo.UseVisualStyleBackColor = false;
            this.btnNovoArtigo.Click += new System.EventHandler(this.btnNovoArtigo_Click);
            // 
            // btnEditarArtigo
            // 
            this.btnEditarArtigo.BackColor = System.Drawing.Color.Purple;
            this.btnEditarArtigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarArtigo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarArtigo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarArtigo.Location = new System.Drawing.Point(134, 244);
            this.btnEditarArtigo.Name = "btnEditarArtigo";
            this.btnEditarArtigo.Size = new System.Drawing.Size(86, 34);
            this.btnEditarArtigo.TabIndex = 8;
            this.btnEditarArtigo.Text = "Editar";
            this.btnEditarArtigo.UseVisualStyleBackColor = false;
            this.btnEditarArtigo.Click += new System.EventHandler(this.btnEditarArtigo_Click);
            // 
            // btnEliminarArtigo
            // 
            this.btnEliminarArtigo.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnEliminarArtigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarArtigo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArtigo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarArtigo.Location = new System.Drawing.Point(236, 244);
            this.btnEliminarArtigo.Name = "btnEliminarArtigo";
            this.btnEliminarArtigo.Size = new System.Drawing.Size(86, 34);
            this.btnEliminarArtigo.TabIndex = 9;
            this.btnEliminarArtigo.Text = "Eliminar";
            this.btnEliminarArtigo.UseVisualStyleBackColor = false;
            this.btnEliminarArtigo.Click += new System.EventHandler(this.btnEliminarArtigo_Click);
            // 
            // comboBoxFiltrarTipo
            // 
            this.comboBoxFiltrarTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltrarTipo.FormattingEnabled = true;
            this.comboBoxFiltrarTipo.Location = new System.Drawing.Point(123, 32);
            this.comboBoxFiltrarTipo.Name = "comboBoxFiltrarTipo";
            this.comboBoxFiltrarTipo.Size = new System.Drawing.Size(183, 21);
            this.comboBoxFiltrarTipo.TabIndex = 10;
            this.comboBoxFiltrarTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltrarTipo_SelectedIndexChanged);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(12, 63);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(555, 175);
            this.dataGridView4.TabIndex = 11;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // lblArtigoNome
            // 
            this.lblArtigoNome.AutoSize = true;
            this.lblArtigoNome.Location = new System.Drawing.Point(16, 9);
            this.lblArtigoNome.Name = "lblArtigoNome";
            this.lblArtigoNome.Size = new System.Drawing.Size(38, 13);
            this.lblArtigoNome.TabIndex = 12;
            this.lblArtigoNome.Text = "Nome:";
            // 
            // txtArtigoNome
            // 
            this.txtArtigoNome.Location = new System.Drawing.Point(60, 6);
            this.txtArtigoNome.Name = "txtArtigoNome";
            this.txtArtigoNome.Size = new System.Drawing.Size(256, 20);
            this.txtArtigoNome.TabIndex = 13;
            this.txtArtigoNome.TextChanged += new System.EventHandler(this.txtFiltrarNome_TextChanged);
            // 
            // FormArtigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 285);
            this.Controls.Add(this.txtArtigoNome);
            this.Controls.Add(this.lblArtigoNome);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.comboBoxFiltrarTipo);
            this.Controls.Add(this.btnEliminarArtigo);
            this.Controls.Add(this.btnEditarArtigo);
            this.Controls.Add(this.btnNovoArtigo);
            this.Controls.Add(this.lblFiltrar);
            this.Name = "FormArtigo";
            this.Text = "FormArtigo";
            this.Load += new System.EventHandler(this.FormArtigo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Button btnNovoArtigo;
        private System.Windows.Forms.Button btnEditarArtigo;
        private System.Windows.Forms.Button btnEliminarArtigo;
        private System.Windows.Forms.ComboBox comboBoxFiltrarTipo;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label lblArtigoNome;
        private System.Windows.Forms.TextBox txtArtigoNome;
    }
}
