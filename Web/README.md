Först skapade jag databasen i MS SQL Server för att ha data att hämta. 

Sedan ladde jag ner NugetPackages: Microsoft.EntityFrameworkCore (6.0.9), Microsoft.EntityFrameworkCore.Design (6.0.9), 
Microsoft.EntityFrameworkCore.SqlServer (6.0.9) och Microsoft.EntityFrameworkCore.Tools (6.0.9).

Sedan skapade jag en klass under Models som fick namnet "AppDbContext" och i den skapade jag kopplingen mellan
Visual Studio och MS SQL Server.

Efter det gick jag in i DatabaseAccess.cs och skrev en metod för att hämta alla dokument i databasen och namnet
på den som laddat upp dokumentet. Jag använde AppDbContext för att kommunicera med MS SQL Server. Sedan skrev jag en query. 
Funktionen returnerar en lista av typen "Document". Listan skapas i funktionen och i listan lägger jag in objekt av typen "Document" 
med properties (FileName, UploadedDate och User med Id, FirstName, LastName).

För att alla dokument ska hämtas ändrade jag "public User UploadedBy" till "public int Uploadedby" i Document.cs. 
Anledningen är att "public int UploadedBy" i Document.cs och id i User.cs ska vara av samma typ dvs en int. 
Propertyn "public User UploadedBy" är användar-id:n från User.cs. 

Jag lade även till en User-property (public User User) i Document.cs. 
User-propertyn behövs för att kunna lägga till Users i Document-objekten. 

Sedan gjorde jag sökfunktionen med en query där jag lade till villkor, att uppgifter ska 
hämtas om söksträngen innehåller något som stämmer med FirstName, eller LastName eller FileName. 
Man kan söka på hela eller en del av FirstName, LastName eller FileName och få träffar. en del av FirstName, LastName eller FileName och få träffar.