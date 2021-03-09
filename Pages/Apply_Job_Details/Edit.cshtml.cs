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

namespace Advertisement_LTd.Pages.Apply_Job_Details
{
    public class EditModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public EditModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Apply_Job_Detail Apply_Job_Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apply_Job_Detail = await _context.Apply_Job_Detail
                .Include(a => a.Candidate)
                .Include(a => a.Job_Detail).FirstOrDefaultAsync(m => m.Id == id);

            if (Apply_Job_Detail == null)
            {
                return NotFound();
            }
           ViewData["CandidateId"] = new SelectList(_context.Candidate, "Id", "Mobile_no_of_candidate");
           ViewData["Job_DetailId"] = new SelectList(_context.Set<Job_Detail>(), "Id", "Id");
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

            _context.Attach(Apply_Job_Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Apply_Job_DetailExists(Apply_Job_Detail.Id))
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

        private bool Apply_Job_DetailExists(int id)
        {
            return _context.Apply_Job_Detail.Any(e => e.Id == id);
        }
    }
}
