using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormUtilizadores : Form
    {
        public FormUtilizadores()
        {
            InitializeComponent();
        }

        public FormUtilizadores(Utilizador utilizador)
        {
            InitializeComponent();
        }

        private void FormUtilizadores_Load(object sender, EventArgs e)
        {
            AtualizarUtilizadores();
        }

        private void AtualizarUtilizadores()
        {
            UtilizadorController utilizadorController = new UtilizadorController();

            dataGridView1.DataSource = utilizadorController.ListarTodos()
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Username
                })
                .ToList();
        }

        private void btnNovoUti_Click(object sender, EventArgs e)
        {
            using (FormRegistar form = new FormRegistar())
            {
                form.ShowDialog();
            }
            AtualizarUtilizadores();
        }

        private void btnEditUti_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione um utilizador.");
                return;
            }

            UtilizadorController utilizadorController = new UtilizadorController();

            Utilizador utilizador = utilizadorController.ObterPorId(id);
            if (utilizador == null)
            {
                MessageBox.Show("Utilizador não encontrado.");
                return;
            }

            string nome = Microsoft.VisualBasic.Interaction.InputBox("Nome:", "Editar Utilizador", utilizador.Nome);
            if (string.IsNullOrWhiteSpace(nome))
            {
                return;
            }

            string username = Microsoft.VisualBasic.Interaction.InputBox("Username:", "Editar Utilizador", utilizador.Username);
            if (string.IsNullOrWhiteSpace(username))
            {
                return;
            }

            string password = Microsoft.VisualBasic.Interaction.InputBox("Nova password (deixe vazio para manter):", "Editar Utilizador", "");

            try
            {
                if (!string.Equals(utilizador.Username, username, StringComparison.OrdinalIgnoreCase)
                    && utilizadorController.UsernameExists(username))
                {
                    MessageBox.Show("Username já existe.");
                    return;
                }

                utilizadorController.Atualizar(id, nome.Trim(), username.Trim(), password);
                AtualizarUtilizadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar utilizador: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione um utilizador.");
                return;
            }

            if (MessageBox.Show("Eliminar este utilizador?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                UtilizadorController utilizadorController = new UtilizadorController();

                utilizadorController.Eliminar(id);
                AtualizarUtilizadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar utilizador: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView1.CurrentRow != null
                && dataGridView1.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value), out id);
        }
    }
}
