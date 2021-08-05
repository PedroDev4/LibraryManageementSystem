using System.Reflection;
using LibraryManagement.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repository
{
    public class LibraryManagementContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }

        public LibraryManagementContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}