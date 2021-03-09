using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Advertisement_LTd.Data;
using Advertisement_LTd.Models;

namespace Advertisement_LTd.Pages.Job_Details
{
    public class DeleteModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public DeleteModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job_Detail = await _context.Job_Detail.FindAsync(id);

            if (Job_Detail != null)
            {
                _context.Job_Detail.Remove(Job_Detail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
