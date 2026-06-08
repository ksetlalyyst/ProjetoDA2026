using iShoppingKelly.Controllers;
using iShoppingKelly.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormOrcamentos : Form
    {
        private readonly Utilizador utilizadorAtual;

        public FormOrcamentos(Utilizador utilizador)
        {
            InitializeComponent();
            utilizadorAtual = utilizador;
        }

        //Carrega os meses, anos e lista de orçamentos ao iniciar
        private void FormOrcamentos_Load(object sender, EventArgs e)
        {
            CarregarMeses();
            CarregarAnos();
            AtualizarOrcamentos();
        }

        //Preenche o combobox com os nomes dos meses
        private void CarregarMeses()
        {
            comboMes.Items.Clear();

            comboMes.Items.Add(new MesItem(1, "Janeiro"));
            comboMes.Items.Add(new MesItem(2, "Fevereiro"));
            comboMes.Items.Add(new MesItem(3, "Março"));
            comboMes.Items.Add(new MesItem(4, "Abril"));
            comboMes.Items.Add(new MesItem(5, "Maio"));
            comboMes.Items.Add(new MesItem(6, "Junho"));
            comboMes.Items.Add(new MesItem(7, "Julho"));
            comboMes.Items.Add(new MesItem(8, "Agosto"));
            comboMes.Items.Add(new MesItem(9, "Setembro"));
            comboMes.Items.Add(new MesItem(10, "Outubro"));
            comboMes.Items.Add(new MesItem(11, "Novembro"));
            comboMes.Items.Add(new MesItem(12, "Dezembro"));

            foreach (MesItem item in comboMes.Items)
            {
                if (item.Numero == DateTime.Now.Month)
                {
                    comboMes.SelectedItem = item;
                    break;
                }
            }
        }

        //Preenche o combobox com anos (2018 até 10 anos no futuro)
        private void CarregarAnos()
        {
            comboAno.Items.Clear();
            for (int ano = 2018; ano <= DateTime.Now.Year + 10; ano++)
            {
                comboAno.Items.Add(ano);
            }
            comboAno.SelectedItem = DateTime.Now.Year;
        }

        //Atualiza a grelha com todos os orçamentos
        private void AtualizarOrcamentos()
        {
            OrcamentoController orcamentoController = new OrcamentoController();

            dataGridView5.DataSource = orcamentoController.ListarTodos()
                .Select(o => new
                {
                    o.Id,
                    o.Mes,
                    o.Ano,
                    o.Valor
                })
                .ToList();
        }

        //Cria um novo orçamento (valida se já existe para o mesmo mês/ano)
        private void btnNovoOrc_Click(object sender, EventArgs e)
        {
            int mes;
            int ano;
            decimal valor;

            if (!TryLerDados(out mes, out ano, out valor))
            {
                return;
            }

            try
            {
                OrcamentoController orcamentoController = new OrcamentoController();

                //Verifica se já existe orçamento para o mês/ano (requisito 8 - único mensal)
                Orcamento existente = orcamentoController.ObterOrcamentoDoMes(mes, ano);
                if (existente != null)
                {
                    MessageBox.Show("Já existe orçamento para esse mês e ano.");
                    return;
                }

                orcamentoController.Criar(mes, ano, valor, utilizadorAtual.Id);
                txtValor.Clear();
                AtualizarOrcamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar orçamento: " + ex.Message);
            }
        }

        //Edita o orçamento selecionado
        private void btnEditarOrc_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione um orçamento para editar.");
                return;
            }

            int mes;
            int ano;
            decimal valor;
            if (!TryLerDados(out mes, out ano, out valor))
            {
                return;
            }

            try
            {
                OrcamentoController orcamentoController = new OrcamentoController();

                orcamentoController.Atualizar(id, mes, ano, valor, utilizadorAtual.Id);
                AtualizarOrcamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar orçamento: " + ex.Message);
            }
        }

        //Elimina o orçamento selecionado (com confirmação)
        private void btnEliminarOrc_Click(object sender, EventArgs e)
        {
            int id;
            if (!TryGetSelectedId(out id))
            {
                MessageBox.Show("Selecione um orçamento.");
                return;
            }

            if (MessageBox.Show("Eliminar este orçamento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                OrcamentoController orcamentoController = new OrcamentoController();

                orcamentoController.Eliminar(id);
                txtValor.Clear();
                AtualizarOrcamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar orçamento: " + ex.Message);
            }
        }

        //Preenche os campos com os dados do orçamento selecionado na grelha
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
            {
                return;
            }

            int mes;
            if (int.TryParse(Convert.ToString(dataGridView5.CurrentRow.Cells["Mes"].Value), out mes))
            {
                SelecionarMes(mes);
            }

            comboAno.Text = Convert.ToString(dataGridView5.CurrentRow.Cells["Ano"].Value);
            txtValor.Text = Convert.ToString(dataGridView5.CurrentRow.Cells["Valor"].Value);
        }

        //Lê e valida os dados preenchidos nos campos (mês, ano, valor)
        private bool TryLerDados(out int mes, out int ano, out decimal valor)
        {
            mes = 0;
            ano = 0;
            valor = 0;

            MesItem mesItem = comboMes.SelectedItem as MesItem;
            if (mesItem == null)
            {
                MessageBox.Show("Selecione um mês válido.");
                return false;
            }

            mes = mesItem.Numero;

            if (!int.TryParse(Convert.ToString(comboAno.Text), out ano))
            {
                MessageBox.Show("Selecione um ano válido.");
                return false;
            }

            if (!decimal.TryParse(txtValor.Text, out valor) || valor < 0)
            {
                MessageBox.Show("Introduza um valor válido.");
                return false;
            }

            return true;
        }

        //Seleciona um mês específico no combobox
        private void SelecionarMes(int mes)
        {
            foreach (MesItem item in comboMes.Items)
            {
                if (item.Numero == mes)
                {
                    comboMes.SelectedItem = item;
                    return;
                }
            }
        }

        //Obtém o ID do orçamento selecionado na grelha
        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            return dataGridView5.CurrentRow != null
                && dataGridView5.Columns.Contains("Id")
                && int.TryParse(Convert.ToString(dataGridView5.CurrentRow.Cells["Id"].Value), out id);
        }

        //Classe auxiliar para representar um mês no combobox
        private class MesItem
        {
            public MesItem(int numero, string nome)
            {
                Numero = numero;
                Nome = nome;
            }

            public int Numero { get; private set; }

            public string Nome { get; private set; }

            public override string ToString()
            {
                return Nome;
            }
        }
    }
}
