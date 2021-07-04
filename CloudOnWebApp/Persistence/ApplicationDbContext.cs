using CloudOnWebApp.Entities;
using CloudOnWebApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudOnWebApp.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<Product> Products { set; get; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}