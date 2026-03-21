namespace task_2.School.Infrastructure.Context
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Infrastructure.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
    }
}
