using System;
using System.Collections.Generic;

namespace Implementação_de_Menu_Interativo
{
    public static class FilaManager
    {
        private static Queue<int> fila = new Queue<int>();

        public static void ExecutarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Gerenciador de Fila Dinâmica (Queue<T>) ---");
                Console.ResetColor();
                Exibir();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("[1] Adicionar (Enqueue)");
                Console.WriteLine("[2] Remover (Dequeue)");
                Console.WriteLine("[3] Ver Próximo (Peek)");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Write("\nDigite o número para entrar na fila: ");
                        if (int.TryParse(Console.ReadLine(), out int val)) fila.Enqueue(val);
                        else Console.WriteLine("\nEntrada inválida.");
                        break;
                    case "2":
                        if (fila.Count > 0) Console.WriteLine($"\nNúmero removido: {fila.Dequeue()}");
                        else Console.WriteLine("\nFila vazia.");
                        break;
                    case "3":
                        if (fila.Count > 0) Console.WriteLine($"\nPróximo da fila: {fila.Peek()}");
                        else Console.WriteLine("\nFila vazia.");
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void Exibir()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nEstado da Fila (Início -> Fim): [ ");
            if (fila.Count == 0) Console.Write("Vazia ");
            else Console.Write(string.Join(", ", fila) + " ");
            Console.WriteLine("]");
            Console.ResetColor();
        }
    }
}