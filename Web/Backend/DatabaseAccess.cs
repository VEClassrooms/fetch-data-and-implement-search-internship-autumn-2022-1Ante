using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Backend.Models;

namespace Web.Backend
{
    public class DatabaseAccess
    {
        public static List<Document> GetDocuments()
        {
            List<Document> documents = new List<Document>();

            using AppDbContext context = new AppDbContext();
            {
                var results = from a in context.Users
                              join b in context.Documents on a.Id equals b.UploadedBy
                              join c in context.Users on b.UploadedBy equals c.Id
                              select new Document()
                              {
                                  FileName = b.FileName,
                                  UploadedDate = b.UploadedDate,
                                  User = new User() { Id = c.Id, FirstName = c.FirstName, LastName = c.LastName }
                              };

                documents.AddRange(results);

                return documents;
            }
               
        }


        public static List<Document> GetDocuments(string searchString)
        {
            List<Document> documents = new List<Document>();

            using AppDbContext context = new AppDbContext();
            {
                var results = from a in context.Users
                              join b in context.Documents on a.Id equals b.UploadedBy
                              join c in context.Users on b.UploadedBy equals c.Id
                              where c.FirstName.Contains(searchString) || c.LastName.Contains(searchString) || b.FileName.Contains(searchString)
                              select new Document()
                              {
                                  FileName = b.FileName,
                                  UploadedDate = b.UploadedDate,
                                  User = new User() { Id = c.Id, FirstName = c.FirstName, LastName = c.LastName }
                              };

                documents.AddRange(results);

                return documents;

            }
        }

    }
}