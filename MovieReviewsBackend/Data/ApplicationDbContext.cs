﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace MovieReviewsBackend.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        //public ApplicationDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public ApplicationDbContext()
        : base("DefaultConnection")
        {
        }

        public DbSet Reviewer { get; set; }
    }
}