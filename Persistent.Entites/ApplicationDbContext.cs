using Microsoft.EntityFrameworkCore;
using Products.Domain.Entites;
using Products.Persistence.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Entites
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Catergories { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added: 
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified: 
                        entry.Entity.Updated = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Updated = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasOne(p => p.Catergory)
                .WithMany(c => c.Products).HasForeignKey(p => p.CatergoryId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Department>().HasMany(dept => dept.Catergories)
                .WithOne(c => c.Department).HasForeignKey(c => c.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>().HasOne(c => c.Department)
                .WithMany(dept => dept.Catergories).HasForeignKey(c => c.DepartmentId).OnDelete(DeleteBehavior.Cascade);

            builder.Seed();
        }
    }
}
