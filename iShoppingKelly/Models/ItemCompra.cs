using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public Compra Compra { get; set; }

        public int ArtigoId { get; set; }
        public Artigo Artigo { get; set; }

        public bool Previsto { get; set; } = true;
        public decimal? QuantidadePrevista { get; set; }
        public decimal? QuantidadeAdquirida { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public bool Adquirido { get; set; } = false;
        public string Observacoes { get; set; }

        public int CriadoPorId { get; set; }
        public Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public Utilizador AlteradoPor { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
    }
}
