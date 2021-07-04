using CloudOnWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CloudOnWebApp.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<Product> Products { set; get; }

        Task<int> SaveChangesAsync();
    }
}
