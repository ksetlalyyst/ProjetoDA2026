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
            this.tabOrçaTotal = new System.Windows.Forms.TabPage();
            this.tabComFechada = new System.Windows.Forms.TabPage();
            this.tabSugInteli = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOpcoes
            // 
            this.tabOpcoes.Controls.Add(this.tabOrçaTotal);
            this.tabOpcoes.Controls.Add(this.tabComFechada);
            this.tabOpcoes.Controls.Add(this.tabSugInteli);
            this.tabOpcoes.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOpcoes.Location = new System.Drawing.Point(12, 12);
            this.tabOpcoes.Name = "tabOpcoes";
            this.tabOpcoes.SelectedIndex = 0;
            this.tabOpcoes.Size = new System.Drawing.Size(554, 186);
            this.tabOpcoes.TabIndex = 0;
            // 
            // tabOrçaTotal
            // 
            this.tabOrçaTotal.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrçaTotal.Location = new System.Drawing.Point(4, 28);
            this.tabOrçaTotal.Name = "tabOrçaTotal";
            this.tabOrçaTotal.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrçaTotal.Size = new System.Drawing.Size(546, 154);
            this.tabOrçaTotal.TabIndex = 0;
            this.tabOrçaTotal.Text = "Orçamentos Totais";
            this.tabOrçaTotal.UseVisualStyleBackColor = true;
            // 
            // tabComFechada
            // 
            this.tabComFechada.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabComFechada.Location = new System.Drawing.Point(4, 28);
            this.tabComFechada.Name = "tabComFechada";
            this.tabComFechada.Padding = new System.Windows.Forms.Padding(3);
            this.tabComFechada.Size = new System.Drawing.Size(546, 154);
            this.tabComFechada.TabIndex = 1;
            this.tabComFechada.Text = "Compras Fechadas";
            this.tabComFechada.UseVisualStyleBackColor = true;
            // 
            // tabSugInteli
            // 
            this.tabSugInteli.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSugInteli.Location = new System.Drawing.Point(4, 28);
            this.tabSugInteli.Name = "tabSugInteli";
            this.tabSugInteli.Padding = new System.Windows.Forms.Padding(3);
            this.tabSugInteli.Size = new System.Drawing.Size(546, 154);
            this.tabSugInteli.TabIndex = 2;
            this.tabSugInteli.Text = "Sugestões Inteligentes";
            this.tabSugInteli.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(546, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // FormEstatísticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 413);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabOpcoes);
            this.Name = "FormEstatísticas";
            this.Text = "FormEstatísticas";
            this.tabOpcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOpcoes;
        private System.Windows.Forms.TabPage tabOrçaTotal;
        private System.Windows.Forms.TabPage tabComFechada;
        private System.Windows.Forms.TabPage tabSugInteli;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}