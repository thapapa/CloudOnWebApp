
using CloudOnWebApp.Entities;
using CloudOnWebApp.Options;
using CloudOnWebApp.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudOnWebApp.Interfaces
{
    public interface IProductService
    {


        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(CreateProductOptions options);
        Task<Product> UpdateProductByIdAsync(int id,UpdateProductsOptions options);
        Task<int> DeleteProductByIdAsync(int id);

    }
}

