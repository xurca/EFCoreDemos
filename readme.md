# EF Core
Entity Framework Core is a library that allows us to access the database from our applications. It is designed as an object-relational mapper (ORM) and it works by mapping the relational database to the applications database model.

EF Core is a cross-platform library and it runs on Windows as well as on Linux. It was introduced with the .NET Core framework thus the “Core” part in its name to distinguish it from the .NET Framework version.

## PMC
get-help entityframework

get-help Remove-Migration -examples
get-help Remove-Migration -detailed
get-help Remove-Migration -full

PM> Install-Package Microsoft.EntityFrameworkCore.Tools

## CLI
Use "dotnet ef [command] --help" for more information about a command.

dotnet ef migrations --help
dotnet ef database --help
dotnet ef dbcontext --help

to enable it global
dotnet tool install --global dotnet-ef
Or just run command
PM> Install-package Microsoft.EntityFrameworkCore.Tools.DotNet

## sqlServer package
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer

## Learn
* https://www.learnentityframeworkcore.com/
* https://www.entityframeworktutorial.net/
* https://haacked.com/archive/2019/07/29/query-filter-by-interface/

## user defined function DbFunction
```SQL
CREATE FUNCTION [dbo].[GetAverage](@id int)
returns decimal
as
begin

declare @avg as decimal = 0
select @avg = avg(price)
from product
where id <> @id

return @avg

end
```