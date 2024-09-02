using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.Data;
using RazorPagesMovieApp.models;

namespace RazorPagesMovieApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMovieApp.Data.RazorPagesMovieAppContext _context;

        public EditModel(RazorPagesMovieApp.Data.RazorPagesMovieAppContext context)
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

            var Customer =  await _context.customer.FirstOrDefaultAsync(m => m.Id == id);
            if (Customer == null)
            {
                return NotFound();
            }
            customer = Customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerExists(customer.Id))
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

        private bool customerExists(int id)
        {
            return _context.customer.Any(e => e.Id == id);
        }
    }
}
