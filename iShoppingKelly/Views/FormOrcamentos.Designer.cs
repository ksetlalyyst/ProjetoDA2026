namespace iShoppingKelly.Views
{
    partial class FormOrcamentos
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
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.btnEliminarOrc = new System.Windows.Forms.Button();
            this.btnEditarOrc = new System.Windows.Forms.Button();
            this.btnNovoOrc = new System.Windows.Forms.Button();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.comboAno = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(12, 71);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(555, 175);
            this.dataGridView5.TabIndex = 19;
            this.dataGridView5.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView5_CellContentClick);
            // 
            // btnEliminarOrc
            // 
            this.btnEliminarOrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarOrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarOrc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarOrc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarOrc.Location = new System.Drawing.Point(217, 252);
            this.btnEliminarOrc.Name = "btnEliminarOrc";
            this.btnEliminarOrc.Size = new System.Drawing.Size(86, 34);
            this.btnEliminarOrc.TabIndex = 18;
            this.btnEliminarOrc.Text = "Eliminar";
            this.btnEliminarOrc.UseVisualStyleBackColor = false;
            this.btnEliminarOrc.Click += new System.EventHandler(this.btnEliminarOrc_Click);
            // 
            // btnEditarOrc
            // 
            this.btnEditarOrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditarOrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarOrc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarOrc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditarOrc.Location = new System.Drawing.Point(115, 252);
            this.btnEditarOrc.Name = "btnEditarOrc";
            this.btnEditarOrc.Size = new System.Drawing.Size(86, 34);
            this.btnEditarOrc.TabIndex = 17;
            this.btnEditarOrc.Text = "Editar";
            this.btnEditarOrc.UseVisualStyleBackColor = false;
            this.btnEditarOrc.Click += new System.EventHandler(this.btnEditarOrc_Click);
            // 
            // btnNovoOrc
            // 
            this.btnNovoOrc.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNovoOrc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoOrc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoOrc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNovoOrc.Location = new System.Drawing.Point(12, 252);
            this.btnNovoOrc.Name = "btnNovoOrc";
            this.btnNovoOrc.Size = new System.Drawing.Size(86, 34);
            this.btnNovoOrc.TabIndex = 16;
            this.btnNovoOrc.Text = "Novo";
            this.btnNovoOrc.UseVisualStyleBackColor = false;
            this.btnNovoOrc.Click += new System.EventHandler(this.btnNovoOrc_Click);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(12, 32);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(30, 13);
            this.lblMes.TabIndex = 20;
            this.lblMes.Text = "Mês:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(357, 32);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 22;
            this.lblValor.Text = "Valor:";
            // 
            // comboMes
            // 
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Location = new System.Drawing.Point(53, 29);
            this.comboMes.Name = "comboMes";
            this.comboMes.Size = new System.Drawing.Size(121, 21);
            this.comboMes.TabIndex = 23;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(190, 32);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(29, 13);
            this.lblAno.TabIndex = 21;
            this.lblAno.Text = "Ano:";
            // 
            // comboAno
            // 
            this.comboAno.FormattingEnabled = true;
            this.comboAno.Location = new System.Drawing.Point(225, 29);
            this.comboAno.Name = "comboAno";
            this.comboAno.Size = new System.Drawing.Size(121, 21);
            this.comboAno.TabIndex = 24;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(397, 29);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 25;
            // 
            // FormOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 300);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.comboAno);
            this.Controls.Add(this.comboMes);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.btnEliminarOrc);
            this.Controls.Add(this.btnEditarOrc);
            this.Controls.Add(this.btnNovoOrc);
            this.Name = "FormOrcamentos";
            this.Text = "FormOrcamentos";
            this.Load += new System.EventHandler(this.FormOrcamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Button btnEliminarOrc;
        private System.Windows.Forms.Button btnEditarOrc;
        private System.Windows.Forms.Button btnNovoOrc;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.ComboBox comboAno;
        private System.Windows.Forms.TextBox txtValor;
    }
}