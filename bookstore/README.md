Bookstore REST API

Overview

A Bookstore REST API built using ASP.NET Core Web API, C#, Entity Framework Core, and SQLite.

Technologies

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- Asynchronous programming with `async/await`

Database

The application uses a SQLite database named `bookstore.db`.

 Books table

| Column | Data type | Description |
|---|---|---|
| Id | INTEGER | Primary key |
| Title | TEXT | Book title |
| AuthorFirstName | TEXT | Author's first name |
| AuthorLastName | TEXT | Author's last name |
| Publisher | TEXT | Publisher name |
| Price | REAL/NUMERIC | Book price |
| ISBN | TEXT | ISBN identifier |
| PublicationYear | TEXT | Publication year |
| Edition | TEXT | Edition information |
| PublicationLocation | TEXT | Publication location |

API Endpoints

 1. Sort by publisher

GET /api/Books/sorted-by-publisher`

Sorts books by publisher, author last name, author first name, and title.

2. Sort by author

`GET /api/Books/sorted-by-author`

Sorts books by author last name, author first name, and title.

3. Calculate total price

`GET /api/Books/total-price`

Returns the sum of the prices of all books.

4. Add a book

`POST /api/Books`

Adds a single book to the database.

5. Bulk insert books

`POST /api/Books/bulk`

Accepts a list of books and saves them using Entity Framework Core's `AddRangeAsync` and a single `SaveChangesAsync` call.

 6. Citation generation

Each book exposes:

- `mlaCitation`
- `chicagoCitation`

These properties generate citations using the book's author, title, publisher, publication year, and optional edition/location information.

 Sample Test Data

Use the following sample JSON to test the bulk insert endpoint.

 Endpoint

POST /api/Books/bulk`

 Request Body


[
  {
    "title": "Clean Code",
    "authorFirstName": "Robert",
    "authorLastName": "Martin",
    "publisher": "Prentice Hall",
    "price": 450.00,
    "isbn": "9780132350884",
    "publicationYear": "2008",
    "edition": "First Edition",
    "publicationLocation": "New Jersey"
  },
  {
    "title": "The Pragmatic Programmer",
    "authorFirstName": "David",
    "authorLastName": "Thomas",
    "publisher": "Addison-Wesley",
    "price": 500.00,
    "isbn": "9780135957059",
    "publicationYear": "2019",
    "edition": "Second Edition",
    "publicationLocation": "Boston"
  },
  {
    "title": "Clean Architecture",
    "authorFirstName": "Robert",
    "authorLastName": "Martin",
    "publisher": "Prentice Hall",
    "price": 600.00,
    "isbn": "9780134494166",
    "publicationYear": "2017",
    "edition": "First Edition",
    "publicationLocation": "Boston"
  },
  {
    "title": "Design Patterns",
    "authorFirstName": "Erich",
    "authorLastName": "Gamma",
    "publisher": "Addison-Wesley",
    "price": 700.00,
    "isbn": "9780201633610",
    "publicationYear": "1994",
    "edition": "First Edition",
    "publicationLocation": "Boston"
  },
  {
    "title": "Refactoring",
    "authorFirstName": "Martin",
    "authorLastName": "Fowler",
    "publisher": "Addison-Wesley",
    "price": 800.00,
    "isbn": "9780201485677",
    "publicationYear": "1999",
    "edition": "First Edition",
    "publicationLocation": "Boston"
  }
]


Expected Results

If these five books are inserted into an empty database:

- Bulk insert returns HTTP `200 OK`.
- The response count is `5`.
- GET /api/Books/total-price` returns `3050`.
- The GET sorting endpoints return books in the specified order.
- Each book response includes `mlaCitation` and `chicagoCitation`.


 How to Run

1. Install the .NET SDK.
2. Open a terminal in the project directory.
3. Run `dotnet restore`.
4. Run `dotnet build`.
5. Run `dotnet run`.
6. Open the Swagger URL shown in the terminal.
7. Use Swagger to execute and test the API endpoints.

Current Limitations

- SQLite does not support SQL Server-style stored procedures. The stored-procedure requirement must be implemented using a suitable database such as SQL Server
