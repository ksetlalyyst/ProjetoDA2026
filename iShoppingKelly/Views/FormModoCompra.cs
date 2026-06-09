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
        //Controla se o aviso de orçamento ultrapassado já foi mostrado (requisito 18)
        private bool orcamentoAvisado;

        public FormModoCompra(Compra compra, Utilizador utilizador)
        {
            InitializeComponent();
            compraAtual = compra;
            utilizadorAtual = utilizador;
            Inicializar();
        }

        //Configura o formulário: nome da compra, grelha de itens e totais
        private void Inicializar()
        {
            boxCompraSem.Text = compraAtual.Nome;
            AtualizarItens();
            AtualizarTotais();
            orcamentoAvisado = false;

            //Se a compra já estiver fechada, desativa todas as ações (apenas leitura)
            if (compraAtual.Fechada)
            {
                btnAdquirido.Enabled = false;
                btnItemNPrevi.Enabled = false;
                btnFecharCompra.Enabled = false;
            }
        }

        //Atualiza a grelha com os itens da compra atual
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

        //Calcula e apresenta os totais: orçamento, gasto total e disponível (requisito 17)
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
                .Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
            decimal totalGasto = totalGastoMes + totalCompraAtual;

            lblResulOrc.Text = valorOrcamento.ToString("0.00") + " €";
            lblResulTotalGasto.Text = totalGasto.ToString("0.00") + " €";

            decimal disponivel = valorOrcamento - totalGasto;
            lblResDispo.Text = disponivel.ToString("0.00") + " €";

            //Requisito 18: alerta visual se o orçamento foi ultrapassado
            if (disponivel < 0)
            {
                lblResDispo.ForeColor = System.Drawing.Color.Red;
                lblResDispo.Font = new System.Drawing.Font(lblResDispo.Font, System.Drawing.FontStyle.Bold);

                //Mostra a mensagem de aviso apenas uma vez por sessão
                if (!orcamentoAvisado)
                {
                    orcamentoAvisado = true;
                    MessageBox.Show("Orçamento ultrapassado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lblResDispo.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
                lblResDispo.Font = new System.Drawing.Font(lblResDispo.Font, System.Drawing.FontStyle.Regular);
            }
        }

        //Marca um item como adquirido: pede quantidade e preço (requisito 14)
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

        //Adiciona um item não previsto à compra (requisitos 15 e 16)
        private void btnItemNPrevi_Click(object sender, EventArgs e)
        {
            //Pede o tipo de artigo
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

            //Pede o nome do artigo
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

            //Pede quantidade, preço e observações
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

        //Fecha a compra: regista data/hora e quem fechou (requisito 19)
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

        //Obtém o ID do item selecionado na grelha
        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView8.CurrentRow != null
                && dataGridView8.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView8.CurrentRow.Cells["Id"].Value), out id);
        }

        //Pede um valor inteiro ao utilizador através de InputBox
        private static bool PedirInteiro(string mensagem, string titulo, out int valor)
        {
            valor = 0;
            string texto = Microsoft.VisualBasic.Interaction.InputBox(mensagem, titulo, "1");
            return !string.IsNullOrWhiteSpace(texto) && int.TryParse(texto, out valor) && valor > 0;
        }

        //Pede um valor decimal ao utilizador através de InputBox
        private static bool PedirDecimal(string mensagem, string titulo, out decimal valor)
        {
            valor = 0;
            string texto = Microsoft.VisualBasic.Interaction.InputBox(mensagem, titulo, "0");
            return !string.IsNullOrWhiteSpace(texto) && decimal.TryParse(texto, out valor) && valor >= 0;
        }
    }
}
