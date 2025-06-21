using System;

namespace Implementação_de_Menu_Interativo
{
    public static class PesquisaManager
    {
        private static int[] arrayOriginal;
        private static int[] arrayOrdenado;

        public static void ExecutarMenu()
        {
            if (arrayOriginal == null) GerarNovoArray();

            while (true)
            {
                ExibirSubMenu();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1": ExecutarBuscaLinear(); break;
                    case "2": ExecutarBuscaBinaria(); break;
                    case "9": GerarNovoArray(); break;
                    case "0": return;
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
            Console.WriteLine("--- Laboratório de Algoritmos de Busca ---");
            Console.ResetColor();
            Console.WriteLine("\nArray Atual: " + string.Join(", ", arrayOriginal));
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("[1] Executar Busca Linear");
            Console.WriteLine("[2] Executar Busca Binária");
            Console.WriteLine("[9] Gerar Novo Array Aleatório");
            Console.WriteLine("[0] Voltar ao Menu Principal");
            Console.Write("\nEscolha uma opção: ");
        }

        private static void GerarNovoArray(int tamanho = 20, int valorMaximo = 100)
        {
            arrayOriginal = new int[tamanho];
            Random random = new Random();
            for (int i = 0; i < tamanho; i++)
            {
                arrayOriginal[i] = random.Next(valorMaximo);
            }
            arrayOrdenado = (int[])arrayOriginal.Clone();
            Array.Sort(arrayOrdenado);
            Console.WriteLine("\nNovo array aleatório gerado!");
        }

        private static void ExecutarBuscaLinear()
        {
            Console.Write("\nDigite o valor para a Busca Linear: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                var (index, comparacoes) = LinearSearch(arrayOriginal, valor);
                if (index != -1) Console.WriteLine($"\nValor {valor} encontrado na posição {index}.");
                else Console.WriteLine($"\nValor {valor} não encontrado.");
                Console.WriteLine($"Comparações realizadas: {comparacoes}");
            }
            else Console.WriteLine("\nEntrada inválida.");
        }

        private static void ExecutarBuscaBinaria()
        {
            Console.WriteLine("\n(A Busca Binária usará a versão ordenada do array)");
            Console.Write("Digite o valor para a Busca Binária: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                var (index, comparacoes) = BinarySearch(arrayOrdenado, valor);
                if (index != -1) Console.WriteLine($"\nValor {valor} encontrado.");
                else Console.WriteLine($"\nValor {valor} não encontrado.");
                Console.WriteLine($"Comparações realizadas: {comparacoes}");
            }
            else Console.WriteLine("\nEntrada inválida.");
        }

        private static (int index, int comparacoes) LinearSearch(int[] arr, int target)
        {
            int comparacoes = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                comparacoes++;
                if (arr[i] == target) return (i, comparacoes);
            }
            return (-1, comparacoes);
        }

        private static (int index, int comparacoes) BinarySearch(int[] arr, int target)
        {
            int comparacoes = 0;
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                comparacoes++;
                int mid = left + (right - left) / 2;
                if (arr[mid] == target) return (mid, comparacoes);
                if (arr[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return (-1, comparacoes);
        }
    }
}