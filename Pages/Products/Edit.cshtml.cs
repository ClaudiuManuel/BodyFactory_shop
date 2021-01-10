using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bodyfactory.Data;
using bodyfactory.Models;


namespace bodyfactory.Pages.Products
{
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly bodyfactory.Data.bodyfactoryContext _context;

        public EditModel(bodyfactory.Data.bodyfactoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
             .Include(b => b.Distributor)
             .Include(b => b.ProductCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);


            if (Product == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Product);
            ViewData["DistributorID"] = new SelectList(_context.Set<Distributor>(), "ID", "DistributorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product
            .Include(i => i.Distributor)
            .Include(i => i.ProductCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Product>(
            productToUpdate,
            "Product",
            i => i.Title, i => i.Manufacturer,
            i => i.Price, i => i.Flavor, i => i.Distributor))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
        }
    


        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
