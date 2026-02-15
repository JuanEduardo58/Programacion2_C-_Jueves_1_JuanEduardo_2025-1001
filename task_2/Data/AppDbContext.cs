using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using task_2.Models;

namespace task_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}