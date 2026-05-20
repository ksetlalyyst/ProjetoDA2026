using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormModoCompra : Form
    {
        private Label lblNomeCompra, lblOrcamento, lblGasto, lblDisponivel, lblAlerta;
        private DataGridView dgvItens;
        private Button btnAdquirir, btnNaoPrevisto, btnFechar;
        private Panel pnlOrcamento;

        private readonly CompraController _ctrl = new CompraController();
        private readonly OrcamentoController _orcCtrl = new OrcamentoController();
        private readonly ArtigoController _artigoCtrl = new ArtigoController();
        private readonly TipoArtigoController _tipoCtrl = new TipoArtigoController();
        private readonly int _compraId;

        public FormModoCompra(int compraId)
        {
            _compraId = compraId;
            this.Text = "🛒 Modo Compra";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Painel orçamento
            pnlOrcamento = new Panel { Location = new Point(10, 10), Size = new Size(860, 70), BackColor = Color.FromArgb(230, 240, 255), BorderStyle = BorderStyle.FixedSingle };

            lblNomeCompra = new Label { Location = new Point(10, 5), Size = new Size(400, 22), Font = new Font("Segoe UI", 11, FontStyle.Bold) };
            lblOrcamento = new Label { Location = new Point(10, 30), Size = new Size(200, 20) };
            lblGasto = new Label { Location = new Point(220, 30), Size = new Size(200, 20) };
            lblDisponivel = new Label { Location = new Point(430, 30), Size = new Size(200, 20), Font = new Font("Segoe UI", 9, FontStyle.Bold) };

            lblAlerta = new Label
            {
                Location = new Point(10, 50), Size = new Size(840, 22),
                ForeColor = Color.Red, Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Visible = false
            };

            pnlOrcamento.Controls.AddRange(new Control[] { lblNomeCompra, lblOrcamento, lblGasto, lblDisponivel, lblAlerta });
            this.Controls.Add(pnlOrcamento);

            this.Controls.Add(new Label { Text = "Itens da Compra:", Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(10, 88), Size = new Size(200, 22) });

            dgvItens = new DataGridView
            {
                Location = new Point(10, 115),
                Size = new Size(860, 360),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            this.Controls.Add(dgvItens);

            // Botões
            int bx = 10, by = 485;
            Button Btn(string t, Color c, int w = 140) { var b = new Button { Text = t, Location = new Point(bx, by), Size = new Size(w, 35), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9) }; bx += w + 8; return b; }

            btnAdquirir = Btn("✓ Marcar Adquirido", Color.FromArgb(0, 130, 0), 160);
            btnNaoPrevisto = Btn("+ Item Não Previsto", Color.FromArgb(180, 100, 0), 160);
            btnFechar = Btn("🔒 Fechar Compra", Color.DarkRed, 140);

            btnAdquirir.Click += BtnAdquirir_Click;
            btnNaoPrevisto.Click += BtnNaoPrevisto_Click;
            btnFechar.Click += BtnFechar_Click;

            this.Controls.AddRange(new Control[] { btnAdquirir, btnNaoPrevisto, btnFechar });

            Carregar();
        }

        private void Carregar()
        {
            var compra = _ctrl.GetPorId(_compraId);
            if (compra == null) { this.Close(); return; }

            lblNomeCompra.Text = compra.Nome;

            // Orçamento
            var hoje = DateTime.Now;
            var orc = _orcCtrl.GetAtual();
            decimal valorOrc = orc?.Valor ?? 0;
            decimal gasto = _ctrl.GetTotalGastoMes(hoje.Month, hoje.Year);
            decimal disponivel = valorOrc - gasto;

            lblOrcamento.Text = $"Orçamento mês: {valorOrc:C2}";
            lblGasto.Text = $"Total gasto: {gasto:C2}";
            lblDisponivel.Text = $"Disponível: {disponivel:C2}";

            if (disponivel < 0)
            {
                lblDisponivel.ForeColor = Color.Red;
                lblAlerta.Text = "⚠⚠ ATENÇÃO: ORÇAMENTO ULTRAPASSADO! Já gastou mais do que o orçamento definido! ⚠⚠";
                lblAlerta.Visible = true;
                pnlOrcamento.BackColor = Color.FromArgb(255, 220, 220);
            }
            else
            {
                lblDisponivel.ForeColor = Color.FromArgb(0, 100, 0);
                lblAlerta.Visible = false;
                pnlOrcamento.BackColor = Color.FromArgb(230, 240, 255);
            }

            // Itens
            dgvItens.DataSource = compra.Itens?.Select(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                Tipo = i.Artigo?.TipoArtigo?.Nome ?? "",
                Previsto = i.Previsto ? "✓" : "—",
                Qtd_Prevista = i.Previsto ? i.QuantidadePrevista?.ToString("F2") ?? "" : "",
                Qtd_Adquirida = i.QuantidadeAdquirida?.ToString("F2") ?? "",
                Preco_Unit = i.PrecoUnitario?.ToString("C2") ?? "",
                Total = (i.QuantidadeAdquirida.HasValue && i.PrecoUnitario.HasValue)
                    ? (i.QuantidadeAdquirida.Value * i.PrecoUnitario.Value).ToString("C2") : "",
                Estado = i.Adquirido ? "✅ Adquirido" : "⬜ Pendente",
                Obs = i.Observacoes ?? ""
            }).ToList();

            if (dgvItens.Columns.Contains("Id")) dgvItens.Columns["Id"].Visible = false;

            // Colorir linhas
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.Cells["Estado"].Value?.ToString().Contains("Adquirido") == true)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                else if (row.Cells["Previsto"].Value?.ToString() == "—")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 200);
            }

            bool fechada = compra.Fechada;
            btnAdquirir.Enabled = !fechada;
            btnNaoPrevisto.Enabled = !fechada;
            btnFechar.Enabled = !fechada;
        }

        private void BtnAdquirir_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0) { MessageBox.Show("Selecione um item."); return; }
            int id = (int)dgvItens.SelectedRows[0].Cells["Id"].Value;
            using var f = new FormAquisicaoItem(id);
            if (f.ShowDialog(this) == DialogResult.OK) Carregar();
        }

        private void BtnNaoPrevisto_Click(object sender, EventArgs e)
        {
            using var f = new FormItemNaoPrevisto(_compraId);
            if (f.ShowDialog(this) == DialogResult.OK) Carregar();
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma o fecho desta compra?\nNão poderá ser alterada depois.", "Fechar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var (ok, erro) = _ctrl.Fechar(_compraId);
            if (!ok) { MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            MessageBox.Show("Compra fechada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Carregar();
        }
    }

    public partial class FormAquisicaoItem : Form
    {
        private NumericUpDown numQtd;
        private TextBox txtPreco;
        private Label lblErro;
        private Button btnGuardar, btnCancelar;
        private readonly CompraController _ctrl = new CompraController();
        private readonly int _itemId;

        public FormAquisicaoItem(int itemId)
        {
            _itemId = itemId;
            this.Text = "Registar Aquisição";
            this.Size = new Size(340, 210);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            numQtd = new NumericUpDown { Location = new Point(150, y), Size = new Size(100, 22), Minimum = 0.001m, Maximum = 9999, DecimalPlaces = 3, Value = 1 };
            this.Controls.Add(new Label { Text = "Qtd. Adquirida:", Location = new Point(10, y + 3), Size = new Size(135, 22) });
            this.Controls.Add(numQtd); y += 40;

            txtPreco = new TextBox { Location = new Point(150, y), Size = new Size(100, 22) };
            this.Controls.Add(new Label { Text = "Preço Unitário (€):", Location = new Point(10, y + 3), Size = new Size(135, 22) });
            this.Controls.Add(txtPreco); y += 40;

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(10, y), Size = new Size(300, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 28;

            btnGuardar = new Button { Text = "Guardar", Location = new Point(150, y), Size = new Size(80, 28), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(240, y), Size = new Size(70, 28), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPreco.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal preco) || preco < 0)
            { lblErro.Text = "Preço inválido."; return; }

            var (ok, erro) = _ctrl.AtualizarAquisicao(_itemId, numQtd.Value, preco);
            if (!ok) { lblErro.Text = erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public partial class FormItemNaoPrevisto : Form
    {
        private ComboBox cmbTipo, cmbArtigo;
        private NumericUpDown numQtd;
        private TextBox txtPreco, txtObs;
        private Label lblErro;
        private Button btnGuardar, btnCancelar;
        private readonly CompraController _ctrl = new CompraController();
        private readonly TipoArtigoController _tipoCtrl = new TipoArtigoController();
        private readonly ArtigoController _artigoCtrl = new ArtigoController();
        private readonly int _compraId;

        public FormItemNaoPrevisto(int compraId)
        {
            _compraId = compraId;
            this.Text = "Adicionar Item Não Previsto";
            this.Size = new Size(400, 330);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 15;
            Action<string, Control> add = (lbl, ctrl) =>
            {
                this.Controls.Add(new Label { Text = lbl, Location = new Point(10, y + 3), Size = new Size(120, 22) });
                ctrl.Location = new Point(135, y); ctrl.Size = new Size(230, 22);
                this.Controls.Add(ctrl); y += 38;
            };

            cmbTipo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTipo.SelectedIndexChanged += (s, e) =>
            {
                cmbArtigo.Items.Clear();
                if (cmbTipo.SelectedItem is TipoArtigo t)
                {
                    foreach (var a in _artigoCtrl.GetPorTipo(t.Id)) cmbArtigo.Items.Add(a);
                    cmbArtigo.DisplayMember = "Nome";
                    if (cmbArtigo.Items.Count > 0) cmbArtigo.SelectedIndex = 0;
                }
            };
            cmbArtigo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            numQtd = new NumericUpDown { Minimum = 0.001m, Maximum = 9999, DecimalPlaces = 3, Value = 1 };
            txtPreco = new TextBox();
            txtObs = new TextBox();

            add("Tipo de Artigo:", cmbTipo);
            add("Artigo:", cmbArtigo);
            add("Qtd. Adquirida:", numQtd);
            add("Preço Unitário (€):", txtPreco);
            add("Observações:", txtObs);

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(10, y), Size = new Size(360, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 28;

            btnGuardar = new Button { Text = "Adicionar", Location = new Point(135, y), Size = new Size(90, 28), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(240, y), Size = new Size(90, 28), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            foreach (var t in _tipoCtrl.GetTodos()) cmbTipo.Items.Add(t);
            cmbTipo.DisplayMember = "Nome";
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbArtigo.SelectedItem is not Artigo artigo) { lblErro.Text = "Selecione um artigo."; return; }
            if (!decimal.TryParse(txtPreco.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal preco) || preco < 0)
            { lblErro.Text = "Preço inválido."; return; }

            var (ok, erro) = _ctrl.AdicionarItemNaoPrevisto(_compraId, artigo.Id, numQtd.Value, preco, txtObs.Text.Trim());
            if (!ok) { lblErro.Text = erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
