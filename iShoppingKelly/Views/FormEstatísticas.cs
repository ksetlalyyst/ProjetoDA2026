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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AtualizarDados();
        }

        private void tabOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDados();
        }

        private void AtualizarDados()
        {
            try
            {
                EstatisticasController estatisticasController = new EstatisticasController();

                if (tabOpcoes.SelectedTab == tabOrçaTotal)
                {
                    dataGridView1.DataSource = estatisticasController.ObterEstatisticasMensais();
                    return;
                }

                if (tabOpcoes.SelectedTab == tabComFechada)
                {
                    dataGridView1.DataSource = estatisticasController.ObterPercentagensCompras();
                    return;
                }

                if (tabOpcoes.SelectedTab == tabSugInteli)
                {
                    dataGridView1.DataSource = estatisticasController.SugerirListaCompras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estatísticas: " + ex.Message);
            }
        }
    }
}
