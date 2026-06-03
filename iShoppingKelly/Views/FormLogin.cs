using iShoppingKelly.Controllers;
using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormLogin : System.Windows.Forms.Form
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
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show("Preencha o username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Preencha a password.");
                return;
            }

            UtilizadorController controller = new UtilizadorController();

            try
            {
                Utilizador utilizador = controller.Login(txtUser.Text, txtPassword.Text);

                MessageBox.Show("Login efetuado com sucesso!");


                FormPrincipal formPrincipal = new FormPrincipal(utilizador);

                this.Hide();
                formPrincipal.ShowDialog();
                this.Show();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao efetuar login.");
            }
        }


        private void btnRegistar_Click(object sender, EventArgs e)
        {
            FormRegistar formRegistar = new FormRegistar();

            this.Hide();
            formRegistar.ShowDialog();
            this.Show();

        }

       
    }
}

       
       
        
    

