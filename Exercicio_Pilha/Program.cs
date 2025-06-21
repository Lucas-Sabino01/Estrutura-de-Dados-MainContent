using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Pilha
{
    public class Program
    {
        static Stack<string> historicoNavegacao = new Stack<string>();

        public static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        VisitarNovaPagina();
                        break;
                    case "2":
                        VoltarPagina();
                        break;
                    case "3":
                        VerPaginaAtual();
                        break;
                    case "4":
                        VerHistoricoCompleto();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do navegador. Até logo!");
                        return;
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
            Console.WriteLine("--- Simulador de Navegador (usando Pilha) ---");
            Console.ResetColor();
            Console.WriteLine("Páginas no histórico: " + historicoNavegacao.Count);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Visitar uma nova página (Push)");
            Console.WriteLine("2 - Voltar para a página anterior (Pop)");
            Console.WriteLine("3 - Ver a página atual (Peek)");
            Console.WriteLine("4 - Ver histórico completo");
            Console.WriteLine("0 - Sair");
            Console.Write("\nSua escolha: ");
        }

        public static void VisitarNovaPagina()
        {
            Console.Write("Digite a URL da página a ser visitada: ");
            string url = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(url))
            {
                historicoNavegacao.Push(url);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPágina '{url}' adicionada ao histórico com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nURL inválida. Tente novamente.");
            }
        }

        public static void VoltarPagina()
        {
            if (historicoNavegacao.Count > 0)
            {
                string paginaAnterior = historicoNavegacao.Pop();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nVoltando... Você estava em '{paginaAnterior}'.");

                if (historicoNavegacao.Count > 0)
                {
                    Console.WriteLine($"Agora você está em '{historicoNavegacao.Peek()}'.");
                }
                else
                {
                    Console.WriteLine("O histórico de navegação agora está vazio.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão há páginas para voltar. O histórico está vazio.");
            }
        }

        public static void VerPaginaAtual()
        {
            
            if (historicoNavegacao.Count > 0)
            {
                string paginaAtual = historicoNavegacao.Peek();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nVocê está na página: '{paginaAtual}'");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão há nenhuma página no histórico.");
            }
        }

        public static void VerHistoricoCompleto()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (historicoNavegacao.Count == 0)
            {
                Console.WriteLine("\nO histórico está vazio.");
                return;
            }

            Console.WriteLine("\n--- Histórico de Navegação Completo ---");
            foreach (string pagina in historicoNavegacao)
            {
                Console.WriteLine($"- {pagina}");
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
