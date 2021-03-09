using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Advertisement_LTd.Data;
using Advertisement_LTd.Models;

namespace Advertisement_LTd.Pages.Apply_Job_Details
{
    public class DeleteModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public DeleteModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apply_Job_Detail = await _context.Apply_Job_Detail.FindAsync(id);

            if (Apply_Job_Detail != null)
            {
                _context.Apply_Job_Detail.Remove(Apply_Job_Detail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
