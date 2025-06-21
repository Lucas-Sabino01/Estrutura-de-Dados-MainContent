using System;

namespace Implementação_de_Menu_Interativo
{
    public static class MatrizManager
    {
        private static int[,] matriz = new int[5, 5];

        public static void ExecutarMenu()
        {
            while (true)
            {
                ExibirSubMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": InserirOuAtualizar(); break;
                    case "2": Remover(); break;
                    case "3": Buscar(); break;
                    case "0": return; // Volta ao menu principal
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

        private static void ExibirSubMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Gerenciador de Matriz (Array 2D) ---");
            Console.ResetColor();
            Console.WriteLine("\nEstado Atual da Matriz:");
            ExibirMatriz(); // Chama o método que desenha a matriz
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("[1] Inserir / Atualizar Elemento");
            Console.WriteLine("[2] Remover Elemento (Zerar)");
            Console.WriteLine("[3] Buscar Elemento");
            Console.WriteLine("[0] Voltar ao Menu Principal");
            Console.Write("\nEscolha uma opção: ");
        }

        private static void ExibirMatriz()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        private static void InserirOuAtualizar()
        {
            try
            {
                Console.Write("\nDigite a linha (0 a 4): ");
                int linha = int.Parse(Console.ReadLine());

                Console.Write("Digite a coluna (0 a 4): ");
                int coluna = int.Parse(Console.ReadLine());

                if (linha < 0 || linha >= matriz.GetLength(0) || coluna < 0 || coluna >= matriz.GetLength(1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nErro: Posição fora dos limites da matriz!");
                    return;
                }

                Console.Write($"Digite o valor para a posição [{linha}, {coluna}]: ");
                int valor = int.Parse(Console.ReadLine());

                matriz[linha, coluna] = valor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nValor inserido/atualizado com sucesso!");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nErro: Entrada inválida. Por favor, digite apenas números.");
            }
        }

        private static void Remover()
        {
            try
            {
                Console.Write("\nDigite a linha do elemento a ser removido (0 a 4): ");
                int linha = int.Parse(Console.ReadLine());

                Console.Write("Digite a coluna do elemento a ser removido (0 a 4): ");
                int coluna = int.Parse(Console.ReadLine());

                if (linha < 0 || linha >= matriz.GetLength(0) || coluna < 0 || coluna >= matriz.GetLength(1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nErro: Posição fora dos limites da matriz!");
                    return;
                }

                matriz[linha, coluna] = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nElemento zerado com sucesso!");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nErro: Entrada inválida. Por favor, digite apenas números.");
            }
        }

        private static void Buscar()
        {
            try
            {
                Console.Write("\nDigite o número para buscar na matriz: ");
                int valorParaBuscar = int.Parse(Console.ReadLine());
                bool encontrado = false;

                Console.WriteLine(); // Espaçamento
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] == valorParaBuscar)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Valor {valorParaBuscar} encontrado na posição [{i}, {j}].");
                            encontrado = true;
                        }
                    }
                }

                if (!encontrado)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O valor {valorParaBuscar} não foi encontrado na matriz.");
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nErro: Entrada inválida. Por favor, digite um número.");
            }
        }
    }
}