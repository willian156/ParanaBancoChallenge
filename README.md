
# Projeto de Microsserviços para o Paraná Banco

Este projeto foi desenvolvido com o intuito de demonstrar habilidades como desenvolvedor pleno, em uma proposta de colaboração com o **Paraná Banco**.

O sistema permite o **cadastro de clientes** e a **geração de propostas de crédito e cartões bancários**, com base em regras automatizadas aplicadas a partir das informações cadastradas.

## 🧩 Arquitetura do Sistema

O sistema é composto por **três microsserviços independentes**, cada um com responsabilidades específicas:

- **Consumer.API**  
  Responsável pelo cadastro de clientes no sistema.

- **Credit.API**  
  Responsável pela geração automática de propostas de crédito com base nos dados dos clientes, além de permitir a consulta dessas propostas.

- **Card.API**  
  Gera a elegibilidade e tipo de cartão bancário disponível com base na proposta de crédito. Também permite a consulta dessa informação.

---

## 🔁 Fluxo de Dados

### 1. Cadastro de Cliente e Geração de Propostas e Cartões

```
Consumer.API (Cadastro de Cliente)
        ↓
     SQL Server
        ↓
 Publicação no RabbitMQ
        ↓
Credit.API (Geração de Proposta de Crédito)
        ↓
     SQL Server
        ↓
 Publicação no RabbitMQ
        ↓
Card.API (Geração de Cartão com base na Proposta)
        ↓
     SQL Server
```

---

### 2. Consulta de Proposta de Crédito

```
Request → Credit.API → SQL Server → Retorno da Proposta
```

---

### 3. Consulta de Cartões de Crédito

```
Request → Card.API → SQL Server → Retorno dos Cartões Disponíveis
```

---

## ⚙️ Atualização e Criação do Banco de Dados

Caso queira rodar o sistema localmente, utilize os seguintes comandos para atualizar ou criar os bancos de dados de cada serviço:

### 🔹 Consumer.API

```bash
dotnet ef migrations add InitialMigration --project ./Customer.Infrastructure/Customer.Infrastructure.csproj --startup-project ./Customer.API/Customer.API.csproj
dotnet ef database update --project ./Customer.Infrastructure/Customer.Infrastructure.csproj --startup-project ./Customer.API/Customer.API.csproj
```

### 🔹 Credit.API

```bash
dotnet ef migrations add InitialMigration --project ./Credit.Infrastructure/Credit.Infrastructure.csproj --startup-project ./Credit.API/Credit.API.csproj
dotnet ef database update --project ./Credit.Infrastructure/Credit.Infrastructure.csproj --startup-project ./Credit.API/Credit.API.csproj
```

### 🔹 Card.API

```bash
dotnet ef migrations add InitialMigration --project ./Card.Infrastructure/Card.Infrastructure.csproj --startup-project ./Card.API/Card.API.csproj
dotnet ef database update --project ./Card.Infrastructure/Card.Infrastructure.csproj --startup-project ./Card.API/Card.API.csproj
```

---

## 📦 Tecnologias Utilizadas

- .NET 8
- RabbitMQ
- SQL Server
- Entity Framework Core
- Arquitetura baseada em microsserviços

---

## 📫 Contato

Caso tenha interesse em saber mais sobre este projeto ou entrar em contato:

**Willian Beck Ribeiro**  
Desenvolvedor Full Stack  
[LinkedIn](https://www.linkedin.com/in/willianbeckribeiro/) • [GitHub](https://github.com/seuusuario)
