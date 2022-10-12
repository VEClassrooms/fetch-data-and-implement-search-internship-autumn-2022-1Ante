using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Web.Backend.Models;

namespace Web.Backend
{
    public class DatabaseAccess
    {
        public static List<dynamic> GetDocuments()
        {
                    
            using AppDbContext context = new AppDbContext();
            {
                var results = from a in context.Users
                              join b in context.Documents on a.Id equals b.UploadedBy                              
                              select new { a.FirstName, a.LastName, b.FileName, b.UploadedDate };

                var list = results.Select(x =>
                    new
                    {
                        x.FirstName,
                        x.LastName,
                        x.FileName,
                        x.UploadedDate,

                    })
                    .Cast<dynamic>()
                    .ToList<dynamic>();
                return list;
            }
        }

        public static List<dynamic> GetDocuments(string searchString)
        {
            using AppDbContext context = new AppDbContext();
            {
                var results = from a in context.Users
                              join b in context.Documents on a.Id equals b.UploadedBy
                              where a.FirstName.Contains(searchString) || a.LastName.Contains (searchString) || b.FileName.Contains(searchString) 
                              select new { a.FirstName, a.LastName, b.FileName, b.UploadedDate };

                var list = results.Select(x =>
                    new
                    {
                        x.FirstName,
                        x.LastName,
                        x.FileName,
                        x.UploadedDate,

                    })
                    .Cast<dynamic>()
                    .ToList<dynamic>();
                return list;
            }
        }
       
    }
}