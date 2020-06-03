
namespace Loja.Propriedades
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }


     
        public override string ToString()
        {
            return "Usuario: "
                + Nome
                + "  Email: "
                + Email
                + "  Senha:  "
                + Senha;
        }
    }
}
