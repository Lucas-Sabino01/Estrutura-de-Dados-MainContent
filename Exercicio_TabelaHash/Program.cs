using System;
using System.Collections.Generic;

namespace Exercicio_TabelaHash
{
    class Program
    {
        static Dictionary<int, string> funcionarios = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            // Pré-carregando alguns dados para o sistema não começar vazio
            funcionarios.Add(101, "Alice Silva");
            funcionarios.Add(102, "Bruno Costa");
            funcionarios.Add(103, "Carla Dias");

            while (true)
            {
                ExibirMenu();
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        ListarFuncionarios();
                        break;
                    case "2":
                        AdicionarFuncionario();
                        break;
                    case "3":
                        BuscarFuncionario();
                        break;
                    case "4":
                        AtualizarFuncionario();
                        break;
                    case "5":
                        RemoverFuncionario();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do sistema...");
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
            Console.WriteLine("--- Sistema de Gerenciamento de Funcionários (Tabela Hash) ---");
            Console.ResetColor();
            Console.WriteLine($"Total de funcionários: {funcionarios.Count}");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1 - Listar todos os funcionários");
            Console.WriteLine("2 - Adicionar novo funcionário");
            Console.WriteLine("3 - Buscar funcionário por ID");
            Console.WriteLine("4 - Atualizar nome de funcionário");
            Console.WriteLine("5 - Remover funcionário");
            Console.WriteLine("0 - Sair");
            Console.Write("\nSua escolha: ");
        }

        static void ListarFuncionarios()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Lista de Funcionários ---");
            if (funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }
            foreach (KeyValuePair<int, string> funcionario in funcionarios)
            {
                Console.WriteLine($"ID: {funcionario.Key}, Nome: {funcionario.Value}");
            }
        }

        static void AdicionarFuncionario()
        {
            Console.Write("\nDigite o ID do novo funcionário: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // VERIFICAÇÃO CRUCIAL: A chave já existe?
                if (funcionarios.ContainsKey(id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erro: O ID {id} já está em uso.");
                }
                else
                {
                    Console.Write("Digite o nome do funcionário: ");
                    string nome = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nome))
                    {
                        funcionarios.Add(id, nome);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Funcionário adicionado com sucesso!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O nome não pode ser vazio.");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID inválido. Por favor, digite um número.");
            }
        }

        static void BuscarFuncionario()
        {
            Console.Write("\nDigite o ID do funcionário a ser buscado: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // MODO SEGURO: Usando TryGetValue para evitar exceções
                if (funcionarios.TryGetValue(id, out string nome))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nFuncionário encontrado -> ID: {id}, Nome: {nome}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nFuncionário com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID inválido. Por favor, digite um número.");
            }
        }

        static void AtualizarFuncionario()
        {
            Console.Write("\nDigite o ID do funcionário a ser atualizado: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (funcionarios.ContainsKey(id))
                {
                    Console.Write($"Digite o novo nome para o funcionário com ID {id}: ");
                    string novoNome = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoNome))
                    {
                        funcionarios[id] = novoNome;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nome do funcionário atualizado com sucesso!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O novo nome não pode ser vazio.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Funcionário com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID inválido. Por favor, digite um número.");
            }
        }

        static void RemoverFuncionario()
        {
            Console.Write("\nDigite o ID do funcionário a ser removido: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (funcionarios.Remove(id))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Funcionário com ID {id} removido com sucesso.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Funcionário com ID {id} não encontrado.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID inválido. Por favor, digite um número.");
            }
        }
    }
}