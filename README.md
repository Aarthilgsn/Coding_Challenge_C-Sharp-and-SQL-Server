# Insurance Management System

## Tech Stack
- Language: C# (.NET Core)
- Database: SQL Server LocalDB
- ORM: ADO.NET (manual SQL queries)
- IDE: Visual Studio 2022

## Folder Structure
- `entity` - Model classes (Policy, Client, etc.)
- `dao` - Interfaces and service implementations
- `util` - DB connection & property reading
- `myexceptions` - Custom exception handling
- `mainmod` - MainModule.cs (menu-driven application)


##  Features Implemented
- Create, Read, Update, Delete (CRUD) for Policy
- Custom Exception: `PolicyNotFoundException`
- Reusable DB utility classes using `.properties` file
- Console-based menu UI

##  How to Run
1. Make sure SQL Server LocalDB is running
2. Create `InsuranceDB` and required tables
3. Configure `appsettings.properties`
4. Build and run the solution in Visual Studio 2022

## Developed by
Aarthi L
