using System.Collections.Generic;

namespace iShopping.Models
{
    public class TipoArtigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Artigo> Artigos { get; set; }
    }
}
