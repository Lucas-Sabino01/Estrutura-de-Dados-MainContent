using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio_Lista
{
    public class Program
    {
        static List<Pessoa> pessoas = new List<Pessoa>();

        public static void Main(string[] args)
        {
            pessoas.Add(new Pessoa { Nome = "Ana", Idade = 28 });
            pessoas.Add(new Pessoa { Nome = "Bruno", Idade = 32 });
            pessoas.Add(new Pessoa { Nome = "Carla", Idade = 25 });

            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        ListarTodasAsPessoas();
                        break;
                    case "2":
                        AdicionarNovaPessoa();
                        break;
                    case "3":
                        RemoverPessoa();
                        break;
                    case "4":
                        EncontrarPessoaPorNome();
                        break;
                    case "5":
                        OrdenarListaPorNome();
                        break;
                    case "6":
                        OrdenarListaPorIdade();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        return; // Encerra o programa
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public static void ExibirMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Gerenciador de Cadastro (usando List<T>) ---");
            Console.ResetColor();
            Console.WriteLine($"Total de pessoas cadastradas: {pessoas.Count}");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("1 - Listar todas as pessoas");
            Console.WriteLine("2 - Adicionar nova pessoa");
            Console.WriteLine("3 - Remover uma pessoa");
            Console.WriteLine("4 - Encontrar pessoa por nome");
            Console.WriteLine("5 - Ordenar lista por nome");
            Console.WriteLine("6 - Ordenar lista por idade");
            Console.WriteLine("0 - Sair");
            Console.Write("\nSua escolha: ");
        }

        public static void ListarTodasAsPessoas()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Lista de Pessoas Cadastradas ---");
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada.");
                return;
            }

            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pessoas[i]}"); 
            }
        }

        public static void AdicionarNovaPessoa()
        {
            try
            {
                Console.Write("Digite o nome da pessoa: ");
                string nome = Console.ReadLine();

                Console.Write("Digite a idade da pessoa: ");
                int idade = int.Parse(Console.ReadLine());

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome não pode ser vazio.");
                    return;
                }

                pessoas.Add(new Pessoa { Nome = nome, Idade = idade });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPessoa '{nome}' adicionada com sucesso!");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nErro: A idade deve ser um número válido.");
            }
        }

        public static void RemoverPessoa()
        {
            Console.Write("Digite o nome da pessoa a ser removida: ");
            string nomeParaRemover = Console.ReadLine();

            int removidos = pessoas.RemoveAll(p => p.Nome.Equals(nomeParaRemover, StringComparison.OrdinalIgnoreCase));

            if (removidos > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{removidos} pessoa(s) com o nome '{nomeParaRemover}' foram removidas.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nNenhuma pessoa com o nome '{nomeParaRemover}' foi encontrada.");
            }
        }

        public static void EncontrarPessoaPorNome()
        {
            Console.Write("Digite o nome da pessoa a ser encontrada: ");
            string nomeParaEncontrar = Console.ReadLine();

            Pessoa pessoaEncontrada = pessoas.Find(p => p.Nome.Equals(nomeParaEncontrar, StringComparison.OrdinalIgnoreCase));

            if (pessoaEncontrada != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nPessoa encontrada: {pessoaEncontrada}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nNenhuma pessoa com o nome '{nomeParaEncontrar}' foi encontrada.");
            }
        }

        public static void OrdenarListaPorNome()
        {
            pessoas = pessoas.OrderBy(p => p.Nome).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLista ordenada por nome com sucesso!");
            ListarTodasAsPessoas(); // Mostra o resultado
        }

        public static void OrdenarListaPorIdade()
        {
            pessoas.Sort((p1, p2) => p1.Idade.CompareTo(p2.Idade));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLista ordenada por idade com sucesso!");
            ListarTodasAsPessoas(); // Mostra o resultado
        }
    }
}