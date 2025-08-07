# 💰 Sistema Bancário em Blazor Server

Este é um sistema bancário desenvolvido com **Blazor Server** em C#, que permite simular operações como:

- Cadastro de clientes
- Login de clientes
- Depósitos
- Saques
- Transferências
- Solicitação de empréstimos
- Visualização de extratos

Todas as informações são persistidas localmente em arquivos `.json`, simulando um banco de dados.

---

## 🚀 Como executar o projeto

### Pré-requisitos

Certifique-se de ter instalado em sua máquina:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) **ou** outro editor compatível com C# e Blazor
- Git (opcional, para clonar o projeto)

---

### Passo a passo

1. **Clone o repositório** (ou baixe como zip):
   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   cd nome-do-repositorio
   ```

2. **Abra o projeto no Visual Studio ou VS Code.**

3. **Restaure os pacotes e compile o projeto:**
   ```bash
   dotnet restore
   dotnet build
   ```

4. **Execute o projeto:**
   ```bash
   dotnet run
   ```

   Ou simplesmente pressione `F5` no Visual Studio.

5. **Acesse no navegador:**
   ```
   https://localhost:5001
   ```

---

## 📁 Estrutura de Pastas

```bash
Banco/
│
├── Models/
│   └── Entities/         # Entidades principais: Cliente, Conta, Extrato, Empréstimo
│
├── Services/             # Regras de negócio
│
├── Infrastructure/       
│   └── JsonRepositories/ # Persistência via arquivos JSON
│
├── Pages/                # Páginas Razor (.razor) do Blazor Server
│
├── wwwroot/              # CSS, JS e outros arquivos estáticos
│
├── appsettings.json      # Configurações do projeto
```

---

## 📦 Funcionalidades

| Funcionalidade       | Descrição                                                                 |
|----------------------|---------------------------------------------------------------------------|
| Cadastro             | Permite criar novos clientes com CPF e senha                              |
| Login                | Acesso à conta bancária por CPF e senha                                   |
| Depósito             | Depósito em conta do cliente                                              |
| Saque                | Saque em conta, com verificação de saldo                                  |
| Transferência        | Transferência entre contas de clientes diferentes                         |
| Solicitação de Empréstimo | Registra um pedido de empréstimo para análise (sem aprovação automática) |
| Extratos             | Lista os lançamentos da conta do cliente                                  |

---

## 🧪 Tecnologias Utilizadas

- C# 12 / .NET 8
- Blazor Server
- Bootstrap (interface)
- Persistência em JSON
- Programação orientada a objetos

---

## 📝 Observações

- Os dados são armazenados em arquivos `.json`. Eles são recriados automaticamente caso não existam.
- Este projeto não possui autenticação robusta (apenas CPF e senha).
- Ideal para fins **educacionais** ou como base para sistemas mais complexos.
