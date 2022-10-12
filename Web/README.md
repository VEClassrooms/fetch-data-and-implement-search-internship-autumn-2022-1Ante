Först skapade jag databasen i MS SQL Server för att ha data att hämta. 

Sedan ladde jag ner NugetPackages: Microsoft.EntityFrameworkCore (6.0.9), Microsoft.EntityFrameworkCore.Design (6.0.9), Microsoft.EntityFrameworkCore.SqlServer (6.0.9) och
Microsoft.EntityFrameworkCore.Tools (6.0.9).

Sedan skapade jag en klass under Models som fick namnet "AppDbContext" och i den skapade jag kopplingen mellan
Visual Studio och MS SQL Server.

Efter det gick jag in i DatabaseAccess.cs och skrev en metod för att hämta alla dokument i databasen och namnet
på den som laddat upp dokumentet. Jag använde AppDbContext för att kommunicera med MS SQL Server. Sedan skrev jag en query. Funktionen returnerar en lista av typen "dynamic". Listan skapas i funktionen, tar in properties (FirstName, LastName osv.) och konverterar dem till rätt typ (string och DateTime). I "Index.cshtml.cs" ändrade jag så att typen av lista med namnet DocumentsList var en lista av typen dynamic.

När jag sedan testade att köra programmet märkte jag att alla dokument hämtades inte om jag skrev "on a.Id equals b.id" i queryn, eftersom den bara matchade användarens id med id på varje record (filename, UploadedDate och UploadedBy) i Document-tabellen. När jag tittde i klassen Document.cs såg jag att en property var "public User UploadedBy". I queryn kan man inte matcha "id" med "UploadedBy" eftersom det var olika typer (den ena var en int och den andra User), så jag ändrade typen "UploadedBy" från User till int och efter det hämtades alla dokument i databasen. Relationen är att en användare kan ha laddat upp flera dokument.

Sedan gjorde jag sökfunktionen med en query där jag lade till villkor, att uppgifter ska hämtas om söksträngen innehåller något som stämmer med FirstName, eller LastName eller FileName. Man kan söka på hela eller en del av FirstName, LastName eller FileName och få träffar.