using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShoppingKelly.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Compra> ComprasCriadas { get; set; }
        public ICollection<Compra> ComprasFechadas { get; set; }
        public ICollection<ItemCompra> ItensCriados { get; set; }
        public ICollection<ItemCompra> ItensAlterados { get; set; }
        public ICollection<Orcamento> OrcamentosCriados { get; set; }
        public ICollection<Orcamento> OrcamentosAlterados { get; set; }
    }
}
