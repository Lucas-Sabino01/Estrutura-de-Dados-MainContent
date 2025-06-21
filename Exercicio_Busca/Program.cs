using System;
using System.Linq;

namespace Exercicio_Busca
{
    class Program
    {
        static int[] arrayOriginal;
        static int[] arrayOrdenado;

        static void Main(string[] args)
        {
            GerarNovoArray(); // Gera o primeiro array ao iniciar

            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        ExecutarBuscaLinear();
                        break;
                    case "2":
                        ExecutarBuscaBinaria();
                        break;
                    case "9":
                        GerarNovoArray();
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
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Laboratório de Algoritmos de Busca ---");
            Console.ResetColor();
            Console.WriteLine("\nArray para busca (a Busca Binária usará a versão ordenada):");
            Console.WriteLine(string.Join(", ", arrayOriginal));
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Escolha um algoritmo para usar:");
            Console.WriteLine("1. Busca Linear (funciona em qualquer array)");
            Console.WriteLine("2. Busca Binária (requer array ordenado, muito mais rápida)");
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("9. Gerar novo array aleatório");
            Console.WriteLine("0. Sair");
            Console.Write("\nSua escolha: ");
        }

        static void GerarNovoArray(int tamanho = 20, int valorMaximo = 100)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            arrayOriginal = new int[tamanho];
            Random random = new Random();
            for (int i = 0; i < tamanho; i++)
            {
                arrayOriginal[i] = random.Next(valorMaximo);
            }

            // Cria a cópia ordenada para a Busca Binária
            arrayOrdenado = (int[])arrayOriginal.Clone();
            Array.Sort(arrayOrdenado);

            Console.WriteLine("\nNovo array aleatório gerado com sucesso!");
            Console.ResetColor();
        }

        // Método que pede o valor ao usuário e executa a Busca Linear
        static void ExecutarBuscaLinear()
        {
            Console.Write("\nDigite o valor que deseja procurar com a Busca Linear: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                var resultado = LinearSearch(arrayOriginal, valor);

                if (resultado.index != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nValor {valor} encontrado na posição {resultado.index}.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nValor {valor} não encontrado.");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Número de comparações realizadas: {resultado.comparacoes}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }
        }

        static void ExecutarBuscaBinaria()
        {
            Console.WriteLine("\n(A Busca Binária será executada no array ordenado: " + string.Join(", ", arrayOrdenado) + ")");
            Console.Write("Digite o valor que deseja procurar com a Busca Binária: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                var resultado = BinarySearch(arrayOrdenado, valor);

                if (resultado.index != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nValor {valor} encontrado na posição {resultado.index} do array ordenado.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nValor {valor} não encontrado.");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Número de comparações realizadas: {resultado.comparacoes}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }
        }


        #region Implementações dos Algoritmos de Busca

        static (int index, int comparacoes) LinearSearch(int[] arr, int target)
        {
            int comparacoes = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                comparacoes++;
                if (arr[i] == target)
                {
                    return (i, comparacoes); // Encontrado!
                }
            }
            return (-1, comparacoes); // Não encontrado
        }

        // Busca Binária modificada para retornar também o número de comparações
        static (int index, int comparacoes) BinarySearch(int[] arr, int target)
        {
            int comparacoes = 0;
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                comparacoes++;
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    return (mid, comparacoes); // Encontrado!
                }

                if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return (-1, comparacoes); // Não encontrado
        }
        #endregion
    }
}