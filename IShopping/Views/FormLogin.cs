using iShopping.Controllers;
using iShopping.Helpers;
using System;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormLogin : Form
    {
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnRegistar;
        private Label lblTitulo, lblUser, lblPass, lblErro;

        private readonly UtilizadorController _ctrl = new UtilizadorController();

        public FormLogin()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "iShopping - Login";
            this.Size = new System.Drawing.Size(400, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblTitulo = new Label { Text = "🛒 iShopping", Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold), Location = new System.Drawing.Point(100, 20), Size = new System.Drawing.Size(200, 40), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };

            lblUser = new Label { Text = "Username:", Location = new System.Drawing.Point(50, 80), Size = new System.Drawing.Size(90, 25) };
            txtUsername = new TextBox { Location = new System.Drawing.Point(150, 80), Size = new System.Drawing.Size(180, 25) };

            lblPass = new Label { Text = "Password:", Location = new System.Drawing.Point(50, 120), Size = new System.Drawing.Size(90, 25) };
            txtPassword = new TextBox { Location = new System.Drawing.Point(150, 120), Size = new System.Drawing.Size(180, 25), UseSystemPasswordChar = true };

            lblErro = new Label { ForeColor = System.Drawing.Color.Red, Location = new System.Drawing.Point(50, 155), Size = new System.Drawing.Size(290, 25), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };

            btnLogin = new Button { Text = "Entrar", Location = new System.Drawing.Point(150, 190), Size = new System.Drawing.Size(90, 35), BackColor = System.Drawing.Color.FromArgb(0, 120, 215), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnLogin.Click += BtnLogin_Click;

            btnRegistar = new Button { Text = "Registar", Location = new System.Drawing.Point(50, 240), Size = new System.Drawing.Size(280, 30), FlatStyle = FlatStyle.Flat };
            btnRegistar.Click += BtnRegistar_Click;

            this.Controls.AddRange(new Control[] { lblTitulo, lblUser, txtUsername, lblPass, txtPassword, lblErro, btnLogin, btnRegistar });

            this.AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblErro.Text = "";
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblErro.Text = "Preencha username e password.";
                return;
            }

            var user = _ctrl.Login(txtUsername.Text.Trim(), txtPassword.Text);
            if (user == null)
            {
                lblErro.Text = "Credenciais inválidas.";
                txtPassword.Clear();
                return;
            }

            Sessao.UtilizadorId = user.Id;
            Sessao.Username = user.Username;
            Sessao.NomeCompleto = user.Nome;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnRegistar_Click(object sender, EventArgs e)
        {
            using var f = new FormRegistar();
            f.ShowDialog(this);
        }
    }
}
