# Backend Internship Challenge Autumn 2022

This is a selection test for backend developers applying for internship at ViaEcole in the autumn of 2022.

You should extend this website to fetch and search data from a database.

## Get up and running

1. Make sure you have [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) installed.
2. Clone and open the project backend-internship-challenge-autumn2022/Web in your prefered IDE (VS Code, Visual Studio etc.).
3. Build and Run the project backend-internship-challenge-autumn2022/Web.
4. You should see a web page with a list of two documents. 

## Assignment

The documents are not fetched from a database. You should create a database and fetch documents from that database and implement search. Write the code as simple and lean as you can. Document your toughts and how you solved the assignment in a Markdown (.md) file.

### Preparation

Create a MS SQL Server Database. Create it locally on your machine or a Azure SQL Database.

Run the script FillDatabase.sql against your database to create tables and insert data to work with.

### Fetch data from the database

Rewrite the code in DatabaseAccess.cs to fetch the documents from the database. Use your prefered technique for fetching the data (ADO.NET, Entity Framework etc.).

### Implement search

On the web page there is a search textbox that posts the search string to a controller action if you hit Enter. 

* Search in FileName, FirstName and LastName.
* The search should be done on the server (not in the browser).
* Implement search as good as you can. Think about how the user would like the search to work.

### Document your assignment process

Document how your search works and how your thought process went during the assignment in a Markdown (.md) file.

## Submit your contribution

This description describes how you complete the assignment you got from Github Classroom.

* Commit your changes
* Push changes to the Github Classroom repository