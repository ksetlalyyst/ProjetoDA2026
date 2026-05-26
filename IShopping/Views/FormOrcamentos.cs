using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormOrcamentos : Form
    {
        private DataGridView dgv;
        private Button btnNovo, btnEditar, btnEliminar;
        private readonly OrcamentoController _ctrl = new OrcamentoController();

        public FormOrcamentos()
        {
            this.Text = "Gestão de Orçamentos";
            this.Size = new Size(750, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            dgv = new DataGridView
            {
                Location = new Point(10, 10), Size = new Size(715, 360),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            int bx = 10;
            Button Btn(string t, Color c) { var b = new Button { Text = t, Location = new Point(bx, 380), Size = new Size(110, 30), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat }; bx += 120; return b; }

            btnNovo = Btn("Novo", Color.FromArgb(0, 120, 215));
            btnEditar = Btn("Editar", Color.FromArgb(0, 100, 0));
            btnEliminar = Btn("Eliminar", Color.DarkRed);

            btnNovo.Click += (s, e) => AbrirEditor(null);
            btnEditar.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0) return;
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                var o = _ctrl.GetTodos().FirstOrDefault(x => x.Id == id);
                AbrirEditor(o);
            };
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.AddRange(new Control[] { dgv, btnNovo, btnEditar, btnEliminar });
            Carregar();
        }

        private void Carregar()
        {
            var lista = _ctrl.GetTodos();
            dgv.DataSource = lista.Select(o => new
            {
                o.Id,
                Mes = o.Mes.ToString("D2") + "/" + o.Ano,
                Valor = o.Valor.ToString("C2"),
                Criado_por = o.CriadoPor?.Nome ?? "",
                Alterado_por = o.AlteradoPor?.Nome ?? ""
            }).ToList();
            if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
        }

        private void AbrirEditor(Orcamento o)
        {
            using var f = new FormEditarOrcamento(o);
            if (f.ShowDialog(this) == DialogResult.OK) Carregar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Confirma eliminação?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var (ok, erro) = _ctrl.Eliminar((int)dgv.SelectedRows[0].Cells["Id"].Value);
            if (!ok) MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else Carregar();
        }
    }

    public partial class FormEditarOrcamento : Form
    {
        private NumericUpDown numMes, numAno;
        private TextBox txtValor;
        private Label lblErro;
        private Button btnGuardar, btnCancelar;
        private readonly OrcamentoController _ctrl = new OrcamentoController();
        private readonly Orcamento _orcamento;

        public FormEditarOrcamento(Orcamento o)
        {
            _orcamento = o;
            this.Text = o == null ? "Novo Orçamento" : "Editar Orçamento";
            this.Size = new Size(360, 240);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            numMes = new NumericUpDown { Location = new Point(130, y), Size = new Size(80, 22), Minimum = 1, Maximum = 12, Value = DateTime.Now.Month };
            this.Controls.Add(new Label { Text = "Mês:", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(numMes); y += 38;

            numAno = new NumericUpDown { Location = new Point(130, y), Size = new Size(80, 22), Minimum = 2000, Maximum = 2100, Value = DateTime.Now.Year };
            this.Controls.Add(new Label { Text = "Ano:", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(numAno); y += 38;

            txtValor = new TextBox { Location = new Point(130, y), Size = new Size(110, 22) };
            this.Controls.Add(new Label { Text = "Valor (€):", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(txtValor); y += 38;

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(20, y), Size = new Size(310, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 28;

            btnGuardar = new Button { Text = "Guardar", Location = new Point(130, y), Size = new Size(90, 30), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(235, y), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            if (o != null) { numMes.Value = o.Mes; numAno.Value = o.Ano; txtValor.Text = o.Valor.ToString("F2"); }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtValor.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal valor) || valor <= 0)
            { lblErro.Text = "Valor inválido."; return; }

            var (ok, erro) = _ctrl.CriarOuAtualizar((int)numMes.Value, (int)numAno.Value, valor);
            if (!ok) { lblErro.Text = erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
