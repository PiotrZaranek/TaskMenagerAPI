using Microsoft.EntityFrameworkCore;
using TaskMenager.Domain.Model;

namespace TaskMenager.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        public Context() { }
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
