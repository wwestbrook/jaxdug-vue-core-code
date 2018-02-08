using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Domain.Entities;

namespace VueDemo.Domain
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options)
        {

        }

        public DbSet<ComicBook> Comics { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ComicBook>().Property(p => p.Title).HasMaxLength(100).IsRequired();
            mb.Entity<ComicBook>().Property(p => p.Publisher).HasMaxLength(50).IsRequired();
            mb.Entity<ComicBook>().HasIndex(i => i.IsDeleted).HasName("IX_IsDeleted");
            mb.Entity<ComicBook>().Property(p => p.Created).HasDefaultValueSql("getDate()");
            mb.Entity<ComicBook>().Property(p => p.Modified).HasDefaultValueSql("getDate()");

            base.OnModelCreating(mb);
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;

                    ((BaseEntity)entry.Entity).IsDeleted = false;
                }
            ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
