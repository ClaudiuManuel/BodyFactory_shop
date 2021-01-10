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
    public class IndexModel : PageModel
    {
        private readonly bodyfactory.Data.bodyfactoryContext _context;

        public IndexModel(bodyfactory.Data.bodyfactoryContext context)
        {
            _context = context;
        }

        public IList<Distributor> Distributor { get;set; }

        public async Task OnGetAsync()
        {
            Distributor = await _context.Distributor.ToListAsync();
        }
    }
}
