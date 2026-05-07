# NFL API

Uma API RESTful para gerenciar times de futebol americano (NFL), desenvolvida com ASP.NET Core.

## 📋 Descrição

Este projeto é uma aplicação de estudos que implementa um CRUD completo de times de futebol americano. A API permite criar, ler, atualizar e deletar informações sobre os times, incluindo dados como nome, cidade, Super Bowls ganhos e jogos realizados fora dos EUA.

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core 7.0** - ORM para acesso a dados
- **SQLite** - Banco de dados
- **Swagger/Swashbuckle** - Documentação interativa da API

## 📦 Pré-requisitos

- .NET 8.0 ou superior
- Visual Studio, Visual Studio Code ou outro editor C#

## 🚀 Como Executar

1. Clone o repositório:
```bash
git clone <url-do-repositorio>
cd USFootball
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Execute as migrations (se necessário):
```bash
dotnet ef database update
```

4. Inicie a aplicação:
```bash
dotnet run
```

A API estará disponível em `https://localhost:5059` (ou a porta configurada).

## 📚 Endpoints da API

### GET /teams
Retorna todos os times cadastrados.

**Resposta:**
```json
[
  {
    "id": 1,
    "nome": "Dallas Cowboys",
    "cidade": "Dallas",
    "superBowlsGanhos": 5,
    "jogosForaDoPais": 2
  }
]
```

### GET /teams/{id}
Retorna um time específico pelo ID.

**Exemplo:**
```
GET /teams/1
```

**Resposta (sucesso):**
```json
{
  "id": 1,
  "nome": "Dallas Cowboys",
  "cidade": "Dallas",
  "superBowlsGanhos": 5,
  "jogosForaDoPais": 2
}
```

### POST /teams
Cria um novo time.

**Corpo da Requisição:**
```json
{
  "nome": "New England Patriots",
  "cidade": "Boston",
  "superBowlsGanhos": 6,
  "jogosForaDoPais": 1
}
```

**Resposta (201 Created):**
```json
{
  "id": 2,
  "nome": "New England Patriots",
  "cidade": "Boston",
  "superBowlsGanhos": 6,
  "jogosForaDoPais": 1
}
```

### PUT /teams/{id}
Atualiza todos os campos de um time (requer todos os campos).

**Exemplo:**
```
PUT /teams/1
```

**Corpo da Requisição:**
```json
{
  "nome": "Dallas Cowboys",
  "cidade": "Arlington",
  "superBowlsGanhos": 5,
  "jogosForaDoPais": 3
}
```

### PATCH /teams/{id}
Atualiza parcialmente um time (apenas os campos fornecidos).

**Exemplo:**
```
PATCH /teams/1
```

**Corpo da Requisição:**
```json
{
  "cidade": "Arlington"
}
```

### DELETE /teams/{id}
Deleta um time.

**Exemplo:**
```
DELETE /teams/1
```

**Resposta:** 204 No Content

## 📖 Swagger/OpenAPI

Quando a aplicação está rodando em desenvolvimento, acesse a documentação interativa:

```
https://localhost:5059/swagger
```

## 🗄️ Estrutura do Banco de Dados

### Tabela: Teams
| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | int | Identificador único (chave primária) |
| Nome | string | Nome do time |
| Cidade | string | Cidade onde o time está sediado |
| SuperBowlsGanhos | int | Quantidade de Super Bowls vencidos |
| JogosForaDoPais | int | Quantidade de jogos realizados fora dos EUA |

## 📝 Modelo de Dados

```csharp
public class Team
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cidade { get; set; }
    public int SuperBowlsGanhos { get; set; }
    public int JogosForaDoPais { get; set; }
}
```

## 🔗 Banco de Dados

O banco de dados SQLite é armazenado em `teams.db` na raiz do projeto. Este arquivo é gerado automaticamente na primeira execução.

## 👨‍💻 Desenvolvimento

Este é um projeto de estudos para praticar:
- ASP.NET Core Minimal APIs
- Entity Framework Core
- Operações CRUD completas (GET, POST, PUT, PATCH, DELETE)
- Banco de dados SQLite

## 📄 Licença

Este projeto é fornecido como é, para fins educacionais.
