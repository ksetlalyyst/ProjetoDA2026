using System;
using System.Collections.Generic;

namespace iShoppingKelly.Models
{
    public class Compra
    {
        public Compra()
        {
            Itens = new List<ItemCompra>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataFechada { get; set; }

        public bool Fechada { get; set; } = false;

        public int CriadaPorId { get; set; }

        public Utilizador CriadaPor { get; set; }

        public int? FechadaPorId { get; set; }

        public Utilizador FechadaPor { get; set; }

        public ICollection<ItemCompra> Itens { get; set; }
        public override string ToString()
        {
            return Nome;
        }
    }
}
