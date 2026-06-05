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
    public partial class FormPrincipal : System.Windows.Forms.Form
    {
        private Utilizador utilizadorAtual;
        public FormPrincipal(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblBemVinda.Text = "Bem-Vinda(o) " + utilizadorAtual.Nome + "!";

            AtualizarCompras();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void artigostool_Click(object sender, EventArgs e)
        {
            FormArtigo form = new FormArtigo();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void tiposDeArtigoTool_Click(object sender, EventArgs e)
        {
            FormTiposArtigo form = new FormTiposArtigo();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void orcamentosTool_Click(object sender, EventArgs e)
        {
            FormOrcamentos form = new FormOrcamentos(utilizadorAtual);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void planeamentoComprasTool_Click(object sender, EventArgs e)
        {
            FormPlaneamentoCompras form = new FormPlaneamentoCompras(utilizadorAtual);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void estatísticasTool_Click(object sender, EventArgs e)
        {
            FormEstatísticas form = new FormEstatísticas();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnModoCompra_Click(object sender, EventArgs e)
        { 
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra.");
                return;
            }

            int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            using (AppDbContext context = new AppDbContext())
            {
                Compra compra = context.Compras
                    .FirstOrDefault(c => c.Id == id);

                if (compra == null)
                {
                    MessageBox.Show("Compra não encontrada.");
                    return;
                }

                FormModoCompra form = new FormModoCompra(
                        compra,
                        utilizadorAtual);

                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarCompras();
        }

        private void AtualizarCompras()
        {
            dataGridView1.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                dataGridView1.DataSource = context.Compras
                    .Where(c => !c.Fechada)
                    .Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        c.DataCriacao
                    })
                    .ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
