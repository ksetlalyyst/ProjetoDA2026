using iShoppingKelly.Controllers;
using iShoppingKelly.Data;
using iShoppingKelly.Models;
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
    public partial class FormEditarCompras : Form
    {
        private Compra compraAtual;
        private Utilizador utilizadorAtual;
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

        private void AtualizarItens()
        {
            dataGridView7.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                dataGridView7.DataSource = context.ItensCompra
                    .Where(i => i.CompraId == compraAtual.Id)
                    .Select(i => new
                    {
                        i.Id,
                        Artigo = i.Artigo.Nome,
                        i.QuantidadePrevista,
                        i.PrecoUnitario,
                        i.Adquirido
                    })
                    .ToList();
            }
        }

        private void btnGuardarNome_Click(object sender, EventArgs e)
        {
            CompraController controller = new CompraController();

            controller.EditarCompra(compraAtual.Id, txtNomeCom.Text);

            MessageBox.Show("Nome Atualizado.");
        }

        private void btnAdicItem_Click(object sender, EventArgs e)
        {
            Artigo artigo = cBoxArtigo.SelectedItem as Artigo;

            if (artigo == null)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            decimal quantidade;
            
            if (!decimal.TryParse(txtQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Quantidade invalida.");
                return;
            }

            ItemCompraController controller = new ItemCompraController();

            controller.AdicionarItem(
                compraAtual.Id,
                artigo.Id,
                quantidade,
                utilizadorAtual.Id);

            AtualizarItens();

            txtQuantidade.Clear();
        }

        private void CarregarArtigos(int tipoId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                cBoxArtigo.DataSource =
                    context.Artigos
                        .Where(a => a.TipoArtigoId == tipoId)
                        .ToList();
            }
        }

        private void CarregarTipos()
        {
            cBoxArtigo.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                cBoxArtigo.DataSource = context.TiposArtigo.ToList();
            }
        }

        private void cBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoArtigo tipo =
                cBoxArtigo.SelectedItem as TipoArtigo;

            if (tipo == null)
            {
                return;
            }

            using (AppDbContext context =
                new AppDbContext())
            {
                cBoxArtigo.DataSource =
                    context.Artigos
                    .Where(a => a.TipoArtigoId == tipo.Id)
                    .ToList();
            }
        }

        private void btnElimItem_Click(object sender, EventArgs e)
        {
            if (dataGridView7.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            int id = (int)dataGridView7.CurrentRow
                .Cells["Id"].Value;

            ItemCompraController controller = new ItemCompraController();

            controller.EliminarItem(id);

            AtualizarItens();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (dataGridView7.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            decimal quantidade;

            if (!decimal.TryParse(txtQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            int id = (int)dataGridView7.CurrentRow
                .Cells["Id"].Value;

            ItemCompraController controller = new ItemCompraController();

            controller.EditarItem(
                id,
                quantidade,
                utilizadorAtual.Id);

            AtualizarItens();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.CurrentRow == null)
            {
                return;
            }

            txtQuantidade.Text = dataGridView7.CurrentRow
                .Cells["QuantidadePrevista"]
                .Value
                .ToString();
        }
    }
}
