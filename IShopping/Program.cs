using iShopping.Data;
using iShopping.Views;
using System;
using System.Windows.Forms;

namespace iShopping
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Garantir que a base de dados está criada
            try
            {
                using var db = new AppDbContext();
                db.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao conectar ao MySQL:\n\n" + ex.Message +
                    "\n\nVerifique:\n" +
                    "  1. O MySQL está em execução\n" +
                    "  2. As credenciais em Data/AppDbContext.cs estão corretas\n" +
                    "  3. O utilizador tem permissão para criar bases de dados",
                    "Erro de Base de Dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Login
            using var loginForm = new FormLogin();
            if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Application.Run(new FormPrincipal());
        }
    }
}
