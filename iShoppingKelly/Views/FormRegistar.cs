using iShoppingKelly.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormRegistar : System.Windows.Forms.Form
    {
        public FormRegistar()
        {
            InitializeComponent();
        }

        private void FormRegistar_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtConfirm.PasswordChar = '*';
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Preencha o nome.");
                return;
            }

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Preencha o username.");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Preencha a password.");
                return;
            }

            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("As passwords não coincidem.");
                return;
            }

            UtilizadorController controller = new UtilizadorController();

            try
            {
                controller.Registar(
                    txtNome.Text,
                    txtUser.Text,
                    txtPassword.Text
                    );

                MessageBox.Show("Utilizador registado com sucesso.");

                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao registar o utilizador.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
