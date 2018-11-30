using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bingo_CSD_412.Models
{
    public class BingoContext : DbContext
    {
        public BingoContext(DbContextOptions<BingoContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; }

        public class Word
        {
            public int WordId { get; set; }
            public string Label { get; set; }
            public string Description { get; set; }
            public string Category { get; set; } 
        }
    }
}
