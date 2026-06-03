using iShoppingKelly.Controllers;
using iShoppingKelly.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormTiposArtigo : System.Windows.Forms.Form
    {
        public FormTiposArtigo()
        {
            InitializeComponent();
        }

        private void AtualizarTipos()
        {
            dataGridView3.DataSource = null;

            using (AppDbContext context = new AppDbContext())
            {
                dataGridView3.DataSource = context.TiposArtigo.Select(t => new
                {
                    t.Id,
                    t.Nome
                })
                    .ToList();
            }
        }
        private void FormTiposArtigo_Load(object sender, EventArgs e)
        {
            AtualizarTipos();
        }

        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            TipoArtigoController controller = new TipoArtigoController();

            try
            {
                controller.AdicionarTipoArtigo(txtNomeTipoArt.Text);

                AtualizarTipos();

                txtNomeTipoArt.Clear();
            } catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarTipo_Click(object sender, EventArgs e)
        {
            if(dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Selecione um tipo para eliminar.");
                return;
            }

            int id = (int)dataGridView3.CurrentRow.Cells["Id"].Value;

            TipoArtigoController controller = new TipoArtigoController();

            controller.RemoverTipoArtigo(id);
            AtualizarTipos();
        }

        private void btnEditarTipo_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Selecione um tipo para editar.");
                return;
            }

            int id = (int)dataGridView3.CurrentRow.Cells["Id"].Value;

            TipoArtigoController controller = new TipoArtigoController();

            controller.EditarTipoArtigo(id, txtNomeTipoArt.Text);
            AtualizarTipos();
        }
        //funcionalidade extra: ao clicar num tipo, o nome aparece na textbox para facilitar a edição
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView3.CurrentRow == null)
            {
                return;
            }

            txtNomeTipoArt.Text = dataGridView3.CurrentRow.Cells["Nome"].Value.ToString();
        }

        

    }

}
