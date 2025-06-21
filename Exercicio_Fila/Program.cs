using System;
using System.Collections.Generic;

namespace Exercicio_Fila
{
    class Program
    {
        static Queue<string> filaDeAtendimento = new Queue<string>();

        static void Main(string[] args)
        {
            while (true) // Loop infinito que só é quebrado com o 'return' no caso '6'
            {
                ExibirMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarCliente();
                        break;
                    case "2":
                        ChamarProximoCliente();
                        break;
                    case "3":
                        VerProximoCliente();
                        break;
                    case "4":
                        MostrarFilaCompleta();
                        break;
                    case "5":
                        // A contagem já é mostrada no menu, mas podemos reforçar
                        Console.WriteLine($"\nAtualmente existem {filaDeAtendimento.Count} clientes na fila.");
                        break;
                    case "6":
                        Console.WriteLine("Saindo do sistema de fila. Até mais!");
                        return; // Encerra o programa
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Sistema de Fila de Atendimento ---");
            Console.ResetColor();
            Console.WriteLine($"Clientes esperando: {filaDeAtendimento.Count}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Adicionar cliente à fila (Enqueue)");
            Console.WriteLine("2. Chamar próximo cliente (Dequeue)");
            Console.WriteLine("3. Ver próximo cliente (Peek)");
            Console.WriteLine("4. Mostrar todos os clientes na fila");
            Console.WriteLine("5. Verificar número de clientes na fila");
            Console.WriteLine("6. Sair");
            Console.Write("Opção: ");
        }

        static void AdicionarCliente()
        {
            Console.Write("\nDigite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nomeCliente))
            {
                filaDeAtendimento.Enqueue(nomeCliente);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"'{nomeCliente}' foi adicionado(a) à fila.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O nome do cliente não pode ser vazio.");
            }
        }

        static void ChamarProximoCliente()
        {
            if (filaDeAtendimento.Count > 0)
            {
                string clienteChamado = filaDeAtendimento.Dequeue();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nChamando cliente: '{clienteChamado}'.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA fila está vazia. Nenhum cliente para chamar.");
            }
        }

        static void VerProximoCliente()
        {
            if (filaDeAtendimento.Count > 0)
            {
                string proximoCliente = filaDeAtendimento.Peek();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nPróximo cliente na fila: '{proximoCliente}'.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA fila está vazia.");
            }
        }

        static void MostrarFilaCompleta()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (filaDeAtendimento.Count > 0)
            {
                Console.WriteLine("\n--- Clientes na Fila (do primeiro ao último) ---");
                int posicao = 1;
                foreach (string cliente in filaDeAtendimento)
                {
                    Console.WriteLine($"{posicao++}. {cliente}");
                }
            }
            else
            {
                Console.WriteLine("\nA fila está vazia.");
            }
        }
    }
}