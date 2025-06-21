using System;
using System.Diagnostics;
using System.Linq;

namespace Exercicio_Ordenacao
{
    class Program
    {
        static int[] arrayParaOrdenar;

        static void Main(string[] args)
        {
            // Gera um array inicial ao iniciar o programa
            GerarNovoArrayAleatorio();

            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        ExecutarEmedirOrdenacao(BubbleSort, "Bubble Sort");
                        break;
                    case "2":
                        ExecutarEmedirOrdenacao(SelectionSort, "Selection Sort");
                        break;
                    case "3":
                        ExecutarEmedirOrdenacao(InsertionSort, "Insertion Sort");
                        break;
                    case "4":
                        ExecutarEmedirOrdenacao(arr => Array.Sort(arr), "Quick Sort (Nativo do .NET)");
                        break;
                    case "5":
                        ExecutarEmedirOrdenacao(arr => { arr = arr.OrderBy(x => x).ToArray(); }, "Merge Sort (LINQ)");
                        break;
                    case "9":
                        GerarNovoArrayAleatorio();
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
            Console.WriteLine("--- Laboratório de Algoritmos de Ordenação ---");
            Console.ResetColor();
            Console.WriteLine("\nArray atual para ordenação:");
            Console.WriteLine(string.Join(", ", arrayParaOrdenar));
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Escolha um algoritmo para aplicar:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Insertion Sort");
            Console.WriteLine("4. Quick Sort (Nativo do .NET, muito rápido)");
            Console.WriteLine("5. Merge Sort (via LINQ, muito rápido)");
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("9. Gerar novo array aleatório");
            Console.WriteLine("0. Sair");
            Console.Write("\nSua escolha: ");
        }

        static void GerarNovoArrayAleatorio(int tamanho = 15, int valorMaximo = 100)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            arrayParaOrdenar = new int[tamanho];
            Random random = new Random();
            for (int i = 0; i < tamanho; i++)
            {
                arrayParaOrdenar[i] = random.Next(valorMaximo);
            }
            Console.WriteLine("\nNovo array aleatório gerado com sucesso!");
            Console.ResetColor();
        }

        static void ExecutarEmedirOrdenacao(Action<int[]> algoritmoDeOrdenacao, string nomeDoAlgoritmo)
        {
            int[] cloneDoArray = (int[])arrayParaOrdenar.Clone();

            // Usei o Stopwatch para medir o tempo
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            algoritmoDeOrdenacao(cloneDoArray);
            stopwatch.Stop();

            Console.WriteLine($"\n--- Resultado para: {nomeDoAlgoritmo} ---");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Array Ordenado: " + string.Join(", ", cloneDoArray));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Tempo de execução: {stopwatch.Elapsed.TotalMilliseconds:F4} ms ({stopwatch.ElapsedTicks} ticks)");
            Console.ResetColor();
        }

        #region Implementações dos Algoritmos de Ordenação

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        #endregion
    }
}