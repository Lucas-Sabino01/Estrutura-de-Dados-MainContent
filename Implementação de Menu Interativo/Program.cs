using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementação_de_Menu_Interativo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("================================================");
                Console.WriteLine("===   PROJETO FINAL - ESTRUTURAS DE DADOS    ===");
                Console.WriteLine("================================================");
                Console.ResetColor();
                Console.WriteLine("\nEscolha uma opção para trabalhar:");
                Console.WriteLine("  [1] Vetores (Lista Estática)");
                Console.WriteLine("  [2] Matrizes");
                Console.WriteLine("  [3] Listas Dinâmicas (List<T>)");
                Console.WriteLine("  [4] Filas Dinâmicas (Queue<T>)");
                Console.WriteLine("  [5] Pilhas Dinâmicas (Stack<T>)");
                Console.WriteLine("  [6] Algoritmos de Pesquisa");
                Console.WriteLine("  [0] Encerrar Programa\n");
                Console.Write("Sua escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": VetorManager.ExecutarMenu(); break;
                    case "2": MatrizManager.ExecutarMenu(); break;
                    case "3": ListaManager.ExecutarMenu(); break;
                    case "4": FilaManager.ExecutarMenu(); break;
                    case "5": PilhaManager.ExecutarMenu(); break;
                    case "6": PesquisaManager.ExecutarMenu(); break;
                    case "0":
                        Console.WriteLine("\nEncerrando o programa... Até logo!");
                        return; // Sai do programa
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para tentar novamente...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}