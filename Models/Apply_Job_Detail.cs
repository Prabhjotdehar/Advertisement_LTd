using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisement_LTd.Models
{
    //This class display the apply job details under which it has apply job id, candidate id, job id, candidate availabilities, candidate notice period
    public class Apply_Job_Detail
    {
        
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int Job_DetailId { get; set; }
        public Job_Detail Job_Detail { get; set; } 
        [Required]
        public string Candidate_availabilities { get; set; }
        public DateTime Candidate_notice_period { get; set; }
    }
}
