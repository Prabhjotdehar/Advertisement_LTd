using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Advertisement_LTd.Data;
using Advertisement_LTd.Models;

namespace Advertisement_LTd.Pages.Candidates
{
    public class IndexModel : PageModel
    {
        private readonly Advertisement_LTd.Data.Advertisement_LTdContext _context;

        public IndexModel(Advertisement_LTd.Data.Advertisement_LTdContext context)
        {
            _context = context;
        }

        public IList<Candidate> Candidate { get;set; }

        public async Task OnGetAsync()
        {
            Candidate = await _context.Candidate.ToListAsync();
        }
    }
}
