using iShoppingKelly.Controllers;
using System;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormRegistar : Form
    {
        public FormRegistar()
        {
            InitializeComponent();
        }

        //Define a máscara das passwords com '*' ao carregar o formulário
        private void FormRegistar_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtConfirm.PasswordChar = '*';
        }

        //Regista um novo utilizador após validar os campos
        private void btnRegistar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text;
            string confirmacao = txtConfirm.Text;

            //Validações obrigatórias
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome.");
                return;
            }

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

            //Confirma que as passwords coincidem
            if (password != confirmacao)
            {
                MessageBox.Show("As passwords não coincidem.");
                return;
            }

            try
            {
                UtilizadorController utilizadorController = new UtilizadorController();

                //Verifica se o username já existe
                if (utilizadorController.UsernameExists(username))
                {
                    MessageBox.Show("Username já existe.");
                    return;
                }

                //Regista o novo utilizador
                utilizadorController.Registar(nome, username, password);
                MessageBox.Show("Utilizador registado com sucesso.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registar o utilizador: " + ex.Message);
            }
        }

        //Fecha o formulário de registo
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
