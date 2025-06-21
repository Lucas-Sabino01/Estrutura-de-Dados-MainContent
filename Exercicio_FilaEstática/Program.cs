using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_FilaEstática
{
    public class StaticQueue<T>
    {
        private T[] _elements;
        private int _front;
        private int _rear;
        private int _count;
        private int _maxSize;

        public StaticQueue(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "O tamanho da fila deve ser maior que zero.");
            }
            _maxSize = size;
            _elements = new T[_maxSize];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("A fila está cheia. Não é possível adicionar mais elementos.");
            }
            _rear = (_rear + 1) % _maxSize;
            _elements[_rear] = item;
            _count++;
            Console.WriteLine($"Adicionado: {item}. Fila agora tem {_count} elementos.");
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("A fila está vazia. Não é possível remover elementos.");
            }
            T item = _elements[_front];
            _front = (_front + 1) % _maxSize;
            _count--;
            Console.WriteLine($"Removido: {item}. Fila agora tem {_count} elementos.");
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("A fila está vazia. Não há elementos para visualizar.");
            }
            return _elements[_front];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _maxSize;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Clear()
        {
            _front = 0;
            _rear = -1;
            _count = 0;
            Console.WriteLine("Fila limpa.");
        }

        public void PrintQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Fila: [Vazia]");
                return;
            }
            Console.Write("Fila: [");
            for (int i = 0; i < _count; i++)
            {
                int index = (_front + i) % _maxSize;
                Console.Write(_elements[index]);
                if (i < _count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Laboratório de Fila Estática Circular ---");
            Console.ResetColor();

            Console.Write("Defina a capacidade máxima da fila de atendimento: ");
            if (!int.TryParse(Console.ReadLine(), out int tamanho) || tamanho <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Capacidade inválida. O programa será encerrado.");
                return;
            }

            StaticQueue<string> filaDeSenhas = new StaticQueue<string>(tamanho);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sistema de senhas com capacidade para {tamanho} clientes foi iniciado!");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para ir ao menu...");
            Console.ReadKey();

            int proximaSenha = 1;

            while (true)
            {
                ExibirMenu(filaDeSenhas);
                string escolha = Console.ReadLine();

                try
                {
                    switch (escolha)
                    {
                        case "1":
                            string novaSenha = $"Senha-{proximaSenha:D3}";
                            filaDeSenhas.Enqueue(novaSenha);
                            proximaSenha++;
                            break;
                        case "2":
                            string senhaChamada = filaDeSenhas.Dequeue();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nCliente da {senhaChamada} chamado para o atendimento!");
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\nPróxima senha a ser chamada: {filaDeSenhas.Peek()}");
                            break;
                        case "4":
                            filaDeSenhas.Clear();
                            break;
                        case "0":
                            Console.WriteLine("Encerrando o sistema de atendimento...");
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

                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ExibirMenu(StaticQueue<string> fila)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Sistema de Senhas de Atendimento ---");
            Console.ResetColor();

            fila.PrintQueue();
            Console.WriteLine($"Capacidade: {fila.Count}/{fila.GetType().GetField("_maxSize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(fila)} | Vazia? {fila.IsEmpty()} | Cheia? {fila.IsFull()}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1. Gerar nova senha e entrar na fila (Enqueue)");
            Console.WriteLine("2. Chamar próximo da fila (Dequeue)");
            Console.WriteLine("3. Ver próximo da fila (Peek)");
            Console.WriteLine("4. Limpar a fila (Clear)");
            Console.WriteLine("0. Sair");
            Console.Write("\nSua escolha: ");
        }
    }
}
