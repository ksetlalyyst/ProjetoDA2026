using System.Collections.Generic;

namespace iShopping.Models
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoArtigoId { get; set; }

        public TipoArtigo TipoArtigo { get; set; }
        public ICollection<ItemCompra> ItensCompra { get; set; }
    }
}
