using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormEstatísticas : Form
    {
        private readonly Utilizador utilizadorAtual;

        public FormEstatísticas()
            : this(null)
        {
        }

        public FormEstatísticas(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
            tabOpcoes.SelectedIndexChanged += tabOpcoes_SelectedIndexChanged;
        }

        //Carrega os dados da estatística do separador inicial ao abrir
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AtualizarDados();
        }

        //Atualiza os dados quando o separador muda
        private void tabOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDados();
        }

        //Carrega os dados conforme o separador selecionado
        private void AtualizarDados()
        {
            try
            {
                EstatisticasController estatisticasController = new EstatisticasController();

                //Separador 1: Estatísticas Mensais
                //Mostra duas grelhas: orçamentos totais (req 21a) e % compras fechadas (req 21b)
                if (tabOpcoes.SelectedTab == tabEstatisticas)
                {
                    dataGridView1.DataSource = estatisticasController.ObterEstatisticasMensais();
                    dataGridView2.DataSource = estatisticasController.ObterPercentagensCompras();

                    return;
                }

                //Separador 2: Sugestões Inteligentes
                //Mostra sugestão de orçamento (req 21c) e lista de compras sugerida (req 21c)
                if (tabOpcoes.SelectedTab == tabSugInteli)
                {
                    decimal sugestaoOrcamento = estatisticasController.SugerirOrcamentoProximoMes();

                    lblSugestaoOrcamento.Text = "Orçamento sugerido para o próximo mês: " + sugestaoOrcamento.ToString("0.00") + " €";
                    dataGridView3.DataSource = estatisticasController.SugerirListaCompras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estatísticas: " + ex.Message);
            }
        }
    }
}
