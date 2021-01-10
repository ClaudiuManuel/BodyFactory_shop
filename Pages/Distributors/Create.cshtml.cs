using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bodyfactory.Data;
using bodyfactory.Models;

namespace bodyfactory.Pages.Distributors
{
    public class CreateModel : PageModel
    {
        private readonly bodyfactory.Data.bodyfactoryContext _context;

        public CreateModel(bodyfactory.Data.bodyfactoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Distributor Distributor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Distributor.Add(Distributor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
