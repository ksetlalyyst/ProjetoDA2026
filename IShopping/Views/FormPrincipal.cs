using iShopping.Controllers;
using iShopping.Helpers;
using iShopping.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormPrincipal : Form
    {
        private MenuStrip menuStrip;
        private DataGridView dgvComprasAbertas;
        private Label lblBemVindo, lblTitulo;
        private Button btnAbrirCompra, btnRefresh;
        private Panel pnlTop;

        private readonly CompraController _compraCtrl = new CompraController();

        public FormPrincipal()
        {
            InitializeUI();
            CarregarCompras();
        }

        private void InitializeUI()
        {
            this.Text = "iShopping - Principal";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Menu
            menuStrip = new MenuStrip();

            var mnuGestao = new ToolStripMenuItem("Gestão");
            mnuGestao.DropDownItems.Add("Utilizadores", null, (s, e) => AbrirForm(new FormUtilizadores()));
            mnuGestao.DropDownItems.Add("Tipos de Artigo", null, (s, e) => AbrirForm(new FormTiposArtigo()));
            mnuGestao.DropDownItems.Add("Artigos", null, (s, e) => AbrirForm(new FormArtigos()));
            mnuGestao.DropDownItems.Add("Orçamentos", null, (s, e) => AbrirForm(new FormOrcamentos()));

            var mnuCompras = new ToolStripMenuItem("Compras");
            mnuCompras.DropDownItems.Add("Planear Compras", null, (s, e) => AbrirForm(new FormPlaneamentoCompras()));

            var mnuRelatorios = new ToolStripMenuItem("Relatórios");
            mnuRelatorios.DropDownItems.Add("Estatísticas", null, (s, e) => AbrirForm(new FormEstatisticas()));

            var mnuSair = new ToolStripMenuItem("Sair", null, (s, e) => Application.Exit());

            menuStrip.Items.AddRange(new ToolStripItem[] { mnuGestao, mnuCompras, mnuRelatorios, mnuSair });
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Top panel
            pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(0, 120, 215) };
            lblBemVindo = new Label
            {
                Text = $"Bem-vindo(a), {Sessao.NomeCompleto}!",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlTop.Controls.Add(lblBemVindo);

            lblTitulo = new Label
            {
                Text = "Compras em Aberto",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 75),
                AutoSize = true
            };

            btnAbrirCompra = new Button
            {
                Text = "🛒 Modo Compra",
                Location = new Point(10, 100),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(0, 150, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAbrirCompra.Click += BtnAbrirCompra_Click;

            btnRefresh = new Button
            {
                Text = "↻ Atualizar",
                Location = new Point(160, 100),
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.Click += (s, e) => CarregarCompras();

            dgvComprasAbertas = new DataGridView
            {
                Location = new Point(10, 145),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Size = new Size(860, 380),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvComprasAbertas.DoubleClick += DgvComprasAbertas_DoubleClick;

            this.Controls.AddRange(new Control[] { pnlTop, lblTitulo, btnAbrirCompra, btnRefresh, dgvComprasAbertas });
        }

        private void CarregarCompras()
        {
            try
            {
                var compras = _compraCtrl.GetAbertas();
                dgvComprasAbertas.DataSource = compras.Select(c => new
                {
                    c.Id,
                    c.Nome,
                    Criada_em = c.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                    Criada_por = c.CriadaPor?.Nome ?? ""
                }).ToList();
                dgvComprasAbertas.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar compras: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAbrirCompra_Click(object sender, EventArgs e)
        {
            if (dgvComprasAbertas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma compra para abrir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = (int)dgvComprasAbertas.SelectedRows[0].Cells["Id"].Value;
            using var f = new FormModoCompra(id);
            f.ShowDialog(this);
            CarregarCompras();
        }

        private void DgvComprasAbertas_DoubleClick(object sender, EventArgs e)
        {
            BtnAbrirCompra_Click(sender, e);
        }

        private void AbrirForm(Form f)
        {
            f.MdiParent = null;
            f.ShowDialog(this);
            CarregarCompras();
        }
    }
}
