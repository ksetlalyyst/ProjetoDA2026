using System;

namespace iShopping.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }

        public int CriadoPorId { get; set; }
        public Utilizador CriadoPor { get; set; }

        public int? AlteradoPorId { get; set; }
        public Utilizador AlteradoPor { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
    }
}
