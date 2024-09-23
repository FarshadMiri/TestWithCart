using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Data.SeedData;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Data
{
    public class TestWithValueDbContext : DbContext
    {
        public TestWithValueDbContext(DbContextOptions<TestWithValueDbContext> options)
            : base(options)
        {

        }
        public DbSet<Tbl_User> Tbl_Users { get; set; }
        public DbSet<Tbl_Question> Tbl_Questions { get; set; }
        public DbSet<Tbl_Answer> Tbl_Answers { get; set; }
        public DbSet<Tbl_Category> Tbl_Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestWithValueDbContext).Assembly);
            CategorySeedData.Seed(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Tbl_User>())
            {
                entry.Entity.UpdatedDateTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDateTime = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Tbl_User>())
            {
                entry.Entity.UpdatedDateTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDateTime = DateTime.Now;
                }
            }
            return base.SaveChanges();


        }
    }
}
