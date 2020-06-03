using Loja.Propriedades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("             BEM-VINDO!");
            Console.WriteLine("");
            string decisaoInicial;
            List<Usuario> listaUsuarios = new List<Usuario>();
            List<Produto> listaProdutos = new List<Produto>();
            List<Venda> listaVendas = new List<Venda>();
            UsuarioDefault(listaUsuarios);

            Console.Clear();
            Usuario usuario = new Usuario();
            Console.WriteLine(">>> EFETUAR LOGIN <<<");
            Console.Write("Nome: ");
            usuario.Nome = Console.ReadLine().Trim().ToUpper();
            Console.Write("Senha: ");
            usuario.Senha = Console.ReadLine();
            var validaUsuarioDefault = listaUsuarios.Any(comparaUsuarioESenha => comparaUsuarioESenha.Nome.Equals(usuario.Nome) && comparaUsuarioESenha.Senha.Equals(usuario.Senha));

            if (validaUsuarioDefault)
            {
                do
                {
                    decisaoInicial = MenuInicial();
                    switch (decisaoInicial)
                    {
                        case "1":
                            MenuCadastro(listaUsuarios);
                            break;
                        case "2":
                            MenuProduto(listaProdutos);
                            break;
                        case "3":
                            MenuVenda(listaProdutos);
                            break;
                        case "4":
                            MenuRelatorios(listaUsuarios, listaProdutos, listaVendas);
                            break;
                        case "0":
                            Console.WriteLine("Até logo!");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("'{0}' não é válido.Tente novamente. ", decisaoInicial);
                            Console.ReadKey();
                            break;
                    }
                } while (decisaoInicial != "0");

                return;
            }
            else
            {
                Console.WriteLine(">>> Login ou senha inválida! <<<");
                Main(args);
            }
        }




        private static string MenuInicial()
        {
            string decisaoMenuInicial;
            Console.Clear();
            Console.WriteLine("             [MENU]");
            Console.WriteLine("   1 - Cadastro de Usuário   ");
            Console.WriteLine("   2 - Cadastro de Produto   ");
            Console.WriteLine("   3 - Realizar uma Venda    ");
            Console.WriteLine("   4 - Relatórios            ");
            Console.WriteLine("   0 - Sair                  ");

            Console.Write("[Digite opção] ");
            decisaoMenuInicial = Console.ReadLine();
            return decisaoMenuInicial;
        }
        private static void MenuCadastro(List<Usuario> listaUsuarios)
        {
            Console.Clear();
            string decisaoCadastro;
            Console.WriteLine("          [USUARIOS]");
            Console.WriteLine("   1 - Cadastrar novo usuário  ");
            Console.WriteLine("   2 - Consultar usuario       ");
            Console.WriteLine("   3 - Alterar cadastro        ");
            Console.WriteLine("   4 - Excluir cadastro        ");
            Console.Write("[Digite opção] ");
            decisaoCadastro = Console.ReadLine();

            switch (decisaoCadastro)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--Cadastrar novo usuário--");
                    Usuario usuario = new Usuario();
                    Console.Write("Nome: ");
                    usuario.Nome = Console.ReadLine().Trim().ToUpper();
                    Console.Write("Email: ");
                    usuario.Email = Console.ReadLine();
                    Console.Write("Senha: ");
                    usuario.Senha = Console.ReadLine();
                    listaUsuarios.Add(usuario);
                    Console.WriteLine("Cadastro realizado");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--Consultar Usuario--");
                    Console.WriteLine("Digite nome do usuario: ");
                    string consultaUsuario = Console.ReadLine().Trim().ToUpper();
                    var consUsuario = listaUsuarios.Where(c => c.Nome.Equals(consultaUsuario)).FirstOrDefault();

                    if (consUsuario != null)
                    {
                        Console.WriteLine(consUsuario);

                    }
                    else
                    {
                        Console.WriteLine(">>> Usuario nao cadastrado! <<<");
                    }
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("--Alterar cadastro--"); ;
                    Console.WriteLine("Digite nome do usuario: ");
                    string alteraUsuario = Console.ReadLine().Trim().ToUpper();
                    var altUsuario = listaUsuarios.Where(c => c.Nome.Equals(alteraUsuario)).FirstOrDefault();

                    if (altUsuario != null)
                    {
                        Console.WriteLine(altUsuario);

                        Console.Write("Nome: ");
                        altUsuario.Nome = Console.ReadLine().Trim().ToUpper();
                        Console.Write("Email: ");
                        altUsuario.Email = Console.ReadLine();
                        Console.Write("Senha: ");
                        altUsuario.Senha = Console.ReadLine();
                        Console.WriteLine(">>> Alteração realizada com sucesso <<<");
                    }
                    else
                    {
                        Console.WriteLine(">>> Usuario nao cadastrado! <<<");
                    }
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("--Excluir cadastro--\n");
                    Console.Write("Digite o nome do usuario: ");
                    string removeUsuario = Console.ReadLine().Trim().ToUpper();
                    var RUsuario = listaUsuarios.Where(c => c.Nome.Equals(removeUsuario)).FirstOrDefault();

                    if (RUsuario != null)
                    {
                        listaUsuarios.Remove(RUsuario);
                        Console.WriteLine(">>> Cadastro removido com sucesso! <<< ");
                    }
                    else
                    {
                        Console.WriteLine(">>> Usuario nao cadastrado! <<<");
                    }
                    Console.ReadKey();
                    break;
            }
        }
        private static void MenuProduto(List<Produto> listaProdutos)
        {
            Console.Clear();
            string decisaoProduto;
            Console.WriteLine("          [PRODUTOS]");
            Console.WriteLine("   1 - Cadastrar novo produto  ");
            Console.WriteLine("   2 - Consultar produto       ");
            Console.WriteLine("   3 - Alterar produto         ");
            Console.WriteLine("   4 - Excluir produto        ");
            Console.Write("[Digite opção] ");
            decisaoProduto = Console.ReadLine();

            switch (decisaoProduto)
            {
                case "1":
                    Console.Clear();
                    Produto produto = new Produto();
                    Console.WriteLine("             [CADASTRO DE PRODUTOS]");
                    Console.Write("Digite uma ID <numérica>: ");
                    try
                    {
                        produto.Id = int.Parse(Console.ReadLine());
                        Console.Write("Produto: ");
                        produto.Nome = Console.ReadLine().Trim().ToUpper();
                        Console.Write("Preço(R$): ");
                        try
                        {
                            produto.Preco = double.Parse(Console.ReadLine());
                            listaProdutos.Add(produto);
                            Console.WriteLine("\n----------------------------------------------------------------------");
                            Console.WriteLine(produto);
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Console.Write("[Preço] aceita apenas números! Tente novamente!");
                            Console.ReadKey();
                        }

                    }
                    catch (Exception)
                    {
                        Console.Write("[ID] aceita apenas números! Tente novamente!");
                        Console.ReadKey();
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--Consultar Produto--");
                    Console.WriteLine("Digite nome do produto: ");
                    string consultaProduto = Console.ReadLine().Trim().ToUpper();
                    var consProduto = listaProdutos.Where(p => p.Nome.Equals(consultaProduto)).FirstOrDefault();

                    if (consProduto != null)
                    {
                        Console.WriteLine(consProduto);

                    }
                    else
                    {
                        Console.WriteLine(">>> Produto nao cadastrado! <<<");
                    }
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("--Alterar Produto--"); ;
                    Console.WriteLine("Digite nome do Produto: ");
                    string alteraProduto = Console.ReadLine().Trim().ToUpper();
                    var altProduto = listaProdutos.Where(p => p.Nome.Equals(alteraProduto)).FirstOrDefault();

                    if (altProduto != null)
                    {
                        Console.WriteLine(altProduto);

                        Console.Write("Nome: ");
                        altProduto.Id = int.Parse(Console.ReadLine());
                        Console.Write("Email: ");
                        altProduto.Nome = Console.ReadLine().Trim().ToUpper();
                        Console.Write("Senha: ");
                        altProduto.Preco = double.Parse(Console.ReadLine());
                        Console.WriteLine(">>> Alteração realizada com sucesso <<<");
                    }
                    else
                    {
                        Console.WriteLine(">>> Produto nao cadastrado! <<<");
                    }
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("--Excluir cadastro--\n");
                    Console.Write("Digite o nome do usuario: ");
                    string removeProduto = Console.ReadLine().Trim().ToUpper();
                    var remProduto = listaProdutos.Where(p => p.Nome.Equals(removeProduto)).FirstOrDefault();

                    if (remProduto != null)
                    {
                        listaProdutos.Remove(remProduto);
                        Console.WriteLine(">>> Produto removido com sucesso! <<< ");
                    }
                    else
                    {
                        Console.WriteLine(">>> Produto nao cadastrado! <<<");
                    }
                    Console.ReadKey();
                    break;
            }
        }
        private static void MenuVenda(List<Produto> listaProdutos)
        {
            Console.Clear();
            Console.WriteLine("             [REALIZAR VENDA]");
            Venda venda = new Venda();
            char cond;
            do
            {
                Console.Write("Digite o ID do produto: ");
                int idProduto = int.Parse(Console.ReadLine());
                foreach (var p in listaProdutos)
                {
                    if (idProduto == p.Id)
                    {
                        venda.produtos.Add(p);
                        Console.WriteLine("ID: " + p.Id + "Nome: " + p.Nome + "Preço:" + p.Preco);

                    }
                }
                Console.Write("\nAdicionar produto [s / n]?  ");
                cond = char.Parse(Console.ReadLine());

            } while (cond != 'n' && cond != 'N');

            Console.Clear();
            foreach (var produtoSelecionado in venda.produtos)
            {
                venda.Total += produtoSelecionado.Preco;
                Console.WriteLine(produtoSelecionado);


            }
            Console.WriteLine("\nTotal =  R$" + venda.Total);
            Console.WriteLine("\n----- VENDA REALIZADA COM SUCESSO ! -----");

            Console.ReadKey();
        }
        private static void MenuRelatorios(List<Usuario> listaUsuarios, List<Produto> listaProdutos, List<Venda> listaVendas)
        {
            string decisaoRelatorio;
            Console.Clear();
            Console.WriteLine("             [RELATORIOS]");
            Console.WriteLine("   1 - Usuários Cadastrados    ");
            Console.WriteLine("   2 - Produtos Cadastrados    ");
            Console.WriteLine("   3 - Vendas Realizadas       ");
            Console.Write("[Digite opção] ");
            decisaoRelatorio = Console.ReadLine();

            switch (decisaoRelatorio)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--Usuários cadastrados--");
                    foreach (var usuarios in listaUsuarios)
                    {
                        Console.WriteLine(usuarios);
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("--Produtos cadastrados--");
                    foreach (var produtos in listaProdutos)
                    {
                        Console.WriteLine(produtos);
                    }
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("--Vendas Realizadas--");
                    foreach (var vendas in listaVendas)
                    {
                        Console.WriteLine(vendas);
                    }
                    Console.ReadKey();
                    break;

            }
        }

        private static void UsuarioDefault(List<Usuario> listaUsuarios)
        {
            listaUsuarios.Add(new Usuario() { Nome = "ADMIN", Email = "ADMIN", Senha = "1234" });
        }
    }
}