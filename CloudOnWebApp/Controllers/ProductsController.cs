using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudOnWebApp.Entities;
using CloudOnWebApp.Interfaces;
using CloudOnWebApp.Options;

namespace CloudOnWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productsService;

        public ProductsController(IProductService productsService)
        {
            _productsService = productsService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            
            return View(await _productsService.GetProductsAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsService.GetProductByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExternalId,Code,Description,Name,Barcode,RetailPrice,WholePrice,Discount")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productsService.CreateProductAsync(new CreateProductOptions
                {
                    ExternalId = product.ExternalId,
                    Code = product.Code,
                    Description = product.Description,
                    Name = product.Name,
                    Barcode = product.Barcode,
                    RetailPrice = product.RetailPrice,
                    WholePrice = product.WholePrice,
                    Discount = product.Discount

                });


                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
          //  if (id == null)
            //{
              //  return NotFound();
            //}

            //var product = await _context.Products.FindAsync(id);
            //if (product == null)
            //{
              //  return NotFound();
            //}
            //return View(product);
        //}

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Edit(int id, [Bind("Id,ExternalId,Code,Description,Name,Barcode,RetailPrice,WholePrice,Discount")] Product product)
       // {
       //     if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

         //   if (ModelState.IsValid)
          //  {
            //    try
            //    {
            //        _context.Update(product);
            //        await _context.SaveChangesAsync();
            //    }
             //   catch (DbUpdateConcurrencyException)
             //   {
              //      if (!ProductExists(product.Id))
              //      {
               //         return NotFound();
               //     }
               //     else
              //     {
                 //       throw;
                //    }
              //  }
             //   return RedirectToAction(nameof(Index));
           // }
          //  return View(product);
      //  }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsService.GetProductByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productsService.DeleteProductByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
