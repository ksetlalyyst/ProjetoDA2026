using iShopping.Controllers;
using System;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormRegistar : Form
    {
        private TextBox txtNome, txtUsername, txtPassword, txtConfirm;
        private Button btnGuardar, btnCancelar;
        private Label lblErro;
        private readonly UtilizadorController _ctrl = new UtilizadorController();

        public FormRegistar()
        {
            this.Text = "Novo Utilizador";
            this.Size = new System.Drawing.Size(380, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int y = 20;
            Action<string, Control> addRow = (label, ctrl) =>
            {
                this.Controls.Add(new Label { Text = label, Location = new System.Drawing.Point(20, y + 3), Size = new System.Drawing.Size(100, 22) });
                ctrl.Location = new System.Drawing.Point(130, y);
                ctrl.Size = new System.Drawing.Size(210, 22);
                this.Controls.Add(ctrl);
                y += 40;
            };

            txtNome = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox { UseSystemPasswordChar = true };
            txtConfirm = new TextBox { UseSystemPasswordChar = true };

            addRow("Nome:", txtNome);
            addRow("Username:", txtUsername);
            addRow("Password:", txtPassword);
            addRow("Confirmar:", txtConfirm);

            lblErro = new Label { ForeColor = System.Drawing.Color.Red, Location = new System.Drawing.Point(20, y), Size = new System.Drawing.Size(320, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro);
            y += 30;

            btnGuardar = new Button { Text = "Registar", Location = new System.Drawing.Point(130, y), Size = new System.Drawing.Size(90, 30), BackColor = System.Drawing.Color.FromArgb(0, 120, 215), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(240, y), Size = new System.Drawing.Size(90, 30), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });
            this.AcceptButton = btnGuardar;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            lblErro.Text = "";
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            { lblErro.Text = "Preencha todos os campos."; return; }

            if (txtPassword.Text != txtConfirm.Text)
            { lblErro.Text = "As passwords não coincidem."; return; }

            if (txtPassword.Text.Length < 4)
            { lblErro.Text = "Password deve ter pelo menos 4 caracteres."; return; }

            var (sucesso, erro) = _ctrl.Registar(txtNome.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text);
            if (!sucesso) { lblErro.Text = erro; return; }

            MessageBox.Show("Utilizador registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
