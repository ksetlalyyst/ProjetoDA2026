using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormModoCompra : Form
    {
        private readonly Compra compraAtual;
        private readonly Utilizador utilizadorAtual;

        public FormModoCompra(Compra compra, Utilizador utilizador)
        {
            InitializeComponent();
            compraAtual = compra;
            utilizadorAtual = utilizador;
            Inicializar();
        }

        private void Inicializar()
        {
            boxCompraSem.Text = compraAtual.Nome;
            AtualizarItens();
            AtualizarTotais();

            if (compraAtual.Fechada)
            {
                btnAdquirido.Enabled = false;
                btnItemNPrevi.Enabled = false;
                btnFecharCompra.Enabled = false;
            }
        }

        private void AtualizarItens()
        {
            ItemCompraController itemCompraController = new ItemCompraController();

            dataGridView8.DataSource = itemCompraController.ListarPorCompra(compraAtual.Id)
                .Select(i => new
                {
                    i.Id,
                    Artigo = i.Artigo == null ? "" : i.Artigo.Nome,
                    i.Previsto,
                    i.QuantidadePrevista,
                    i.QuantidadeAdquirida,
                    i.PrecoUnitario,
                    i.Adquirido,
                    i.Observacoes
                })
                .ToList();
        }

        private void AtualizarTotais()
        {
            OrcamentoController orcamentoController = new OrcamentoController();
            ItemCompraController itemCompraController = new ItemCompraController();

            DateTime agora = DateTime.Now;
            Orcamento orcamento = orcamentoController.ObterOrcamentoDoMes(agora.Month, agora.Year);
            decimal valorOrcamento = orcamento == null ? 0 : orcamento.Valor;
            decimal totalGastoMes = orcamentoController.ObterTotalGastoNoMes(agora.Month, agora.Year);
            decimal totalCompraAtual = itemCompraController.ListarPorCompra(compraAtual.Id)
                .Where(i => i.Adquirido)
                .Sum(i => (i.QuantidadeAdquirida ?? 0) * (i.PrecoUnitario ?? 0));
            decimal totalGasto = totalGastoMes + totalCompraAtual;

            lblResulOrc.Text = valorOrcamento.ToString("0.00") + " €";
            lblResulTotalGasto.Text = totalGasto.ToString("0.00") + " €";
            lblResDispo.Text = (valorOrcamento - totalGasto).ToString("0.00") + " €";
        }

        private void btnAdquirido_Click(object sender, EventArgs e)
        {
            int itemId;
            if (!TryGetSelectedId(out itemId))
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            int quantidade;
            decimal preco;
            if (!PedirInteiro("Quantidade adquirida:", "Marcar adquirido", out quantidade))
            {
                return;
            }

            if (!PedirDecimal("Preço unitário:", "Marcar adquirido", out preco))
            {
                return;
            }

            try
            {
                ItemCompraController itemCompraController = new ItemCompraController();

                itemCompraController.AtualizarQuantidadeAdquirida(itemId, quantidade, preco, utilizadorAtual.Id);
                AtualizarItens();
                AtualizarTotais();
                MessageBox.Show("Item atualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar item: " + ex.Message);
            }
        }

        private void btnItemNPrevi_Click(object sender, EventArgs e)
        {
            string tipoTexto = Microsoft.VisualBasic.Interaction.InputBox("Tipo de artigo:", "Item não previsto", "");
            if (string.IsNullOrWhiteSpace(tipoTexto))
            {
                return;
            }

            TipoArtigoController tipoArtigoController = new TipoArtigoController();

            TipoArtigo tipo = tipoArtigoController.ListarTodos()
                .FirstOrDefault(t => string.Equals(t.Nome, tipoTexto.Trim(), StringComparison.OrdinalIgnoreCase));

            if (tipo == null)
            {
                MessageBox.Show("Tipo de artigo não encontrado.");
                return;
            }

            string artigoTexto = Microsoft.VisualBasic.Interaction.InputBox("Artigo:", "Item não previsto", "");
            if (string.IsNullOrWhiteSpace(artigoTexto))
            {
                return;
            }

            ArtigoController artigoController = new ArtigoController();

            Artigo artigo = artigoController.ListarPorTipo(tipo.Id)
                .FirstOrDefault(a => string.Equals(a.Nome, artigoTexto.Trim(), StringComparison.OrdinalIgnoreCase));

            if (artigo == null)
            {
                MessageBox.Show("Artigo não encontrado para o tipo selecionado.");
                return;
            }

            int quantidade;
            decimal preco;
            if (!PedirInteiro("Quantidade:", "Item não previsto", out quantidade))
            {
                return;
            }

            if (!PedirDecimal("Preço unitário:", "Item não previsto", out preco))
            {
                return;
            }

            string observacoes = Microsoft.VisualBasic.Interaction.InputBox("Observações:", "Item não previsto", "");

            try
            {
                ItemCompraController itemCompraController = new ItemCompraController();

                itemCompraController.AdicionarItemNaoPrevisto(compraAtual.Id, artigo.Id, quantidade, preco, observacoes, utilizadorAtual.Id);
                AtualizarItens();
                AtualizarTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar item não previsto: " + ex.Message);
            }
        }

        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fechar compra? Depois disso deixa de poder ser alterada.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                CompraController compraController = new CompraController();

                compraController.Fechar(compraAtual.Id, utilizadorAtual.Id);
                MessageBox.Show("Compra fechada.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar compra: " + ex.Message);
            }
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView8.CurrentRow != null
                && dataGridView8.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView8.CurrentRow.Cells["Id"].Value), out id);
        }

        private static bool PedirInteiro(string mensagem, string titulo, out int valor)
        {
            valor = 0;
            string texto = Microsoft.VisualBasic.Interaction.InputBox(mensagem, titulo, "1");
            return !string.IsNullOrWhiteSpace(texto) && int.TryParse(texto, out valor) && valor > 0;
        }

        private static bool PedirDecimal(string mensagem, string titulo, out decimal valor)
        {
            valor = 0;
            string texto = Microsoft.VisualBasic.Interaction.InputBox(mensagem, titulo, "0");
            return !string.IsNullOrWhiteSpace(texto) && decimal.TryParse(texto, out valor) && valor >= 0;
        }
    }
}
