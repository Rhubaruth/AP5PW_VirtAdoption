## Instalace do Infrastructure
    - dependencies > Manage NuGet Package
install:
    - Microsoft.EntityFrameworkCore
        (apply, accept)
    - Pomelo.*.MySql
    - Microsoft.EntityFrameworkCore.Tools

## Instalace do WEB
    - dependencies > Manage NuGet Package
install:
    - Microsoft.EntityFrameworkCore.Design


# DB
## config DB 
pridana class **UtulekDbContext**
    - tvorba relaci

propojeni: v Program.cs
db location string: appsettings.json

## add Migrations
view > other windows > PackageManagerConsole
change Web -> Infrastructure 
''' Add-Migration "<name of migration>" '''
(pro vymazaní poslední - 'Remove-Migration')

''' Update-Database '''
nahraje migraci na db

## Popis property
[Key]               - Primární klíč
[ForeignKey()]      - Cizí klíč
[Required]          - Povinné               (nadřazené nad nullable)
<T>?                - volitelné/nullable    (? za dat. typ)
[StringLength()]    - omezení délky


# Identity Roles
    - dependencies > Manage NuGet Package
install:
    - Microsoft.AspNetCore.Identity.EntityFrameworkCore
include:
    - FrameworkReference Include="Microsoft.AspNetCore.App"


# Test
install:
    - Moq
    - Microsoft.EntityFrameworkCore.InMemory












