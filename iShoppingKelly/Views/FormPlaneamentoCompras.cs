using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
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

        private void FormPlaneamentoCompras_Load(object sender, EventArgs e)
        {
            AtualizarCompras();
            txtNomeCompra.Clear();
        }

        private void AtualizarCompras()
        {
            CompraController compraController = new CompraController();
            string filtro = txtFiltro.Text.Trim().ToLower();

            dataGridView6.DataSource = compraController.ListarTodas()
                .Where(c => string.IsNullOrWhiteSpace(filtro) || c.Nome.ToLower().Contains(filtro))
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AtualizarCompras();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV (*.csv)|*.csv";
                dialog.FileName = "compras.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StringBuilder csv = new StringBuilder();
                csv.AppendLine("Id;Nome;DataCriacao;Fechada");

                CompraController compraController = new CompraController();

                foreach (Compra compra in compraController.ListarTodas())
                {
                    csv.AppendLine(string.Format("{0};{1};{2};{3}", compra.Id, compra.Nome, compra.DataCriacao, compra.Fechada ? "Sim" : "Não"));
                }

                File.WriteAllText(dialog.FileName, csv.ToString(), Encoding.UTF8);
                MessageBox.Show("Compras exportadas com sucesso.");
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.CurrentRow == null || !dataGridView6.Columns.Contains("NomeCompra"))
            {
                return;
            }

            txtNomeCompra.Text = Convert.ToString(dataGridView6.CurrentRow.Cells["NomeCompra"].Value);
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView6.CurrentRow != null
                && dataGridView6.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView6.CurrentRow.Cells["Id"].Value), out id);
        }
    }
}
