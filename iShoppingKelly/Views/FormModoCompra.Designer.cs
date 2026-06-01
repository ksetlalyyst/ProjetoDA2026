namespace iShoppingKelly.Views
{
    partial class FormModoCompra
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
            this.boxCompraSem = new System.Windows.Forms.GroupBox();
            this.lblResDispo = new System.Windows.Forms.Label();
            this.lblDisponivel = new System.Windows.Forms.Label();
            this.lblResulTotalGasto = new System.Windows.Forms.Label();
            this.lblTotalGasto = new System.Windows.Forms.Label();
            this.lblResulOrc = new System.Windows.Forms.Label();
            this.lblOrcMes = new System.Windows.Forms.Label();
            this.lblItensCompra = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnFecharCompra = new System.Windows.Forms.Button();
            this.btnAdquirido = new System.Windows.Forms.Button();
            this.btnItemNPrevi = new System.Windows.Forms.Button();
            this.boxCompraSem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // boxCompraSem
            // 
            this.boxCompraSem.Controls.Add(this.lblResDispo);
            this.boxCompraSem.Controls.Add(this.lblDisponivel);
            this.boxCompraSem.Controls.Add(this.lblResulTotalGasto);
            this.boxCompraSem.Controls.Add(this.lblTotalGasto);
            this.boxCompraSem.Controls.Add(this.lblResulOrc);
            this.boxCompraSem.Controls.Add(this.lblOrcMes);
            this.boxCompraSem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCompraSem.Location = new System.Drawing.Point(12, 29);
            this.boxCompraSem.Name = "boxCompraSem";
            this.boxCompraSem.Size = new System.Drawing.Size(605, 87);
            this.boxCompraSem.TabIndex = 0;
            this.boxCompraSem.TabStop = false;
            this.boxCompraSem.Text = "Compra Semanal";
            // 
            // lblResDispo
            // 
            this.lblResDispo.AutoSize = true;
            this.lblResDispo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResDispo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblResDispo.Location = new System.Drawing.Point(480, 47);
            this.lblResDispo.Name = "lblResDispo";
            this.lblResDispo.Size = new System.Drawing.Size(38, 18);
            this.lblResDispo.TabIndex = 5;
            this.lblResDispo.Text = "label";
            // 
            // lblDisponivel
            // 
            this.lblDisponivel.AutoSize = true;
            this.lblDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDisponivel.Location = new System.Drawing.Point(393, 47);
            this.lblDisponivel.Name = "lblDisponivel";
            this.lblDisponivel.Size = new System.Drawing.Size(91, 18);
            this.lblDisponivel.TabIndex = 4;
            this.lblDisponivel.Text = "Disponível:";
            // 
            // lblResulTotalGasto
            // 
            this.lblResulTotalGasto.AutoSize = true;
            this.lblResulTotalGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResulTotalGasto.Location = new System.Drawing.Point(297, 47);
            this.lblResulTotalGasto.Name = "lblResulTotalGasto";
            this.lblResulTotalGasto.Size = new System.Drawing.Size(38, 18);
            this.lblResulTotalGasto.TabIndex = 3;
            this.lblResulTotalGasto.Text = "label";
            // 
            // lblTotalGasto
            // 
            this.lblTotalGasto.AutoSize = true;
            this.lblTotalGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGasto.Location = new System.Drawing.Point(199, 47);
            this.lblTotalGasto.Name = "lblTotalGasto";
            this.lblTotalGasto.Size = new System.Drawing.Size(102, 18);
            this.lblTotalGasto.TabIndex = 2;
            this.lblTotalGasto.Text = "Total Gasto:";
            // 
            // lblResulOrc
            // 
            this.lblResulOrc.AutoSize = true;
            this.lblResulOrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResulOrc.Location = new System.Drawing.Point(135, 47);
            this.lblResulOrc.Name = "lblResulOrc";
            this.lblResulOrc.Size = new System.Drawing.Size(38, 18);
            this.lblResulOrc.TabIndex = 1;
            this.lblResulOrc.Text = "label";
            // 
            // lblOrcMes
            // 
            this.lblOrcMes.AutoSize = true;
            this.lblOrcMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrcMes.Location = new System.Drawing.Point(6, 47);
            this.lblOrcMes.Name = "lblOrcMes";
            this.lblOrcMes.Size = new System.Drawing.Size(134, 18);
            this.lblOrcMes.TabIndex = 0;
            this.lblOrcMes.Text = "Orçamento Mês:";
            // 
            // lblItensCompra
            // 
            this.lblItensCompra.AutoSize = true;
            this.lblItensCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItensCompra.Location = new System.Drawing.Point(18, 131);
            this.lblItensCompra.Name = "lblItensCompra";
            this.lblItensCompra.Size = new System.Drawing.Size(130, 16);
            this.lblItensCompra.TabIndex = 6;
            this.lblItensCompra.Text = "Itens da Compra:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(596, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnFecharCompra
            // 
            this.btnFecharCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFecharCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharCompra.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharCompra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFecharCompra.Location = new System.Drawing.Point(340, 306);
            this.btnFecharCompra.Name = "btnFecharCompra";
            this.btnFecharCompra.Size = new System.Drawing.Size(145, 34);
            this.btnFecharCompra.TabIndex = 18;
            this.btnFecharCompra.Text = "Fechar Compra";
            this.btnFecharCompra.UseVisualStyleBackColor = false;
            // 
            // btnAdquirido
            // 
            this.btnAdquirido.BackColor = System.Drawing.Color.Fuchsia;
            this.btnAdquirido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdquirido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdquirido.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdquirido.Location = new System.Drawing.Point(21, 306);
            this.btnAdquirido.Name = "btnAdquirido";
            this.btnAdquirido.Size = new System.Drawing.Size(146, 34);
            this.btnAdquirido.TabIndex = 17;
            this.btnAdquirido.Text = "Marcar Adquirido";
            this.btnAdquirido.UseVisualStyleBackColor = false;
            // 
            // btnItemNPrevi
            // 
            this.btnItemNPrevi.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnItemNPrevi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemNPrevi.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemNPrevi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnItemNPrevi.Location = new System.Drawing.Point(180, 306);
            this.btnItemNPrevi.Name = "btnItemNPrevi";
            this.btnItemNPrevi.Size = new System.Drawing.Size(145, 34);
            this.btnItemNPrevi.TabIndex = 16;
            this.btnItemNPrevi.Text = "+ Item não previsto";
            this.btnItemNPrevi.UseVisualStyleBackColor = false;
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 362);
            this.Controls.Add(this.btnFecharCompra);
            this.Controls.Add(this.btnAdquirido);
            this.Controls.Add(this.btnItemNPrevi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblItensCompra);
            this.Controls.Add(this.boxCompraSem);
            this.Name = "FormModoCompra";
            this.Text = "FormModoCompra";
            this.boxCompraSem.ResumeLayout(false);
            this.boxCompraSem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox boxCompraSem;
        private System.Windows.Forms.Label lblOrcMes;
        private System.Windows.Forms.Label lblResDispo;
        private System.Windows.Forms.Label lblDisponivel;
        private System.Windows.Forms.Label lblResulTotalGasto;
        private System.Windows.Forms.Label lblTotalGasto;
        private System.Windows.Forms.Label lblResulOrc;
        private System.Windows.Forms.Label lblItensCompra;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFecharCompra;
        private System.Windows.Forms.Button btnAdquirido;
        private System.Windows.Forms.Button btnItemNPrevi;
    }
}