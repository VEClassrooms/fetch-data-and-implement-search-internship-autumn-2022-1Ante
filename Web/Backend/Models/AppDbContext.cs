using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Web.Backend.Models;



namespace Web.Backend.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-BRKQTHE\SQLEXPRESS;Initial Catalog=DocumentStore;Integrated Security = True;");
        }
    }
}
