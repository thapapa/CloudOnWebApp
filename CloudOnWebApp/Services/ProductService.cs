using CloudOnWebApp.Entities;
using CloudOnWebApp.Interfaces;
using CloudOnWebApp.Options;
using CloudOnWebApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudOnWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ApplicationDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<Product> CreateProductAsync(CreateProductOptions options)
        {
            //Validation for creating new product
            if (options == null)
            {
                _logger.LogError("Null options.");
                return null;
            }

            if (options.RetailPrice<=0 || options.WholePrice <= 0 || options.Discount <= 0)
            {
                _logger.LogError("Product Reatail price or Whole price or Discount cannot be less or equal to zero.");

                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Description) ||
                string.IsNullOrWhiteSpace(options.Name) )
            {
                _logger.LogError("Not all required parameters passed.");
                return null;

            }

            var productWithSameCode = await _context.Products.SingleOrDefaultAsync(pro => pro.Code == options.Code);
            if (productWithSameCode != null)
            {
                _logger.LogError("Product code already exists.");
                return null;
            }


            var newProduct = new Product
            {
                ExternalId = options.ExternalId,
                Code = options.Code,
                Description = options.Description,
                Name = options.Name,
                Barcode = options.Barcode,
                RetailPrice = options.RetailPrice,
                WholePrice = options.WholePrice,
                Discount = options.Discount
            };

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync();

            return newProduct;
        }

        public async Task<int> DeleteProductByIdAsync(int id)
        {
            var productToDelete = await GetProductByIdAsync(id);

            if (productToDelete == null)
            {
                _logger.LogError("Product not found.");

                return -1;
            }

            _context.Products.Remove(productToDelete);

            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {

            if (id <= 0)
            {
                _logger.LogError("Id cannot be less or equal to zero.");

                return null;
            }

            var product = await _context
                .Products
                .SingleOrDefaultAsync(pro => pro.Id == id);

            if (product == null)
            {
                _logger.LogError("Product not found.");

                return null;
            }

            return product;

        }

        public async Task<List<Product>> GetProductsAsync()
        {

            return await _context.Products.ToListAsync();
        }

    }
}
