using AngularAsyncValidator.Api.Models;
using AngularAsyncValidator.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularAsyncValidator.Api.Data
{
    public class AngularAsyncValidatorDbContext : DbContext, IAngularAsyncValidatorDbContext
    {
        public DbSet<Profile> Profiles { get; private set; }
        public AngularAsyncValidatorDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AngularAsyncValidatorDbContext).Assembly);
        }

    }
}
