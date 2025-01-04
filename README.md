# AssignmentQHRM

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/CHANDAN1896/AssignmentQHRM.git
   ```
2. Open the project in Visual Studio.
3. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=QHRMCrudDB;Trusted_Connection=True; TrustServerCertificate=True;"
   }
   ```
4. Run the migrations to create the database schema 
5. or
6. Create database QHRMCrudDB
  use QHRMCrudDB

  create table QHRMProducts(
  Id int primary key identity(1,1),
  Name nvarchar(100) not null,
  Price decimal (10,2) not null,
  Description nvarchar(255) null,
  Created datetime 
  )
7. Press F5 to run the application.
