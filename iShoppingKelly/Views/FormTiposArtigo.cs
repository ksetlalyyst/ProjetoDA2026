using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormTiposArtigo : Form
    {
        public FormTiposArtigo()
        {
            InitializeComponent();
        }

        private void FormTiposArtigo_Load(object sender, EventArgs e)
        {
            AtualizarTipos();
        }

        private void AtualizarTipos()
        {
            TipoArtigoController tipoArtigoController = new TipoArtigoController();

            dataGridView3.DataSource = tipoArtigoController.ListarTodos()
                .Select(t => new
                {
                    t.Id,
                    t.Nome
                })
                .ToList();
        }

        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            string nome = txtNomeTipoArt.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do tipo de artigo.");
                return;
            }

            try
            {
                TipoArtigoController tipoArtigoController = new TipoArtigoController();

                tipoArtigoController.Criar(nome);
                txtNomeTipoArt.Clear();
                AtualizarTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar tipo de artigo: " + ex.Message);
            }
        }

        private void btnEditarTipo_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(dataGridView3, out id))
            {
                MessageBox.Show("Selecione um tipo para editar.");
                return;
            }

            string nome = txtNomeTipoArt.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do tipo de artigo.");
                return;
            }

            try
            {
                TipoArtigoController tipoArtigoController = new TipoArtigoController();

                tipoArtigoController.Atualizar(id, nome);
                txtNomeTipoArt.Clear();
                AtualizarTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar tipo de artigo: " + ex.Message);
            }
        }

        private void btnEliminarTipo_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(dataGridView3, out id))
            {
                MessageBox.Show("Selecione um tipo para eliminar.");
                return;
            }

            if (MessageBox.Show("Eliminar este tipo de artigo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                TipoArtigoController tipoArtigoController = new TipoArtigoController();

                tipoArtigoController.Eliminar(id);
                txtNomeTipoArt.Clear();
                AtualizarTipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar tipo de artigo: " + ex.Message);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentRow == null || !dataGridView3.Columns.Contains("Nome"))
            {
                return;
            }

            txtNomeTipoArt.Text = Convert.ToString(dataGridView3.CurrentRow.Cells["Nome"].Value);
        }

        private static bool TryGetSelectedId(DataGridView dataGridView, out int id)
        {
            id = 0;
            return dataGridView.CurrentRow != null
                && dataGridView.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView.CurrentRow.Cells["Id"].Value), out id);
        }
    }
}
