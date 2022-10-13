using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
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
                              select new { c.Id, c.FirstName, c.LastName, b.FileName, b.UploadedDate };              

                
                foreach (var item in results)
                {
                    documents.Add(new Document()
                    {
                        FileName = item.FileName,
                        UploadedDate = item.UploadedDate,
                        User = new User() { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName }
                    });
                }                

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
                              select new { c.Id, c.FirstName, c.LastName, b.FileName, b.UploadedDate };


                foreach (var item in results)
                {
                    documents.Add(new Document()
                    {
                        FileName = item.FileName,
                        UploadedDate = item.UploadedDate,
                        User = new User() { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName }
                    });
                }

                return documents;

            }
        }

    }
}