
namespace Loja.Propriedades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

       
        

        public override string ToString()
        {
            return "ID: "
                + Id
                + "  Produto: "
                + Nome
                + "  Preço: R$"
                + Preco;
        }
    }
}
