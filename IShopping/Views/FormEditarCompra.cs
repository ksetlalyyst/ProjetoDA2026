using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormEditarCompra : Form
    {
        private TextBox txtNome;
        private Label lblInfo, lblErro;
        private DataGridView dgvItens;
        private Button btnGuardarNome, btnAdicionarItem, btnEditarItem, btnEliminarItem;
        private Panel pnlInfo;

        private readonly CompraController _ctrl = new CompraController();
        private readonly TipoArtigoController _tipoCtrl = new TipoArtigoController();
        private readonly ArtigoController _artigoCtrl = new ArtigoController();
        private int _compraId;
        private bool _fechada;

        public FormEditarCompra(int compraId)
        {
            _compraId = compraId;
            this.Text = compraId == 0 ? "Nova Compra Planeada" : "Editar Compra";
            this.Size = new Size(800, 560);
            this.StartPosition = FormStartPosition.CenterParent;

            // Header
            this.Controls.Add(new Label { Text = "Nome da Compra:", Location = new Point(10, 15), Size = new Size(120, 22) });
            txtNome = new TextBox { Location = new Point(135, 12), Size = new Size(300, 22) };
            this.Controls.Add(txtNome);

            btnGuardarNome = new Button { Text = "Guardar Nome", Location = new Point(445, 10), Size = new Size(110, 26), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardarNome.Click += BtnGuardarNome_Click;
            this.Controls.Add(btnGuardarNome);

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(10, 40), Size = new Size(750, 20) };
            this.Controls.Add(lblErro);

            pnlInfo = new Panel { Location = new Point(10, 60), Size = new Size(760, 35), BackColor = Color.LightYellow, BorderStyle = BorderStyle.FixedSingle };
            lblInfo = new Label { Location = new Point(5, 8), Size = new Size(750, 20), Font = new Font("Segoe UI", 9) };
            pnlInfo.Controls.Add(lblInfo);
            this.Controls.Add(pnlInfo);

            this.Controls.Add(new Label { Text = "Itens Previstos:", Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(10, 100), Size = new Size(150, 22) });

            dgvItens = new DataGridView
            {
                Location = new Point(10, 125), Size = new Size(760, 320),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            this.Controls.Add(dgvItens);

            // Botões
            int bx = 10;
            int by = 455;
            Button Btn(string t, Color c, int w = 130) { var b = new Button { Text = t, Location = new Point(bx, by), Size = new Size(w, 30), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat }; bx += w + 5; return b; }

            btnAdicionarItem = Btn("+ Adicionar Item", Color.FromArgb(0, 130, 0));
            btnEditarItem = Btn("Editar Item", Color.FromArgb(0, 100, 150), 110);
            btnEliminarItem = Btn("Eliminar Item", Color.DarkRed, 110);

            btnAdicionarItem.Click += BtnAdicionarItem_Click;
            btnEditarItem.Click += BtnEditarItem_Click;
            btnEliminarItem.Click += BtnEliminarItem_Click;

            this.Controls.AddRange(new Control[] { btnAdicionarItem, btnEditarItem, btnEliminarItem });

            if (compraId == 0)
                IniciarNovaCompra();
            else
                CarregarCompra();
        }

        private void IniciarNovaCompra()
        {
            var (ok, erro, id) = _ctrl.Criar("Nova Compra");
            if (!ok) { MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); return; }
            _compraId = id;
            var c = _ctrl.GetPorId(id);
            txtNome.Text = c.Nome;
            AtualizarInterface(c);
        }

        private void CarregarCompra()
        {
            var c = _ctrl.GetPorId(_compraId);
            if (c == null) { this.Close(); return; }
            txtNome.Text = c.Nome;
            AtualizarInterface(c);
        }

        private void AtualizarInterface(Compra c)
        {
            _fechada = c.Fechada;
            if (_fechada)
            {
                this.Text = "Compra (Só Leitura)";
                txtNome.ReadOnly = true;
                btnGuardarNome.Enabled = false;
                btnAdicionarItem.Enabled = false;
                btnEditarItem.Enabled = false;
                btnEliminarItem.Enabled = false;
                pnlInfo.BackColor = Color.LightCoral;
                lblInfo.Text = $"⚠ Compra FECHADA em {c.DataFechada?.ToString("dd/MM/yyyy HH:mm")} por {c.FechadaPor?.Nome}";
            }
            else
            {
                lblInfo.Text = $"Criada por {c.CriadaPor?.Nome} em {c.DataCriacao:dd/MM/yyyy HH:mm}";
            }

            // Carregar itens
            dgvItens.DataSource = c.Itens?.Select(i => new
            {
                i.Id,
                Artigo = i.Artigo?.Nome ?? "",
                Tipo = i.Artigo?.TipoArtigo?.Nome ?? "",
                Qtd_Prevista = i.QuantidadePrevista?.ToString("F2") ?? "",
                Criado_por = i.CriadoPor?.Nome ?? "",
                Data_Criacao = i.DataCriacao.ToString("dd/MM/yyyy")
            }).ToList();

            if (dgvItens.Columns.Contains("Id")) dgvItens.Columns["Id"].Visible = false;
            this.DialogResult = DialogResult.OK;
        }

        private void BtnGuardarNome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { lblErro.Text = "Nome não pode ser vazio."; return; }
            var (ok, erro) = _ctrl.AtualizarNome(_compraId, txtNome.Text.Trim());
            if (!ok) { lblErro.Text = erro; return; }
            lblErro.Text = "";
            MessageBox.Show("Nome guardado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAdicionarItem_Click(object sender, EventArgs e)
        {
            using var f = new FormAdicionarItemPrevisto(_compraId);
            if (f.ShowDialog(this) == DialogResult.OK) CarregarCompra();
        }

        private void BtnEditarItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0) return;
            int itemId = (int)dgvItens.SelectedRows[0].Cells["Id"].Value;
            using var f = new FormAdicionarItemPrevisto(_compraId, itemId);
            if (f.ShowDialog(this) == DialogResult.OK) CarregarCompra();
        }

        private void BtnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Confirma eliminação do item?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var (ok, erro) = _ctrl.EliminarItem((int)dgvItens.SelectedRows[0].Cells["Id"].Value);
            if (!ok) MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else CarregarCompra();
        }
    }

    public partial class FormAdicionarItemPrevisto : Form
    {
        private ComboBox cmbTipo, cmbArtigo;
        private NumericUpDown numQtd;
        private Label lblErro;
        private Button btnGuardar, btnCancelar;
        private readonly CompraController _ctrl = new CompraController();
        private readonly TipoArtigoController _tipoCtrl = new TipoArtigoController();
        private readonly ArtigoController _artigoCtrl = new ArtigoController();
        private readonly int _compraId;
        private readonly int _itemId;

        public FormAdicionarItemPrevisto(int compraId, int itemId = 0)
        {
            _compraId = compraId;
            _itemId = itemId;
            this.Text = itemId == 0 ? "Adicionar Item Previsto" : "Editar Item";
            this.Size = new Size(380, 260);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            cmbTipo = new ComboBox { Location = new Point(130, y), Size = new Size(210, 22), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTipo.SelectedIndexChanged += CmbTipo_Changed;
            this.Controls.Add(new Label { Text = "Tipo de Artigo:", Location = new Point(10, y + 3), Size = new Size(115, 22) });
            this.Controls.Add(cmbTipo); y += 40;

            cmbArtigo = new ComboBox { Location = new Point(130, y), Size = new Size(210, 22), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(new Label { Text = "Artigo:", Location = new Point(10, y + 3), Size = new Size(115, 22) });
            this.Controls.Add(cmbArtigo); y += 40;

            numQtd = new NumericUpDown { Location = new Point(130, y), Size = new Size(100, 22), Minimum = 0.001m, Maximum = 9999, DecimalPlaces = 3, Value = 1 };
            this.Controls.Add(new Label { Text = "Qtd. Prevista:", Location = new Point(10, y + 3), Size = new Size(115, 22) });
            this.Controls.Add(numQtd); y += 40;

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(10, y), Size = new Size(340, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 28;

            btnGuardar = new Button { Text = "Guardar", Location = new Point(130, y), Size = new Size(90, 30), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(235, y), Size = new Size(90, 30), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            foreach (var t in _tipoCtrl.GetTodos()) cmbTipo.Items.Add(t);
            cmbTipo.DisplayMember = "Nome";
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
        }

        private void CmbTipo_Changed(object sender, EventArgs e)
        {
            cmbArtigo.Items.Clear();
            if (cmbTipo.SelectedItem is TipoArtigo t)
            {
                foreach (var a in _artigoCtrl.GetPorTipo(t.Id)) cmbArtigo.Items.Add(a);
                cmbArtigo.DisplayMember = "Nome";
                if (cmbArtigo.Items.Count > 0) cmbArtigo.SelectedIndex = 0;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbArtigo.SelectedItem is not Artigo artigo) { lblErro.Text = "Selecione um artigo."; return; }

            (bool ok, string erro) r = _itemId == 0
                ? _ctrl.AdicionarItemPrevisto(_compraId, artigo.Id, numQtd.Value)
                : _ctrl.AtualizarItemPrevisto(_itemId, artigo.Id, numQtd.Value);

            if (!r.ok) { lblErro.Text = r.erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
