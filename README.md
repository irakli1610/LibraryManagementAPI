# 📚 Library Management System API

This is a RESTful API built with ASP.NET Core Web API, Entity Framework Core, and MS SQL Server, designed for managing a library system. It covers CRUD operations, borrowing workflows, and supports clean architecture principles.

---

## 🧾 Overview

This project demonstrates:

- API design using REST principles
- Database interaction via EF Core
- Middleware implementation
- Dependency Injection
- Exception handling
- Logging, validation, and configuration management

---

## 🧱 Domain Models

### 📘 Book

- `Id` (int): Primary key  
- `Title` (string, required): Book title  
- `ISBN` (string, required): International Standard Book Number  
- `PublicationYear` (int): Year the book was published  
- `Description` (string): Book description  
- `CoverImageUrl` (string): URL to book cover image  
- `Quantity` (int): Number of copies available  
- `AuthorId` (int): Foreign key to `Author`

### ✍️ Author

- `Id` (int): Primary key  
- `FirstName` (string, required)  
- `LastName` (string, required)  
- `Biography` (string)  
- `DateOfBirth` (DateTime?)  
- `Books`: ICollection of authored books

### 🔄 BorrowRecord

- `Id` (int): Primary key  
- `BookId` (int): Foreign key to `Book`  
- `PatronId` (int): Foreign key to `Patron`  
- `BorrowDate` (DateTime)  
- `DueDate` (DateTime)  
- `ReturnDate` (DateTime?)  
- `Status` (enum): Borrowed, Returned, Overdue

### 🙋 Patron

- `Id` (int): Primary key  
- `FirstName` (string, required)  
- `LastName` (string, required)  
- `Email` (string, required)  
- `MembershipDate` (DateTime)  
- `BorrowRecords`: ICollection of borrow records

---

## 🔗 API Endpoints

### 📚 Books API

- `GET /api/books`: Get all books (with pagination)  
- `GET /api/books/{id}`: Get book by ID  
- `GET /api/books/search?title={title}&author={author}`: Search books  
- `POST /api/books`: Add a new book  
- `PUT /api/books/{id}`: Update book  
- `DELETE /api/books/{id}`: Delete book  
- `GET /api/books/{id}/availability`: Check availability

### ✍️ Authors API

- `GET /api/authors`: Get all authors (pagination supported)  
- `GET /api/authors/{id}`: Get author by ID  
- `GET /api/authors/{id}/books`: Books by author  
- `POST /api/authors`: Add author  
- `PUT /api/authors/{id}`: Update author  
- `DELETE /api/authors/{id}`: Delete author

### 🙋 Patrons API

- `GET /api/patrons`: Get all patrons (with pagination)  
- `GET /api/patrons/{id}`: Get patron by ID  
- `GET /api/patrons/{id}/books`: Books borrowed by patron  
- `POST /api/patrons`: Add patron  
- `PUT /api/patrons/{id}`: Update patron  
- `DELETE /api/patrons/{id}`: Delete patron

### 🔄 Borrow Records API

- `GET /api/borrow-records`: All borrow records (with filtering)  
- `GET /api/borrow-records/{id}`: Specific borrow record  
- `POST /api/borrow-records`: Create borrow record (checkout)  
- `PUT /api/borrow-records/{id}/return`: Return book  
- `GET /api/borrow-records/overdue`: List overdue records

---

## ⚙️ Technical Overview

### 🧱 Architecture & Design

- Clean Architecture with separation of concerns:
  - API Controllers
  - Services
  - Repositories
  - Data Access Layer
- DTOs with Mapper
- Repository Pattern: `IAuthorRepository`, `IBookRepository`, etc.

### 🔧 ASP.NET Core Features

- **Dependency Injection**
  - Registered in `Program.cs`
  - Constructor injection in services and controllers
- **Custom Middleware**
  - Exception handling
  - Request/response logging
- **Configuration**
  - `appsettings.json` and environment-specific files
- **Validation**
  - FluentValidation

### 🗄 Database

- **Entity Framework Core**
  - Code-first migrations
  - Relationship config via Fluent API
- **Database Seeding**
- **Transactions** for multi-entity updates

### 🔍 API Design

- Follows **REST** principles
- Correct **HTTP status codes**
- **HATEOAS** support (optional)
- **Swagger** documentation with examples
- **Pagination**, **Filtering**, **Sorting**

### ⚠️ Error Handling & Logging

- **Global Exception Middleware**
  - Standardized error responses
- **Logging**
  - Serilog
  - Logs to file/console

---

### 🔄 Functional

1. Full management of books, authors, patrons, and borrow records  
2. Search books by title, author, or ISBN  
3. Track and restrict unavailable books  
4. View overdue borrow records  
5. CRUD for all entities

### 🔧 Technical

1. Correct HTTP status codes  
2. Input validation and user-friendly error messages  
3. Transactions on multi-entity operations  
4. Full use of dependency injection  
5. Clean architecture and separation of concerns  
6. Custom middleware for exceptions  
7. Swagger documentation  
8. Edge case handling  
9. Database migrations included  
10. Filtering and pagination support

### 💡 Code Quality

- Follows C# conventions  
- Well-structured, clean code  
- Meaningful comments and documentation

---

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/library-api.git
