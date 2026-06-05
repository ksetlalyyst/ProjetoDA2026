using iShoppingKelly.Controllers;
using iShoppingKelly.Data;
using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormArtigo : Form
    {
        

        public FormArtigo()
        {
            InitializeComponent();
            
        }

        private void AtualizarTipos()
        {
            comboBoxFiltrarTipo.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                List<TipoArtigo> tipos = context.TiposArtigo.ToList();

                TipoArtigo todos = new TipoArtigo();
                todos.Id = 0;
                todos.Nome = "Todos";

                tipos.Insert(0, todos);

                comboBoxFiltrarTipo.DataSource = tipos;
            }
        }

        private void AtualizarArtigos()
        {
            dataGridView4.DataSource = null;
            using (AppDbContext context = new AppDbContext())
            {
                dataGridView4.DataSource = context.Artigos.Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Tipo = a.TipoArtigo.Nome
                }).ToList();
            }
            /* dataGridView4.Columns["Id"].HeaderText = "Código";
             dataGridView4.Columns["Nome"].HeaderText = "Nome";
             dataGridView4.Columns["TipoArtigo"].HeaderText = "Tipo";*/
        }
        private void FormArtigo_Load(object sender, EventArgs e)
        {
            AtualizarTipos();
            AtualizarArtigos();

        }

        private void txtFiltrarNome_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxFiltrarTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoArtigo tipo = comboBoxFiltrarTipo.SelectedItem as TipoArtigo;

            if (tipo == null)
            {
                return;
            }

            using (AppDbContext context = new AppDbContext())
            {
                if (tipo.Id == 0)
                {
                    dataGridView4.DataSource = context.Artigos
                        .Select(a => new
                        {
                            a.Id,
                            a.Nome,
                            Tipo = a.TipoArtigo.Nome
                        })
                        .ToList();
                }
                else
                {
                    dataGridView4.DataSource = context.Artigos
                        .Where(a => a.TipoArtigoId == tipo.Id)
                        .Select(a => new
                        {
                            a.Id,
                            a.Nome,
                            Tipo = a.TipoArtigo.Nome
                        })
                        .ToList();
                }
            }
        }
        private void btnNovoArtigo_Click(object sender, EventArgs e)
        {
            TipoArtigo tipoSelecionado =
                comboBoxFiltrarTipo.SelectedItem as TipoArtigo;

            if (tipoSelecionado == null)
            {
                MessageBox.Show("Selecione um tipo.");
                return;
            }

            ArtigoController controller = new ArtigoController();

            try
            {
                controller.AdicionarArtigo(txtArtigoNome.Text, tipoSelecionado.Id);

                AtualizarArtigos();

                txtArtigoNome.Clear();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        

        private void btnEditarArtigo_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow == null)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            TipoArtigo tipoSelecionado =
                comboBoxFiltrarTipo.SelectedItem as TipoArtigo;

            int id = (int)dataGridView4.CurrentRow.Cells["Id"].Value;

            ArtigoController controller = new ArtigoController();

            controller.EditarArtigo(id, txtArtigoNome.Text, tipoSelecionado.Id);

            AtualizarArtigos();
        }
    
        

        private void btnEliminarArtigo_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow == null)
            {
                MessageBox.Show("Selecione um artigo.");
                return;
            }

            int id = (int)dataGridView4.CurrentRow.Cells["Id"].Value;

            ArtigoController controller = new ArtigoController();

            controller.EliminarArtigo(id);

            AtualizarArtigos();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentRow == null)
            {
                return;
            }

            txtArtigoNome.Text = dataGridView4.CurrentRow.Cells["Nome"]
                                .Value.ToString();
        }
    }
}
