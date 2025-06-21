using System;

namespace Implementação_de_Menu_Interativo
{
    public static class VetorManager
    {
        private static int[] vetor = new int[10];
        private static int elementosNoVetor = 0;

        public static void ExecutarMenu()
        {
            while (true)
            {
                ExibirSubMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Inserir(); break;
                    case "2": Remover(); break;
                    case "3": Exibir(); break;
                    case "4": Buscar(); break;
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
            Console.WriteLine("--- Gerenciador de Vetor (Lista Estática) ---");
            Console.ResetColor();
            Exibir();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("[1] Inserir Elemento");
            Console.WriteLine("[2] Remover Elemento");
            Console.WriteLine("[3] Exibir Todos os Elementos");
            Console.WriteLine("[4] Buscar Elemento");
            Console.WriteLine("[0] Voltar ao Menu Principal");
            Console.Write("\nEscolha uma opção: ");
        }

        private static void Inserir()
        {
            if (elementosNoVetor >= vetor.Length)
            {
                Console.WriteLine("\nErro: Vetor está cheio!");
                return;
            }

            Console.Write("\nDigite o número para inserir: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                vetor[elementosNoVetor] = valor;
                elementosNoVetor++;
                Console.WriteLine("\nNúmero inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número.");
            }
        }

        private static void Remover()
        {
            Console.Write("\nDigite o número para remover: ");
            if (int.TryParse(Console.ReadLine(), out int valorParaRemover))
            {
                int indiceRemover = -1;
                for (int i = 0; i < elementosNoVetor; i++)
                {
                    if (vetor[i] == valorParaRemover)
                    {
                        indiceRemover = i;
                        break;
                    }
                }

                if (indiceRemover != -1)
                {
                    for (int i = indiceRemover; i < elementosNoVetor - 1; i++)
                    {
                        vetor[i] = vetor[i + 1];
                    }
                    elementosNoVetor--;
                    Console.WriteLine("\nNúmero removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nNúmero não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("\nEntrada inválida.");
            }
        }

        private static void Exibir()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nEstado do Vetor: [ ");
            if (elementosNoVetor == 0)
            {
                Console.Write("Vazio ");
            }
            else
            {
                for (int i = 0; i < elementosNoVetor; i++)
                {
                    Console.Write(vetor[i] + " ");
                }
            }
            Console.WriteLine("]");
            Console.ResetColor();
        }

        private static void Buscar()
        {
            Console.Write("\nDigite o número para buscar: ");
            if (int.TryParse(Console.ReadLine(), out int valorParaBuscar))
            {
                bool encontrado = false;
                for (int i = 0; i < elementosNoVetor; i++)
                {
                    if (vetor[i] == valorParaBuscar)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado) Console.WriteLine($"\nO número {valorParaBuscar} foi encontrado no vetor.");
                else Console.WriteLine($"\nO número {valorParaBuscar} não foi encontrado.");
            }
            else
            {
                Console.WriteLine("\nEntrada inválida.");
            }
        }
    }
}