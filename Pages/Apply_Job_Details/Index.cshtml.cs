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
    public class IndexModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public IndexModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
        {
            _context = context;
        }

        public IList<Apply_Job_Detail> Apply_Job_Detail { get;set; }

        public async Task OnGetAsync()
        {
            Apply_Job_Detail = await _context.Apply_Job_Detail
                .Include(a => a.Candidate)
                .Include(a => a.Job_Detail).ToListAsync();
        }
    }
}
