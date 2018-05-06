# Creating a SQLite database code-first with Entity Framework Core

## Configuring the Project
Add the following packages to the project:
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design

Next you need to manually add
``` xml
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.2" />
```
to the csproj file in order to use `dotnet` on the command line console.

## Defining the Database Model
A model for the database needs to be defined, this contains the definitions for tables and their relationships, along with a *DbContext* which represents a session with the database.

See the folder *DbModel* for an example.

`Program.Main()` contains an example of (manually) adding data to a database table.

## Creating the Database
This is done via `dotnet` on the Command Line, run the following commands in order.
Make sure you're in same directory containing *csproj* file.

`dotnet ef migrations add <MIGRATION NAME>`
Creates scaffolding code for migrations under the *Migrations* folder.

`dotnet ef database update`
To apply the new migration to the database. This command creates the database before applying migrations.

`dotnet run`
Runs the project, in this case, `Program.Main()` simply adds a new URL to the database.

## Issues at of Time of Writing
*DataAnnotations* does not support all of the functionality required to define a database, such as composite keys and indexes.
However, *Fluent API*  covers these limitations and it is recommended to use it instead.

SQLite does not support editing schemas directly, subsequent migrations run against a database will fail. As per the Microsoft [documentation](https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#migrations-limitations-workaround):

> You can workaround some of these limitations by manually writing code in your migrations to perform a table rebuild. A table rebuild involves renaming the existing table, creating a new table, copying data to the new table, and dropping the old table. You will need to use the `Sql(string)` method to perform some of these steps.
...
In the future, EF may support some of these operations by using the table rebuild approach under the covers.

## Further Information
See the Microsoft [tutorial](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite) for more information.

