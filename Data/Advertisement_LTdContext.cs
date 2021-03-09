using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Advertisement_LTd.Models;

namespace Advertisement_LTd.Data
{
    public class Advertisement_LTdContext : DbContext
    {
        public Advertisement_LTdContext (DbContextOptions<Advertisement_LTdContext> options)
            : base(options)
        {
        }

        public DbSet<Advertisement_LTd.Models.Candidate> Candidate { get; set; }

        public DbSet<Advertisement_LTd.Models.Apply_Job_Detail> Apply_Job_Detail { get; set; }

        public DbSet<Advertisement_LTd.Models.Employer> Employer { get; set; }

        public DbSet<Advertisement_LTd.Models.Job_Detail> Job_Detail { get; set; }
    }
}
