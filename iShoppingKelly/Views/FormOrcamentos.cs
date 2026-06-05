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
    
    public partial class FormOrcamentos : System.Windows.Forms.Form
    {
        private Utilizador utilizadorAtual;
        public FormOrcamentos(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }
        private void AtualizarDocumentos()
        {
            dataGridView5.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                dataGridView5.DataSource = context.Orcamentos.Select(o => new
                {
                    o.Id,
                    o.Mes,
                    o.Ano,
                    o.Valor,
                    CriadoPor = o.CriadoPor.Nome
                })
                    .ToList();
            }
        }

        private void CarregarMeses()
        {
            comboMes.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                comboMes.Items.Add(i);
            }
        }

        private void CarregarAnos()
        {
            comboAno.Items.Clear();

            for (int i = 2024; i <= 2035; i++)
            {
                comboAno.Items.Add(i);
            }
        }

        private void FormOrcamentos_Load(object sender, EventArgs e)
        {
            CarregarMeses();
            CarregarAnos();

            AtualizarDocumentos();
        }

        private void btnNovoOrc_Click(object sender, EventArgs e)
        {
            OrcamentoController controller = new OrcamentoController();

            try
            {
                controller.AdicionarOrcamento
                    (Convert.ToInt32(comboMes.Text),
                    Convert.ToInt32(comboAno.Text),
                    Convert.ToDecimal(txtValor.Text),
                    utilizadorAtual.Id);


                AtualizarDocumentos();
                txtValor.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditarOrc_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
            {
                MessageBox.Show("Selecione um orçamento para editar.");
                return;
            }

            int id = (int)dataGridView5.CurrentRow.Cells["Id"].Value;

            OrcamentoController controller = new OrcamentoController();

            try
            {
                controller.EditarOrcamento(id, 
                    Convert.ToInt32(comboMes.Text),
                    Convert.ToInt32(comboAno.Text),
                    Convert.ToDecimal(txtValor.Text));


                AtualizarDocumentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarOrc_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
            {
                MessageBox.Show("Selecione um orçamento.");
                return;
            }

            int id = (int)dataGridView5.CurrentRow.Cells["Id"].Value;

            OrcamentoController controller = new OrcamentoController();

            try
            {
                controller.EliminarOrcamento(id);
                AtualizarDocumentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
            {
                return;
            }

            comboMes.Text = dataGridView5.CurrentRow.Cells["Mes"].Value.ToString();
            comboAno.Text = dataGridView5.CurrentRow.Cells["Ano"].Value.ToString();
            txtValor.Text = dataGridView5.CurrentRow.Cells["Valor"].Value.ToString();
        }
    }
}
