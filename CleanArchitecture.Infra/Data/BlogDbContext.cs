using CleanArchitecture.Application;
using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace CleanArchitecture.Infra.Data
{
    public class BlogDbContext : DbContext, IUnitOfWork
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = await Database.BeginTransactionAsync(cancellationToken);
            return transaction.GetDbTransaction();
        }

        public async ValueTask DisposeAsync()
        {
            Database.CurrentTransaction?.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Optional: force table name
            modelBuilder.Entity<Blog>().ToTable("Blogs");
        }
    }
}
