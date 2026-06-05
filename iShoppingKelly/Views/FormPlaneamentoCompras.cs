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
    public partial class FormPlaneamentoCompras : Form
    {
        private Utilizador utilizadorAtual;
        public FormPlaneamentoCompras(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }

        private void AtualizarCompras()
        {
            dataGridView6.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                dataGridView6.DataSource = context.Compras
                    .Where (c => !c.Fechada)
                    .Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        c.DataCriacao,
                        c.Fechada
                    })
                    .ToList();
            }
        }

        private void FormPlaneamentoCompras_Load(object sender, EventArgs e)
        {
            AtualizarCompras();

            txtNomeCompra.Clear();
        }

        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            CompraController controller = new CompraController();

            try
            {
                controller.AdicionarCompra(
                    txtNomeCompra.Text,
                    utilizadorAtual.Id);

                AtualizarCompras();

                txtNomeCompra.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditarNovaCom_Click(object sender, EventArgs e)
        {
            if (dataGridView6.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra para editar.");
                return;
            }

            int id = (int)dataGridView6.CurrentRow.Cells["Id"].Value;

            using (AppDbContext context = new AppDbContext())
            {
                Compra compraSelecionada = context.Compras.FirstOrDefault(c => c.Id == id);


                if (compraSelecionada == null)
                {
                    MessageBox.Show("Compra não encontrada.");
                    return;
                }
                if (compraSelecionada.Fechada)
                {
                    MessageBox.Show("Não é possível editar uma compra fechada.");
                    return;
                }

                FormEditarCompras form = new FormEditarCompras(compraSelecionada,
                    utilizadorAtual);

                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            AtualizarCompras();
        }

        private void btnEliminarNovaCom_Click(object sender, EventArgs e)
        {
            if (dataGridView6.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra para eliminar.");
                return;
            }

            int id = (int)dataGridView6.CurrentRow.Cells["Id"].Value;

            CompraController controller = new CompraController();

            try
            {
                controller.EliminarCompra(id);
                AtualizarCompras();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.CurrentRow == null)
            {
                return;
            }

            txtNomeCompra.Text = dataGridView6.CurrentRow.Cells["Nome"].Value.ToString();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            using (AppDbContext context = new AppDbContext())
            {
                string filtro = txtFiltro.Text.ToLower();

                dataGridView6.DataSource = context.Compras
                    .Where (c => !c.Fechada)
                    .Where ( c => c.Nome.ToLower()
                    .Contains(filtro))
                    .Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        c.DataCriacao,
                        c.Fechada
                    })
                    .ToList();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show ("Exportação de compras não implementada ainda.");
        }
    }
}
