using System;
using System.Collections.Generic;

namespace Exercicio_EstruturasHomogeneas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        DemonstrarArrayHomogeneo();
                        break;
                    case "2":
                        DemonstrarListaHomogenea();
                        break;
                    case "3":
                        DemonstrarTuplaHeterogenea();
                        break;
                    case "4":
                        DemonstrarClasseHeterogenea();
                        break;
                    case "5":
                        DemonstrarListaDeObjetosHeterogenea();
                        break;
                    case "6":
                        DemonstrarDicionarioHeterogeneo();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }

        public static void ExibirMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Menu de Demonstração de Estruturas de Dados ---");
            Console.ResetColor();
            Console.WriteLine("\n-- Estruturas Homogêneas (mesmo tipo de dado) --");
            Console.WriteLine("1 - Exemplo com Array de Inteiros");
            Console.WriteLine("2 - Exemplo com Lista de Strings");

            Console.WriteLine("\n-- Estruturas Heterogêneas (tipos de dados diferentes) --");
            Console.WriteLine("3 - Exemplo com Tupla");
            Console.WriteLine("4 - Exemplo com Classe/Objeto (Pessoa)");
            Console.WriteLine("5 - Exemplo com Lista de 'object'");
            Console.WriteLine("6 - Exemplo com Dicionário");

            Console.WriteLine("\n0 - Sair");
            Console.Write("\nEscolha qual demonstração você quer ver: ");
        }

        public static void DemonstrarArrayHomogeneo()
        {
            Console.Clear();
            Console.WriteLine("--- 1. Estrutura de Dados Homogênea (Array de inteiros) ---");
            Console.WriteLine("Um array tem tamanho fixo e só pode conter um tipo de dado.\n");

            int[] numeros = new int[] { 10, 20, 30, 40, 50 };

            foreach (int num in numeros)
            {
                Console.WriteLine($"Número: {num}");
            }
        }

        public static void DemonstrarListaHomogenea()
        {
            Console.Clear();
            Console.WriteLine("--- 2. Estrutura de Dados Homogênea (Lista de strings) ---");
            Console.WriteLine("Uma List<T> tem tamanho dinâmico, mas também só pode conter um tipo de dado (definido em T).\n");

            List<string> nomes = new List<string> { "Alice", "Bob", "Charlie" };

            foreach (string nome in nomes)
            {
                Console.WriteLine($"Nome: {nome}");
            }
        }

        public static void DemonstrarTuplaHeterogenea()
        {
            Console.Clear();
            Console.WriteLine("--- 3. Estrutura de Dados Heterogênea (Tupla) ---");
            Console.WriteLine("Uma tupla é uma estrutura simples para agrupar um número fixo de itens de tipos diferentes.\n");

            (string nomeProduto, int quantidade, double preco) produto1 = ("Laptop", 2, 1200.50);
            Console.WriteLine($"Produto: {produto1.nomeProduto}, Quantidade: {produto1.quantidade}, Preço: {produto1.preco:C}");
        }

        public static void DemonstrarClasseHeterogenea()
        {
            Console.Clear();
            Console.WriteLine("--- 4. Estrutura de Dados Heterogênea (Classe/Objeto) ---");
            Console.WriteLine("Uma classe é a forma mais robusta de agrupar dados e comportamentos de tipos diferentes.\n");

            Pessoa pessoa1 = new Pessoa { Nome = "Maria", Idade = 30, Cidade = "São Paulo" };
            Console.WriteLine(pessoa1);
        }

        public static void DemonstrarListaDeObjetosHeterogenea()
        {
            Console.Clear();
            Console.WriteLine("--- 5. Estrutura de Dados Heterogênea (Lista de 'object') ---");
            Console.WriteLine("Uma List<object> permite misturar qualquer tipo, mas perdemos a segurança de tipo.\n");

            List<object> itensDiversos = new List<object>
            {
                123, "Olá Mundo", true, 3.14,
                new Pessoa { Nome = "João", Idade = 25, Cidade = "Rio de Janeiro" }
            };

            foreach (var item in itensDiversos)
            {
                Console.WriteLine($"Tipo: {item.GetType().Name}, Valor: {item}");
                if (item is Pessoa p)
                {
                    Console.WriteLine($"  -> Encontrei uma pessoa! A cidade dela é: {p.Cidade}");
                }
            }
        }

        public static void DemonstrarDicionarioHeterogeneo()
        {
            Console.Clear();
            Console.WriteLine("--- 6. Estrutura de Dados Heterogênea (Dictionary) ---");
            Console.WriteLine("Um Dictionary<TKey, TValue> armazena pares de chave-valor. Usando 'object' como valor, podemos ter tipos diferentes.\n");

            Dictionary<string, object> dadosUsuario = new Dictionary<string, object>
            {
                { "Nome", "Carlos" }, { "Idade", 40 }, { "Ativo", true }, { "Salario", 5000.75 }
            };

            foreach (var entry in dadosUsuario)
            {
                Console.WriteLine($"Chave: {entry.Key}, Valor: {entry.Value}, Tipo do Valor: {entry.Value.GetType().Name}");
            }
        }
    }
}