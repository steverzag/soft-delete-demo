# SoftDeleteDemo

**SoftDeleteDemo** is a minimal and modular .NET Aspire Web API project focused on demonstrating how to implement and work with **Soft Deleting** using **Entity Framework Core**. It provides a clean structure ideal for learning, experimentation, and serving as a base for future projects using modern .NET and EF Core practices.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server Database

## Installation
1. Clone this repository:
   ```sh
   git clone https://github.com/steverzag/user-tasks.git
   cd <repository-folder>
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the application:
   ```sh
   dotnet build
   ```
4. Apply Database Migrations:
  ```sh
  dotnet ef database update --project ./SoftDeleteDemo.API/SoftDeleteDemo.API.csproj
  ```
  Make sure you have the EF Core tools installed globally:
  ```sh
  dotnet tool install --global dotnet-ef
  ```
  and you configure your connection string at [appsettings](SoftDeleteDemo.API/appsettings.json) file


## Running the Application
To run the application locally:
   ```sh
   dotnet run --project ./SoftDeleteDemo.API/SoftDeleteDemo.API.csproj
   ```

Or to run the application using [Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
   ```
   dotnet run --project ./SoftDeleteDemo.AppHost/SoftDeleteDemo.AppHost.csproj
   ```

By default, the application will be available at `http://localhost:5000` (or `https://localhost:5001` for HTTPS).

## Usage
The application exposes endpoints to create, update, and manage users and tasks. It demonstrates how to implement soft deletes using EF Core, where deleted entities are excluded from query results but retained in the database.

Refer to the [./SoftDeleteDemo.API/SoftDeleteDemo.http](SoftDeleteDemo.API/SoftDeleteDemo.http) file for example requests and usage.
    