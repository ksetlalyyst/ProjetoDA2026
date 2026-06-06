using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormArtigo : Form
    {
        public FormArtigo()
        {
            InitializeComponent();
        }

        private void FormArtigo_Load(object sender, EventArgs e)
        {
            CarregarTipos();
            AtualizarArtigos();
        }

        private void CarregarTipos()
        {
            TipoArtigoController tipoArtigoController = new TipoArtigoController();
            List<TipoArtigo> tipos = tipoArtigoController.ListarTodos();

            TipoArtigo todos = new TipoArtigo();
            todos.Id = 0;
            todos.Nome = "Todos";

            tipos.Insert(0, todos);

            comboBoxFiltrarTipo.DataSource = tipos;
            comboBoxFiltrarTipo.DisplayMember = "Nome";
            comboBoxFiltrarTipo.ValueMember = "Id";
        }

        private void AtualizarArtigos()
        {
            ArtigoController artigoController = new ArtigoController();
            TipoArtigo tipo = comboBoxFiltrarTipo.SelectedItem as TipoArtigo;
            List<Artigo> artigos = tipo == null || tipo.Id == 0
                ? artigoController.ListarTodos()
                : artigoController.ListarPorTipo(tipo.Id);

            dataGridView4.DataSource = artigos
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Tipo = a.TipoArtigo == null ? "" : a.TipoArtigo.Nome
                })
                .ToList();
        }

        private void comboBoxFiltrarTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarArtigos();
        }

        private void txtFiltrarNome_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnNovoArtigo_Click(object sender, EventArgs e)
        {
            TipoArtigo tipo = comboBoxFiltrarTipo.SelectedItem as TipoArtigo;
            string nome = txtArtigoNome.Text.Trim();

            if (tipo == null || tipo.Id == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo válido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do artigo.");
                return;
            }

            try
            {
                ArtigoController artigoController = new ArtigoController();

                artigoController.Criar(nome, tipo.Id);
                txtArtigoNome.Clear();
                AtualizarArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar artigo: " + ex.Message);
            }
        }

        private void btnEditarArtigo_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(dataGridView4, out id))
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            TipoArtigo tipo = comboBoxFiltrarTipo.SelectedItem as TipoArtigo;
            string nome = txtArtigoNome.Text.Trim();

            if (tipo == null || tipo.Id == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo válido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do artigo.");
                return;
            }

            try
            {
                ArtigoController artigoController = new ArtigoController();

                artigoController.Atualizar(id, nome, tipo.Id);
                txtArtigoNome.Clear();
                AtualizarArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar artigo: " + ex.Message);
            }
        }

        private void btnEliminarArtigo_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(dataGridView4, out id))
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            if (MessageBox.Show("Eliminar este artigo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                ArtigoController artigoController = new ArtigoController();

                artigoController.Eliminar(id);
                txtArtigoNome.Clear();
                AtualizarArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar artigo: " + ex.Message);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentRow == null || !dataGridView4.Columns.Contains("Nome"))
            {
                return;
            }

            txtArtigoNome.Text = Convert.ToString(dataGridView4.CurrentRow.Cells["Nome"].Value);
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
