using iShoppingKelly.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iShoppingKelly.Views
{
    public partial class FormSelecionarTipo : Form
    {
        public int TipoArtigoId { get; private set; }

        public FormSelecionarTipo(List<TipoArtigo> tipos, int tipoSelecionadoId = 0)
        {
            InitializeComponent();

            foreach (TipoArtigo tipo in tipos)
            {
                comboBoxTipo.Items.Add(tipo);
            }

            comboBoxTipo.DisplayMember = "Nome";

            if (tipoSelecionadoId > 0)
            {
                for (int i = 0; i < comboBoxTipo.Items.Count; i++)
                {
                    TipoArtigo item = (TipoArtigo)comboBoxTipo.Items[i];
                    if (item.Id == tipoSelecionadoId)
                    {
                        comboBoxTipo.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (comboBoxTipo.Items.Count > 0)
            {
                comboBoxTipo.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TipoArtigo tipoSelecionado = comboBoxTipo.SelectedItem as TipoArtigo;

            if (tipoSelecionado == null)
            {
                MessageBox.Show("Selecione um tipo de artigo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TipoArtigoId = tipoSelecionado.Id;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
