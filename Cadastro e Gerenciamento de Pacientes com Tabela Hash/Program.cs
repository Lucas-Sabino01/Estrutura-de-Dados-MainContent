using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_e_Gerenciamento_de_Pacientes_com_Tabela_Hash
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string PressaoArterial { get; set; }
        public float TemperaturaCorporal { get; set; }
        public int NivelOxigenacao { get; set; }

        public string Prioridade
        {
            get
            {
                int sistolica = 0;
                if (!string.IsNullOrEmpty(PressaoArterial))
                {
                    var partes = PressaoArterial.Split('/');
                    if (int.TryParse(partes[0], out int sist))
                        sistolica = sist;
                }

                if (sistolica > 18 || TemperaturaCorporal > 39 || NivelOxigenacao < 90)
                    return "VERMELHO";
                else if ((sistolica >= 14 && sistolica <= 18) ||
                         (TemperaturaCorporal >= 37.5 && TemperaturaCorporal <= 39) ||
                         (NivelOxigenacao >= 90 && NivelOxigenacao < 95))
                    return "AMARELO";
                else
                    return "VERDE";
            }
        }
    }

    public class TabelaHash
    {
        private readonly int tamanho;
        private LinkedList<KeyValuePair<string, Paciente>>[] buckets;

        public TabelaHash(int tamanho = 10)
        {
            this.tamanho = tamanho;
            buckets = new LinkedList<KeyValuePair<string, Paciente>>[tamanho];
            for (int i = 0; i < tamanho; i++)
                buckets[i] = new LinkedList<KeyValuePair<string, Paciente>>();
        }

        private int Hash(string chave)
        {
            return Math.Abs(chave.GetHashCode()) % tamanho;
        }

        public void Inserir(Paciente paciente)
        {
            int indice = Hash(paciente.CPF);

            foreach (var item in buckets[indice])
                if (item.Key == paciente.CPF)
                {
                    Console.WriteLine("CPF já cadastrado!");
                    return;
                }

            buckets[indice].AddLast(new KeyValuePair<string, Paciente>(paciente.CPF, paciente));
            Console.WriteLine($"Paciente {paciente.Nome} inserido com sucesso.");
        }

        public Paciente Buscar(string cpf)
        {
            int indice = Hash(cpf);
            foreach (var item in buckets[indice])
                if (item.Key == cpf)
                    return item.Value;

            return null;
        }

        public void Atualizar(string cpf)
        {
            Paciente paciente = Buscar(cpf);
            if (paciente == null)
            {
                Console.WriteLine("Paciente não encontrado.");
                return;
            }

            Console.Write("Nova Pressão Arterial: ");
            paciente.PressaoArterial = Console.ReadLine();

            Console.Write("Nova Temperatura: ");
            paciente.TemperaturaCorporal = float.Parse(Console.ReadLine());

            Console.Write("Oxigenação: ");
            if (!int.TryParse(Console.ReadLine(), out int oxi))
            {
                Console.WriteLine("Erro: Nível de oxigenação inválido.");
                return; // Aborta a inserção
            }

            Console.WriteLine("Dados atualizados com sucesso.");
        }

        public void Remover(string cpf)
        {
            int indice = Hash(cpf);
            var bucket = buckets[indice];

            var itemParaRemover = bucket.FirstOrDefault(kvp => kvp.Key == cpf);

            if (!itemParaRemover.Equals(default(KeyValuePair<string, Paciente>)))
            {
                bucket.Remove(itemParaRemover);
                Console.WriteLine("Paciente removido.");
            }
            else
            {
                Console.WriteLine("Paciente não encontrado.");
            }
        }

        public void ExibirTabela()
        {
            for (int i = 0; i < tamanho; i++)
            {
                Console.WriteLine($"Bucket {i}:");

                foreach (var item in buckets[i])
                {
                    var p = item.Value;
                    Console.WriteLine($"  CPF: {p.CPF}, Nome: {p.Nome}, Prioridade: {p.Prioridade}");
                }

                if (buckets[i].Count == 0)
                    Console.WriteLine("  (vazio)");
            }
        }
    }

    class Program
    {
        static TabelaHash tabela = new TabelaHash();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n--- MENU CLÍNICA HASH ---");
                Console.WriteLine("[1] Inserir Paciente");
                Console.WriteLine("[2] Buscar Paciente");
                Console.WriteLine("[3] Atualizar Dados");
                Console.WriteLine("[4] Remover Paciente");
                Console.WriteLine("[5] Exibir Tabela Hash");
                Console.WriteLine("[0] Sair");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        InserirPaciente();
                        break;
                    case "2":
                        BuscarPaciente();
                        break;
                    case "3":
                        AtualizarPaciente();
                        break;
                    case "4":
                        RemoverPaciente();
                        break;
                    case "5":
                        tabela.ExibirTabela();
                        break;
                    case "0":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void InserirPaciente()
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Pressão Arterial: ");
            string pressao = Console.ReadLine();

            Console.Write("Temperatura: ");
            if (!float.TryParse(Console.ReadLine(), out float temp))
            {
                Console.WriteLine("Erro: Temperatura inválida.");
                return; // Aborta a inserção
            }

            Console.Write("Oxigenação: ");
            int oxi = int.Parse(Console.ReadLine());

            Paciente p = new Paciente
            {
                CPF = cpf,
                Nome = nome,
                PressaoArterial = pressao,
                TemperaturaCorporal = temp,
                NivelOxigenacao = oxi
            };

            tabela.Inserir(p);
        }

        static void BuscarPaciente()
        {
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();
            Paciente p = tabela.Buscar(cpf);

            if (p != null)
            {
                Console.WriteLine($"Nome: {p.Nome}");
                Console.WriteLine($"Pressão: {p.PressaoArterial}");
                Console.WriteLine($"Temperatura: {p.TemperaturaCorporal}");
                Console.WriteLine($"Oxigenação: {p.NivelOxigenacao}");
                Console.WriteLine($"Prioridade: {p.Prioridade}");
            }
            else
                Console.WriteLine("Paciente não encontrado.");
        }

        static void AtualizarPaciente()
        {
            Console.Write("Digite o CPF para atualizar: ");
            string cpf = Console.ReadLine();
            tabela.Atualizar(cpf);
        }

        static void RemoverPaciente()
        {
            Console.Write("Digite o CPF para remover: ");
            string cpf = Console.ReadLine();
            tabela.Remover(cpf);
        }
    }
}