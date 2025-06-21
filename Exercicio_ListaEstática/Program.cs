using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_ListaEstática
{
    public class StaticList<T>
    {
        private T[] _elements;
        private int _count;
        private int _capacity;

        public StaticList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "A capacidade da lista deve ser maior que zero.");
            }
            _capacity = capacity;
            _elements = new T[_capacity];
            _count = 0;
        }

        public void Add(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("A lista está cheia. Não é possível adicionar mais elementos.");
            }
            _elements[_count] = item;
            _count++;
            Console.WriteLine($"Adicionado: {item}. Total de elementos: {Count}.");
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Índice fora dos limites da lista.");
            }
            return _elements[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Índice fora dos limites da lista.");
            }

            T removedItem = _elements[index];

            for (int i = index; i < _count - 1; i++)
            {
                _elements[i] = _elements[i + 1];
            }
            _elements[_count - 1] = default(T);
            _count--;
            Console.WriteLine($"Removido item na posição {index}: {removedItem}. Total de elementos: {Count}.");
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _capacity;
        }

        public int Count
        {
            get { return _count; }
        }

        public int Capacity
        {
            get { return _capacity; }
        }

        public void Clear()
        {
            _count = 0;
            _elements = new T[_capacity];
            Console.WriteLine("Lista limpa.");
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Lista: [Vazia]");
                return;
            }
            Console.Write("Lista: [");
            for (int i = 0; i < _count; i++)
            {
                Console.Write(_elements[i]);
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
            Console.WriteLine("--- Laboratório de Lista Estática (Lista de Tarefas) ---");
            Console.ResetColor();

            Console.Write("Defina o número máximo de tarefas na sua lista: ");
            if (!int.TryParse(Console.ReadLine(), out int capacidade) || capacidade <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Capacidade inválida. O programa será encerrado.");
                return;
            }

            StaticList<string> listaDeTarefas = new StaticList<string>(capacidade);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Lista de tarefas com capacidade para {capacidade} itens criada!");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para ir ao menu...");
            Console.ReadKey();

            while (true)
            {
                ExibirMenu(listaDeTarefas);
                string escolha = Console.ReadLine();

                try
                {
                    switch (escolha)
                    {
                        case "1":
                            AdicionarTarefa(listaDeTarefas);
                            break;
                        case "2":
                            ConcluirTarefa(listaDeTarefas);
                            break;
                        case "3":
                            VerTarefaEspecifica(listaDeTarefas);
                            break;
                        case "0":
                            Console.WriteLine("Saindo do gerenciador de tarefas...");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentOutOfRangeException || ex is FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERRO: {ex.Message}");
                }

                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ExibirMenu(StaticList<string> lista)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Gerenciador de Tarefas ---");
            Console.ResetColor();

            lista.PrintList();
            Console.WriteLine($"Capacidade: {lista.Count}/{lista.Capacity} | Vazia? {lista.IsEmpty()} | Cheia? {lista.IsFull()}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1. Adicionar nova tarefa");
            Console.WriteLine("2. Concluir uma tarefa (Remover por número)");
            Console.WriteLine("3. Ver uma tarefa específica (Acessar por número)");
            Console.WriteLine("0. Sair");
            Console.Write("\nSua escolha: ");
        }

        static void AdicionarTarefa(StaticList<string> lista)
        {
            Console.Write("\nDigite a descrição da nova tarefa: ");
            string tarefa = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tarefa))
            {
                lista.Add(tarefa);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tarefa adicionada!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A descrição da tarefa não pode ser vazia.");
            }
        }

        static void ConcluirTarefa(StaticList<string> lista)
        {
            Console.Write("\nDigite o NÚMERO da tarefa a ser concluída (ex: 1, 2, 3...): ");
            int numeroTarefa = int.Parse(Console.ReadLine());

            int indice = numeroTarefa - 1;

            lista.RemoveAt(indice);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tarefa concluída e removida da lista!");
        }

        static void VerTarefaEspecifica(StaticList<string> lista)
        {
            Console.Write("\nDigite o NÚMERO da tarefa que deseja ver (ex: 1, 2, 3...): ");
            int numeroTarefa = int.Parse(Console.ReadLine());
            int indice = numeroTarefa - 1;

            string tarefa = lista.Get(indice);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nDetalhe da Tarefa {numeroTarefa}: '{tarefa}'");
        }
    }
}
