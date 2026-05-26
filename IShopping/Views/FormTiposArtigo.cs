using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormTiposArtigo : Form
    {
        private DataGridView dgv;
        private Button btnNovo, btnEditar, btnEliminar;
        private readonly TipoArtigoController _ctrl = new TipoArtigoController();

        public FormTiposArtigo()
        {
            this.Text = "Gestão de Tipos de Artigo";
            this.Size = new Size(650, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            dgv = new DataGridView
            {
                Location = new Point(10, 10), Size = new Size(615, 350),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            int bx = 10;
            Button Btn(string t, Color c) { var b = new Button { Text = t, Location = new Point(bx, 370), Size = new Size(100, 30), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat }; bx += 110; return b; }

            btnNovo = Btn("Novo", Color.FromArgb(0, 120, 215));
            btnEditar = Btn("Editar", Color.FromArgb(0, 100, 0));
            btnEliminar = Btn("Eliminar", Color.DarkRed);

            btnNovo.Click += (s, e) => AbrirEditor(null);
            btnEditar.Click += (s, e) => { if (dgv.SelectedRows.Count == 0) return; AbrirEditor(_ctrl.GetPorId((int)dgv.SelectedRows[0].Cells["Id"].Value)); };
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.AddRange(new Control[] { dgv, btnNovo, btnEditar, btnEliminar });
            Carregar();
        }

        private void Carregar()
        {
            dgv.DataSource = _ctrl.GetTodos().Select(t => new { t.Id, t.Nome, t.Descricao }).ToList();
            if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
        }

        private void AbrirEditor(TipoArtigo t)
        {
            using var f = new FormEditarTipoArtigo(t);
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

    public partial class FormEditarTipoArtigo : Form
    {
        private TextBox txtNome, txtDescricao;
        private Label lblErro;
        private Button btnGuardar, btnCancelar;
        private readonly TipoArtigoController _ctrl = new TipoArtigoController();
        private readonly TipoArtigo _tipo;

        public FormEditarTipoArtigo(TipoArtigo t)
        {
            _tipo = t;
            this.Text = t == null ? "Novo Tipo de Artigo" : "Editar Tipo de Artigo";
            this.Size = new Size(370, 230);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            txtNome = new TextBox { Location = new Point(130, y), Size = new Size(200, 22) };
            this.Controls.Add(new Label { Text = "Nome:", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(txtNome); y += 40;

            txtDescricao = new TextBox { Location = new Point(130, y), Size = new Size(200, 22) };
            this.Controls.Add(new Label { Text = "Descrição:", Location = new Point(20, y + 3), Size = new Size(100, 22) });
            this.Controls.Add(txtDescricao); y += 40;

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(20, y), Size = new Size(310, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 30;

            btnGuardar = new Button { Text = "Guardar", Location = new Point(130, y), Size = new Size(90, 30), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(235, y), Size = new Size(90, 30), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            if (t != null) { txtNome.Text = t.Nome; txtDescricao.Text = t.Descricao; }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { lblErro.Text = "Nome é obrigatório."; return; }
            (bool ok, string erro) r = _tipo == null
                ? _ctrl.Criar(txtNome.Text.Trim(), txtDescricao.Text.Trim())
                : _ctrl.Atualizar(_tipo.Id, txtNome.Text.Trim(), txtDescricao.Text.Trim());
            if (!r.ok) { lblErro.Text = r.erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
