# Ambev Developer Evaluation

Avaliação técnica para vaga de desenvolvedor .NET utilizando Clean Architecture, MediatR, Entity Framework Core e testes automatizados.

---

## ✅ Funcionalidades

- Autenticação de usuários
- CRUD de usuários
- CRUD de vendas
- Regras de desconto por quantidade:
  - 4–9 itens: 10%
  - 10–20 itens: 20%
  - >20 itens: inválido
- Listagem com filtros, paginação e ordenação
- Tratamento de erros padronizado
- Testes unitários com xUnit, NSubstitute e Bogus
- Logs simulando eventos de domínio (`SaleCreated`, etc.)

---

## 🚀 Como rodar localmente

### Pré-requisitos
- .NET 8 SDK
- Docker e Docker Compose

### Setup via Docker
```bash
docker-compose up --build
```

### Setup manual
```bash
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet run
```

A API estará disponível em: `https://localhost:5001` ou `http://localhost:5000`

---

## 🔍 Endpoints principais

### Autenticação
- `POST /api/auth` → login

### Usuários
- `POST /api/users`
- `GET /api/users/{id}`
- `DELETE /api/users/{id}`

### Vendas
- `GET /api/sales?_page=1&_size=10&_order=saleDate desc`
- `GET /api/sales/{id}`
- `POST /api/sales`
- `PUT /api/sales/{id}`
- `DELETE /api/sales/{id}`

---

## ✅ Rodando os testes

```bash
cd tests/Ambev.DeveloperEvaluation.Unit
dotnet test
```

---

## 🛠️ Tecnologias utilizadas

- .NET 8.0
- MediatR
- AutoMapper
- Entity Framework Core
- FluentValidation
- xUnit + NSubstitute + Bogus
- PostgreSQL
- Docker

---

## 📁 Estrutura de projeto

```text
src/
├── Domain
├── Application
├── Infrastructure
├── ORM
├── WebApi
└── IoC

tests/
├── Unit
├── Integration
└── Functional
```

---

## 📦 Observações

- Todos os handlers são testáveis via `IMediator`
- Regras de negócio são validadas no domínio
- Testes cobrem casos de sucesso e falha
- Paginação, ordenação e filtro conforme padrão REST

---

## 🤝 Agradecimentos

Projeto entregue com atenção aos requisitos técnicos, boas práticas de arquitetura e testes. Disponível para eventuais esclarecimentos!