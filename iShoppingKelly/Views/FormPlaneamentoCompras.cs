using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormPlaneamentoCompras : Form
    {
        private readonly Utilizador utilizadorAtual;

        public FormPlaneamentoCompras(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }

        //Inicializa o filtro de estado e carrega as compras
        private void FormPlaneamentoCompras_Load(object sender, EventArgs e)
        {
            comboFiltroEstado.Items.AddRange(new string[] { "Todas", "Abertas", "Fechadas" });
            comboFiltroEstado.SelectedIndex = 0;
            AtualizarCompras();
            txtNomeCompra.Clear();
        }

        //Atualiza a grelha de compras aplicando os filtros de nome e estado
        private void AtualizarCompras()
        {
            CompraController compraController = new CompraController();
            string filtro = txtFiltro.Text.Trim().ToLower();
            string estado = comboFiltroEstado.SelectedItem as string;

            //Aplica filtro por nome (se preenchido)
            var compras = compraController.ListarTodas()
                .Where(c => string.IsNullOrWhiteSpace(filtro) || c.Nome.ToLower().Contains(filtro));

            //Aplica filtro por estado (Todas, Abertas, Fechadas)
            if (estado == "Abertas")
            {
                compras = compras.Where(c => !c.Fechada);
            }
            else if (estado == "Fechadas")
            {
                compras = compras.Where(c => c.Fechada);
            }

            dataGridView6.DataSource = compras
                .Select(c => new
                {
                    c.Id,
                    NomeCompra = c.Nome,
                    c.DataCriacao,
                    c.Fechada
                })
                .ToList();

            if (dataGridView6.Columns.Contains("NomeCompra"))
            {
                dataGridView6.Columns["NomeCompra"].HeaderText = "Nome da Compra";
            }
        }

        //Cria uma nova compra com o nome preenchido
        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            string nome = txtNomeCompra.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome da compra.");
                return;
            }

            try
            {
                CompraController compraController = new CompraController();

                compraController.Criar(nome, utilizadorAtual.Id);
                txtNomeCompra.Clear();
                AtualizarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar compra: " + ex.Message);
            }
        }

        //Abre o formulário de edição da compra selecionada (apenas se não estiver fechada)
        private void btnEditarNovaCom_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione uma compra para editar.");
                return;
            }

            CompraController compraController = new CompraController();

            Compra compra = compraController.ObterPorId(id);
            if (compra == null)
            {
                MessageBox.Show("Compra não encontrada.");
                return;
            }

            //Requisito 13: não permite editar compras fechadas
            if (compra.Fechada)
            {
                MessageBox.Show("Não é possível editar uma compra fechada.");
                return;
            }

            Hide();
            using (FormEditarCompras form = new FormEditarCompras(compra, utilizadorAtual))
            {
                form.ShowDialog();
            }
            Show();
            AtualizarCompras();
        }

        //Elimina a compra selecionada (com confirmação)
        private void btnEliminarNovaCom_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione uma compra para eliminar.");
                return;
            }

            if (MessageBox.Show("Eliminar esta compra?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                CompraController compraController = new CompraController();

                compraController.Eliminar(id);
                AtualizarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar compra: " + ex.Message);
            }
        }

        //Atualiza a lista quando o filtro de nome muda
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AtualizarCompras();
        }

        //Atualiza a lista quando o filtro de estado muda
        private void comboFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCompras();
        }

        //Exporta as compras fechadas do utilizador para ficheiro CSV
        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV (*.csv)|*.csv";
                dialog.FileName = "compras_fechadas.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    EstatisticasController estatisticasController = new EstatisticasController();

                    estatisticasController.ExportarComprasCsv(dialog.FileName, utilizadorAtual.Id);
                    MessageBox.Show("Compras fechadas exportadas com sucesso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao exportar: " + ex.Message);
                }
            }
        }

        //Preenche o campo de nome ao clicar numa compra na grelha
        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.CurrentRow == null || !dataGridView6.Columns.Contains("NomeCompra"))
            {
                return;
            }

            txtNomeCompra.Text = Convert.ToString(dataGridView6.CurrentRow.Cells["NomeCompra"].Value);
        }

        //Obtém o ID da compra selecionada na grelha
        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView6.CurrentRow != null
                && dataGridView6.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView6.CurrentRow.Cells["Id"].Value), out id);
        }
    }
}
