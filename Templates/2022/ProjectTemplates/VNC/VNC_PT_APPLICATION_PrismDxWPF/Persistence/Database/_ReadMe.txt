$xxxAPPLICATIONxxx$$xxxNAMESPACExxx$\Persistence\Database\

EFCore does not perform automatic database creations and migrations.  Need to use Package Manager

From Package Manager Console

Both Entity Framework 6 and Entity Framework Core are installed. The Entity Framework 6 tools are running. 
Use 'EntityFrameworkCore\Add-Migration' for Entity Framework Core.

Both Entity Framework Core and Entity Framework 6 are installed. The Entity Framework Core tools are running. 
Use 'EntityFramework6\Add-Migration' for Entity Framework 6.

PM> EntityFrameworkCore\add-migration initialdb -OutputDir "Persistence/Database/Migrations"
Build started...
Build succeeded.
To undo this action, use Remove-Migration.

N.B.  If don't use -OutputDir, will go in Migrations folder at top level of project

PM> EntityFrameworkCore\update-database
Build started...
Build succeeded.
Applying migration '20250227064149_initialdb'.
Done.

