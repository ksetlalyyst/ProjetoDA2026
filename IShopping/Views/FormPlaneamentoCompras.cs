using iShopping.Controllers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormPlaneamentoCompras : Form
    {
        private DataGridView dgv;
        private ComboBox cmbFiltro;
        private Button btnNova, btnEditar, btnEliminar, btnExportarCSV;
        private readonly CompraController _ctrl = new CompraController();

        public FormPlaneamentoCompras()
        {
            this.Text = "Planeamento de Compras";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;

            this.Controls.Add(new Label { Text = "Estado:", Location = new Point(10, 15), Size = new Size(60, 22) });
            cmbFiltro = new ComboBox { Location = new Point(75, 12), Size = new Size(130, 22), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFiltro.Items.AddRange(new[] { "Todas", "Em Aberto", "Fechadas" });
            cmbFiltro.SelectedIndex = 0;
            cmbFiltro.SelectedIndexChanged += (s, e) => Carregar();
            this.Controls.Add(cmbFiltro);

            dgv = new DataGridView
            {
                Location = new Point(10, 45), Size = new Size(765, 360),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgv.DoubleClick += (s, e) => BtnEditar_Click(s, e);

            int bx = 10;
            Button Btn(string t, Color c, int w = 110) { var b = new Button { Text = t, Location = new Point(bx, 415), Size = new Size(w, 30), BackColor = c, ForeColor = Color.White, FlatStyle = FlatStyle.Flat }; bx += w + 5; return b; }

            btnNova = Btn("Nova Compra", Color.FromArgb(0, 120, 215));
            btnEditar = Btn("Editar", Color.FromArgb(0, 100, 0), 90);
            btnEliminar = Btn("Eliminar", Color.DarkRed, 90);
            btnExportarCSV = Btn("Exportar CSV", Color.FromArgb(100, 0, 150), 120);

            btnNova.Click += BtnNova_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnExportarCSV.Click += BtnExportarCSV_Click;

            this.Controls.AddRange(new Control[] { dgv, btnNova, btnEditar, btnEliminar, btnExportarCSV });
            Carregar();
        }

        private void Carregar()
        {
            System.Collections.Generic.List<Compra> lista = cmbFiltro.SelectedIndex switch
            {
                1 => _ctrl.GetAbertas(),
                2 => _ctrl.GetFechadas(),
                _ => _ctrl.GetTodas()
            };

            dgv.DataSource = lista.Select(c => new
            {
                c.Id,
                c.Nome,
                Estado = c.Fechada ? "Fechada" : "Em Aberto",
                Criada_em = c.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                Fechada_em = c.DataFechada?.ToString("dd/MM/yyyy HH:mm") ?? "",
                Criada_por = c.CriadaPor?.Nome ?? ""
            }).ToList();
            if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
        }

        private void BtnNova_Click(object sender, EventArgs e)
        {
            using var f = new FormEditarCompra(0);
            if (f.ShowDialog(this) == DialogResult.OK) Carregar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
            using var f = new FormEditarCompra(id);
            if (f.ShowDialog(this) == DialogResult.OK) Carregar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int id = (int)dgv.SelectedRows[0].Cells["Id"].Value;
            if (MessageBox.Show("Confirma eliminação?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var (ok, erro) = _ctrl.Eliminar(id);
            if (!ok) MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else Carregar();
        }

        private void BtnExportarCSV_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"ComprasFechadas_{DateTime.Now:yyyyMMdd}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            var (ok, erro) = _ctrl.ExportarCSV(sfd.FileName);
            if (ok)
                MessageBox.Show("Exportação concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
