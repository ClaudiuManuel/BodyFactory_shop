using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bodyfactory.Data;
using bodyfactory.Models;

namespace bodyfactory.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly bodyfactory.Data.bodyfactoryContext _context;

        public CreateModel(bodyfactory.Data.bodyfactoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistributorID"] = new SelectList(_context.Set<Distributor>(), "ID", "DistributorName");
            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Product>(
            newProduct,
            "Product",
            i => i.Title, i => i.Manufacturer,
            i => i.Price, i => i.Flavor, i => i.DistributorID))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();
        }

    }
}
