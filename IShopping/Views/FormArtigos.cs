using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormArtigos : Form
    {
        private DataGridView dgv;
        private ComboBox cmbTipo;
        private Button btnNovo, btnEditar, btnEliminar;
        private readonly ArtigoController _ctrl = new ArtigoController();
        private readonly TipoArtigoController _tipoCtrl = new TipoArtigoController();

        public FormArtigos()
        {
            this.Text = "Gestão de Artigos";
            this.Size = new Size(700, 480);
            this.StartPosition = FormStartPosition.CenterParent;

            this.Controls.Add(new Label { Text = "Filtrar por Tipo:", Location = new Point(10, 15), Size = new Size(110, 22) });
            cmbTipo = new ComboBox { Location = new Point(125, 12), Size = new Size(200, 22), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTipo.SelectedIndexChanged += (s, e) => Carregar();
            this.Controls.Add(cmbTipo);

            dgv = new DataGridView
            {
                Location = new Point(10, 45), Size = new Size(665, 350),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            int bx = 10;
            Button Btn(string t, Color c) { var b = new Button { Text = t, Location = new Point(bx, 405), Size = new Size(100, 30), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat }; bx += 110; return b; }

            btnNovo = Btn("Novo", Color.FromArgb(0, 120, 215));
            btnEditar = Btn("Editar", Color.FromArgb(0, 100, 0));
            btnEliminar = Btn("Eliminar", Color.DarkRed);

            btnNovo.Click += (s, e) => AbrirEditor(null);
            btnEditar.Click += (s, e) => { if (dgv.SelectedRows.Count == 0) return; AbrirEditor(_ctrl.GetPorId((int)dgv.SelectedRows[0].Cells["Id"].Value)); };
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.AddRange(new Control[] { dgv, btnNovo, btnEditar, btnEliminar });

            CarregarTipos();
        }

        private void CarregarTipos()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add(new { Id = 0, Nome = "(Todos)" });
            foreach (var t in _tipoCtrl.GetTodos())
                cmbTipo.Items.Add(t);
            cmbTipo.DisplayMember = "Nome";
            cmbTipo.SelectedIndex = 0;
        }

        private void Carregar()
        {
            try
            {
                System.Collections.Generic.List<Artigo> lista;
                if (cmbTipo.SelectedIndex <= 0 || !(cmbTipo.SelectedItem is TipoArtigo t))
                    lista = _ctrl.GetTodos();
                else
                    lista = _ctrl.GetPorTipo(t.Id);

                dgv.DataSource = lista.Select(a => new { a.Id, a.Nome, Tipo = a.TipoArtigo?.Nome ?? "" }).ToList();
                if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AbrirEditor(Artigo a)
        {
            using var f = new FormEditarArtigo(a);
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

    public partial class FormEditarArtigo : Form
    {
        private TextBox txtNome;
        private ComboBox cmbTipo;
        private Label lblErro;
        private Button btnGuardar, btnCancelar;
        private readonly ArtigoController _ctrl = new ArtigoController();
        private readonly TipoArtigoController _tipoCtrl = new TipoArtigoController();
        private readonly Artigo _artigo;

        public FormEditarArtigo(Artigo a)
        {
            _artigo = a;
            this.Text = a == null ? "Novo Artigo" : "Editar Artigo";
            this.Size = new Size(370, 240);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            txtNome = new TextBox { Location = new Point(130, y), Size = new Size(200, 22) };
            this.Controls.Add(new Label { Text = "Nome:", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(txtNome); y += 40;

            cmbTipo = new ComboBox { Location = new Point(130, y), Size = new Size(200, 22), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(new Label { Text = "Tipo de Artigo:", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(cmbTipo); y += 40;

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(20, y), Size = new Size(310, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 30;

            btnGuardar = new Button { Text = "Guardar", Location = new Point(130, y), Size = new Size(90, 30), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(235, y), Size = new Size(90, 30), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            // Carregar tipos
            foreach (var t in _tipoCtrl.GetTodos())
                cmbTipo.Items.Add(t);
            cmbTipo.DisplayMember = "Nome";

            if (a != null)
            {
                txtNome.Text = a.Nome;
                for (int i = 0; i < cmbTipo.Items.Count; i++)
                    if (cmbTipo.Items[i] is TipoArtigo t && t.Id == a.TipoArtigoId)
                    { cmbTipo.SelectedIndex = i; break; }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { lblErro.Text = "Nome é obrigatório."; return; }
            if (cmbTipo.SelectedItem is not TipoArtigo tipo) { lblErro.Text = "Selecione um tipo."; return; }

            (bool ok, string erro) r = _artigo == null
                ? _ctrl.Criar(txtNome.Text.Trim(), tipo.Id)
                : _ctrl.Atualizar(_artigo.Id, txtNome.Text.Trim(), tipo.Id);

            if (!r.ok) { lblErro.Text = r.erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
