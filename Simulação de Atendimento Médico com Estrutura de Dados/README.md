# Simulação de Atendimento Médico com Estruturas de Dados

## 📜 Descrição do projeto

Este repositório contém a implementação de um sistema de console em C# que simula o fluxo de triagem e atendimento de pacientes em uma unidade de saúde. O projeto foi desenvolvido para aplicar conceitos fundamentais de estruturas de dados e algoritmos na resolução de um problema prático e relevante.

O objetivo é demonstrar como diferentes estruturas de dados podem ser combinadas para gerenciar um fluxo de trabalho complexo. A simulação gerencia a chegada de pacientes, a coleta de sinais vitais, a classificação de risco e a visualização do histórico de atendimentos, culminando em uma listagem ordenada por prioridade.

### ✨ Funcionalidades Principais

A aplicação é construída sobre uma combinação inteligente de estruturas de dados, cada uma com um propósito específico:

- **Fluxo de Atendimento FIFO:** Utiliza uma **Fila (`Queue<T>`)** para gerenciar os pacientes que chegam, garantindo que o primeiro a entrar na clínica seja o primeiro a passar pela triagem.

- **Triagem com Lógica de Negócio:** Após a chegada, o sistema coleta os sinais vitais do paciente (pressão arterial, temperatura, nível de oxigenação). Com base nesses dados, uma lógica de negócio classifica o paciente em uma de três categorias de prioridade:
    - 🟥 **VERMELHO (Emergência):** Casos mais graves que exigem atenção imediata.
    - 🟨 **AMARELO (Urgência):** Casos de atenção que não podem esperar muito.
    - 🟩 **VERDE (Não Urgente):** Casos de menor risco.

- **Histórico de Pacientes Atendidos:** Utiliza uma **Pilha (`Stack<T>`)** para armazenar os registros dos pacientes que já passaram pela triagem. Isso permite uma visualização rápida dos últimos atendimentos (LIFO).

- **Visualização por Ordem de Prioridade:** Uma funcionalidade avançada que converte a pilha de atendidos em uma lista e a **ordena pelo nível de prioridade** (Vermelho > Amarelo > Verde), demonstrando o uso de algoritmos de ordenação (`List.Sort`) com uma lógica de comparação customizada.

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (recomenda-se .NET 6.0 ou superior)
- Um ambiente de desenvolvimento C#, como o [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).

### Passo a Passo
1.  **Clone o repositório** para sua máquina local usando o seguinte comando:
    ```bash
    git clone [https://github.com/Lucas-Sabino01/Estrutura-de-Dados-MainContent/tree/master/Simula%C3%A7%C3%A3o%20de%20Atendimento%20M%C3%A9dico%20com%20Estrutura%20de%20Dados]
    ```

2.  **Abra a Solução** no Visual Studio clicando duas vezes no arquivo `.sln` ou abrindo a pasta do projeto.

3.  **Execute o projeto** pressionando `F5` ou o botão de "Play".

4.  O menu interativo da clínica aparecerá no console.

## 🕹️ Estrutura do Menu e Comandos

- **[1] Chegada de paciente:** Inicia o fluxo de trabalho: registra um novo paciente na fila, coleta seus sinais vitais, determina sua prioridade e o move para o histórico de atendidos.
- **[2] Ver pacientes atendidos:** Exibe o histórico de todos os pacientes que já passaram pela triagem, em ordem cronológica inversa (o último atendido aparece primeiro).
- **[3] Ver a prioriedade na clinica:** Exibe o histórico de pacientes atendidos, mas **ordenado por nível de prioridade**, dos casos mais graves aos mais leves.
- **[4] Limpar Terminal:** Limpa a tela do console para uma melhor visualização.
- **[0] Sair:** Encerra a aplicação.

---
*Desenvolvido por: Lucas Sabino*
