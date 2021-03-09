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
    public class IndexModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public IndexModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
        {
            _context = context;
        }

        public IList<Job_Detail> Job_Detail { get;set; }

        public async Task OnGetAsync()
        {
            Job_Detail = await _context.Job_Detail
                .Include(j => j.Employer).ToListAsync();
        }
    }
}
