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

        //Define a máscara da password com '*' ao carregar o formulário
        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        //Autentica o utilizador com username/password e abre o FormPrincipal
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text;

            //Validação dos campos
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
                //Tenta autenticar
                UtilizadorController utilizadorController = new UtilizadorController();

                Utilizador utilizador = utilizadorController.Login(username, password);

                //Abre o formulário principal e esconde o login
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

        //Abre o formulário de registo de novo utilizador
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
