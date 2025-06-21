# Menu Interativo de Estruturas de Dados em C#

## 📜 Descrição do projeto

Este repositório contém a implementação de um sistema de console em C# que serve como um **laboratório interativo** para o estudo e demonstração de diversas estruturas de dados e algoritmos fundamentais da engenharia de software.

O objetivo principal é fornecer uma ferramenta didática onde o usuário pode escolher uma estrutura (Vetor, Matriz, Lista, Fila, Pilha) ou um tipo de algoritmo (Busca) e executar operações em tempo real, visualizando os resultados diretamente no terminal.

A aplicação foi construída com foco em boas práticas de programação, como a **separação de responsabilidades** (utilizando um "Manager Pattern"), **tratamento de entradas inválidas** e uma arquitetura de menus modularizada para facilitar a manutenção e leitura do código.

## ⚙️ Pré-requisitos de execução

Para compilar e executar este projeto, você precisará de:
* [.NET SDK](https://dotnet.microsoft.com/download) (recomenda-se .NET 6.0 ou superior)
* Um ambiente de desenvolvimento C#, como o [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).

## 🚀 Como rodar o sistema (passo a passo)

1.  **Clone o repositório** para sua máquina local usando o seguinte comando:
    ```bash
    git clone [https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git](https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git)
    ```
    *(Substitua `SEU-USUARIO` e `SEU-REPOSITORIO` pelos seus dados)*

2.  **Abra a Solução** no Visual Studio clicando duas vezes no arquivo `MenuEstruturasDeDados.sln`.

3.  **Execute o projeto** pressionando `F5` ou clicando no botão de "Play" (com o nome do projeto) na barra de ferramentas superior.

4.  O menu principal aparecerá no console. A partir daí, basta seguir as instruções na tela.

## 🧭 Estrutura do menu e comandos disponíveis

A aplicação funciona com um sistema de menus aninhados. O menu principal permite escolher a estrutura de dados, e cada uma delas possui um submenu com operações específicas.

* **Menu Principal:**
    * `[1] Vetores (Lista Estática)`
    * `[2] Matrizes`
    * `[3] Listas Dinâmicas (List<T>)`
    * `[4] Filas Dinâmicas (Queue<T>)`
    * `[5] Pilhas Dinâmicas (Stack<T>)`
    * `[6] Algoritmos de Pesquisa`
    * `[0] Encerrar Programa`

* **Submenus (Comandos comuns):**
    * **Inserir / Adicionar:** Adiciona um novo elemento à estrutura.
    * **Remover:** Exclui um elemento (por valor ou por índice).
    * **Exibir:** Mostra todos os elementos contidos na estrutura.
    * **Buscar / Consultar:** Verifica se um elemento existe na estrutura.
    * **Voltar ao Menu Principal:** Encerra o submenu e retorna à tela inicial.

## 💡 Exemplos de uso

Abaixo estão alguns exemplos de como interagir com o sistema.

### Exemplo 1: Adicionando e Removendo de um Vetor

1.  No menu principal, escolha a opção `[1]` para Vetores.
2.  No submenu de Vetores, escolha `[1]` para Inserir.
3.  Digite um número (ex: `42`) e pressione Enter.
4.  O menu será atualizado, mostrando `[ 42 ]`.
5.  Escolha a opção `[2]` para Remover.
6.  Digite o número `42` e pressione Enter.
7.  O menu será atualizado, mostrando o vetor vazio novamente.

**Simulação no Console:**
```
--- Gerenciador de Vetor (Lista Estática) ---
Estado do Vetor: [ Vazio ]
-------------------------------------------
[1] Inserir Elemento
...
Escolha uma opção: 1

Digite o número para inserir: 42

Número inserido com sucesso!
Pressione qualquer tecla para continuar...
```

### Exemplo 2: Comparando Algoritmos de Busca

1.  No menu principal, escolha a opção `[6]` para Algoritmos de Pesquisa.
2.  Um array aleatório é exibido.
3.  Escolha `[1]` para executar a Busca Linear.
4.  Digite um número presente no array. O sistema mostrará a posição e o **número de comparações**.
5.  Escolha `[2]` para executar a Busca Binária.
6.  Digite o mesmo número. O sistema mostrará o resultado com um **número muito menor de comparações**, demonstrando a eficiência do algoritmo.

**Simulação no Console:**
```
--- Laboratório de Algoritmos de Busca ---
Array Atual: 23, 8, 99, 45, 12, 5, 67, ...
----------------------------------------
[1] Executar Busca Linear
...
Escolha uma opção: 1

Digite o valor para a Busca Linear: 67

Valor 67 encontrado na posição 6.
Comparações realizadas: 7
```

---
*Desenvolvido por: Lucas Sabino*
