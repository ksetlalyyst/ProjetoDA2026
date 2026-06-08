using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormPrincipal : Form
    {
        private readonly Utilizador utilizadorAtual;

        public FormPrincipal(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }

        //Apresenta a mensagem de boas-vindas e carrega as compras em aberto
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblBemVinda.Text = "Bem-vinda(o) " + (string.IsNullOrWhiteSpace(utilizadorAtual.Nome) ? utilizadorAtual.Username : utilizadorAtual.Nome) + "!";
            AtualizarCompras();
        }

        //Menu: Sair - fecha a aplicação
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Menu: Gestão > Artigos
        private void artigostool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormArtigo());
        }

        //Menu: Gestão > Tipos de Artigo
        private void tiposDeArtigoTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormTiposArtigo());
        }

        //Menu: Gestão > Orçamentos
        private void orcamentosTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormOrcamentos(utilizadorAtual));
        }

        //Menu: Compras > Planeamento Compras
        private void planeamentoComprasTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormPlaneamentoCompras(utilizadorAtual));
            AtualizarCompras();
        }

        //Menu: Relatórios > Estatísticas
        private void estatísticasTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormEstatísticas(utilizadorAtual));
        }

        //Abre o Modo Compra para a compra selecionada na grelha
        private void btnModoCompra_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione uma compra.");
                return;
            }

            CompraController compraController = new CompraController();

            Compra compra = compraController.ObterPorId(id);
            if (compra == null)
            {
                MessageBox.Show("Compra não encontrada.");
                return;
            }

            AbrirForm(new FormModoCompra(compra, utilizadorAtual));
            AtualizarCompras();
        }

        //Atualiza a lista de compras em aberto
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarCompras();
        }

        //Carrega as compras que ainda estão abertas (não fechadas)
        private void AtualizarCompras()
        {
            CompraController compraController = new CompraController();

            dataGridView1.DataSource = compraController.ListarPorEstado(false)
                .Select(c => new
                {
                    c.Id,
                    c.Nome,
                    c.DataCriacao
                })
                .ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //Abre um formulário filho, escondendo o formulário atual
        private void AbrirForm(Form form)
        {
            Hide();
            using (form)
            {
                form.ShowDialog();
            }
            Show();
        }

        //Obtém o ID selecionado na primeira coluna da DataGridView
        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView1.CurrentRow != null
                && dataGridView1.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value), out id);
        }

        //Menu: Gestão > Utilizadores
        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormUtilizadores(utilizadorAtual));
        }
    }
}
