using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPISecure.Models;

namespace WebAPISecure.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext (DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPISecure.Models.Book> Book { get; set; } = default!;
    }
}
