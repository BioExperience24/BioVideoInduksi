# Clean Architecture Web API Project

## About the Project

This project serves as a template for building a Clean Architecture Web API in ASP.NET Core. It focuses on separation of concerns by dividing the application into distinct layers: Domain, Application, Web API, and Infrastructure.

## Main Features

- Clean Architecture structure (Domain, Application, Web API, Infrastructure)
- ASP.NET Core 8.0 with Entity Framework Core
- Health Check and Logging
- Middleware for Exception Handling and Validation


## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server

### Installation

1. Clone the repository:

   ```bash
   Clone Project
   ```

2. Run project:

   - Copy file `appsettings.Development copy.json` to `appsettings.Development.json` for Development

   - Running project backend bash terminal

     ```bash
     dotnet run ./src/CleanArchitecture/CleanArchitecture.csproj
     ```

   - Running project frontend bash terminal

      ```bash
      dotnet run ./src/CleanArchitecture.Frontend/CleanArchitecture.csproj
      ```
