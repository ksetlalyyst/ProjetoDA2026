using iShopping.Controllers;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormEstatisticas : Form
    {
        private TabControl tabControl;
        private TabPage tabMensais, tabCompras, tabSugestoes;
        private DataGridView dgvMensais, dgvCompras;
        private RichTextBox rtbSugestoes;
        private Button btnGerarSugestoes;
        private readonly CompraController _ctrl = new CompraController();
        private readonly OrcamentoController _orcCtrl = new OrcamentoController();

        public FormEstatisticas()
        {
            this.Text = "Estatísticas";
            this.Size = new Size(850, 530);
            this.StartPosition = FormStartPosition.CenterParent;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            // Tab 1 - Mensais + Compras fechadas
            tabMensais = new TabPage("Orçamentos e Totais");
            tabCompras = new TabPage("Compras Fechadas");
            tabSugestoes = new TabPage("Sugestões Inteligentes");

            CriarTabMensais();
            CriarTabCompras();
            CriarTabSugestoes();

            tabControl.TabPages.AddRange(new[] { tabMensais, tabCompras, tabSugestoes });
            this.Controls.Add(tabControl);

            CarregarMensais();
            CarregarCompras();
        }

        private void CriarTabMensais()
        {
            dgvMensais = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            tabMensais.Controls.Add(dgvMensais);
        }

        private void CriarTabCompras()
        {
            dgvCompras = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            tabCompras.Controls.Add(dgvCompras);
        }

        private void CriarTabSugestoes()
        {
            var pnl = new Panel { Dock = DockStyle.Fill };

            btnGerarSugestoes = new Button
            {
                Text = "🔮 Gerar Sugestões",
                Location = new Point(10, 10),
                Size = new Size(180, 35),
                BackColor = Color.FromArgb(100, 0, 150),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10)
            };
            btnGerarSugestoes.Click += BtnGerarSugestoes_Click;

            rtbSugestoes = new RichTextBox
            {
                Location = new Point(10, 55),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Size = new Size(810, 390),
                ReadOnly = true,
                BackColor = Color.FromArgb(250, 250, 255),
                Font = new Font("Consolas", 10)
            };

            pnl.Controls.AddRange(new Control[] { btnGerarSugestoes, rtbSugestoes });
            tabSugestoes.Controls.Add(pnl);
        }

        private void CarregarMensais()
        {
            try
            {
                var dados = _ctrl.GetEstatisticasMensais();
                dgvMensais.DataSource = dados.Select(d => new
                {
                    Mês = d.Mes.ToString("D2") + "/" + d.Ano,
                    Orçamento = d.Orcamento.ToString("C2"),
                    Total_Compras = d.TotalCompras.ToString("C2"),
                    Diferença = d.Diferenca.ToString("C2"),
                    Estado = d.Diferenca >= 0 ? "✅ Dentro do orçamento" : "⚠ Excedido"
                }).ToList();

                // Colorir linhas excedidas
                foreach (DataGridViewRow row in dgvMensais.Rows)
                {
                    if (row.Cells["Estado"].Value?.ToString().Contains("Excedido") == true)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    else
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CarregarCompras()
        {
            try
            {
                var dados = _ctrl.GetEstatisticasCompras();
                dgvCompras.DataSource = dados.Select(d => new
                {
                    Compra = d.Compra.Nome,
                    Data_Fecho = d.Compra.DataFechada?.ToString("dd/MM/yyyy") ?? "",
                    Total_Itens = d.TotalItens,
                    Previstos = d.Previstos,
                    Nao_Previstos = d.NaoPrevistos,
                    Pct_Previsto = d.PctPrev.ToString("F1") + "%",
                    Pct_Nao_Previsto = d.PctNaoPrev.ToString("F1") + "%"
                }).ToList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnGerarSugestoes_Click(object sender, EventArgs e)
        {
            try
            {
                rtbSugestoes.Clear();
                var hoje = DateTime.Now;
                int semana = ((hoje.Day - 1) / 7) + 1;

                rtbSugestoes.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
                rtbSugestoes.SelectionColor = Color.FromArgb(0, 80, 160);
                rtbSugestoes.AppendText($"📊 SUGESTÕES INTELIGENTES — {hoje:dd/MM/yyyy}\n");
                rtbSugestoes.AppendText(new string('─', 60) + "\n\n");

                // Orçamento sugerido
                decimal orcSugerido = _orcCtrl.SugerirProximoMes();
                var proximoMes = hoje.AddMonths(1);

                rtbSugestoes.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
                rtbSugestoes.SelectionColor = Color.DarkGreen;
                rtbSugestoes.AppendText($"💰 Orçamento Sugerido para {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(proximoMes.Month)} {proximoMes.Year}:\n");
                rtbSugestoes.SelectionFont = new Font("Consolas", 12, FontStyle.Bold);
                rtbSugestoes.SelectionColor = Color.Black;
                rtbSugestoes.AppendText($"   {orcSugerido:C2}");
                rtbSugestoes.SelectionFont = new Font("Segoe UI", 9);
                rtbSugestoes.AppendText("  (média dos últimos 6 meses)\n\n");

                // Lista sugerida
                rtbSugestoes.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
                rtbSugestoes.SelectionColor = Color.FromArgb(150, 80, 0);
                rtbSugestoes.AppendText($"🛒 Lista Sugerida para a {semana}ª semana do mês:\n");
                rtbSugestoes.SelectionFont = new Font("Segoe UI", 9);
                rtbSugestoes.SelectionColor = Color.Gray;
                rtbSugestoes.AppendText($"   (com base em compras feitas nesta semana nos meses anteriores)\n\n");

                var lista = _ctrl.SugerirListaCompras();
                if (!lista.Any())
                {
                    rtbSugestoes.SelectionFont = new Font("Segoe UI", 9, FontStyle.Italic);
                    rtbSugestoes.SelectionColor = Color.Gray;
                    rtbSugestoes.AppendText("   Sem dados suficientes para sugerir uma lista.\n   Complete mais compras para obter sugestões!\n");
                }
                else
                {
                    int i = 1;
                    foreach (var item in lista)
                    {
                        rtbSugestoes.SelectionFont = new Font("Consolas", 10);
                        rtbSugestoes.SelectionColor = Color.Black;
                        rtbSugestoes.AppendText($"   {i++,2}. {item}\n");
                    }
                }

                rtbSugestoes.AppendText("\n" + new string('─', 60) + "\n");
                rtbSugestoes.SelectionFont = new Font("Segoe UI", 8, FontStyle.Italic);
                rtbSugestoes.SelectionColor = Color.Gray;
                rtbSugestoes.AppendText("Sugestões geradas automaticamente com base no histórico de compras.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar sugestões: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
