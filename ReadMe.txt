


# ASP.NET MVC Application  
### Identity + Entity Framework (Code First)

## Overview
This is an ASP.NET MVC application built using the **Code First** approach with **Entity Framework** and **ASP.NET Identity** for authentication and authorization.  
The database schema is generated from the model classes and managed through migrations.

---

## Technologies Used
- ASP.NET MVC
- .NET Framework / .NET Core
- Entity Framework (Code First)
- ASP.NET Identity
- SQL Server

---

## Project Structure
/Controllers
/Models
├── ApplicationUser.cs
├── ApplicationDbContext.cs
└── Domain Models
/Views
/Migrations

yaml
Copy code

---

## Authentication & Identity
The application uses **ASP.NET Identity** for user management.  
Default Identity tables include:
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- AspNetUserClaims
- AspNetUserLogins

`ApplicationUser` inherits from `IdentityUser` and can be extended with custom properties.

---

## Database (Code First Approach)
- Database is created and updated using Entity Framework migrations
- Schema changes are handled via migration files
- Identity tables are created automatically

---

## Configuration
Update the database connection string in `appsettings.json`:

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Server=.;Database=MvcIdentityDb;
       Trusted_Connection=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>