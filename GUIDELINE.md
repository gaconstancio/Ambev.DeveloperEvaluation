
# Copilot Development Guideline

This GUIDELINE.md file serves as a reference for GitHub Copilot to provide consistent, accurate, and context-aware suggestions throughout the development of the Developer Evaluation Project. It includes architectural patterns, naming conventions, business rules, tech stack, and API expectations.

## Project Purpose

Build a fully functional CRUD API in .NET 8.0 to manage sales records, implementing:
- Domain-Driven Design (DDD) principles
- Clean architecture and separation of concerns
- External Identities pattern with denormalized descriptions

Entities must include:
- Sale Number
- Sale Date
- Customer Info
- Branch
- Product(s)
- Quantity
- Unit Price
- Discount
- Item Total
- Sale Status (Cancelled / Not Cancelled)

## Business Rules (Sales)

Apply the following discount rules based on quantity per product:

Quantity Range: Discount
1 - 3 items: No discount
4 - 9 items: 10 percent discount
10 - 20 items: 20 percent discount
Above 20 items: Not allowed

Optional event logging for:
- SaleCreated
- SaleModified
- SaleCancelled
- ItemCancelled

These events should be logged, not published to a message broker.

## Project Structure

root/
├── src/           # Application code (Domain, Application, API)
├── tests/         # Unit tests using xUnit
└── README.md      # Setup & instructions

## Tech Stack

Backend
- .NET 8.0
- C#

Libraries / Frameworks
- MediatR – Mediator pattern implementation
- AutoMapper – Object-to-object mapper
- Entity Framework Core – ORM for PostgreSQL and MongoDB
- Rebus – Messaging abstraction (used only for simulating/logging events)

Testing
- xUnit – Unit test framework
- NSubstitute – Mocking
- Bogus – Fake data generation

## Architecture & Patterns

- Follow Domain-Driven Design (DDD)
  - Use External Identities to refer to external domain entities
  - Store denormalized descriptive data
- Apply Clean Architecture:
  - Domain Layer (core business logic)
  - Application Layer (use cases)
  - Infrastructure Layer (data persistence)
  - API Layer (controllers & endpoints)
- Favor Dependency Injection and asynchronous programming

## API Guidelines

Pagination
GET /products?_page=1&_size=20

Sorting
GET /products?_order="price desc, title asc"

Filtering
- By exact value: ?category=men's clothing
- By partial match: ?title=Fjallraven*
- By range: ?_minPrice=50&_maxPrice=200
- Combine filters using &

Error Handling (Standard Format)
{
  "type": "ValidationError",
  "error": "Invalid input data",
  "detail": "The 'price' field must be a positive number"
}

HTTP Status Codes
- 2xx: Success
- 4xx: Client error
- 5xx: Server error

## Testing Guidelines

- Use xUnit for all unit tests
- Mock dependencies with NSubstitute
- Generate data using Bogus
- Focus on isolated tests and business rule validation
- Favor testing edge cases and negative scenarios

## Code Practices & Commit Flow

- Follow Semantic Commit Messages (feat:, fix:, test:, refactor:, etc.)
- Prefer Git Flow branching model
- Keep code clean and well-documented
- Use ILogger for diagnostics and event simulation
- Prioritize performance in queries and responses

## Completion Checklist for Copilot

- All sales rules applied
- Clean architecture enforced
- Event logs implemented
- Controllers follow RESTful pattern
- DTOs mapped with AutoMapper
- API handles pagination, filters, sorting
- Consistent and structured error responses
- Unit tests cover all use cases
- Code is readable, reusable, and testable

Note: This guideline was created to enhance GitHub Copilot’s assistance by aligning its suggestions with the expectations, rules, and architecture of the Developer Evaluation Project.
