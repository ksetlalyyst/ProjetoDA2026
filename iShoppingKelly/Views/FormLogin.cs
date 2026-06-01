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
        private readonly UtilizadorController UtilizadorController;
        List<UtilizadorController> utilizadores = new List<UtilizadorController>();
        public int UtilizadorId { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
            var context = new AppDbContext();
            UtilizadorController = new UtilizadorController(context);
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha o username e a password.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var utilizador = UtilizadorController.Login(username, password);
            if (utilizador != null)
            {
                UtilizadorId = utilizador.Id;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Username ou password inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRegistar_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPassword.Text;


            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Introduza um nome de utilizador.");
                return;
            }

            string connectionString = "Server=SERVIDOR;Database=BASE_DADOS;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO utilizadores (username) VALUES (@username)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();

            if (!string.IsNullOrEmpty(username))
            {
                utilizadores.Add(username);
            }
        }
    }
}
