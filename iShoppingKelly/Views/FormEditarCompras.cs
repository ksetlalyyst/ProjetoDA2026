using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormEditarCompras : Form
    {
        private Compra compraAtual;
        private readonly Utilizador utilizadorAtual;

        public FormEditarCompras(Compra compra, Utilizador utilizador)
        {
            InitializeComponent();
            compraAtual = compra;
            utilizadorAtual = utilizador;
        }

        private void FormEditarCompras_Load(object sender, EventArgs e)
        {
            txtNomeCom.Text = compraAtual.Nome;
            CarregarTipos();
            AtualizarItens();
        }

        private void CarregarTipos()
        {
            TipoArtigoController tipoArtigoController = new TipoArtigoController();

            cBoxTipo.DataSource = tipoArtigoController.ListarTodos();
            cBoxTipo.DisplayMember = "Nome";
            cBoxTipo.ValueMember = "Id";
        }

        private void CarregarArtigos(int tipoId)
        {
            ArtigoController artigoController = new ArtigoController();

            cBoxArtigo.DataSource = artigoController.ListarPorTipo(tipoId);
            cBoxArtigo.DisplayMember = "Nome";
            cBoxArtigo.ValueMember = "Id";
        }

        private void AtualizarItens()
        {
            ItemCompraController itemCompraController = new ItemCompraController();

            dataGridView7.DataSource = itemCompraController.ListarPorCompra(compraAtual.Id)
                .Select(i => new
                {
                    i.Id,
                    Artigo = i.Artigo == null ? "" : i.Artigo.Nome,
                    i.QuantidadePrevista,
                    i.Adquirido,
                    i.QuantidadeAdquirida,
                    i.PrecoUnitario
                })
                .ToList();
        }

        private void btnGuardarNome_Click(object sender, EventArgs e)
        {
            string nome = txtNomeCom.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome da compra.");
                return;
            }

            try
            {
                CompraController compraController = new CompraController();

                compraController.Atualizar(compraAtual.Id, nome);
                compraAtual = compraController.ObterPorId(compraAtual.Id);
                MessageBox.Show("Nome atualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar compra: " + ex.Message);
            }
        }

        private void btnAdicItem_Click(object sender, EventArgs e)
        {
            Artigo artigo = cBoxArtigo.SelectedItem as Artigo;
            int quantidade;

            if (artigo == null)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Introduza uma quantidade prevista válida.");
                return;
            }

            try
            {
                ItemCompraController itemCompraController = new ItemCompraController();

                itemCompraController.AdicionarItemPrevisto(compraAtual.Id, artigo.Id, quantidade, utilizadorAtual.Id);
                txtQuantidade.Clear();
                AtualizarItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar item: " + ex.Message);
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            Artigo artigo = cBoxArtigo.SelectedItem as Artigo;
            int quantidade;

            if (artigo == null)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Introduza uma quantidade prevista válida.");
                return;
            }

            try
            {
                ItemCompraController itemCompraController = new ItemCompraController();

                itemCompraController.AtualizarItemPrevisto(id, artigo.Id, quantidade, utilizadorAtual.Id);
                AtualizarItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar item: " + ex.Message);
            }
        }

        private void btnElimItem_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            if (MessageBox.Show("Remover este item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                ItemCompraController itemCompraController = new ItemCompraController();

                itemCompraController.Eliminar(id);
                AtualizarItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover item: " + ex.Message);
            }
        }

        private void cBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoArtigo tipo = cBoxTipo.SelectedItem as TipoArtigo;
            if (tipo == null)
            {
                cBoxArtigo.DataSource = null;
                return;
            }

            CarregarArtigos(tipo.Id);
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.CurrentRow == null)
            {
                return;
            }

            txtQuantidade.Text = Convert.ToString(dataGridView7.CurrentRow.Cells["QuantidadePrevista"].Value);
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView7.CurrentRow != null
                && dataGridView7.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView7.CurrentRow.Cells["Id"].Value), out id);
        }
    }
}
