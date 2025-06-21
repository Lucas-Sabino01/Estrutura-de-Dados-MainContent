# Sistema de Gerenciamento de Pacientes com Tabela Hash

Este repositório contém a implementação de um sistema de console em C# que simula o cadastro, triagem e gerenciamento de pacientes em uma clínica. O projeto foi desenvolvido para demonstrar a aplicação prática e a implementação manual de uma Tabela Hash.

## 📜 Descrição do projeto

O objetivo principal deste projeto é demonstrar a construção e o uso de uma **Tabela Hash implementada do zero**, utilizando a técnica de **encadeamento separado (separate chaining)** com `LinkedList` para tratar colisões. A estrutura não utiliza a classe `Dictionary<TKey, TValue>` nativa do .NET, focando no entendimento da lógica interna do algoritmo.

O sistema simula um ambiente de clínica onde pacientes são cadastrados usando o **CPF como chave única**. Além do cadastro, a aplicação inclui uma lógica de negócio para realizar uma triagem automática, classificando a prioridade de atendimento de cada paciente com base em seus sinais vitais.

### ✨ Funcionalidades Principais

- **Implementação Manual da Tabela Hash:** O coração do projeto é uma classe `TabelaHash` construída do zero, com uma função de hash própria e um array de `LinkedList` para armazenar os dados e resolver colisões.
- **Cadastro de Pacientes (CRUD):** O menu permite realizar as operações essenciais de um cadastro:
    - **Inserir (Create):** Adiciona novos pacientes, validando se o CPF já existe.
    - **Buscar (Read):** Utiliza a função de hash para localizar um paciente pelo CPF de forma eficiente.
    - **Atualizar (Update):** Permite a modificação dos sinais vitais de um paciente existente.
    - **Remover (Delete):** Exclui o registro de um paciente da tabela.
- **Lógica de Triagem por Prioridade:** A classe `Paciente` possui uma propriedade calculada (`Prioridade`) que classifica o paciente em uma de três categorias de risco, com base na pressão arterial, temperatura e nível de oxigenação:
    - 🟥 **VERMELHO (Emergência):** Casos mais graves.
    - 🟨 **AMARELO (Urgência):** Casos de atenção.
    - 🟩 **VERDE (Não Urgente):** Casos de menor risco.
- **Visualização da Estrutura Interna:** Uma funcionalidade essencial que exibe o estado atual da Tabela Hash, mostrando os "buckets" e as listas encadeadas, permitindo visualizar como as colisões estão sendo tratadas.

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (recomenda-se .NET 6.0 ou superior)
- Um ambiente de desenvolvimento C#, como o [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).

### Passo a Passo
1.  **Clone o repositório** para sua máquina local usando o seguinte comando:
    ```bash
    git clone [https://github.com/SEU-USUARIO/SEU-REPOSITORIO-CLINICA.git](https://github.com/SEU-USUARIO/SEU-REPOSITORIO-CLINICA.git)
    ```
    *(Substitua `SEU-USUARIO` e `SEU-REPOSITORIO-CLINICA` pelos dados corretos)*

2.  **Abra a Solução** no Visual Studio clicando duas vezes no arquivo `.sln`.

3.  **Execute o projeto** pressionando `F5` ou o botão de "Play".

4.  O menu interativo da clínica aparecerá no console, pronto para uso.

## 🕹️ Estrutura do Menu e Comandos

- **[1] Inserir Paciente:** Solicita todos os dados do paciente (CPF, nome, sinais vitais) para realizar o cadastro.
- **[2] Buscar Paciente:** Pede um CPF e, se encontrado, exibe todos os dados do paciente, incluindo a sua prioridade de atendimento calculada.
- **[3] Atualizar Dados:** Pede um CPF e permite que o usuário insira novos valores para os sinais vitais do paciente.
- **[4] Remover Paciente:** Pede um CPF para remover o registro completo do paciente.
- **[5] Exibir Tabela Hash:** Mostra a organização interna da Tabela Hash, listando o conteúdo de cada "bucket".
- **[0] Sair:** Encerra a aplicação.

---
*Desenvolvido por: Lucas Sabino*