namespace iShoppingKelly.Views
{
    partial class FormPrincipal
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
            this.lblBemVinda = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestaotool = new System.Windows.Forms.ToolStripMenuItem();
            this.artigostool = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.orcamentosTool = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasTool = new System.Windows.Forms.ToolStripMenuItem();
            this.planeamentoComprasTool = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosTool = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasTool = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCompraAberta = new System.Windows.Forms.Label();
            this.btnModoCompra = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBemVinda
            // 
            this.lblBemVinda.BackColor = System.Drawing.Color.Purple;
            this.lblBemVinda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBemVinda.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBemVinda.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBemVinda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBemVinda.Location = new System.Drawing.Point(0, 24);
            this.lblBemVinda.Name = "lblBemVinda";
            this.lblBemVinda.Size = new System.Drawing.Size(800, 41);
            this.lblBemVinda.TabIndex = 3;
            this.lblBemVinda.Text = "Bem-vinda(o), !";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestaotool,
            this.comprasTool,
            this.relatóriosTool,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestaotool
            // 
            this.gestaotool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.artigostool,
            this.tiposDeArtigoTool,
            this.orcamentosTool});
            this.gestaotool.Name = "gestaotool";
            this.gestaotool.Size = new System.Drawing.Size(55, 20);
            this.gestaotool.Text = "Gestão";
            // 
            // artigostool
            // 
            this.artigostool.Name = "artigostool";
            this.artigostool.Size = new System.Drawing.Size(180, 22);
            this.artigostool.Text = "Artigos";
            this.artigostool.Click += new System.EventHandler(this.artigostool_Click);
            // 
            // tiposDeArtigoTool
            // 
            this.tiposDeArtigoTool.Name = "tiposDeArtigoTool";
            this.tiposDeArtigoTool.Size = new System.Drawing.Size(180, 22);
            this.tiposDeArtigoTool.Text = "Tipos de Artigo";
            this.tiposDeArtigoTool.Click += new System.EventHandler(this.tiposDeArtigoTool_Click);
            // 
            // orcamentosTool
            // 
            this.orcamentosTool.Name = "orcamentosTool";
            this.orcamentosTool.Size = new System.Drawing.Size(180, 22);
            this.orcamentosTool.Text = "Orçamentos";
            this.orcamentosTool.Click += new System.EventHandler(this.orcamentosTool_Click);
            // 
            // comprasTool
            // 
            this.comprasTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planeamentoComprasTool});
            this.comprasTool.Name = "comprasTool";
            this.comprasTool.Size = new System.Drawing.Size(67, 20);
            this.comprasTool.Text = "Compras";
            // 
            // planeamentoComprasTool
            // 
            this.planeamentoComprasTool.Name = "planeamentoComprasTool";
            this.planeamentoComprasTool.Size = new System.Drawing.Size(195, 22);
            this.planeamentoComprasTool.Text = "Planeamento Compras";
            this.planeamentoComprasTool.Click += new System.EventHandler(this.planeamentoComprasTool_Click);
            // 
            // relatóriosTool
            // 
            this.relatóriosTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estatísticasTool});
            this.relatóriosTool.Name = "relatóriosTool";
            this.relatóriosTool.Size = new System.Drawing.Size(71, 20);
            this.relatóriosTool.Text = "Relatórios";
            // 
            // estatísticasTool
            // 
            this.estatísticasTool.Name = "estatísticasTool";
            this.estatísticasTool.Size = new System.Drawing.Size(131, 22);
            this.estatísticasTool.Text = "Estatísticas";
            this.estatísticasTool.Click += new System.EventHandler(this.estatísticasTool_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // lblCompraAberta
            // 
            this.lblCompraAberta.AutoSize = true;
            this.lblCompraAberta.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompraAberta.Location = new System.Drawing.Point(12, 75);
            this.lblCompraAberta.Name = "lblCompraAberta";
            this.lblCompraAberta.Size = new System.Drawing.Size(129, 17);
            this.lblCompraAberta.TabIndex = 5;
            this.lblCompraAberta.Text = "Compras em aberto";
            // 
            // btnModoCompra
            // 
            this.btnModoCompra.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnModoCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModoCompra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModoCompra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModoCompra.Location = new System.Drawing.Point(15, 106);
            this.btnModoCompra.Name = "btnModoCompra";
            this.btnModoCompra.Size = new System.Drawing.Size(109, 23);
            this.btnModoCompra.TabIndex = 6;
            this.btnModoCompra.Text = "Modo Compra";
            this.btnModoCompra.UseVisualStyleBackColor = false;
            this.btnModoCompra.Click += new System.EventHandler(this.btnModoCompra_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(130, 106);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(109, 23);
            this.btnAtualizar.TabIndex = 7;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(602, 170);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 317);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnModoCompra);
            this.Controls.Add(this.lblCompraAberta);
            this.Controls.Add(this.lblBemVinda);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBemVinda;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestaotool;
        private System.Windows.Forms.ToolStripMenuItem comprasTool;
        private System.Windows.Forms.ToolStripMenuItem relatóriosTool;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Label lblCompraAberta;
        private System.Windows.Forms.Button btnModoCompra;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem artigostool;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigoTool;
        private System.Windows.Forms.ToolStripMenuItem orcamentosTool;
        private System.Windows.Forms.ToolStripMenuItem planeamentoComprasTool;
        private System.Windows.Forms.ToolStripMenuItem estatísticasTool;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
    }
}