using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_PilhaEstática
{
    public class StaticStack<T>
    {
        private T[] _elements;
        private int _top;
        private int _maxSize;

        public StaticStack(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "O tamanho da pilha deve ser maior que zero.");
            }
            _maxSize = size;
            _elements = new T[_maxSize];
            _top = -1; // Indica que a pilha está vazia
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("A pilha está cheia. Não é possível adicionar mais elementos.");
            }
            _elements[++_top] = item;
            Console.WriteLine($"Adicionado: {item}. Pilha agora tem {Count} elementos.");
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("A pilha está vazia. Não é possível remover elementos.");
            }
            T item = _elements[_top--];
            Console.WriteLine($"Removido: {item}. Pilha agora tem {Count} elementos.");
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("A pilha está vazia. Não há elementos para visualizar.");
            }
            return _elements[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public bool IsFull()
        {
            return _top == _maxSize - 1;
        }

        public int Count
        {
            get { return _top + 1; }
        }

        public void Clear()
        {
            _top = -1;
            Console.WriteLine("Pilha limpa.");
        }

        public void PrintStack()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Pilha: [Vazia]");
                return;
            }
            Console.Write("Pilha: [");
            for (int i = 0; i <= _top; i++)
            {
                Console.Write(_elements[i]);
                if (i < _top)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("] (Topo: {_elements[_top]}) ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Laboratório de Pilha Estática Genérica ---");
            Console.ResetColor();

            Console.Write("Primeiro, defina o tamanho máximo da sua pilha: ");
            if (!int.TryParse(Console.ReadLine(), out int tamanho) || tamanho <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tamanho inválido. O programa será encerrado.");
                return;
            }

            StaticStack<int> minhaPilha = new StaticStack<int>(tamanho);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Pilha estática com capacidade para {tamanho} inteiros foi criada!");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para ir ao menu...");
            Console.ReadKey();

            while (true)
            {
                ExibirMenu(minhaPilha);
                string escolha = Console.ReadLine();

                try
                {
                    switch (escolha)
                    {
                        case "1":
                            Console.Write("Digite o número para adicionar (Push): ");
                            int valorParaAdicionar = int.Parse(Console.ReadLine());
                            minhaPilha.Push(valorParaAdicionar);
                            break;
                        case "2":
                            minhaPilha.Pop();
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Elemento no topo (Peek): {minhaPilha.Peek()}");
                            break;
                        case "4":
                            minhaPilha.Clear();
                            break;
                        case "0":
                            Console.WriteLine("Saindo...");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERRO: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nERRO: Entrada inválida. Por favor, digite um número.");
                }

                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        } 

        static void ExibirMenu(StaticStack<int> pilha)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Menu de Operações da Pilha Estática ---");
            Console.ResetColor();

            pilha.PrintStack();
            Console.WriteLine($"Capacidade Máxima: {pilha.Count}/{pilha.GetType().GetField("_maxSize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(pilha)}");
            Console.WriteLine($"Está Vazia? {pilha.IsEmpty()} | Está Cheia? {pilha.IsFull()}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1. Adicionar (Push)");
            Console.WriteLine("2. Remover (Pop)");
            Console.WriteLine("3. Ver Topo (Peek)");
            Console.WriteLine("4. Limpar Pilha (Clear)");
            Console.WriteLine("0. Sair");
            Console.Write("\nSua escolha: ");
        }
    }
}
