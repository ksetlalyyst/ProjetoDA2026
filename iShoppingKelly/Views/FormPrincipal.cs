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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblBemVinda.Text = "Bem-vinda(o) " + (string.IsNullOrWhiteSpace(utilizadorAtual.Nome) ? utilizadorAtual.Username : utilizadorAtual.Nome) + "!";
            AtualizarCompras();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void artigostool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormArtigo());
        }

        private void tiposDeArtigoTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormTiposArtigo());
        }

        private void orcamentosTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormOrcamentos(utilizadorAtual));
        }

        private void planeamentoComprasTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormPlaneamentoCompras(utilizadorAtual));
            AtualizarCompras();
        }

        private void estatísticasTool_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormEstatísticas(utilizadorAtual));
        }

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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarCompras();
        }

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

        private void AbrirForm(Form form)
        {
            Hide();
            using (form)
            {
                form.ShowDialog();
            }
            Show();
        }

        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView1.CurrentRow != null
                && dataGridView1.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView1.CurrentRow.Cells["Id"].Value), out id);
        }

        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FormUtilizadores(utilizadorAtual));
        }
    }
}
