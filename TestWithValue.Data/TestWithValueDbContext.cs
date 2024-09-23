using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Data
{
    public class TestWithValueDbContext : DbContext
    {
        public TestWithValueDbContext(DbContextOptions<TestWithValueDbContext> options)
            : base(options)
        {

        }
        public DbSet<Tbl_Answer> tbl_Answers { get; set; }
        public DbSet<Tbl_Option> tbl_Options { get; set; }

        public DbSet<Tbl_Question> tbl_Questions { get; set; }
        public DbSet<Tbl_Test> tbl_Tests { get; set; }
        public DbSet<Tbl_Topic> tbl_Topics { get; set; }
        public DbSet<Tbl_User> tbl_Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestWithValueDbContext).Assembly);
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
