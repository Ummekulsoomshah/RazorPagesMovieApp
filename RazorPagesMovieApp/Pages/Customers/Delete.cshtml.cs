using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.Data;
using RazorPagesMovieApp.models;

namespace RazorPagesMovieApp.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovieApp.Data.RazorPagesMovieAppContext _context;

        public DeleteModel(RazorPagesMovieApp.Data.RazorPagesMovieAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public customer customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            customer = await _context.customer.FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            customer = await _context.customer.FindAsync(id);

            if (customer != null)
            {
                _context.customer.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
