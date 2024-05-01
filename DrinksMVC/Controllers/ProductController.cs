using DrinksMVC.Data;
using DrinksMVC.Models;
using DrinksMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DrinksMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DrinksDbContext drinksDbContext;

        public ProductController(DrinksDbContext drinksDbContext)
        {
            this.drinksDbContext = drinksDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var drinks = await drinksDbContext.Drinks.ToListAsync();
            return View(drinks);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductRequest)
        {
            var drinks = new ListDrinks()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                PhotoUrl = addProductRequest.PhotoUrl,
                Price = addProductRequest.Price,
                Count = addProductRequest.Count,
                isAvailable = addProductRequest.isAvailable
            };

            await drinksDbContext.Drinks.AddAsync(drinks);
            await drinksDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var product = await drinksDbContext.Drinks.FirstOrDefaultAsync(x => x.Id == id);
            if(product!= null)
            {
                var viewModel = new UpdateProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    PhotoUrl = product.PhotoUrl,
                    Price = product.Price,
                    Count = product.Count,
                    isAvailable = product.isAvailable
                };
                return await Task.Run(() =>View("View",viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model)
        {
            var product = await drinksDbContext.Drinks.FindAsync(model.Id);

            if(product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.PhotoUrl = model.PhotoUrl;
                product.Price = model.Price;
                product.Count = model.Count;
                product.isAvailable = model.isAvailable;

                await drinksDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var product = await drinksDbContext.Drinks.FindAsync(model.Id);

            if(product != null)
            {
                drinksDbContext.Drinks.Remove(product);
                await drinksDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
