using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Preencha o username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Preencha a password.");
                return;
            }

            try
            {
                UtilizadorController utilizadorController = new UtilizadorController();

                Utilizador utilizador = utilizadorController.Login(username, password);

                Hide();
                using (FormPrincipal formPrincipal = new FormPrincipal(utilizador))
                {
                    formPrincipal.ShowDialog();
                }
                Show();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao efetuar login: " + ex.Message);
            }
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            Hide();
            using (FormRegistar formRegistar = new FormRegistar())
            {
                formRegistar.ShowDialog();
            }
            Show();
        }
    }
}
