using MagnumStore.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MagnumStore.Data
{
    public class MagnumStoreDbContext : DbContext
 {
        public MagnumStoreDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
