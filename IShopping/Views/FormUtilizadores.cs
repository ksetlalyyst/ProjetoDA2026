using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormUtilizadores : Form
    {
        private DataGridView dgv;
        private Button btnNovo, btnEditar, btnEliminar;
        private readonly UtilizadorController _ctrl = new UtilizadorController();

        public FormUtilizadores()
        {
            this.Text = "Gestão de Utilizadores";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            dgv = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(660, 350),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            btnNovo = CriarBotao("Novo", 10, 370, Color.FromArgb(0, 120, 215));
            btnNovo.Click += (s, e) => AbrirEditor(null);

            btnEditar = CriarBotao("Editar", 110, 370, Color.FromArgb(0, 100, 0));
            btnEditar.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Selecione um utilizador."); return; }
                int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
                AbrirEditor(_ctrl.GetPorId(id));
            };

            btnEliminar = CriarBotao("Eliminar", 210, 370, Color.DarkRed);
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.AddRange(new Control[] { dgv, btnNovo, btnEditar, btnEliminar });
            Carregar();
        }

        private Button CriarBotao(string texto, int x, int y, Color cor)
        {
            return new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(90, 30),
                BackColor = cor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        private void Carregar()
        {
            var lista = _ctrl.GetTodos();
            dgv.DataSource = lista.Select(u => new { u.Id, u.Nome, u.Username }).ToList();
            if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
        }

        private void AbrirEditor(Utilizador u)
        {
            using var f = new FormEditarUtilizador(u);
            if (f.ShowDialog(this) == DialogResult.OK)
                Carregar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
            if (MessageBox.Show("Confirma eliminação?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var (ok, erro) = _ctrl.Eliminar(id);
                if (!ok) MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else Carregar();
            }
        }
    }

    public partial class FormEditarUtilizador : Form
    {
        private TextBox txtNome, txtUsername, txtPassword;
        private Button btnGuardar, btnCancelar;
        private Label lblErro;
        private readonly UtilizadorController _ctrl = new UtilizadorController();
        private readonly Utilizador _utilizador;

        public FormEditarUtilizador(Utilizador u)
        {
            _utilizador = u;
            this.Text = u == null ? "Novo Utilizador" : "Editar Utilizador";
            this.Size = new Size(370, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int y = 20;
            Action<string, TextBox> add = (lbl, txt) =>
            {
                this.Controls.Add(new Label { Text = lbl, Location = new Point(20, y + 3), Size = new Size(100, 22) });
                txt.Location = new Point(130, y); txt.Size = new Size(200, 22);
                this.Controls.Add(txt);
                y += 40;
            };

            txtNome = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox { UseSystemPasswordChar = true };

            add("Nome:", txtNome);
            add("Username:", txtUsername);
            add(u == null ? "Password:" : "Nova Password:", txtPassword);

            lblErro = new Label { ForeColor = Color.Red, Location = new Point(20, y), Size = new Size(310, 22), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(lblErro); y += 28;

            btnGuardar = new Button { Text = "Guardar", Location = new Point(130, y), Size = new Size(90, 30), BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(235, y), Size = new Size(90, 30), FlatStyle = FlatStyle.Flat };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            if (u != null) { txtNome.Text = u.Nome; txtUsername.Text = u.Username; }
            this.AcceptButton = btnGuardar;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            lblErro.Text = "";
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            { lblErro.Text = "Nome e Username são obrigatórios."; return; }

            if (_utilizador == null && string.IsNullOrWhiteSpace(txtPassword.Text))
            { lblErro.Text = "Password é obrigatória."; return; }

            (bool ok, string erro) resultado;
            if (_utilizador == null)
                resultado = _ctrl.Registar(txtNome.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text);
            else
                resultado = _ctrl.Atualizar(_utilizador.Id, txtNome.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text);

            if (!resultado.ok) { lblErro.Text = resultado.erro; return; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
