using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advertisement_LTd.Data;
using Advertisement_LTd.Models;

namespace Advertisement_LTd.Pages.Job_Details
{
    public class EditModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public EditModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job_Detail Job_Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job_Detail = await _context.Job_Detail
                .Include(j => j.Employer).FirstOrDefaultAsync(m => m.Id == id);

            if (Job_Detail == null)
            {
                return NotFound();
            }
           ViewData["EmployerId"] = new SelectList(_context.Employer, "Id", "Id");
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

            _context.Attach(Job_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Job_DetailExists(Job_Detail.Id))
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

        private bool Job_DetailExists(int id)
        {
            return _context.Job_Detail.Any(e => e.Id == id);
        }
    }
}
