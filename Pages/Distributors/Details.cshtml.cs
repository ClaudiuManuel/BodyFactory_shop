using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bodyfactory.Data;
using bodyfactory.Models;

namespace bodyfactory.Pages.Distributors
{
    public class DetailsModel : PageModel
    {
        private readonly bodyfactory.Data.bodyfactoryContext _context;

        public DetailsModel(bodyfactory.Data.bodyfactoryContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
