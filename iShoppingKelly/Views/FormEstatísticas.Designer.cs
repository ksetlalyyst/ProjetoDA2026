namespace iShoppingKelly.Views
{
    partial class FormEstatísticas
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
            this.tabOpcoes = new System.Windows.Forms.TabControl();
            this.tabEstatisticas = new System.Windows.Forms.TabPage();
            this.tabSugInteli = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.lblSugestaoOrcamento = new System.Windows.Forms.Label();
            this.tabOpcoes.SuspendLayout();
            this.tabEstatisticas.SuspendLayout();
            this.tabSugInteli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOpcoes
            // 
            this.tabOpcoes.Controls.Add(this.tabEstatisticas);
            this.tabOpcoes.Controls.Add(this.tabSugInteli);
            this.tabOpcoes.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOpcoes.Location = new System.Drawing.Point(12, 12);
            this.tabOpcoes.Name = "tabOpcoes";
            this.tabOpcoes.SelectedIndex = 0;
            this.tabOpcoes.Size = new System.Drawing.Size(554, 340);
            this.tabOpcoes.TabIndex = 0;
            // 
            // tabEstatisticas
            // 
            this.tabEstatisticas.Controls.Add(this.dataGridView2);
            this.tabEstatisticas.Controls.Add(this.dataGridView1);
            this.tabEstatisticas.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEstatisticas.Location = new System.Drawing.Point(4, 28);
            this.tabEstatisticas.Name = "tabEstatisticas";
            this.tabEstatisticas.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstatisticas.Size = new System.Drawing.Size(546, 308);
            this.tabEstatisticas.TabIndex = 0;
            this.tabEstatisticas.Text = "Estatísticas Mensais";
            this.tabEstatisticas.UseVisualStyleBackColor = true;
            // 
            // tabSugInteli
            // 
            this.tabSugInteli.Controls.Add(this.lblSugestaoOrcamento);
            this.tabSugInteli.Controls.Add(this.dataGridView3);
            this.tabSugInteli.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSugInteli.Location = new System.Drawing.Point(4, 28);
            this.tabSugInteli.Name = "tabSugInteli";
            this.tabSugInteli.Padding = new System.Windows.Forms.Padding(3);
            this.tabSugInteli.Size = new System.Drawing.Size(546, 308);
            this.tabSugInteli.TabIndex = 1;
            this.tabSugInteli.Text = "Sugestões Inteligentes";
            this.tabSugInteli.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(534, 145);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 157);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(534, 145);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 36);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(534, 266);
            this.dataGridView3.TabIndex = 2;
            // 
            // lblSugestaoOrcamento
            // 
            this.lblSugestaoOrcamento.AutoSize = true;
            this.lblSugestaoOrcamento.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugestaoOrcamento.Location = new System.Drawing.Point(6, 6);
            this.lblSugestaoOrcamento.Name = "lblSugestaoOrcamento";
            this.lblSugestaoOrcamento.Size = new System.Drawing.Size(175, 20);
            this.lblSugestaoOrcamento.TabIndex = 3;
            this.lblSugestaoOrcamento.Text = "Orçamento sugerido: --";
            this.lblSugestaoOrcamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormEstatísticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 365);
            this.Controls.Add(this.tabOpcoes);
            this.Name = "FormEstatísticas";
            this.Text = "FormEstatísticas";
            this.tabOpcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOpcoes;
        private System.Windows.Forms.TabPage tabEstatisticas;
        private System.Windows.Forms.TabPage tabSugInteli;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label lblSugestaoOrcamento;
    }
}