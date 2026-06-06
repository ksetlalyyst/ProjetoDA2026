namespace iShoppingKelly.Views
{
    partial class FormUtilizadores
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNovoUti = new System.Windows.Forms.Button();
            this.btnEditUti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Location = new System.Drawing.Point(368, 179);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(145, 34);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNovoUti
            // 
            this.btnNovoUti.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNovoUti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoUti.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoUti.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNovoUti.Location = new System.Drawing.Point(49, 179);
            this.btnNovoUti.Name = "btnNovoUti";
            this.btnNovoUti.Size = new System.Drawing.Size(146, 34);
            this.btnNovoUti.TabIndex = 20;
            this.btnNovoUti.Text = "Novo Utilizador";
            this.btnNovoUti.UseVisualStyleBackColor = false;
            this.btnNovoUti.Click += new System.EventHandler(this.btnNovoUti_Click);
            // 
            // btnEditUti
            // 
            this.btnEditUti.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnEditUti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUti.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUti.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditUti.Location = new System.Drawing.Point(208, 179);
            this.btnEditUti.Name = "btnEditUti";
            this.btnEditUti.Size = new System.Drawing.Size(145, 34);
            this.btnEditUti.TabIndex = 19;
            this.btnEditUti.Text = "Editar Utilizador";
            this.btnEditUti.UseVisualStyleBackColor = false;
            this.btnEditUti.Click += new System.EventHandler(this.btnEditUti_Click);
            // 
            // FormUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 240);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNovoUti);
            this.Controls.Add(this.btnEditUti);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormUtilizadores";
            this.Text = "FormUtilizadores";
            this.Load += new System.EventHandler(this.FormUtilizadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNovoUti;
        private System.Windows.Forms.Button btnEditUti;
    }
}
