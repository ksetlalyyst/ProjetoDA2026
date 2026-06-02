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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminarOrc = new System.Windows.Forms.Button();
            this.btnEditarOrc = new System.Windows.Forms.Button();
            this.btnNovoOrc = new System.Windows.Forms.Button();
            this.txtNomeTipoArt = new System.Windows.Forms.TextBox();
            this.lblNomeTipoArt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 175);
            this.dataGridView1.TabIndex = 19;
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
            // 
            // txtNomeTipoArt
            // 
            this.txtNomeTipoArt.Location = new System.Drawing.Point(61, 12);
            this.txtNomeTipoArt.Name = "txtNomeTipoArt";
            this.txtNomeTipoArt.Size = new System.Drawing.Size(504, 20);
            this.txtNomeTipoArt.TabIndex = 21;
            // 
            // lblNomeTipoArt
            // 
            this.lblNomeTipoArt.AutoSize = true;
            this.lblNomeTipoArt.Location = new System.Drawing.Point(16, 12);
            this.lblNomeTipoArt.Name = "lblNomeTipoArt";
            this.lblNomeTipoArt.Size = new System.Drawing.Size(38, 13);
            this.lblNomeTipoArt.TabIndex = 20;
            this.lblNomeTipoArt.Text = "Nome:";
            // 
            // FormOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 300);
            this.Controls.Add(this.txtNomeTipoArt);
            this.Controls.Add(this.lblNomeTipoArt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminarOrc);
            this.Controls.Add(this.btnEditarOrc);
            this.Controls.Add(this.btnNovoOrc);
            this.Name = "FormOrcamentos";
            this.Text = "FormOrcamentos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminarOrc;
        private System.Windows.Forms.Button btnEditarOrc;
        private System.Windows.Forms.Button btnNovoOrc;
        private System.Windows.Forms.TextBox txtNomeTipoArt;
        private System.Windows.Forms.Label lblNomeTipoArt;
    }
}