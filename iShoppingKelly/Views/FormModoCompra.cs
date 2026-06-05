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
    public partial class FormModoCompra : Form
    {
        private Compra compraAtual;
        private Utilizador utilizadorAtual;

        public FormModoCompra(Compra compra, Utilizador utilizador)
        {
            InitializeComponent();
            compraAtual = compra;
            utilizadorAtual = utilizador;
        }

        private void AtualizarItens()
        {
            using (AppDbContext context = new AppDbContext())
            {
                dataGridView8.DataSource = context.ItensCompra
                    .Where(i => i.CompraId == compraAtual.Id)
                    .Select(i => new
                    {
                        i.Id,
                        Artigo = i.Artigo.Nome,
                        i.QuantidadePrevista,
                        i.QuantidadeAdquirida,
                        i.PrecoUnitario,
                        i.Adquirido
                    })
                    .ToList();
            }
        }

        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            CompraController controller = new CompraController();

            try
            {
                controller.FecharCompra(
                    compraAtual.Id,
                    utilizadorAtual.Id);

                MessageBox.Show("Compra fechada com sucesso.");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdquirido_Click(object sender, EventArgs e)
        {
            if (dataGridView8.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item.");
                return;
            }

            try
            {
                int itemId = Convert.ToInt32(dataGridView8.CurrentRow.Cells["Id"].Value);

                decimal quantidade = Convert.ToDecimal(dataGridView8.CurrentRow
                        .Cells["QuantidadeAdquirida"]
                        .Value);

                decimal preco = Convert.ToDecimal( dataGridView8.CurrentRow
                        .Cells["PrecoUnitario"]
                        .Value);

                ItemCompraController controller = new ItemCompraController();

                controller.MarcarAdquirido(
                    itemId,
                    quantidade,
                    preco,
                    utilizadorAtual.Id);

                AtualizarItens();
                AtualizarTotais();

                MessageBox.Show( "Item marcado como adquirido.");
            }
            catch
            {
                MessageBox.Show("Preencha Quantidade Adquirida e Preço Unitário.");
            }
        }

        private void AtualizarTotais()
        {
            using (AppDbContext context = new AppDbContext())
            {
                decimal totalGasto = context.ItensCompra
                    .Where(i =>
                        i.CompraId == compraAtual.Id &&
                        i.Adquirido)
                    .Sum(i =>
                        (i.QuantidadeAdquirida ?? 0) *
                        (i.PrecoUnitario ?? 0));

                lblResulTotalGasto.Text = totalGasto.ToString("0.00 €");
            }
        }

        private void btnItemNPrevi_Click(object sender, EventArgs e)
        {
            
        }


    }
}
