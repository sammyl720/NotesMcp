# NotesMcp

A .NET 9 console application for managing notes, using Entity Framework Core with SQLite and Model Context Protocol.

## Features
- Create, update, and manage notes
- SQLite database with Entity Framework Core
- Extensible via Model Context Protocol

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- (Optional) Docker

## Getting Started

### Build and Run
```sh
dotnet build
dotnet run
```

### Database Migrations
To apply migrations and update the database:
```sh
dotnet ef database update
```

### Docker
To build and run the app in Docker:
```sh
docker build -t notesmcp .
docker run --rm notesmcp
```

## Project Structure
- `Models/` - Note entity definitions
- `Data/` - Database context
- `Dto/` - Data transfer objects
- `Services/` - Business logic and services
- `Migrations/` - Entity Framework migrations
- `Tools/` - Utility tools

## License
MIT
