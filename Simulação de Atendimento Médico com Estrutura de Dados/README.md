# Simulação de Atendimento Médico com Estruturas de Dados

Este repositório contém a implementação de um sistema de console em C# que simula o fluxo de triagem e atendimento de pacientes em uma unidade de saúde. O projeto foi desenvolvido para aplicar conceitos fundamentais de estruturas de dados na resolução de um problema prático.

## 📜 Sobre o Projeto

O objetivo principal é demonstrar como diferentes estruturas de dados podem ser combinadas para gerenciar um fluxo de trabalho complexo. A simulação gerencia a chegada de pacientes, a coleta de sinais vitais, a classificação de risco e a visualização do histórico de atendimentos.

A arquitetura do sistema utiliza `Queue<T>` para a fila de chegada (garantindo o atendimento na ordem correta - FIFO) e `Stack<T>` para o histórico dos pacientes já triados.

### ✨ Funcionalidades Principais

- **Fluxo de Atendimento FIFO:** Utiliza uma **Fila (`Queue<T>`)** para gerenciar os pacientes que chegam, garantindo que o primeiro a chegar seja o primeiro a passar pela triagem.
- **Triagem com Lógica de Negócio:** Após a chegada, o sistema coleta os sinais vitais do paciente (pressão arterial, temperatura, nível de oxigenação).
- **Cálculo de Prioridade de Atendimento:** Com base nos sinais vitais, o sistema classifica cada paciente em uma de três categorias de prioridade, seguindo um critério de risco:
    - 🟥 **VERMELHO (Emergência):** Casos mais graves.
    - 🟨 **AMARELO (Urgência):** Casos de atenção.
    - 🟩 **VERDE (Não Urgente):** Casos de menor risco.
- **Histórico de Pacientes Atendidos:** Utiliza uma **Pilha (`Stack<T>`)** para armazenar os registros dos pacientes que já passaram pela triagem.
- **Visualização por Ordem de Prioridade:** Uma funcionalidade avançada que permite visualizar a lista de pacientes atendidos, **ordenada pelo nível de prioridade**, demonstrando o uso de algoritmos de ordenação (`List.Sort`) em conjunto com as estruturas de dados.

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- Um ambiente de desenvolvimento C#, como o [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).

### Passo a Passo
1.  Clone este repositório para sua máquina local.
2.  Abra o arquivo de Solução (`.sln`) ou o projeto (`.csproj`) no Visual Studio.
3.  Pressione `F5` ou o botão de "Play" para compilar e executar o programa.
4.  O menu interativo da clínica aparecerá no console.

## 🕹️ Estrutura do Menu e Comandos

- **[1] Chegada de paciente:** Inicia o processo de registro de um novo paciente na fila de triagem.
- **[2] Ver pacientes atendidos:** Exibe o histórico de todos os pacientes que já passaram pela triagem, em ordem cronológica inversa (último atendido aparece primeiro).
- **[3] Ver a prioridade na clinica:** Exibe o histórico de pacientes atendidos, mas **ordenado por nível de prioridade** (Vermelho > Amarelo > Verde).
- **[4] Limpar Terminal:** Limpa a tela do console.
- **[0] Sair:** Encerra a aplicação.

---
*Desenvolvido por: Lucas Sabino*