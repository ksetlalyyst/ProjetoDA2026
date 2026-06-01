namespace iShoppingKelly.Views
{
    partial class FormArtigo
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
            this.lblNome = new System.Windows.Forms.Label();
            this.btnNovoArtigo = new System.Windows.Forms.Button();
            this.btnEditarArtigo = new System.Windows.Forms.Button();
            this.btnEliminarArtigo = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblArtigoNome = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(15, 31);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(102, 19);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Filtrar por Tipo:";
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
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "(Todos)"});
            this.comboBox1.Location = new System.Drawing.Point(123, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 175);
            this.dataGridView1.TabIndex = 11;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormArtigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 285);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblArtigoNome);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnEliminarArtigo);
            this.Controls.Add(this.btnEditarArtigo);
            this.Controls.Add(this.btnNovoArtigo);
            this.Controls.Add(this.lblNome);
            this.Name = "FormArtigo";
            this.Text = "FormArtigo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Button btnNovoArtigo;
        private System.Windows.Forms.Button btnEditarArtigo;
        private System.Windows.Forms.Button btnEliminarArtigo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblArtigoNome;
        private System.Windows.Forms.TextBox textBox1;
    }
}