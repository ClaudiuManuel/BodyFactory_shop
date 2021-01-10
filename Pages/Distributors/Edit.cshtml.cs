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

namespace bodyfactory.Pages.Distributors
{
    public class EditModel : PageModel
    {
        private readonly bodyfactory.Data.bodyfactoryContext _context;

        public EditModel(bodyfactory.Data.bodyfactoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Distributor Distributor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Distributor = await _context.Distributor.FirstOrDefaultAsync(m => m.ID == id);

            if (Distributor == null)
            {
                return NotFound();
            }
            ViewData["DistributorID"] = new SelectList(_context.Set<Distributor>(), "ID", "DistributorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Distributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributorExists(Distributor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DistributorExists(int id)
        {
            return _context.Distributor.Any(e => e.ID == id);
        }
    }
}
