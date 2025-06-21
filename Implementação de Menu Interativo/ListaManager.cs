using System;
using System.Collections.Generic;

namespace Implementação_de_Menu_Interativo
{
    public static class ListaManager
    {
        private static List<int> lista = new List<int>();

        public static void ExecutarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Gerenciador de Lista Dinâmica (List<T>) ---");
                Console.ResetColor();
                Exibir();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("[1] Inserir Elemento");
                Console.WriteLine("[2] Remover Elemento");
                Console.WriteLine("[3] Buscar Elemento");
                Console.WriteLine("[0] Voltar ao Menu Principal");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Write("\nDigite o número para inserir: ");
                        if (int.TryParse(Console.ReadLine(), out int val)) lista.Add(val);
                        else Console.WriteLine("\nEntrada inválida.");
                        break;
                    case "2":
                        Console.Write("\nDigite o número para remover: ");
                        if (int.TryParse(Console.ReadLine(), out int valRem))
                        {
                            if (lista.Remove(valRem)) Console.WriteLine("Número removido com sucesso.");
                            else Console.WriteLine("Número não encontrado.");
                        }
                        else Console.WriteLine("\nEntrada inválida.");
                        break;
                    case "3":
                        Console.Write("\nDigite o número para buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valBusca))
                        {
                            if (lista.Contains(valBusca)) Console.WriteLine("Número encontrado na lista.");
                            else Console.WriteLine("Número não encontrado.");
                        }
                        else Console.WriteLine("\nEntrada inválida.");
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
            Console.Write("\nEstado da Lista: [ ");
            if (lista.Count == 0) Console.Write("Vazia ");
            else Console.Write(string.Join(", ", lista) + " ");
            Console.WriteLine("]");
            Console.ResetColor();
        }
    }
}