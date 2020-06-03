using System.Collections.Generic;

namespace Loja.Propriedades
{
    public class Venda : Produto
    {
        public List<Produto> produtos = new List<Produto>();    
        public double Total { get; set; }

    }

}
