using System;
using System.Collections.Generic;

namespace Implementação_de_Menu_Interativo
{
    public static class PilhaManager
    {
        private static Stack<int> pilha = new Stack<int>();

        public static void ExecutarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Gerenciador de Pilha Dinâmica (Stack<T>) ---");
                Console.ResetColor();
                Exibir();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("[1] Adicionar (Push)");
                Console.WriteLine("[2] Remover (Pop)");
                Console.WriteLine("[3] Ver Topo (Peek)");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Write("\nDigite o número para empilhar: ");
                        if (int.TryParse(Console.ReadLine(), out int val)) pilha.Push(val);
                        else Console.WriteLine("\nEntrada inválida.");
                        break;
                    case "2":
                        if (pilha.Count > 0) Console.WriteLine($"\nNúmero removido: {pilha.Pop()}");
                        else Console.WriteLine("\nPilha vazia.");
                        break;
                    case "3":
                        if (pilha.Count > 0) Console.WriteLine($"\nNúmero no topo: {pilha.Peek()}");
                        else Console.WriteLine("\nPilha vazia.");
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
            Console.Write("\nEstado da Pilha (Topo -> Base): [ ");
            if (pilha.Count == 0) Console.Write("Vazia ");
            else Console.Write(string.Join(", ", pilha) + " ");
            Console.WriteLine("]");
            Console.ResetColor();
        }
    }
}