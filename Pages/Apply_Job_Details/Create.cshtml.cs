using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Advertisement_LTd.Data;
using Advertisement_LTd.Models;

namespace Advertisement_LTd.Pages.Apply_Job_Details
{
    public class CreateModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public CreateModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CandidateId"] = new SelectList(_context.Candidate, "Id", "Mobile_no_of_candidate");
        ViewData["Job_DetailId"] = new SelectList(_context.Set<Job_Detail>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Apply_Job_Detail Apply_Job_Detail { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Apply_Job_Detail.Add(Apply_Job_Detail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
