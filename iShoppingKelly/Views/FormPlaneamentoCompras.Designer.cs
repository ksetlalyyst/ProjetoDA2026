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
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.btnEliminarNovaCom = new System.Windows.Forms.Button();
            this.btnEditarNovaCom = new System.Windows.Forms.Button();
            this.btnNovaCompra = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblNomeTipoArt = new System.Windows.Forms.Label();
            this.txtNomeCompra = new System.Windows.Forms.TextBox();
            this.lblNomeCompra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(10, 65);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(555, 175);
            this.dataGridView6.TabIndex = 23;
            this.dataGridView6.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView6_CellContentClick);
            // 
            // btnEliminarNovaCom
            // 
            this.btnEliminarNovaCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarNovaCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarNovaCom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarNovaCom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarNovaCom.Location = new System.Drawing.Point(240, 246);
            this.btnEliminarNovaCom.Name = "btnEliminarNovaCom";
            this.btnEliminarNovaCom.Size = new System.Drawing.Size(86, 34);
            this.btnEliminarNovaCom.TabIndex = 22;
            this.btnEliminarNovaCom.Text = "Eliminar";
            this.btnEliminarNovaCom.UseVisualStyleBackColor = false;
            this.btnEliminarNovaCom.Click += new System.EventHandler(this.btnEliminarNovaCom_Click);
            // 
            // btnEditarNovaCom
            // 
            this.btnEditarNovaCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditarNovaCom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarNovaCom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarNovaCom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarNovaCom.Location = new System.Drawing.Point(138, 246);
            this.btnEditarNovaCom.Name = "btnEditarNovaCom";
            this.btnEditarNovaCom.Size = new System.Drawing.Size(86, 34);
            this.btnEditarNovaCom.TabIndex = 21;
            this.btnEditarNovaCom.Text = "Editar";
            this.btnEditarNovaCom.UseVisualStyleBackColor = false;
            this.btnEditarNovaCom.Click += new System.EventHandler(this.btnEditarNovaCom_Click);
            // 
            // btnNovaCompra
            // 
            this.btnNovaCompra.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNovaCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovaCompra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaCompra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovaCompra.Location = new System.Drawing.Point(10, 246);
            this.btnNovaCompra.Name = "btnNovaCompra";
            this.btnNovaCompra.Size = new System.Drawing.Size(111, 34);
            this.btnNovaCompra.TabIndex = 20;
            this.btnNovaCompra.Text = "Nova Compra";
            this.btnNovaCompra.UseVisualStyleBackColor = false;
            this.btnNovaCompra.Click += new System.EventHandler(this.btnNovaCompra_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Purple;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExportar.Location = new System.Drawing.Point(345, 246);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 34);
            this.btnExportar.TabIndex = 24;
            this.btnExportar.Text = "Exportar CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(61, 12);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(504, 20);
            this.txtFiltro.TabIndex = 26;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lblNomeTipoArt
            // 
            this.lblNomeTipoArt.AutoSize = true;
            this.lblNomeTipoArt.Location = new System.Drawing.Point(16, 12);
            this.lblNomeTipoArt.Name = "lblNomeTipoArt";
            this.lblNomeTipoArt.Size = new System.Drawing.Size(35, 13);
            this.lblNomeTipoArt.TabIndex = 25;
            this.lblNomeTipoArt.Text = "Filtrar:";
            // 
            // txtNomeCompra
            // 
            this.txtNomeCompra.Location = new System.Drawing.Point(61, 39);
            this.txtNomeCompra.Name = "txtNomeCompra";
            this.txtNomeCompra.Size = new System.Drawing.Size(504, 20);
            this.txtNomeCompra.TabIndex = 28;
            // 
            // lblNomeCompra
            // 
            this.lblNomeCompra.AutoSize = true;
            this.lblNomeCompra.Location = new System.Drawing.Point(16, 39);
            this.lblNomeCompra.Name = "lblNomeCompra";
            this.lblNomeCompra.Size = new System.Drawing.Size(38, 13);
            this.lblNomeCompra.TabIndex = 27;
            this.lblNomeCompra.Text = "Nome:";
            // 
            // FormPlaneamentoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 299);
            this.Controls.Add(this.txtNomeCompra);
            this.Controls.Add(this.lblNomeCompra);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblNomeTipoArt);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dataGridView6);
            this.Controls.Add(this.btnEliminarNovaCom);
            this.Controls.Add(this.btnEditarNovaCom);
            this.Controls.Add(this.btnNovaCompra);
            this.Name = "FormPlaneamentoCompras";
            this.Text = "FormPlaneamentoCompras";
            this.Load += new System.EventHandler(this.FormPlaneamentoCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.Button btnEliminarNovaCom;
        private System.Windows.Forms.Button btnEditarNovaCom;
        private System.Windows.Forms.Button btnNovaCompra;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblNomeTipoArt;
        private System.Windows.Forms.TextBox txtNomeCompra;
        private System.Windows.Forms.Label lblNomeCompra;
    }
}