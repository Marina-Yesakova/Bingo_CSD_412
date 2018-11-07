using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bingo_CSD_412.Models
{
    public class DBConnectionContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        /*This will populate the database when migrating. Use following commands to populate the data in OnModelCreating:
         1. dotnet ef migrations add WordSeedData -o Data/Migrations
         2. dotnet ef database update
         */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Word>().HasData(
                new Word
                {
                    Id = 1,
                    Entry = "C#",
                    Definition = "A programming language"
                }
            );
        }

        public DBConnectionContext(DbContextOptions<DBConnectionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}